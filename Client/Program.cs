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

		var configFile = builder.Configuration;

		builder.Services.AddScoped(sp =>
			new HttpClient
			{
				BaseAddress = new Uri(configFile["ApiBaseUrl"]!)
			});

		var app = builder.Build();

		await
			app.RunAsync();
	}
}