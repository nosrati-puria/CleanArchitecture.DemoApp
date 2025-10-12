using Microsoft.AspNetCore.Builder;

namespace API.Middlewares;

public static class ExtensionMethods
{
	static ExtensionMethods()
	{
	}

	/// <summary>
	/// Extention method for use culture cookie
	/// </summary>
	/// <param name="app"></param>
	/// <returns></returns>
	public static IApplicationBuilder UseCultureCookie(this IApplicationBuilder app)
	{
		return app.UseMiddleware<CultureCookieHandlerMiddleware>();
	}

	/// <summary>
	/// Extention method for use global exception
	/// </summary>
	/// <param name="app"></param>
	/// <returns></returns>
	public static IApplicationBuilder UseGlobalException(this IApplicationBuilder app)
	{
		return app.UseMiddleware<GlobalExceptionHandelrMiddleware>();
	}
}