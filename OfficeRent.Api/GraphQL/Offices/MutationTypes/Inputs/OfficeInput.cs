using OfficeRent.Api.Models.Offices;

namespace OfficeRent.Api.GraphQL.Offices
{
	internal record OfficeInput(string Name, Address Address, short Floor);
}