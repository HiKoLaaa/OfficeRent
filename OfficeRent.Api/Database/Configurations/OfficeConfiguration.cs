using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfficeRent.Api.Models.Offices;

namespace OfficeRent.Api.Database.Configurations
{
	internal sealed class OfficeConfiguration : IEntityTypeConfiguration<Office>
	{
		public void Configure(EntityTypeBuilder<Office> builder)
		{
			builder.HasKey(office => office.Id);
			builder.Property(office => office.Name).IsRequired().HasColumnType("varchar(100)");

			builder
				.OwnsOne(office => office.Address, address =>
				{
					address
						.Property(a => a.City)
						.IsRequired()
						.HasColumnType("varchar(70)")
						.HasColumnName(nameof(Address.City).ToSnakeCase());

					address
						.Property(a => a.Street)
						.IsRequired()
						.HasColumnType("varchar(70)")
						.HasColumnName(nameof(Address.Street).ToSnakeCase());

					address
						.Property(a => a.StreetNumber)
						.IsRequired()
						.HasColumnType("varchar(10)")
						.HasColumnName(nameof(Address.StreetNumber).ToSnakeCase());

				})
				.Navigation(office => office.Address)
				.IsRequired();

			builder
				.Property(a => a.Floor)
				.IsRequired()
				.HasColumnType("smallint");
		}
	}
}