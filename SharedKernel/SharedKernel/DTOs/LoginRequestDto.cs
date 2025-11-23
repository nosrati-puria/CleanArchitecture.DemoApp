namespace SharedKernel.DTOs;

public record LoginRequestDto(
	string Username,
	string Password
);