using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OfficeRent.Api.Database
{
	internal static class ConventionExtensions
	{
		public static KeyBuilder SetPkName(this KeyBuilder keyBuilder, string primaryKeyColumn)
		{
			keyBuilder.HasName($"pk_{primaryKeyColumn}");

			return keyBuilder;
		}
	}
}