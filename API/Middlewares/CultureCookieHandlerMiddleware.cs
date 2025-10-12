using System;
using System.Linq;
using System.Threading;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Builder;

namespace API.Middlewares;

public class CultureCookieHandlerMiddleware(RequestDelegate next,
		IOptions<RequestLocalizationOptions>? requestLocalizationOptions)
{
	#region Fields and Properties
	private readonly static string CookieName = "Culture.Cookie";

	private RequestDelegate Next { get; } = next;

	private RequestLocalizationOptions? RequestLocalizationOptions { get; } = requestLocalizationOptions?.Value;
	#endregion /Fields and Properties


	#region Methods
	/// <summary>
	/// Set Culture
	/// </summary>
	/// <param name="cultureName"></param>
	public static void SetCulture(string? cultureName)
	{
		if (!string.IsNullOrWhiteSpace(value: cultureName))
		{
			var cultureInfo =
				new CultureInfo(name: cultureName);

			Thread.CurrentThread.CurrentCulture = cultureInfo;
			Thread.CurrentThread.CurrentUICulture = cultureInfo;
		}
	}

	/// <summary>
	/// Create Cookies
	/// </summary>
	/// <param name="httpContext"></param>
	/// <param name="cultureName"></param>
	public static void CreateCookies(HttpContext httpContext, string cultureName)
	{
		var cookieOptions = new CookieOptions
		{
			Path = "/",
			MaxAge = null,
			Secure = false,
			HttpOnly = false,
			IsEssential = false,
			SameSite = SameSiteMode.Unspecified,
			Expires = DateTimeOffset.UtcNow.AddYears(1),
		};

		httpContext.Response.Cookies.Delete(key: CookieName);

		if (!string.IsNullOrWhiteSpace(cultureName))
		{
			cultureName =
				cultureName[..2].ToLower();

			httpContext.Response.Cookies
				.Append(key: CookieName, value: cultureName, options: cookieOptions);
		}
	}

	/// <summary>
	/// Get user culture base on cookie
	/// </summary>
	/// <param name="httpContext"></param>
	/// <param name="supportedCultures"></param>
	/// <returns></returns>
	public static string? GetCultureNameByCookie
		(HttpContext httpContext, List<string>? supportedCultures)
	{
		if (supportedCultures == null || supportedCultures.Count == 0)
		{
			return null;
		}

		var cultureName =
			httpContext.Request.Cookies[key: CookieName];

		if (string.IsNullOrWhiteSpace(value: cultureName) ||
			!supportedCultures.Contains(item: cultureName))
		{
			return null;
		}

		return cultureName;
	}

	public async Task InvokeAsync(HttpContext httpContext)
	{
		var defaultCultureName =
			RequestLocalizationOptions?
			.DefaultRequestCulture.UICulture.Name;

		var supportedCultures =
			RequestLocalizationOptions?.SupportedCultures?
			.Select(current => current.Name)
			.ToList();

		var currentCultureName =
			GetCultureNameByCookie(httpContext, supportedCultures);

		if (string.IsNullOrWhiteSpace(value: currentCultureName))
		{
			currentCultureName = defaultCultureName;
		}

		SetCulture(cultureName: currentCultureName);

		await Next(context: httpContext);
	}
	#endregion /Methods
}