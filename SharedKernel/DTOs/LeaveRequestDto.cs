using System;

namespace SharedKernel.DTOs;

public record LeaveRequestDto()
{
	/// <summary>
	/// شناسه
	/// </summary>
	public Guid Id { get; set; }


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
	/// وضعیت
	/// </summary>
	public string Status { get; set; } = string.Empty;


	/// <summary>
	/// شناسه‌ی کارمند جایگزین
	/// </summary>
	public Guid? SubstituteEmployeeId { get; set; }
}