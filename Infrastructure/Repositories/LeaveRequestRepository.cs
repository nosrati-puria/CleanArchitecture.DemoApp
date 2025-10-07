using System;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class LeaveRequestRepository(AppDbContext appDbContext) : ILeaveRequestRepository
{
	#region Properties

	private readonly AppDbContext _appDbContext = appDbContext;

	#endregion /Properties

	//*************************

	#region Methods

	public async Task SaveChangesAsync()
	{
		await _appDbContext.SaveChangesAsync();
	}

	public async Task AddAsync(LeaveRequest leaveRequest)
	{
		await _appDbContext.LeaveRequests.AddAsync(entity: leaveRequest);
	}

	public async Task<LeaveRequest?> GetByIdAsync(Guid id)
	{
		return await
			_appDbContext.LeaveRequests
				.Include(current => current.Employee)
				.FirstOrDefaultAsync(current => current.Id == id);
	}

	public async Task<List<LeaveRequest>> GetAllAsync()
	{
		return await
			_appDbContext.LeaveRequests
				.Include(current => current.Employee)
				.ToListAsync();
	}

	public async Task<List<LeaveRequest>> GetByEmployeeIdAsync(Guid id)
	{
		return await
			_appDbContext.LeaveRequests
				.Include(current => current.Employee)
				.Where(current => current.EmployeeId == id)
				.ToListAsync();
	}

	#endregion /Methods
}