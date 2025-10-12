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
public class AuthController(IConfiguration configuration) : ControllerBase
{
	private readonly IConfiguration _configuration = configuration;


	/// <summary>
	/// Login Method
	/// </summary>
	/// <param name="model"></param>
	/// <returns></returns>
	[HttpPost(Name = nameof(Login))]
	[ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
	[ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(LoginResponse))]
	public IActionResult Login([FromBody] LoginModel model)
	{
		if (model.Username != nameof(DataDictionary.Admin) || model.Password != nameof(DataDictionary.Admin))
		{
			return Unauthorized();
		}

		var claims = new[]
		{
			new Claim(type: ClaimTypes.Name, value: model.Username),
			new Claim(type: ClaimTypes.Role, value: nameof(DataDictionary.Admin))
		};

		var issuer = _configuration[key: "Jwt:Issuer"];
		var audience = _configuration[key: "Jwt:Audience"];
		var secretKey = _configuration[key: "Jwt:SecretKey"];

		var expiration = DateTime.UtcNow.AddMinutes(
			_configuration.GetValue<int>(key: "Jwt:ExpirationInMinutes"));

		var securityKey = new SymmetricSecurityKey(key: Encoding.UTF8.GetBytes(secretKey!));
		var credentials = new SigningCredentials(key: securityKey, algorithm: SecurityAlgorithms.HmacSha256);

		var token = new JwtSecurityToken(
			issuer: issuer,
			audience: audience,
			claims: claims,
			expires: expiration,
			signingCredentials: credentials
		);

		var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

		return Ok(value: new
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