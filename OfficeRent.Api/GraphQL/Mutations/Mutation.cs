using System.Threading.Tasks;
using HotChocolate;
using OfficeRent.Api.Database.Abstractions;
using OfficeRent.Api.GraphQL.Offices;
using OfficeRent.Api.Models.Offices;

namespace OfficeRent.Api.GraphQL.Mutations
{
	internal class Mutation
	{
		public async Task<OfficeAddedPayload> AddOfficeAsync(OfficeInput officeInput, [Service] IOfficeRepository officeRepository)
		{
			var newOffice = new Office(officeInput.Name, officeInput.Address, officeInput.Floor);
			await officeRepository.AddOfficeAsync(newOffice);
			await officeRepository.SaveAllChangesAsync();

			return new(newOffice);
		}
	}
}