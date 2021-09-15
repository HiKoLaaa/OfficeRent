using System.Threading.Tasks;
using HotChocolate;
using OfficeRent.Api.Database.Abstractions;
using OfficeRent.Api.GraphQL.Offices;
using OfficeRent.Api.Models.Offices;

namespace OfficeRent.Api.GraphQL.Mutations
{
	internal class Mutation
	{
		public async Task<OfficeOutput> AddOfficeAsync(
			OfficeAddInput officeAddInput,
			[Service] IOfficeRepository officeRepository)
		{
			var newAddress = new Address(
				officeAddInput.Address.City,
				officeAddInput.Address.Street,
				officeAddInput.Address.StreetNumber);

			var newOffice = new Office(officeAddInput.Name, newAddress, officeAddInput.Floor);

			await officeRepository.AddOfficeAsync(newOffice);
			await officeRepository.SaveAllChangesAsync();

			return new OfficeOutput(newOffice);
		}

		public async Task<OfficeOutput> EditOfficeAsync(
			int id,
			OfficeEditInput officeEditInput,
			[Service] IOfficeRepository officeRepository)
		{
			var office = await officeRepository.GetOfficeAsync(id);
			officeRepository.EditOffice(office);

			if (!string.IsNullOrEmpty(officeEditInput.Name))
			{
				office.ChangeName(officeEditInput.Name);
			}

			if (officeEditInput.Address is not null)
			{
				var newAddress = CreateEditingAddress(officeEditInput.Address, office.Address);
				office.ChangeAddress(newAddress);
			}

			if (officeEditInput.Floor is not null)
			{
				office.ChangeFloor(officeEditInput.Floor.Value);
			}

			await officeRepository.SaveAllChangesAsync();

			return new OfficeOutput(office);
		}

		private Address CreateEditingAddress(AddressEditInput addressEditInput, Address oldAddress)
		{
			var city = !string.IsNullOrEmpty(addressEditInput.City) ? addressEditInput.City : oldAddress.City;
			var street = !string.IsNullOrEmpty(addressEditInput.Street) ? addressEditInput.Street : oldAddress.Street;
			var streetNumber = !string.IsNullOrEmpty(addressEditInput.StreetNumber)
				? addressEditInput.StreetNumber
				: oldAddress.StreetNumber;

			return new Address(city, street, streetNumber);
		}
	}
}