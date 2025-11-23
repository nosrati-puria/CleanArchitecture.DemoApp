using System;
using SharedKernel.DTOs;
using Application.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AuthController(ILoginService loginService) : ControllerBase
{
	public ILoginService LoginService { get; } = loginService;


	[HttpPost(Name = nameof(Login))]
	[ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
	[ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(LoginResponseDto))]
	public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
	{
		try
		{
			var result = await
				LoginService.LoginAsync(request:
					new LoginRequestDto(Username: model.Username, Password: model.Password));

			return Ok(value: result);
		}
		catch (Exception)
		{
			return Unauthorized();
		}
	}
}