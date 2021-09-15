using HotChocolate.Types;

namespace OfficeRent.Api.GraphQL.Offices
{
	internal class AddressEditInputType : InputObjectType<AddressEditInput>
	{
		protected override void Configure(IInputObjectTypeDescriptor<AddressEditInput> descriptor)
		{
			descriptor.Field(address => address.City).Type<StringType>();
			descriptor.Field(address => address.Street).Type<StringType>();
			descriptor.Field(address => address.StreetNumber).Type<StringType>();
		}
	}
}