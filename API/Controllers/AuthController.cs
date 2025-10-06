using System;
using System.Text;
using System.Security.Claims;
using Domain.Shared.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
	private readonly IConfiguration _configuration;

	public AuthController(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	[HttpPost(Name = nameof(Login))]
	[ProducesResponseType(StatusCodes.Status401Unauthorized)]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
	public IActionResult Login([FromBody] LoginModel model)
	{
		if (model.Username != "admin" || model.Password != "admin")
		{
			return Unauthorized();
		}

		var claims = new[]
		{
			new Claim(ClaimTypes.Name, model.Username),
			new Claim(ClaimTypes.Role, nameof(DataDictionary.Admin))
		};

		var issuer = _configuration["Jwt:Issuer"];
		var audience = _configuration["Jwt:Audience"];
		var secretKey = _configuration["Jwt:SecretKey"];

		var expiration = DateTime.UtcNow.AddMinutes(
			_configuration.GetValue<int>("Jwt:ExpirationInMinutes")
		);

		var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
		var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

		var token = new JwtSecurityToken(
			issuer: issuer,
			audience: audience,
			claims: claims,
			expires: expiration,
			signingCredentials: credentials
		);

		var tokenString = new
			JwtSecurityTokenHandler().WriteToken(token);

		return Ok(new
		{
			Token = tokenString,
		});
	}
}

public class LoginModel
{
	public string? Username { get; set; }
	public string? Password { get; set; }
}

public class LoginResponse
{
	public string Token { get; set; } = string.Empty;
}