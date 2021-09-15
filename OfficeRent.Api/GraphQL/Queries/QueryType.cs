using HotChocolate.Types;
using OfficeRent.Api.GraphQL.Offices;

namespace OfficeRent.Api.GraphQL.Queries
{
	internal class QueryType : ObjectType<Query>
	{
		protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
		{
			descriptor
				.Field(query => query.GetOfficeAsync(default, default!))
				.Type<NonNullType<OfficeType>>()
				.Description("Get office with specified id.");

			descriptor
				.Field(query => query.GetOffices(default!))
				.Type<NonNullType<ListType<NonNullType<OfficeType>>>>()
				.Description("Get all offices.");
		}
	}
}