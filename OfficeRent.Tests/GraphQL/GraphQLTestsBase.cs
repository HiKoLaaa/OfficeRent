using Microsoft.Extensions.DependencyInjection;
using OfficeRent.Api;
using OfficeRent.Api.GraphQL;
using OfficeRent.Api.GraphQL.Mutations;
using OfficeRent.Api.GraphQL.Offices;

namespace OfficeRent.Tests.GraphQL
{
	public abstract class GraphQLTestsBase : OfficeTestsBase
	{
		protected override void ConfigureServices(IServiceCollection services)
		{
			base.ConfigureServices(services);

			services.ConfigureGraphQL();
		}
	}
}