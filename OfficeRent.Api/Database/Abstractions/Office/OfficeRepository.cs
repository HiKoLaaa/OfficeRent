using System.Linq;
using System.Threading.Tasks;
using OfficeRent.Api.Database.Exceptions;
using OfficeRent.Api.Models.Office;

namespace OfficeRent.Api.Database.Abstractions
{
	internal class OfficeRepository : IOfficeRepository
	{
		private readonly OfficeDbContext _context;

		public OfficeRepository(OfficeDbContext context)
		{
			_context = context;
		}

		public async Task<Office> GetOffice(int id)
		{
			var office = await _context.Offices.FindAsync(id);
			if (office is null)
				throw new EntityNotFoundException<int>(typeof(Office), id);

			return office;
		}

		public IQueryable<Office> GetOffices() => _context.Offices;
	}
}