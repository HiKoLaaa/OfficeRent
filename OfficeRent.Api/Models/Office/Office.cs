namespace OfficeRent.Api.Models.Office
{
	public class Office
	{
		public int Id { get; private set; }

		public string Name { get; }

		public Address Address { get; }

		public byte Floor { get; }

		public Office(string name, Address address, byte floor)
		{
			Name = name;
			Address = address;
			Floor = floor;
		}
	}
}