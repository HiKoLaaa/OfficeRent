using System.Linq;
using System.Threading.Tasks;
using OfficeRent.Api.Models.Offices;

namespace OfficeRent.Api.Database.Abstractions
{
	public interface IOfficeRepository
	{
		Task<Office> GetOfficeAsync(int id);

		IQueryable<Office> GetOffices();

		Task AddOfficeAsync(Office office);

		void DeleteOffice(Office office);

		void EditOffice(Office office);

		Task SaveAllChangesAsync();
	}
}