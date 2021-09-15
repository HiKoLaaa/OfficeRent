using HotChocolate.Types;
using OfficeRent.Api.Models.Offices;

namespace OfficeRent.Api.GraphQL.Offices
{
	internal class OfficeType : ObjectType<Office>
	{
		protected override void Configure(IObjectTypeDescriptor<Office> descriptor)
		{
			descriptor.Description("Represents office");

			descriptor
				.Field(office => office.Id)
				.Type<NonNullType<IntType>>()
				.Description("Id in the database.");

			descriptor
				.Field(office => office.Name)
				.Type<NonNullType<StringType>>()
				.Description("Name of the office which just for human readability.");

			descriptor
				.Field(office => office.Address)
				.Type<NonNullType<AddressType>>()
				.Description("Address of the office, including city, street and street number.");

			descriptor
				.Field(office => office.Floor)
				.Type<NonNullType<ShortType>>()
				.Description("Floor of the office.");
		}
	}
}