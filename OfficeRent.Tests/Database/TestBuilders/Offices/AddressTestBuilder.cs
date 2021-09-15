using Castle.Core.Internal;
using OfficeRent.Api.Models.Offices;

namespace OfficeRent.Tests.Database.TestBuilders.Offices
{
	public class AddressTestBuilder : TestBuilderBase<Address>
	{
		private string? _city;

		private string? _street;

		private string? _streetNumber;

		public AddressTestBuilder WithCity(string city)
		{
			_city = city;
			return this;
		}

		public AddressTestBuilder WithStreet(string street)
		{
			_street = street;
			return this;
		}

		public AddressTestBuilder WithStreetNumber(string streetNumber)
		{
			_streetNumber = streetNumber;
			return this;
		}

		public override Address Build()
		{
			if (_city.IsNullOrEmpty())
			{
				_city = RandomValueGenerator.GetRandomString();
			}

			if (_street.IsNullOrEmpty())
			{
				_street = RandomValueGenerator.GetRandomString();
			}

			if (_streetNumber.IsNullOrEmpty())
			{
				_streetNumber = RandomValueGenerator.GetRandomString();
			}

			return new Address(_city!, _street!, _streetNumber!);
		}
	}
}