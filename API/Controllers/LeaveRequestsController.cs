using System;
using Domain.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class LeaveRequestsController(ILeaveRequestRepository requestRepo) : ControllerBase
{
	private readonly ILeaveRequestRepository _requestRepo = requestRepo;


	/// <summary>
	/// دریافت لیست درخواست‌ها برای کاربر مشخص
	/// </summary>
	/// <param name="userID"></param>
	/// <returns></returns>
	[HttpGet(template: nameof(GetList))]
	public async Task<ActionResult> GetList(Guid userID)
	{
		var requestList = await
			_requestRepo.GetByEmployeeIdAsync(userID);

		return Ok(requestList);
	}
}