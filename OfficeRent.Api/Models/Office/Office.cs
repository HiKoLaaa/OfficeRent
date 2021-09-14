namespace OfficeRent.Api.Models.Office
{
	public class Office
	{
		public int Id { get; private set; }

		public string Name { get; private set; }

		public Address Address { get; private set; }

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