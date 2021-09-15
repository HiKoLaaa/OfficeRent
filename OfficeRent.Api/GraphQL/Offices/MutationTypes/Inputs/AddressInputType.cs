using HotChocolate.Types;
using OfficeRent.Api.Models.Offices;

namespace OfficeRent.Api.GraphQL.Offices
{
	internal class AddressInputType : InputObjectType<Address>
	{
		protected override void Configure(IInputObjectTypeDescriptor<Address> descriptor)
		{
			descriptor.Field(address => address.City).Type<NonNullType<StringType>>();
			descriptor.Field(address => address.Street).Type<NonNullType<StringType>>();
			descriptor.Field(address => address.StreetNumber).Type<NonNullType<StringType>>();
		}
	}
}