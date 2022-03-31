using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Squazz.Sugar
{
    public static class EnumerableOfTExtensions
    {

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
            {
                return true;
            }
            /* If this is a list, use the Count property for efficiency. 
             * The Count property is O(1) while IEnumerable.Count() is O(N). */
            var collection = enumerable as ICollection<T>;
            if (collection != null)
            {
                return collection.Count < 1;
            }

            return !enumerable.Any();
        }

        public static Task<T[]> WhenAll<T>(this IEnumerable<Task<T>> source)
        {
            return Task.WhenAll(source);
        }

        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> value)
        {
            return value ?? Enumerable.Empty<T>();
        }

        public static IEnumerable<T> NullIfEmpty<T>(this IEnumerable<T> value)
        {
            // ReSharper disable PossibleMultipleEnumeration
            return IsNullOrEmpty(value) ? null : value;
            // ReSharper enable PossibleMultipleEnumeration
        }

        public static IEnumerable<T> Distinct<T, TValue>(this IEnumerable<T> source, Func<T, TValue> keySelector, IEqualityComparer<TValue> comparer)
        {
            return source.Distinct(comparer.ByProperty(keySelector));
        }
    }
}
