using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    using System.Reflection;
    using App.Core.Shared.Attributes;

    public static class PropertyInfoExtensions
    {

        public static string GetAlias(this PropertyInfo propertyInfo)
        {

            // Use aliases first, as they can be richer, if there are any:
            var aliasAttribute = propertyInfo.GetCustomAttribute<AliasAttribute>();

            if (aliasAttribute != null)
            {
                return aliasAttribute.DisplayName;
            }
            return null;
        }
    }
}
