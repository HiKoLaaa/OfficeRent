using Castle.Core.Internal;
using OfficeRent.Api.Models.Offices;

namespace OfficeRent.Tests.Database.TestBuilders.Offices
{
	public class OfficeTestBuilder : TestBuilderBase<Office>
	{
		private string? _name;

		private Address? _address;

		private short? _floor;

		public OfficeTestBuilder WithName(string name)
		{
			_name = name;
			return this;
		}

		public OfficeTestBuilder WithAddress(Address address)
		{
			_address = address;
			return this;
		}

		public OfficeTestBuilder WithFloor(short floor)
		{
			_floor = floor;
			return this;
		}

		public override Office Build()
		{
			if (_name.IsNullOrEmpty())
			{
				_name = RandomValueGenerator.GetRandomString();
			}

			_address ??= new AddressTestBuilder().Build();

			_floor ??= RandomValueGenerator.GetRandomShort();

			return new Office(_name!, _address, _floor.Value);
		}
	}
}