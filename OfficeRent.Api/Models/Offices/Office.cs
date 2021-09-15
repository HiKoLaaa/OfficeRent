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

		private Office()
		{
		}
	}
}