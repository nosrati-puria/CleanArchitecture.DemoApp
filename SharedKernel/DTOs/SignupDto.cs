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
	[Display(Name = nameof(DataDictionary.Username), ResourceType = typeof(DataDictionary))]
	public string Username { get; set; } = string.Empty;


	/// <summary>
	/// گذرواژه
	/// </summary>
	[Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.Required))]
	[Display(Name = nameof(DataDictionary.Password), ResourceType = typeof(DataDictionary))]
	public string Password { get; set; } = string.Empty;


	/// <summary>
	/// تکرار گذرواژه
	/// </summary>
	[Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.Required))]
	[Compare
		(nameof(Password),
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.Compare))]
	[Display(Name = nameof(DataDictionary.ConfirmPassword), ResourceType = typeof(DataDictionary))]
	public string ConfirmPassword { get; set; } = string.Empty;


	/// <summary>
	/// نام و نام خانوادگی
	/// </summary>
	[Display(Name = nameof(DataDictionary.FullName), ResourceType = typeof(DataDictionary))]
	public string FullName { get; set; } = string.Empty;


	/// <summary>
	/// ایمیل
	/// </summary>
	[Display(Name = nameof(DataDictionary.EmailAddress), ResourceType = typeof(DataDictionary))]
	public string EmailAddress { get; set; } = string.Empty;


	/// <summary>
	/// شماره تلفن همراه
	/// </summary>
	[Display(Name = nameof(DataDictionary.CellPhoneNumber), ResourceType = typeof(DataDictionary))]
	public string CellPhoneNumber { get; set; } = string.Empty;
}
