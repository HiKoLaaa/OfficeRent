using Microsoft.Extensions.DependencyInjection;
using OfficeRent.Api.GraphQL;
using OfficeRent.Api.GraphQL.Offices;

namespace OfficeRent.Tests.GraphQL
{
	public abstract class GraphQLTestsBase : OfficeTestsBase
	{
		protected override void ConfigureServiceCollection(IServiceCollection serviceCollection)
		{
			base.ConfigureServiceCollection(serviceCollection);

			serviceCollection
				.AddGraphQLServer()
				.AddQueryType<QueryType>()
				.AddErrorFilter<ErrorFilter>()
				.AddType<OfficeType>();
		}
	}
}