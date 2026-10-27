using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Symbion {
	public static class Guard {
		public const string CannotBeNull = "{0} cannot be null.";
		public const string CannotBeEmpty = "{0} cannot be empty.";
		public const string OutOfRange = "{0} is must be between {1} and {2}.";
		public const string IsNotValid = "{0} is not valid.";

		public static void NotNull(this object value, string name) {
			if (value == null) throw new Exception(string.Format(
				CannotBeNull, name));
		}
		public static void NotNullOrEmpty(this string value, string name) {
			NotNull(value, name);
			if (value.Length == 0) throw new Exception(
				string.Format(CannotBeEmpty, name));
		}
		public static void InRange(this int value,
		string name, int minValue, int maxValue) {
			if (value < minValue || value > maxValue) throw new Exception(
				string.Format(OutOfRange, name, minValue, maxValue));
		}
		public static void InRange(this double value, string name, double minValue, double maxValue) {
			if (value < minValue || value > maxValue)
				throw new Exception(string.Format(
					OutOfRange, name, minValue, maxValue));
		}
		public static void InRange(this decimal value, string name, decimal minValue, decimal maxValue) {
			if (value < minValue || value > maxValue)
				throw new Exception(string.Format(
					OutOfRange, name, minValue, maxValue));
		}
		public static void Exists<T>(this T value, string name, ICollection<T> collection) {
			if (!collection.Contains(value))
				throw new Exception(string.Format(
					IsNotValid, name));
		}
		public static void Exists<T>(this T value, string name, params T[] array) {
			int count = array.Length;
			for (int index = 0; index < count; index++)
				if (array[index].Equals(value)) return;
			throw new Exception(string.Format(
				IsNotValid, name));

		}
		public static void Matches(this string value, string name, string pattern) {
			if (!new Regex(pattern).IsMatch(value))
				throw new Exception(string.Format(
					IsNotValid, name));

		}
	}
}
