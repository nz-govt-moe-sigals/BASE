namespace App.Core.Infrastructure.Factories
{
    using System;
    using System.ComponentModel;
    using System.Configuration;
    using System.Linq;
    using System.Reflection;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Attributes;
    using Microsoft.Azure;
    /// <summary>
    /// WORK IN PROGRESS.
    /// <para>
    /// When working on prem, Configuration settings
    /// are sourced directly from AppSettings using
    /// ConfigurationManager.
    /// When deployed to cloud, there's
    /// CloudConfigurationManager to handle a more layered
    /// approach. At least, that's the theory (if it worked).
    /// Rather than leave it in <see cref="IHostSettingsService"/>
    /// the access logic is externalized to this class.
    /// </para>
    /// This might be overkill...(and it doesn't work for now).
    /// On 
    /// <para>
    /// Inherited by <see cref="ExtendedConfigurationFactory"/>.
    /// </para>
    /// </summary>
    public class ConfigurationFactory
    {
        private readonly bool _useAppSettingsOnly;


        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationFactory"/> class.
        /// </summary>
        /// <param name="useAppSettingsOnly">if set to <c>true</c> [use application settings only].</param>
        public ConfigurationFactory(bool useAppSettingsOnly)
        {
            this._useAppSettingsOnly = useAppSettingsOnly;
        }


        /// <summary>
        /// Creates the specified prefix.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="prefix">The prefix.</param>
        /// <returns></returns>
        public virtual T Create<T>(string prefix = null) where T : class
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
                    if (DoesKeyExist(tmp))
                    {
                        s = GetAppSetting(tmp);
                        set = true;
                    }
                }
                if (!set)
                {
                    var tmp = hostKey;
                    if (DoesKeyExist(tmp))
                    {
                        s = GetAppSetting(tmp);
                    }
                }

                //Set the typed value from th string:
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


        protected T SafeConvert<T>(string s, T defaultValue)
        {
            if (string.IsNullOrEmpty(s))
            {
                return defaultValue;
            }
            return (T) Convert.ChangeType(s, typeof(T));
        }

        protected virtual bool DoesKeyExist(string key)
        {
            if (_useAppSettingsOnly)
            {
                return (ConfigurationManager.AppSettings.AllKeys.Contains(key,
                    StringComparer.InvariantCultureIgnoreCase));
            }

            bool result;
            try
            {
                CloudConfigurationManager.GetSetting(key, false, true);
                result = true;
            }
            catch
            {
                //Ok. So the Azure Wrapper is not smart enough to handle old-school 
                // appSettings@File attribute...so try again before giving up:
                result = ConfigurationManager.AppSettings.AllKeys.Contains(key,
                    StringComparer.InvariantCultureIgnoreCase);
            }
            return result;
        }

        protected string GetAppSetting(string key)
        {
            if (_useAppSettingsOnly)
            {
                return ConfigurationManager.AppSettings[key];
            }
            string result;
            try
            {
                result = CloudConfigurationManager.GetSetting(key, false, true);
            }
            catch
            {
                //Ok. So the Azure Wrapper is not smart enough to handle old-school 
                // appSettings@File attribute...so try again before giving up:
                result = ConfigurationManager.AppSettings[key];
            }
            return result;
        }

    }

}
    