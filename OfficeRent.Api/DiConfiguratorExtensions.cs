using Microsoft.Extensions.DependencyInjection;
using OfficeRent.Api.Database.Abstractions;
using OfficeRent.Api.GraphQL;
using OfficeRent.Api.GraphQL.Mutations;

namespace OfficeRent.Api
{
	internal static class DiConfiguratorExtensions
	{
		public static void ConfigureRepositories(this IServiceCollection services)
		{
			services.AddScoped<IOfficeRepository, OfficeRepository>();
		}

		public static void ConfigureGraphQL(this IServiceCollection services)
		{
			services
				.AddGraphQLServer()
				.AddQueryType<QueryType>()
				.AddMutationType<MutationType>()
				.AddErrorFilter<ErrorFilter>();
		}
	}
}