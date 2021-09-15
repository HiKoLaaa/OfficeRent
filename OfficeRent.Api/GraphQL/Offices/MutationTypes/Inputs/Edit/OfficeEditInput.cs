namespace OfficeRent.Api.GraphQL.Offices
{
	internal record OfficeEditInput(string? Name, AddressEditInput? Address, short? Floor);
}