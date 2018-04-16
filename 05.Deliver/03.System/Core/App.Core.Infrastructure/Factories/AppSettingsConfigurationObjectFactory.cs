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
    /// A Factory to create a Configuration object 
    /// and provision it from Host Settings (ie AppSettings)
    /// with keys that match the names of the properties
    /// or <see cref="AliasAttribute"/> they have been decorated with.
    /// <para>
    /// Invoked from within <see cref="IHostSettingsService"/>.
    /// </para>
    /// <para>
    /// It's much more maintainable and practical
    /// to work with configuration objects
    /// of multiple related properties than multiple
    /// configuration values 'flying in close formation'.
    /// And they are also cachable, for better performance.
    /// </para>
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
    /// </summary>
    public class AppSettingsConfigurationObjectFactory
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly bool _useAppSettingsOnly;


        /// <summary>
        /// Initializes a new instance of the <see cref="AppSettingsConfigurationObjectFactory"/> class.
        /// </summary>
        /// <param name="diagnosticsTracingService"></param>
        public AppSettingsConfigurationObjectFactory(IDiagnosticsTracingService diagnosticsTracingService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
            this._useAppSettingsOnly = true;
        }


        /// <summary>
        /// Instantiates a new blank target object, 
        /// then <see cref="Provision{T}"/>'s it's properties
        /// from host settings (ie AppSettings)
        /// with keys match the property's name, or any <see cref="AliasAttribute"/>
        /// the property has been decorated with.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="prefix">The prefix.</param>
        /// <returns></returns>
        public virtual T Create<T>(string prefix = null) where T : class
        {
            var target = Activator.CreateInstance<T>();
            return Provision(target, prefix);
        }

        /// <summary>
        /// Provisions the specified target object's properties
        /// from host settings (ie AppSettings)
        /// with keys match the property's name, or any <see cref="AliasAttribute"/>
        /// the property has been decorated with.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">The target object .</param>
        /// <param name="prefix">The prefix.</param>
        /// <returns></returns>
        public virtual T Provision<T>(T target, string prefix = null) where T : class
        {
            var objectName = target.GetType().Name;
            var validSources = new[]
                {ConfigurationSettingSource.SourceType.All, ConfigurationSettingSource.SourceType.AppSetting};
                
            // Iterate over the public properties of the target object
            // using the property's name, o
            foreach (var propertyInfo in typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public |
                                                                 BindingFlags.IgnoreCase))
            {
                var hostKey = propertyInfo.Name;


                // Determine if we should look for this value here:
                var sourceAttribute = propertyInfo.GetCustomAttribute<ConfigurationSettingSource>();
                if (sourceAttribute != null)
                {
                    if (!validSources.Any(x => x == sourceAttribute.Source))
                    {
                        continue;
                    }
                }


                // Use aliases first, as they can be richer, if there are any:
                var aliasAttribute = propertyInfo.GetCustomAttribute<AliasAttribute>();

                if (aliasAttribute != null)
                {
                    hostKey = aliasAttribute.DisplayName;
                }

                // Falling back to the property's name
                if (string.IsNullOrEmpty(hostKey))
                {
                    hostKey = propertyInfo.Name;
                }

                // If given a prefix as an argument
                // see if there is a property with the prefix:
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
                // If not set/not found, work with just the key
                // without prefix:
                if (!set)
                {
                    var tmp = hostKey;
                    if (DoesKeyExist(tmp))
                    {
                        s = GetAppSetting(tmp);
                    }
                }

                // Set the typed value from th string
                // to the target property:
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

            }//~ iterate to the next property

            return target;
        }




        ///// <summary>
        ///// Converts the AppSetting (string) value to the 
        ///// target property type.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="s">The s.</param>
        ///// <param name="defaultValue">The default value.</param>
        ///// <returns></returns>
        // protected T SafeConvert<T>(string s, T defaultValue)
        //{
        //    if (string.IsNullOrEmpty(s))
        //    {
        //        return defaultValue;
        //    }
        //    return (T)Convert.ChangeType(s, typeof(T));
        //}

        /// <summary>
        /// Helper method to verify if the requested property
        /// exists within the Host Device's AppSettings.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        protected virtual bool DoesKeyExist(string key)
        {
            if (this._useAppSettingsOnly)
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


        /// <summary>
        /// Helper method to gets the application setting (as a string, 
        /// to be subseqently Typed).
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        protected string GetAppSetting(string key)
        {
            if (this._useAppSettingsOnly)
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
