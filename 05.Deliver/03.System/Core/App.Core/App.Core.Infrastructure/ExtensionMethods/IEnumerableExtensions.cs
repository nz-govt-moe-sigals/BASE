// Extensions are always put in root namespace
// for maximum usability from elsewhere:

namespace App
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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



        public static T[] SortByOrderByAttribute<T>(this IEnumerable<T> data)
        {
            var tmp = new List<T>();
            foreach (var o in data)
            {
                OrderByAttribute attribute = (o).GetType().GetCustomAttributes(typeof(OrderByAttribute), false).FirstOrDefault() as OrderByAttribute;

                bool found = false;
                if ((attribute != null) && (!string.IsNullOrWhiteSpace(attribute.After)))
                {
                    for (var i = 0; i < tmp.Count; i++)
                    {
                        var x = tmp[i];
                        var t = x.GetType();
                        OrderByAttribute a = t.GetCustomAttributes(typeof(OrderByAttribute), false).FirstOrDefault() as OrderByAttribute;
                        var key = a?.Key;
                        if (string.IsNullOrEmpty(key)) { key = t.Name; }
                        if (string.Compare(key, attribute.After, true) == 0)
                        {
                            tmp.Insert(i, o);
                            found = true;
                            break;
                        }
                    }
                }
                // Was not found, so add at end:
                if (found)
                {
                    continue;
                }
                tmp.Add(o);
            }
            var results = tmp.ToArray();

            return results;

        }

    }
}