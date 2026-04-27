using Domain.Shared.Resources;
using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum LeaveStatus
{
	/// <summary>
	/// در حال بررسی
	/// </summary>
	[Display(Description = nameof(DataDictionary.Pending))]
	Pending = 0,


	/// <summary>
	/// تایید شده
	/// </summary>
	[Display(Description = nameof(DataDictionary.Approved))]
	Approved = 1,


	/// <summary>
	/// رد شده
	/// </summary>
	[Display(Description = nameof(DataDictionary.Rejected))]
	Rejected = 2,
}