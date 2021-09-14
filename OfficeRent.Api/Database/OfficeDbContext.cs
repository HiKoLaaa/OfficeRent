using Microsoft.EntityFrameworkCore;
using OfficeRent.Api.Models.Office;

namespace OfficeRent.Api.Database
{
	public class OfficeDbContext : DbContext
	{
		public DbSet<Office> Offices { get; set; } = null!;
	}
}