using Microsoft.Extensions.DependencyInjection;
using OfficeRent.Api;

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