using System;
using System.Collections.Generic;

namespace Squazz.Sugar
{
    public static class IntExtensions
    {
        public static int IndexOf<T>(this IEnumerable<T> list, Predicate<T> predicate)
        {
            int num = 0;
            foreach (T obj in list)
            {
                if (predicate(obj))
                    return num;
                ++num;
            }
            return -1;
        }
    }
}
