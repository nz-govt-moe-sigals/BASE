using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Infrastructure.ExtensionMethods
{
    public static class Enumerations
    {
        public static string GetEnumDescription(Enum value)
        {
            return value.GetDescription();
        }

        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            return value.ToString();
        }

        public static string GetName(this Enum value)
        {
            return nameof(value);
        }
    }
}
