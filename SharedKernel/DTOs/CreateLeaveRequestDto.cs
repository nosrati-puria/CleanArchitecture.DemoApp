using System;

namespace SharedKernel.DTOs;

public record CreateLeaveRequestDto(
	Guid EmployeeId,
	DateTime FromDate,
	DateTime ToDate,
	string Reason,
	Guid? SubstituteEmployeeId
);