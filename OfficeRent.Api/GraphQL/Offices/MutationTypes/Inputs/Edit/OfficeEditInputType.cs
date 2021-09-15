using HotChocolate.Types;

namespace OfficeRent.Api.GraphQL.Offices
{
	internal class OfficeEditInputType : InputObjectType<OfficeEditInput>
	{
		protected override void Configure(IInputObjectTypeDescriptor<OfficeEditInput> descriptor)
		{
			descriptor.Field(officeInput => officeInput.Name).Type<StringType>();
			descriptor.Field(officeInput => officeInput.Address).Type<AddressEditInputType>();
			descriptor.Field(officeInput => officeInput.Floor).Type<ShortType>();
		}
	}
}