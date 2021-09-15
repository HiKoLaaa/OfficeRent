using HotChocolate.Types;

namespace OfficeRent.Api.GraphQL.Offices
{
	internal class AddressAddInputType : InputObjectType<AddressAddInput>
	{
		protected override void Configure(IInputObjectTypeDescriptor<AddressAddInput> descriptor)
		{
			descriptor.Field(address => address.City).Type<NonNullType<StringType>>();
			descriptor.Field(address => address.Street).Type<NonNullType<StringType>>();
			descriptor.Field(address => address.StreetNumber).Type<NonNullType<StringType>>();
		}
	}
}