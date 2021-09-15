using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OfficeRent.Api.Database;

namespace OfficeRent.Api
{
	public class Startup
	{
		private readonly IConfiguration _configuration;

		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<OfficeDbContext>(
				options => options.UseNpgsql(_configuration["ConnectionString"]).UseSnakeCaseNamingConvention());

			services.AddCors();
			services.ConfigureRepositories();
			services.ConfigureGraphQL();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCors(policyBuilder => policyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
			app.UseRouting();

			app.UseEndpoints(endpoints => endpoints.MapGraphQL());
		}
	}
}