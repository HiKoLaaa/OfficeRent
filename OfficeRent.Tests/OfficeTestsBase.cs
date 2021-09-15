using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OfficeRent.Api.Database;
using OfficeRent.Api.Database.Abstractions;
using OfficeRent.Tests.Database;

namespace OfficeRent.Tests
{
	public abstract class OfficeTestsBase
	{
		private IServiceProvider? _serviceProvider;

		protected IServiceProvider ServiceProvider =>
			_serviceProvider ??= _serviceCollection.BuildServiceProvider();

		private readonly IServiceCollection _serviceCollection;

	 	internal OfficeDbContext Database => ServiceProvider.GetRequiredService<TestDbContext>().DbContext;

	    protected OfficeTestsBase()
	    {
		    _serviceCollection = new ServiceCollection();
	    }

	    [SetUp]
		public void Setup()
		{
			ConfigureServiceCollection(_serviceCollection);
		}

		[TearDown]
		public void CleanUp()
		{
			_serviceProvider = null;
			_serviceCollection.Clear();
		}

		protected virtual void ConfigureServiceCollection(IServiceCollection serviceCollection)
		{
			serviceCollection.AddDbContext<TestDbContext>();
			serviceCollection.AddTransient<IOfficeRepository, OfficeRepository>(_ => new OfficeRepository(Database));
		}

		protected async Task AddEntityToDbAsync<TEntity>(TEntity entity) where TEntity : class
		{
			await Database.AddAsync(entity);
			await SaveChangesAsync();
		}

		protected async Task AddEntitiesToDbAsync<TEntity>(params TEntity[] entities) where TEntity : class
		{
			await Database.AddRangeAsync(entities);
			await SaveChangesAsync();
		}

		private async Task SaveChangesAsync() => await Database.SaveChangesAsync();
	}
}