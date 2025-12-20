using SharedKernel;
using Domain.Shared;
using SharedKernel.DTOs;
using Domain.Interfaces;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Shared.Resources.Messages;

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


	public async Task<ServiceResult<LoginResponseDto>> LoginAsync(LoginRequestDto request)
	{
		var employee = await
			EmployeeRepo.GetByUsername(username: request.Username);

		if (employee is null || !CheckPassword(inputPlainText: request.Password, storedHashedPassword: employee.Password))
		{
			return ServiceResult<LoginResponseDto>.Failed(message: Errors.InvalidUsernameOrPassword, statusCode: 401);
		}

		var token = JwtRepo.GenerateToken(employee);

		var response = new LoginResponseDto
		{
			Token = token
		};

		return ServiceResult<LoginResponseDto>.Succeeded(response);
	}

	private static bool CheckPassword(string inputPlainText, string storedHashedPassword)
	{
		var hashOfEnteredPassword = Utility.Hasher.GetHash(input: inputPlainText);

		return hashOfEnteredPassword == storedHashedPassword;
	}
}