using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OfficeRent.Api.Database;
using OfficeRent.Api.Database.Abstractions;
using OfficeRent.Api.GraphQL;
using OfficeRent.Api.GraphQL.Offices;

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

			services.AddTransient<IOfficeRepository, OfficeRepository>();

			services
				.AddGraphQLServer()
				.AddQueryType<QueryType>()
				.AddErrorFilter<ErrorFilter>()
				.AddType<OfficeType>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			
			app.UseRouting();

			app.UseEndpoints(
				endpoints =>
				{
					endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
					endpoints.MapGraphQL();
				});
		}
	}
}