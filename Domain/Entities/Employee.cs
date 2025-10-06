using Domain.Shared;
using System.Collections.Generic;
using Domain.Shared.Resources.Messages;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class Employee() : Seedwork.BaseEntity
{
	#region FullName

	/// <summary>
	/// نام و نام خانوادگی
	/// </summary>
	[Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.Required))]
	[StringLength
		(maximumLength: Utility.Const.FullNameMaxLength,
		MinimumLength = Utility.Const.FullNameMinLength,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.StringLength))]
	[Display(Name = nameof(Shared.Resources.DataDictionary.FullName))]
	public string FullName { get; set; } = null!;

	#endregion /FullName

	//*************************

	#region Email

	/// <summary>
	/// ایمیل
	/// </summary>
	[Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.Required))]
	[RegularExpression
		(pattern: Utility.Regex.Email,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.EmailAddress),
		MatchTimeoutInMilliseconds = 0)]
	[Display(Name = nameof(Shared.Resources.DataDictionary.EmailAddress))]
	public string Email { get; set; } = null!;

	#endregion /Email

	//*************************

	#region LeaveRequests

	/// <summary>
	/// درخواست مرخصی
	/// </summary>
	public ICollection<LeaveRequest> LeaveRequests { get; } = [];

	#endregion /LeaveRequests

	//*************************
}
