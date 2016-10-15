using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;

namespace TitiusLabs.Core
{
	public static class Extensions
	{
		public static double TryParseDouble(this string text)
		{
			double result;
			if (double.TryParse(text, out result))
				return result;
			return -1;
		}

		public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
		{
			foreach (var item in items)
			{
				action(item);
			}
		}

		public static IEnumerable<T> Union<T>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, T, bool> comparer, Func<T, T, T> eval)
		{
			foreach (var item in first)
			{
				var secondItem = second.FirstOrDefault((c) => comparer(item, c));
				yield return eval(item, secondItem);
			}

			foreach (var item in second.Where(s => !first.Any(f => comparer(s, f))))
			{
				yield return item;
			}
		}

		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
		{
			return source.Shuffle(new Random());
		}

		public static IEnumerable<T> Shuffle<T>(
			this IEnumerable<T> source, Random rng)
		{
			if (source == null) throw new ArgumentNullException("source");
			if (rng == null) throw new ArgumentNullException("rng");

			return source.ShuffleIterator(rng);
		}

		private static IEnumerable<T> ShuffleIterator<T>(
			this IEnumerable<T> source, Random rng)
		{
			var buffer = source.ToList();
			for (int i = 0; i < buffer.Count; i++)
			{
				int j = rng.Next(i, buffer.Count);
				yield return buffer[j];

				buffer[j] = buffer[i];
			}
		}

		public static T NextTo<T>(this IEnumerable<T> source, T item)
		{
			bool founded = false;
			foreach (var current in source)
			{
				if (current == null)
					continue;
				if (founded)
					return current;
				if (current.Equals(item))
					founded = true;	
			}

			return default(T);
		}

		public static ObservableCollection<T> ToObservable<T>(this IEnumerable<T> items)
		{
			return new ObservableCollection<T>(items);
		}

		public static DateTime ToDateTime(this string dateTimeString)
		{
			DateTime dt;
			if (!DateTime.TryParse(dateTimeString ?? "", out dt))
			{
				dt = DateTime.MinValue;
			}
			return dt;
		}
	}
}
