using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using OfficeRent.Api.Database.Abstractions;
using OfficeRent.Api.Models.Offices;

namespace OfficeRent.Api.GraphQL
{
	internal class Query
	{
		public async Task<Office> GetOffice(int id, [Service] IOfficeRepository officeRepository) =>
			await officeRepository.GetOffice(id);

		public IQueryable<Office> GetOffices([Service] IOfficeRepository officeRepository) =>
			officeRepository.GetOffices();
	}
}