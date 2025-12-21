using Domain.Shared;
using Domain.Shared.Resources;
using Domain.Shared.Resources.Messages;
using System.ComponentModel.DataAnnotations;

namespace SharedKernel.DTOs;

public record LoginRequestDto()
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
}
