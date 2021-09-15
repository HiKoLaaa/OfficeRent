using HotChocolate.Types;

namespace OfficeRent.Api.GraphQL.Offices
{
	internal class OfficeInputType : InputObjectType<OfficeInput>
	{
		protected override void Configure(IInputObjectTypeDescriptor<OfficeInput> descriptor)
		{
			descriptor.Field(officeInput => officeInput.Name).Type<NonNullType<StringType>>();
			descriptor.Field(officeInput => officeInput.Address).Type<NonNullType<AddressInputType>>();
			descriptor.Field(officeInput => officeInput.Floor).Type<NonNullType<ShortType>>();
		}
	}
}