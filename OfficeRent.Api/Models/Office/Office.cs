namespace OfficeRent.Api.Models.Office
{
	public class Office
	{
		public int Id { get; private set; }

		public string Name { get; }

		public Address Address { get; }

		public short Floor { get; }

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