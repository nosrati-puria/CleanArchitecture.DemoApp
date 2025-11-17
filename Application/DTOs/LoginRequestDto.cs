namespace Application.DTOs;

public record LoginRequestDto(
	string Username,
	string Password
);