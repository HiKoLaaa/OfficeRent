using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace OfficeRent.Frontend
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
			builder
				.Services
				.AddOfficeRentClient()
				.ConfigureHttpClient(client => client.BaseAddress = new Uri(builder.Configuration["GraphQLEndpoint"]));

			await builder.Build().RunAsync();
		}
	}
}