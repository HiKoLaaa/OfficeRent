using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using OfficeRent.Api.Database.Abstractions;
using OfficeRent.Api.Models.Offices;

namespace OfficeRent.Api.GraphQL.Queries
{
	internal class Query
	{
		public async Task<Office> GetOfficeAsync(int id, [Service] IOfficeRepository officeRepository)
		{
			return await officeRepository.GetOfficeAsync(id);
		}

		public IQueryable<Office> GetOffices([Service] IOfficeRepository officeRepository)
		{
			return officeRepository.GetOffices();
		}
	}
}