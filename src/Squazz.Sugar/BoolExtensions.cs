using System;
using System.Collections.Generic;
using System.Linq;

namespace Squazz.Sugar
{
    public static class BoolExtensions
    {
        public static bool None<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return !source.Any();
        }

        public static bool CountIsAtLeast<TSource>(this IEnumerable<TSource> source, int count)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Skip(count - 1).Any();
        }

        public static bool CountIsExactly<TSource>(this IEnumerable<TSource> source, int count)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var enumerable = source.ToArray();
            return enumerable.CountIsAtLeast(count) && enumerable.Skip(count).None();
        }
    }
}
