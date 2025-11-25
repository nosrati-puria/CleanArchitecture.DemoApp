using System;

namespace SharedKernel.DTOs;

public record CreateLeaveRequestDto()
{
	/// <summary>
	/// شناسه‌ی کارمند
	/// </summary>
	public Guid EmployeeId { get; set; }


	/// <summary>
	/// از تاریخِ
	/// </summary>
	public DateTime FromDate { get; set; }


	/// <summary>
	/// تا تاریخِ
	/// </summary>
	public DateTime ToDate { get; set; }


	/// <summary>
	/// علت مرخصی
	/// </summary>
	public string Reason { get; set; } = string.Empty;


	/// <summary>
	/// کارمند جایگزین
	/// </summary>
	public Guid? SubstituteEmployeeId { get; set; }
}