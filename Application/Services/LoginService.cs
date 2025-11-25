using System;
using Domain.Shared;
using SharedKernel.DTOs;
using Domain.Interfaces;
using System.Threading.Tasks;
using Application.Interfaces;

namespace Application.Services;

/// <summary>
/// سرویس لاگین
/// </summary>
/// <param name="employeeRepository"></param>
/// <param name="jwtService"></param>
public class LoginService(IEmployeeRepository employeeRepository, IJwtService jwtService) : ILoginService
{
	public IEmployeeRepository EmployeeRepo { get; } = employeeRepository;
	public IJwtService JwtRepo { get; } = jwtService;


	public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
	{
		var employee = await
			EmployeeRepo.GetByUsername(username: request.Username);

		if (employee is null)
		{
			throw new Exception(Domain.Shared.Resources.Messages.Errors.InvalidUsernameOrPassword);
		}

		if (!CheckPassword(inputPlainText: request.Password, storedHashedPassword: employee.Password))
		{
			throw new Exception(Domain.Shared.Resources.Messages.Errors.InvalidUsernameOrPassword);
		}

		var token = JwtRepo.GenerateToken(employee);

		var response = new LoginResponseDto
		{
			Token = token
		};

		return response;
	}

	private static bool CheckPassword(string inputPlainText, string storedHashedPassword)
	{
		var hashOfEnteredPassword = Utility.Hasher.GetHash(input: inputPlainText);

		return hashOfEnteredPassword == storedHashedPassword;
	}
}