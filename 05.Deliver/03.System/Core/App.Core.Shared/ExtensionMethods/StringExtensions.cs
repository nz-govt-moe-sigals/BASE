using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public static class StringExtensions
    {
            public static bool Contains(this string text, string value,
                StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
            {
                return text.IndexOf(value, stringComparison) >= 0;
            }
    }
}
