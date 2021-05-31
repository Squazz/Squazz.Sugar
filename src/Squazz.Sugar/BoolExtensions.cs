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
    }
}
