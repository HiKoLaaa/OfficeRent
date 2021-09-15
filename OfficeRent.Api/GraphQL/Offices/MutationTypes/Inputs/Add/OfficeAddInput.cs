namespace OfficeRent.Api.GraphQL.Offices
{
	internal record OfficeAddInput(string Name, AddressAddInput Address, short Floor);
}