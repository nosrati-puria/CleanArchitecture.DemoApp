using System;
using System.Linq;
using Domain.Enums;
using Domain.Entities;
using SharedKernel.DTOs;
using Domain.Interfaces;
using Application.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Shared.Resources.Messages;

namespace Application.Services;

/// <summary>
/// سرویس درخواست‌ها
/// </summary>
/// <param name="leaveRequestRepo"></param>
public class LeaveRequestService(ILeaveRequestRepository leaveRequestRepo) : ILeaveRequestService
{
	#region Properties

	private ILeaveRequestRepository LeaveRequestRepo { get; } = leaveRequestRepo;

	#endregion /Properties

	//*************************

	#region Methods

	/// <summary>
	/// ثبت مرخصی
	/// </summary>
	/// <param name="request"></param>
	/// <returns></returns>
	/// <exception cref="ArgumentException"></exception>
	/// <exception cref="InvalidOperationException"></exception>
	public async Task<Guid> CreateAsync(CreateLeaveRequestDto request)
	{
		if (request.ToDate < request.FromDate)
		{
			throw new ArgumentException(nameof(Errors.FromDateIsGreaterThanToDate));
		}

		if (request.SubstituteEmployeeId.HasValue)
		{
			var substituteEmployeeRequests = await LeaveRequestRepo
				.GetByEmployeeIdAsync(request.SubstituteEmployeeId.Value);

			var unverifiedSubstitute = substituteEmployeeRequests
				.Any(current => current.Status != LeaveStatus.Rejected
					&& current.FromDate <= request.ToDate);

			if (unverifiedSubstitute)
			{
				throw new InvalidOperationException(nameof(Errors.UnverifiedSubstituteEmployee));
			}
		}

		var entity = new LeaveRequest
		{
			EmployeeId = request.EmployeeId,
			FromDate = request.FromDate,
			ToDate = request.ToDate,
			Reason = request.Reason,
			Status = LeaveStatus.Pending,
			SubstituteEmployeeId = request.SubstituteEmployeeId
		};

		await LeaveRequestRepo.AddAsync(leaveRequest: entity);
		await LeaveRequestRepo.SaveChangesAsync();

		return entity.Id;
	}

	/// <summary>
	/// پیدا کردن درخواست طبق شناسه کارمند
	/// </summary>
	/// <param name="employeeId"></param>
	/// <returns></returns>
	public async Task<IEnumerable<LeaveRequestDto>> GetByEmployeeAsync(Guid employeeId)
	{
		var requestsList = await
			LeaveRequestRepo.GetByEmployeeIdAsync(employeeId);

		return requestsList
			.Select(request =>
				new LeaveRequestDto(
					request.Id,
					request.EmployeeId,
					request.FromDate,
					request.ToDate,
					request.Reason,
					request.Status.ToString(),
					request.SubstituteEmployeeId
				)
			);
	}

	/// <summary>
	/// پیدا کردن تمامی درخواست‌ها
	/// </summary>
	/// <returns></returns>
	public async Task<IEnumerable<LeaveRequestDto>> GetAllAsync()
	{
		var requestsList = await
			LeaveRequestRepo.GetAllAsync();

		return requestsList
			.Select(request =>
				new LeaveRequestDto(
					request.Id,
					request.EmployeeId,
					request.FromDate,
					request.ToDate,
					request.Reason,
					request.Status.ToString(),
					request.SubstituteEmployeeId
				)
			);
	}

	/// <summary>
	/// تایید درخواست
	/// </summary>
	/// <param name="requestId"></param>
	/// <returns></returns>
	/// <exception cref="KeyNotFoundException"></exception>
	public async Task ApproveAsync(Guid requestId)
	{
		var request = await
			LeaveRequestRepo.GetByIdAsync(requestId)
			?? throw new KeyNotFoundException("Leave request not found");

		request.Status = LeaveStatus.Approved;

		await
			LeaveRequestRepo.SaveChangesAsync();
	}

	/// <summary>
	/// رد درخواست
	/// </summary>
	/// <param name="requestId"></param>
	/// <returns></returns>
	/// <exception cref="KeyNotFoundException"></exception>
	public async Task RejectAsync(Guid requestId)
	{
		var request = await
			LeaveRequestRepo.GetByIdAsync(requestId)
			?? throw new KeyNotFoundException("Leave request not found");

		request.Status = LeaveStatus.Rejected;

		await
			LeaveRequestRepo.SaveChangesAsync();
	}

	#endregion /Methods
}