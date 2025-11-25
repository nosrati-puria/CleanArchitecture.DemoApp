namespace SharedKernel.DTOs;

public record LoginRequestDto()
{
	/// <summary>
	/// شناسه‌ی کاربری
	/// </summary>
	public string Username { get; set; } = string.Empty;


	/// <summary>
	/// رمز عبور
	/// </summary>
	public string Password { get; set; } = string.Empty;
}
