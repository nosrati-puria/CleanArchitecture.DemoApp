namespace SharedKernel.DTOs;

public record LoginResponseDto()
{
	public string Token { get; set; } = string.Empty;
}