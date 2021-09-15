using Microsoft.EntityFrameworkCore;
using OfficeRent.Api.Database;

namespace OfficeRent.Tests.Database
{
	internal sealed class TestDbContext : DbContext
	{
		public OfficeDbContext DbContext { get; }

		public TestDbContext()
		{
			var options = new DbContextOptionsBuilder<OfficeDbContext>()
				.UseInMemoryDatabase(databaseName: "InMemory")
				.Options;

			DbContext = new OfficeDbContext(options);
		}
	}
}