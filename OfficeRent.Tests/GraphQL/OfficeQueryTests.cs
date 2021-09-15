using System.Threading.Tasks;
using HotChocolate.Execution;
using NUnit.Framework;
using OfficeRent.Tests.Database.TestBuilders.Offices;
using OfficeRent.Tests.GraphQL;
using Snapshooter.NUnit;

namespace OfficeRent.Tests
{
	[TestFixture]
	public class OfficeQueryTests : GraphQLTestsBase
	{
		[Test]
		public async Task GetOffices_RequestThrowGraphQL_AllOfficesGot()
		{
			var office1 = new OfficeTestBuilder()
				.WithAddress(new AddressTestBuilder().WithCity("Moscow").WithStreet("Koroleva").WithStreetNumber("1").Build())
				.WithName("office number 1")
				.WithFloor(1)
				.Build();

			var office2 = new OfficeTestBuilder()
				.WithAddress(new AddressTestBuilder().WithCity("Abakan").WithStreet("Krilova").WithStreetNumber("2").Build())
				.WithName("office number 2")
				.WithFloor(7)
				.Build();

			await AddEntitiesToDbAsync(office1, office2);

			var executor = await ServiceProvider.GetRequestExecutorAsync();

			var request = QueryRequestBuilder
				.New()
				.SetQuery(OfficeQueries.GetAllOffices())
				.SetServices(ServiceProvider)
				.Create();

			var result = await executor.ExecuteAsync(request);

			result.MatchSnapshot();
		}

		[Test]
		public async Task GetOffice_RequestThrowGraphQL_OfficeGot()
		{
			var office1 = new OfficeTestBuilder()
				.WithAddress(new AddressTestBuilder().WithCity("Moscow").WithStreet("Koroleva").WithStreetNumber("1").Build())
				.WithName("office number 1")
				.WithFloor(1)
				.Build();

			var office2 = new OfficeTestBuilder()
				.WithAddress(new AddressTestBuilder().WithCity("Abakan").WithStreet("Krilova").WithStreetNumber("2").Build())
				.WithName("office number 2")
				.WithFloor(7)
				.Build();

			await AddEntitiesToDbAsync(office1, office2);

			var executor = await ServiceProvider.GetRequestExecutorAsync();

			var request = QueryRequestBuilder
				.New()
				.SetQuery(OfficeQueries.GetOffice(office1.Id))
				.SetServices(ServiceProvider)
				.Create();

			var result = await executor.ExecuteAsync(request);

			result.MatchSnapshot();
		}

		private static class OfficeQueries
		{
			public static string GetAllOffices()
			{
				return 
					@"query
{
	offices
	{
		id,
		name,
		address 
		{
			city,
			street,
			streetNumber
		},
		floor
		}
}";
			}

			public static string GetOffice<TId>(TId id)
			{
				return 
					$@"query
{{
	office(id: {id})
	{{
		id,
		name,
		address 
		{{
			city,
			street,
			streetNumber
		}},
		floor
		}}
}}";
			}
		}
	}
}