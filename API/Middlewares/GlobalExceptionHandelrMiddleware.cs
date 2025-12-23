using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace API.Middlewares;

public class GlobalExceptionHandelrMiddleware(RequestDelegate next)
{
	private RequestDelegate Next { get; } = next;

	/// <summary>
	/// Log and redirect the errors
	/// </summary>
	/// <param name="httpContext"></param>
	/// <returns></returns>
	public async Task InvokeAsync(HttpContext httpContext)
	{
		try
		{
			await Next(context: httpContext);
		}
		catch (Exception ex)
		{
			//Todo
			//Log

			httpContext.Response.Redirect
				(location: "/Errors/Error", permanent: false);
		}
	}
}