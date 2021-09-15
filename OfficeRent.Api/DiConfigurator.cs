using Microsoft.Extensions.DependencyInjection;
using OfficeRent.Api.Database.Abstractions;
using OfficeRent.Api.GraphQL;
using OfficeRent.Api.GraphQL.Mutations;
using OfficeRent.Api.GraphQL.Offices;

namespace OfficeRent.Api
{
	internal static class DiConfigurator
	{
		public static void ConfigureRepositories(IServiceCollection services)
		{
			services.AddScoped<IOfficeRepository, OfficeRepository>();
		}

		public static void ConfigureGraphQL(IServiceCollection services)
		{
			services
				.AddGraphQLServer()
				.AddQueryType<QueryType>()
				.AddMutationType<MutationType>()
				.AddErrorFilter<ErrorFilter>()
				.AddType<OfficeType>()
				.AddType<AddressType>()
				.AddType<OfficeAddedPayloadType>()
				.AddType<OfficeInputType>()
				.AddType<AddressInputType>();
		}
	}
}