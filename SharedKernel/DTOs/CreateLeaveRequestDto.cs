using System;

namespace SharedKernel.DTOs;

public record CreateLeaveRequestDto()
{
	public Guid EmployeeId { get; set; }
	public DateTime FromDate { get; set; }
	public DateTime ToDate { get; set; }
	public string Reason { get; set; } = string.Empty;
	public Guid? SubstituteEmployeeId { get; set; }
}