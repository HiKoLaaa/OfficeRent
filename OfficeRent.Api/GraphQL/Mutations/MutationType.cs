using HotChocolate.Types;
using OfficeRent.Api.GraphQL.Offices;

namespace OfficeRent.Api.GraphQL.Mutations
{
	internal class MutationType : ObjectType<Mutation>
	{
		public const string AddOfficeInputName = "officeAddInput";

		public const string EditOfficeInputName = "officeEditInput";

		protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
		{
			descriptor
				.Field(mutation => mutation.AddOfficeAsync(default!, default!))
				.Argument(
					"officeAddInput",
					argumentDescriptor => argumentDescriptor.Type<NonNullType<OfficeAddInputType>>())
				.Type<NonNullType<OfficeOutputType>>()
				.Description("Add new entity of office type.");

			descriptor
				.Field(mutation => mutation.EditOfficeAsync(default, default!, default!))
				.Argument(
					"officeEditInput",
					argumentDescriptor => argumentDescriptor.Type<NonNullType<OfficeEditInputType>>())
				.Argument(
					"id",
					argumentDescriptor => argumentDescriptor.Type<NonNullType<IntType>>())
				.Type<NonNullType<OfficeOutputType>>()
				.Description("Edit existing office type.");
		}
	}
}