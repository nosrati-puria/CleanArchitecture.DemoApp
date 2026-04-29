using System;

namespace SharedKernel.DTOs;

public record LoginResponseDto()
{
	/// <summary>
	/// شناسه کاربری
	/// </summary>
	public Guid UserID { get; set; }


	/// <summary>
	/// توکن
	/// </summary>
	public string Token { get; set; } = string.Empty;
}