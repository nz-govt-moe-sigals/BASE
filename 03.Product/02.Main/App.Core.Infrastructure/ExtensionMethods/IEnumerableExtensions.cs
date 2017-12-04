// Extensions are always put in root namespace
// for maximum usability from elsewhere:

namespace App
{
    using System;
    using System.Collections.Generic;

    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            if (list == null || action == null)
            {
                return;
            }
            foreach (var obj in list)
            {
                action(obj);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> list, Action<T, int> action)
        {
            if (list == null || action == null)
            {
                return;
            }
            var num = 0;
            foreach (var obj in list)
            {
                action(obj, num);
                ++num;
            }
        }
    }
}