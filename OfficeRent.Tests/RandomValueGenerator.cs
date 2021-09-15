using System;

namespace OfficeRent.Tests
{
	public static class RandomValueGenerator
	{
		private static readonly Random Random = new();

		public static string GetRandomString()
		{
			return $"Rnd{Random.Next(0, 100)}";
		}

		public static short GetRandomShort()
		{
			return (short)Random.Next(short.MinValue, short.MaxValue);
		}
	}
}