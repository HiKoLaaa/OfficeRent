using Npgsql.NameTranslation;

namespace OfficeRent.Api.Database
{
	internal static class PostgreConventionExtensions
	{
		public static string ToSnakeCase(this string value)
		{
			return NpgsqlSnakeCaseNameTranslator.ConvertToSnakeCase(value);
		}
	}
}