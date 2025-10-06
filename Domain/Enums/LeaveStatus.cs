using Domain.Shared.Resources;
using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum LeaveStatus
{
	[Display(Description = nameof(DataDictionary.Pending))]
	Pending = 0,

	[Display(Description = nameof(DataDictionary.Approved))]
	Approved = 1,

	[Display(Description = nameof(DataDictionary.Rejected))]
	Rejected = 2,
}