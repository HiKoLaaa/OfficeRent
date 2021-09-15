using System.Threading.Tasks;
using HotChocolate.Execution;
using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Extensions;
using NUnit.Framework;
using OfficeRent.Api.GraphQL.Mutations;
using OfficeRent.Api.GraphQL.Offices;
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

			var officeAddInput = new OfficeAddInput(
				officeToAdd.Name,
				new AddressAddInput(officeToAdd.Address.City, officeToAdd.Address.Street, officeToAdd.Address.StreetNumber),
				officeToAdd.Floor);

			var result = await ExecuteRequest(OfficeQueries.AddOffice(officeAddInput));

			result.MatchSnapshot();
		}

		[Test]
		public async Task EditOffice_RequestThrowGraphQL_OfficeEdited()
		{
			var office = new OfficeTestBuilder()
				.WithAddress(new AddressTestBuilder().WithCity("Moscow").WithStreet("Koroleva").WithStreetNumber("1").Build())
				.WithName("office number 1")
				.WithFloor(1)
				.Build();

			await AddEntityToDbAsync(office);

			var officeEditInput = new OfficeEditInput(
				Name: "office",
				new AddressEditInput(City: "city 17", Street: "Some street 17", StreetNumber: "Beautiful street 17"),
				Floor: 17);

			var result = await ExecuteRequest(OfficeQueries.EditOffice(office.Id, officeEditInput));

			result.MatchSnapshot();
		}

		[Test]
		public async Task DeleteOffice_RequestThrowGraphQL_OfficeDeleted()
		{
			var office = new OfficeTestBuilder()
				.WithAddress(new AddressTestBuilder().WithCity("Moscow").WithStreet("Koroleva").WithStreetNumber("1").Build())
				.WithName("office number 1")
				.WithFloor(1)
				.Build();

			await AddEntityToDbAsync(office);
			await ExecuteRequest(OfficeQueries.DeleteOffice(office.Id));

			var result = await ExecuteRequest(OfficeQueries.GetOffice(office.Id));

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

			public static string AddOffice(OfficeAddInput office)
			{
				return
					$@"mutation
{{
  addOffice({MutationType.AddOfficeInputName}:
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

			public static string EditOffice<TId>(TId id, OfficeEditInput office)
			{
				return
					$@"mutation
{{
  editOffice(
	id: {id},
	{MutationType.EditOfficeInputName}:
	{{
		{AddKeyValueIfNotNullOrEmpty("name", office.Name)}
		address:
		{{
			{AddKeyValueIfNotNullOrEmpty("city", $"{office.Address?.City}")},
			{AddKeyValueIfNotNullOrEmpty("street", $"{office.Address?.Street}")},
			{AddKeyValueIfNotNullOrEmpty("streetNumber", $"{office.Address?.StreetNumber}")},
		}},
		{AddKeyValueIfNotNull("floor", office.Floor)}
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

			public static string DeleteOffice<TId>(TId id)
			{
				return
					$@"mutation
{{
	deleteOffice(id: {id})
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

			private static string AddKeyValueIfNotNullOrEmpty(string key, string? value) =>
				string.IsNullOrEmpty(value) ? string.Empty : $"{key}: {value.AddDoubleQuote()}";

			private static string AddKeyValueIfNotNull(string key, short? value) =>
				value is null ? string.Empty : $"{key}: {value}";
		}
	}
}