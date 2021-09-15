using System.Threading.Tasks;
using HotChocolate.Execution;
using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Extensions;
using NUnit.Framework;
using OfficeRent.Api.Models.Offices;
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

			var result = await ExecuteRequest(OfficeQueries.GetAllOffices());

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

			var result = await ExecuteRequest(OfficeQueries.GetOffice(office1.Id));

			result.MatchSnapshot();
		}

		[Test]
		public async Task AddOffice_RequestThrowGraphQL_OfficeAdded()
		{
			var officeToAdd = new OfficeTestBuilder()
				.WithAddress(new AddressTestBuilder().WithCity("Moscow").WithStreet("Koroleva").WithStreetNumber("1").Build())
				.WithName("office number 1")
				.WithFloor(1)
				.Build();

			var result = await ExecuteRequest(OfficeQueries.AddOffice(officeToAdd));

			result.MatchSnapshot();
		}

		private async Task<IExecutionResult> ExecuteRequest(string requestText)
		{
			var executor = await ServiceProvider.GetRequestExecutorAsync();
			
			var request = QueryRequestBuilder
				.New()
				.SetQuery(requestText)
				.SetServices(ServiceProvider)
				.Create();

			return await executor.ExecuteAsync(request);
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

			public static string AddOffice(Office office)
			{
				return
					$@"mutation
{{
  addOffice(officeInput:
  {{
    name: {office.Name.AddDoubleQuote()},
				address:
				{{
					city: {office.Address.City.AddDoubleQuote()},
					street: {office.Address.Street.AddDoubleQuote()},
					streetNumber: {office.Address.StreetNumber.AddDoubleQuote()}
				}},
				floor: {office.Floor}
			}})
			{{
				office
				{{
					id,
					name,
					floor,
					address
					{{
						street,
						city,
						streetNumber
					}}
				}}
			}}
		}}";
			}
		}
	}
}