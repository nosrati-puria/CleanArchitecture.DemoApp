using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Client;

public static class Program
{
	/// <summary>
	/// Main Function
	/// </summary>
	/// <returns></returns>
	private static async Task Main(string[] args)
	{
		var builder = WebAssemblyHostBuilder.CreateDefault(args);

		builder.RootComponents.Add<App>("#app");
		builder.RootComponents.Add<HeadOutlet>("head::after");

		builder.Services
			.AddScoped(options =>
				new HttpClient
				{
					BaseAddress = new Uri(uriString: builder.HostEnvironment.BaseAddress)
				}
			);

		//builder.Services.AddCors(options =>
		//{
		//	options.AddPolicy("AllowBlazor",
		//		policy =>
		//		{
		//			policy.WithOrigins("https://localhost:7223")
		//				  .AllowAnyHeader()
		//				  .AllowAnyMethod();
		//		});
		//});

		var app = builder.Build();

		await
			app.RunAsync();
	}
}