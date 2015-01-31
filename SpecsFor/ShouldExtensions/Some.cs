﻿using System;
using System.Linq.Expressions;

namespace SpecsFor.ShouldExtensions
{
	public static class Some
	{
		public static T ValueOf<T>(Expression<Func<T, bool>> matcher)
		{
			Matcher.Create(matcher, "Object matching " + matcher.Body);

			return default(T);
		}

		public static T ValueInRange<T>(T min, T max) where T : IComparable
		{
			return ValueInRange(min, max, true);
		}

		public static T ValueInRange<T>(T min, T max, bool inclusive) where T: IComparable
		{
			if (inclusive)
			{
				var message = string.Format("Object greater than or equal to {0} and less than or equal to {1}", min, max);
				Matcher.Create<T>(x => x.CompareTo(min) >= 0 && x.CompareTo(max) <= 0, message);
			}
			else
			{
				var message = string.Format("Object greater than {0} and less than {1}", min, max);
				Matcher.Create<T>(x => x.CompareTo(min) > 0 && x.CompareTo(max) < 0, message);				
			}

			return default(T);
		}
	}
}