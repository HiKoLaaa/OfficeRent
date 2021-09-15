using System;
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

	    public void Setup()
		{
			ConfigureServiceCollection(_serviceCollection);
		}

		protected virtual void ConfigureServiceCollection(IServiceCollection serviceCollection)
		{
			serviceCollection.AddDbContext<TestDbContext>();
			serviceCollection.AddTransient<IOfficeRepository, OfficeRepository>();
		}
	}
}