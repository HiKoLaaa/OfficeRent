using HotChocolate.Types;

namespace OfficeRent.Api.GraphQL.Offices
{
	internal class OfficeOutputType : ObjectType<OfficeOutput>
	{
		protected override void Configure(IObjectTypeDescriptor<OfficeOutput> descriptor)
		{
			descriptor
				.Field(officeAddedPayload => officeAddedPayload.Office)
				.Type<NonNullType<OfficeType>>();
		}
	}
}