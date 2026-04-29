using Domain.Shared;
using Domain.Entities;
using Domain.Interfaces;
using SharedKernel.DTOs;
using System.Threading.Tasks;
using Domain.Shared.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class SignupController(IEmployeeRepository employeeRepository) : ControllerBase
{
	private readonly IEmployeeRepository _employeeRepository = employeeRepository;

	[AllowAnonymous]
	[HttpPost(template: nameof(Register))]
	[ProducesResponseType(statusCode: StatusCodes.Status409Conflict)]
	[ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(LoginResponseDto))]
	public async Task<IActionResult> Register([FromBody] SignupDto model)
	{
		var employee = new Employee()
		{
			Username = model.Username,
			Password = Utility.Hasher.GetHash(input: model.Password),
			FullName = model.FullName,
			Email = model.EmailAddress,
			CellPhoneNumber = model.CellPhoneNumber,
			Role = new Role()
			{
				Number = Domain.Enums.Role.Employee,
				Description = nameof(DataDictionary.Employee),
			},
		};

		var alreadyExists = await
			_employeeRepository.CheckUsernameExistAsync(employee.Username);

		if (alreadyExists)
		{
			return Conflict(Domain.Shared.Resources.Messages.Errors.AlreadyExists);
		}
		else
		{
			await
				_employeeRepository.AddAsync(employee);

			return Ok(model);
		}
	}
}