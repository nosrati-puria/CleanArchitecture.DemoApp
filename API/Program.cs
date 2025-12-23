using System;
using System.Text;
using API.Middlewares;
using Domain.Interfaces;
using Infrastructure.Data;
using Application.Services;
using System.Globalization;
using Application.Interfaces;
using System.Threading.Tasks;
using Infrastructure.Repositories;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace API;
public static class Program
{
	/// <summary>
	/// Main Function
	/// </summary>
	/// <returns></returns>
	private static async Task Main()
	{
		var webApplication = new WebApplicationOptions
		{
			EnvironmentName = Environments.Development
			//EnvironmentName = Environments.Production
		};

		var builder = WebApplication.CreateBuilder(options: webApplication);

		// Add services to the container:
		builder.Services.AddControllers();
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
		builder.Services.AddOpenApi();

		builder.Services
			.Configure<RequestLocalizationOptions>(option =>
			{
				var supportedCultures = new[]
				{
					new CultureInfo(name: "fa-IR"),
					new CultureInfo(name: "en-US"),
				};

				option.SupportedCultures = supportedCultures;
				option.SupportedUICultures = supportedCultures;

				option.DefaultRequestCulture =
					new RequestCulture(culture: "en-US", uiCulture: "en-US");
			});

		builder.Services
			.AddDbContext<AppDbContext>(option =>
				 option.UseSqlServer(connectionString: builder.Configuration
					 .GetConnectionString(name: nameof(Domain.Shared.Utility.Const.DefaultConnection))));

		builder.Services
			.AddCors(options =>
			{
				options.AddPolicy("AllowBlazorClient", policy =>
				{
					policy.WithOrigins("https://localhost:7298")
						  .AllowAnyHeader()
						  .AllowAnyMethod()
						  .AllowCredentials();
				});
			});

		builder.Services
			.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidIssuer = builder.Configuration["Jwt:Issuer"],

					ValidateAudience = true,
					ValidAudience = builder.Configuration["Jwt:Audience"],

					ValidateIssuerSigningKey = true,

					IssuerSigningKey = new SymmetricSecurityKey(key:
						Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]!)),

					ValidateLifetime = true,

					ClockSkew = TimeSpan.Zero
				};

				options.Events = new JwtBearerEvents
				{
					OnAuthenticationFailed = context =>
					{
						return Task.CompletedTask;
					}
				};
			});

		builder.Services.AddProblemDetails();
		builder.Services.AddScoped<IJwtService, JwtService>();
		builder.Services.AddScoped<ILoginService, LoginService>();
		builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

		var app = builder.Build();

		using (var scope = app.Services.CreateScope())
		{
			var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
			await appDbContext.Database.MigrateAsync();
		}

		if (app.Environment.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
			app.UseSwagger();
			app.UseSwaggerUI();
			app.MapOpenApi();
		}
		else
		{
			app.UseExceptionHandler(errorHandlingPath: "/Errors/Error");
			app.UseHsts();
		}

		app.UseHttpsRedirection();

		app.UseStaticFiles();

		app.UseCors("AllowBlazorClient");
		app.UseRouting();

		app.UseAuthentication();
		app.UseAuthorization();

		app.UseCultureCookie();
		app.UseGlobalException();

		app.MapControllers();

		await
			app.RunAsync();
	}
}