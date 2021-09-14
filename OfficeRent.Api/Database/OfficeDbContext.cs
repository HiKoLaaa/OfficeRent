using Microsoft.EntityFrameworkCore;
using OfficeRent.Api.Database.Configurations;
using OfficeRent.Api.Models.Office;
using static EfSnakeCase.Core;

namespace OfficeRent.Api.Database
{
	internal sealed class OfficeDbContext : DbContext
	{
		public DbSet<Office> Offices { get; set; } = null!;

		public OfficeDbContext(DbContextOptions<OfficeDbContext> options)
			: base(options)
		{
		}
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.UseSerialColumns();

			modelBuilder.ApplyConfiguration(new OfficeConfiguration());

			ToSnakeCase(modelBuilder);
		}
	}
}