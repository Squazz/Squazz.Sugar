using System.Collections.Generic;
using System.Linq;

namespace Squazz.Sugar
{
    public static class SplitIEnumerableExtension
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this List<T> list, int chunkSize)
        {
            if (!list.Any())
                yield break;
            int me = -chunkSize;
            int max = list.Count() - chunkSize;
            while (max >= me)
            {
                me += chunkSize;
                yield return list.Skip(me).Take(chunkSize);
            }
        }
    }
}
