namespace App.Core.Infrastructure.Services.Implementations
{
    using System;
    using System.ComponentModel;
    using System.Configuration;
    using App.Core.Infrastructure.Factories;
    using Microsoft.Azure;


    /// <summary>
    /// Implementation of a Service Contract to
    /// manage Host specific, immutable Settings
    /// (commonly this wraps web.config, etc. settings
    /// that were injected at deployment time by the 
    /// Build Engine).
    /// <para>
    /// Work in Progress:
    /// Note that because of HostSettings being 
    /// AppSettings based when developing on-prem,
    /// and slightly layered when in the cloud, 
    /// actual readding of settings is externalized
    /// using <see cref="ExtendedConfigurationFactory"/>
    /// </para>
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.IHostSettingsService" />
    public class HostSettingsService : IHostSettingsService
    {

        private readonly ExtendedConfigurationFactory _configurationFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="HostSettingsService"/> class.
        /// </summary>
        /// <param name="configurationFactory">The configuration factory.</param>
        public HostSettingsService(ExtendedConfigurationFactory configurationFactory)
        {
            this._configurationFactory = configurationFactory;
        }

        /// <summary>
        /// Return a single Host Setting, typed.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public T Get<T>(string key, T defaultValue)
        {
            var result = ConvertTypesSafely(GetAppSetting(key), defaultValue);

            return result;
        }

        /// <summary>
        /// Create a Configuration object and fill properties from Host Settings with the same name.
        /// <para>
        /// Note that default values are not provided if the property value = default(T)
        /// </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public T GetObject<T>(string prefix = null) where T : class
        {
            // Build a unique Key to see if the object has already been created
            // and stored in cache.
            var key = typeof(T).FullName + ":" + prefix;

            if (ConfigurationObjectCache.ObjectCache.ContainsKey(key))
            {
                return (T)ConfigurationObjectCache.ObjectCache[key];
            }

            // If not, use the ConfigFactory helper,
            // create the new obj, cache, and return:
            var result = this._configurationFactory.Create<T>(prefix);
            ConfigurationObjectCache.ObjectCache[key] = result;

            return result;
        }

        /// <summary>
        /// Converts the types safely.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s">The s.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        private T ConvertTypesSafely<T>(string s, T defaultValue)
        {
            if (string.IsNullOrEmpty(s))
            {
                return defaultValue;
            }

            return (T) Convert.ChangeType(s, typeof(T));

            //var typeConverter = TypeDescriptor.GetConverter(typeof(T));

            //var typedValue =
            //    typeConverter
            //        .ConvertFromString(
            //            s) as T;

            //return typedValue;
        }

        private string GetAppSetting(string key)
        {
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