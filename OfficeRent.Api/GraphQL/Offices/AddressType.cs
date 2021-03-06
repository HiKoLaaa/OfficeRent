using HotChocolate.Types;
using OfficeRent.Api.Models.Offices;

namespace OfficeRent.Api.GraphQL.Offices
{
	internal class AddressType : ObjectType<Address>
	{
		protected override void Configure(IObjectTypeDescriptor<Address> descriptor)
		{
			descriptor.Field(address => address.City).Type<NonNullType<StringType>>();
			descriptor.Field(address => address.Street).Type<NonNullType<StringType>>();
			descriptor.Field(address => address.StreetNumber).Type<NonNullType<StringType>>();
		}
	}
}