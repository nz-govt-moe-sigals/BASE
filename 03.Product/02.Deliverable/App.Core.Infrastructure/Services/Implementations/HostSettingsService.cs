namespace App.Core.Infrastructure.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using App.Core.Infrastructure.Factories;

    public class HostSettingsService : IHostSettingsService
    {
        public static Dictionary<string, object> _cache = new Dictionary<string, object>();

        public T Get<T>(string key, T defaultValue)
        {
            return SafeConvert(ConfigurationManager.AppSettings[key], defaultValue);
        }

        public T GetObject<T>(string prefix = null) where T : class
        {
            var key = typeof(T).FullName + ":" + prefix;
            if (_cache.ContainsKey(key))
            {
                return (T) _cache[key];
            }

            var result = ConfigurationFactory.Create<T>(prefix);
            _cache[key] = result;
            return result;
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