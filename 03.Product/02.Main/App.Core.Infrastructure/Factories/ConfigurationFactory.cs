namespace App.Core.Infrastructure.Factories
{
    using System;
    using System.ComponentModel;
    using System.Configuration;
    using System.Linq;
    using System.Reflection;
    using App.Core.Shared.Attributes;

    public static class ConfigurationFactory
    {
        public static T Create<T>(string prefix = null) where T : class
        {
            var target = Activator.CreateInstance<T>();

            foreach (var propertyInfo in typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public |
                                                                 BindingFlags.IgnoreCase))
            {
                var aliasAttribute = propertyInfo.GetCustomAttribute<AliasAttribute>();
                var hostKey = propertyInfo.Name;

                if (aliasAttribute != null)
                {
                    hostKey = aliasAttribute.DisplayName;
                }

                if (string.IsNullOrEmpty(hostKey))
                {
                    hostKey = propertyInfo.Name;
                }

                var set = false;
                string s = null;
                if (!string.IsNullOrEmpty(prefix))
                {
                    var tmp = prefix + hostKey;
                    if (ConfigurationManager.AppSettings.AllKeys.Contains(tmp,
                        StringComparer.InvariantCultureIgnoreCase))
                    {
                        s = ConfigurationManager.AppSettings[tmp];
                        set = true;
                    }
                }
                if (!set)
                {
                    var tmp = hostKey;
                    if (ConfigurationManager.AppSettings.AllKeys.Contains(tmp,
                        StringComparer.InvariantCultureIgnoreCase))
                    {
                        s = ConfigurationManager.AppSettings[tmp];
                    }
                }

                if (s == null)
                {
                    continue;
                }
                var typeConverter = TypeDescriptor.GetConverter(propertyInfo.PropertyType);

                var typedValue =
                    typeConverter
                        .ConvertFromString(
                            s);
                propertyInfo.SetValue(target, typedValue);
            }
            return target;
        }


        private static T SafeConvert<T>(string s, T defaultValue)
        {
            if (string.IsNullOrEmpty(s))
            {
                return defaultValue;
            }
            return (T) Convert.ChangeType(s, typeof(T));
        }
    }
}