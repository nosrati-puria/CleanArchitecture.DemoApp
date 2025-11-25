using System;
using Domain.Entities;
using SharedKernel.DTOs;
using Domain.Interfaces;
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


	[HttpPost(Name = nameof(Register))]
	[ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
	[ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(LoginResponseDto))]
	public async Task<IActionResult> Register([FromBody] SignupDto model)
	{
		try
		{
			var employee = new Employee()
			{
				Username = model.Username,
				Password = model.Password,
				FullName = model.FullName,
				Email = model.Email,
				CellPhoneNumber = model.CellPhoneNumber,
				Role = new Role()
				{
					Name = Domain.Enums.RolesName.Employee,
					Description = nameof(DataDictionary.Employee),
				},
			};

			await
				_employeeRepository.CreateAsync(employee);

			return Ok();
		}
		catch (Exception)
		{
			return Unauthorized();
		}
	}
}