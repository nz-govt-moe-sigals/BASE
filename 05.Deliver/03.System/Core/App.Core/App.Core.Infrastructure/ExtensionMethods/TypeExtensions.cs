// Extensions are always put in root namespace
// for maximum usability from elsewhere:

namespace App
{
    using System;
    using System.Reflection;
    using App.Core.Shared.Attributes;

    public static class TypeExtensions
    {
        public static bool IsSameOrSubclassOf(this Type potentialDescendant, Type potentialBase)
        {
            return potentialDescendant.IsSubclassOf(potentialBase)
                   || potentialDescendant == potentialBase;
        }

        public static object GetDefaultValue(this Type t)
        {
            return t.IsValueType ? Activator.CreateInstance(t) : null;
        }


        public static string GetName(this Type type, bool inherit = false)
        {
            // Use aliases first, as they can be richer, if there are any:
            var aliasAttribute = type.GetCustomAttribute<KeyAttribute>(inherit);

            return aliasAttribute?.Key;
        }
    }
}