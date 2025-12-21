using SharedKernel.DTOs;
using Application.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(ILoginService loginService) : ControllerBase
{
	private readonly ILoginService _loginService = loginService;


	[AllowAnonymous]
	[HttpPost(template: nameof(Login))]
	[ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
	[ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(LoginResponseDto))]
	public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
	{
		var result = await
			_loginService.LoginAsync(request:
				new LoginRequestDto
				{
					Username = model.Username,
					Password = model.Password,
				}
			);

		if (!result.IsSuccess)
		{
			return StatusCode(result.StatusCode, new { message = result.Message });
		}

		return Ok(result.Data);
	}
}