using HotChocolate.Types;
using OfficeRent.Api.GraphQL.Offices;

namespace OfficeRent.Api.GraphQL.Mutations
{
	internal class MutationType : ObjectType<Mutation>
	{
		protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
		{
			descriptor
				.Field(mutation => mutation.AddOfficeAsync(default!, default!))
				.Argument(
					argumentName: "officeInput",
					argumentDescriptor => argumentDescriptor.Type<NonNullType<OfficeInputType>>())
				.Type<NonNullType<OfficeAddedPayloadType>>()
				.Description("Add new entity of office type.");
		}
	}
}