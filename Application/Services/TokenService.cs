using System;
using System.Text;
using Domain.Entities;
using Application.Interfaces;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Application.Services;

/// <summary>
/// سرویس توکن
/// </summary>
/// <param name="options"></param>
public class TokenService(IOptions<JwtOptions> options) : ITokenService
{
	public IOptions<JwtOptions> Options { get; } = options;


	public string GenerateToken(Employee employee)
	{
		var claims = new[]
		{
			new Claim(type: ClaimTypes.Name, value: employee.Username),
			new Claim(type: ClaimTypes.Role, value: employee.Role?.Number.ToString()!)
		};

		var issuer = Options.Value.Issuer;
		var audience = Options.Value.Audience;
		var secretKey = Options.Value.SecretKey;
		var expiration = DateTime.UtcNow.AddMinutes(value: Options.Value.ExpirationInMinutes);

		var securityKey = new SymmetricSecurityKey(key: Encoding.UTF8.GetBytes(secretKey!));
		var credentials = new SigningCredentials(key: securityKey, algorithm: SecurityAlgorithms.HmacSha256);

		var token = new JwtSecurityToken
			(issuer: issuer,
			audience: audience,
			claims: claims,
			expires: expiration,
			signingCredentials: credentials);

		var jwt = new JwtSecurityTokenHandler().WriteToken(token);

		return jwt;
	}
}