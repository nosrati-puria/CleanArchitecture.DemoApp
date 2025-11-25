namespace SharedKernel.DTOs;

public record LoginResponseDto()
{
	/// <summary>
	/// توکن
	/// </summary>
	public string Token { get; set; } = string.Empty;
}