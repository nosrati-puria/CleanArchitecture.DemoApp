using System;
using Domain.Shared;
using Domain.Shared.Resources;
using System.Collections.Generic;
using Domain.Shared.Resources.Messages;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class Employee() : Seedwork.BaseEntity
{
	#region Username

	/// <summary>
	/// نام کاربری
	/// </summary>
	[Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.Required))]
	[StringLength
		(maximumLength: Utility.Const.UsernameMaxLength,
		MinimumLength = Utility.Const.UsernameMinLength,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.StringLength))]
	[Display(Name = nameof(DataDictionary.Username))]
	public string Username { get; set; } = null!;

	#endregion /Username

	//**************************************************

	#region Password

	/// <summary>
	/// رمز عبور
	/// </summary>
	[Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.Required))]
	[StringLength
		(maximumLength: Utility.Const.PasswordMaxLength,
		MinimumLength = Utility.Const.PasswordMinLength,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.StringLength))]
	[Display(Name = nameof(DataDictionary.Password))]
	public string Password { get; set; } = null!;

	#endregion /Password

	//**************************************************

	#region FullName

	/// <summary>
	/// نام و نام خانوادگی
	/// </summary>
	[StringLength
		(maximumLength: Utility.Const.FullNameMaxLength,
		MinimumLength = Utility.Const.FullNameMinLength,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.StringLength))]
	[Display(Name = nameof(DataDictionary.FullName))]
	public string FullName { get; set; } = null!;

	#endregion /FullName

	//**************************************************

	#region Email

	/// <summary>
	/// ایمیل
	/// </summary>
	[RegularExpression
		(pattern: Utility.Regex.Email,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.EmailAddress),
		MatchTimeoutInMilliseconds = 0)]
	[Display(Name = nameof(DataDictionary.EmailAddress))]
	public string Email { get; set; } = null!;

	#endregion /Email

	//**************************************************

	#region CellPhoneNumber

	/// <summary>
	/// شماره تلفن همراه
	/// </summary>
	[RegularExpression
		(pattern: Utility.Regex.CellPhoneNumber,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.CellPhoneNumber),
		MatchTimeoutInMilliseconds = 0)]
	[Display(Name = nameof(DataDictionary.CellPhoneNumber))]
	public string CellPhoneNumber { get; set; } = null!;

	#endregion /CellPhoneNumber

	//**************************************************

	#region LeaveRequests

	/// <summary>
	/// درخواست مرخصی
	/// </summary>
	public ICollection<LeaveRequest> LeaveRequests { get; } = [];

	#endregion /LeaveRequests

	//**************************************************

	#region Role

	/// <summary>
	/// نقش
	/// </summary>
	[Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.Required))]
	[Display(Name = nameof(DataDictionary.Role))]
	public virtual Role? Role { get; }
	public Guid RoleId { get; set; }

	#endregion /Role

	//**************************************************

}
