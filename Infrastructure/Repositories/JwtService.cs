using System;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories;

/// <summary>
/// سرویس توکن
/// </summary>
/// <param name="configuration"></param>
public class JwtService(IConfiguration configuration) : IJwtService
{
	public IConfiguration Configuration { get; } = configuration;


	public string GenerateToken(Employee employee)
	{
		var claims = new[]
		{
			new Claim(type: ClaimTypes.Name, value: employee.Username),
			new Claim(type: ClaimTypes.Role, value: employee.Role?.Number.ToString()!)
		};

		var issuer = Configuration[key: "Jwt:Issuer"];
		var audience = Configuration[key: "Jwt:Audience"];
		var secretKey = Configuration[key: "Jwt:SecretKey"];

		var expiration = DateTime.UtcNow.AddMinutes
			(Configuration.GetValue<int>(key: "Jwt:ExpirationInMinutes"));

		var securityKey = new SymmetricSecurityKey(key: Encoding.UTF8.GetBytes(secretKey!));
		var credentials = new SigningCredentials(key: securityKey, algorithm: SecurityAlgorithms.HmacSha256);

		var token = new JwtSecurityToken(
			issuer: issuer,
			audience: audience,
			claims: claims,
			expires: expiration,
			signingCredentials: credentials
		);

		var jwt = new JwtSecurityTokenHandler().WriteToken(token);
		return jwt;
	}
}