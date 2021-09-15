using HotChocolate.Types;

namespace OfficeRent.Api.GraphQL.Offices
{
	internal class OfficeAddInputType : InputObjectType<OfficeAddInput>
	{
		protected override void Configure(IInputObjectTypeDescriptor<OfficeAddInput> descriptor)
		{
			descriptor.Field(officeInput => officeInput.Name).Type<NonNullType<StringType>>();
			descriptor.Field(officeInput => officeInput.Address).Type<NonNullType<AddressAddInputType>>();
			descriptor.Field(officeInput => officeInput.Floor).Type<NonNullType<ShortType>>();
		}
	}
}