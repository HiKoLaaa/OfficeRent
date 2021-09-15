using HotChocolate.Types;

namespace OfficeRent.Api.GraphQL.Offices
{
	internal class OfficeAddedPayloadType : ObjectType<OfficeAddedPayload>
	{
		protected override void Configure(IObjectTypeDescriptor<OfficeAddedPayload> descriptor)
		{
			descriptor
				.Field(officeAddedPayload => officeAddedPayload.Office)
				.Type<NonNullType<OfficeType>>();
		}
	}
}