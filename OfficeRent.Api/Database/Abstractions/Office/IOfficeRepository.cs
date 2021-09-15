using System.Linq;
using System.Threading.Tasks;
using OfficeRent.Api.Models.Office;

namespace OfficeRent.Api.Database.Abstractions
{
	public interface IOfficeRepository
	{
		Task<Office> GetOffice(int id);

		IQueryable<Office> GetOffices();
	}
}