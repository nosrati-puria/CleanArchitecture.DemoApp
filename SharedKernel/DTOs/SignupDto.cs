namespace SharedKernel.DTOs;

public record SignupDto()
{
	/// <summary>
	/// شناسه‌ی کاربری
	/// </summary>
	public string Username { get; set; } = string.Empty;


	/// <summary>
	/// رمز عبور
	/// </summary>
	public string Password { get; set; } = string.Empty;


	/// <summary>
	/// نام و نام خانوادگی
	/// </summary>
	public string FullName { get; set; } = string.Empty;


	/// <summary>
	/// ایمیل
	/// </summary>
	public string Email { get; set; } = string.Empty;


	/// <summary>
	/// شماره تلفن همراه
	/// </summary>
	public string CellPhoneNumber { get; set; } = string.Empty;
}
