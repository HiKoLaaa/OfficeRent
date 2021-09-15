using System.Threading;
using Microsoft.EntityFrameworkCore;
using OfficeRent.Api.Database;

namespace OfficeRent.Tests.Database
{
	internal sealed class TestDbContext : DbContext
	{
		private static int _databaseNumber = 1;

		public OfficeDbContext DbContext { get; }

		public TestDbContext()
		{
			var options = new DbContextOptionsBuilder<OfficeDbContext>()
				.UseInMemoryDatabase(databaseName: $"InMemory{_databaseNumber}")
				.Options;

			Interlocked.Increment(ref _databaseNumber);

			DbContext = new OfficeDbContext(options);
		}
	}
}