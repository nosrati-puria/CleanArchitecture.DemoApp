using Domain.Shared.Resources;
using Domain.Shared.Resources.Messages;
using System.ComponentModel.DataAnnotations;

namespace SharedKernel.DTOs;

public record SignupDto()
{
	/// <summary>
	/// شناسه‌ی کاربری
	/// </summary>
	[Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.Required))]
	[Display(Name = nameof(DataDictionary.Username))]
	public string Username { get; set; } = string.Empty;


	/// <summary>
	/// رمز عبور
	/// </summary>
	[Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.Required))]
	[Display(Name = nameof(DataDictionary.Password))]
	public string Password { get; set; } = string.Empty;


	/// <summary>
	/// نام و نام خانوادگی
	/// </summary>
	public string FullName { get; set; } = string.Empty;


	/// <summary>
	/// ایمیل
	/// </summary>
	[Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.Required))]
	[Display(Name = nameof(DataDictionary.Password))]
	public string Email { get; set; } = string.Empty;


	/// <summary>
	/// شماره تلفن همراه
	/// </summary>
	public string CellPhoneNumber { get; set; } = string.Empty;
}
