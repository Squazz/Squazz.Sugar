using System;
using System.Collections.Generic;
using System.Linq;

namespace Squazz.Sugar
{
    public static class EqualityComparerOfTExtensions
    {
        public static IEqualityComparer<T> ByProperty<T, TValue>(this IEqualityComparer<TValue> baseComparer, Func<T, TValue> extractor)
        {
            return new PropertyBasedEqualityComparer<T, TValue>(baseComparer, extractor);
        }

        private struct PropertyBasedEqualityComparer<T, TValue> : IEqualityComparer<T>
        {
            private readonly IEqualityComparer<TValue> _baseComparer;
            private readonly Func<T, TValue> _extractor;

            public PropertyBasedEqualityComparer(IEqualityComparer<TValue> baseComparer, Func<T, TValue> extractor)
            {
                _baseComparer = baseComparer;
                _extractor = extractor;
            }
            public bool Equals(T x, T y)
            {
                return _baseComparer.Equals(_extractor(x), _extractor(y));
            }

            public int GetHashCode(T obj)
            {
                return _baseComparer.GetHashCode(_extractor(obj));
            }
        }

        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> items, int maxItems)
        {
            return items.Select((item, inx) => new { item, inx })
                .GroupBy(x => x.inx / maxItems)
                .Select(g => g.Select(x => x.item));
        }
    }
}
