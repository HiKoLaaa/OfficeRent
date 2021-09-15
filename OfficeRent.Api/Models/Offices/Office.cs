namespace OfficeRent.Api.Models.Offices
{
	public class Office
	{
		public int Id { get; private set; }

		public string Name { get; private set; } = null!;

		public Address Address { get; private set; } = null!;

		public short Floor { get; private set; }

		public Office(string name, Address address, short floor)
		{
			Name = name;
			Address = address;
			Floor = floor;
		}

		public void ChangeName(string name)
		{
			Name = name;
		}

		public void ChangeAddress(Address address)
		{
			Address = address;
		}

		public void ChangeFloor(short floor)
		{
			Floor = floor;
		}

		private Office()
		{
		}
	}
}