namespace App.Core.Infrastructure.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Configuration;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Attributes;
    using App.Core.Shared.Models.Entities;
    using Microsoft.Azure;



    /// <summary>
    /// A Factory to create a Configuration object 
    /// and provision it from Key Vault Secrets
    /// with keys that match the names of the properties
    /// or <see cref="AliasAttribute"/> they have been decorated with.
    /// <para>
    /// Used by the implementation of <see cref="IAzureKeyVaultService"/>.
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
    public class KeyVaultConfigurationObjectFactory
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly IAzureKeyVaultService _keyVaultService;


        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultConfigurationObjectFactory" /> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="keyVaultService">The key vault service.</param>
        public KeyVaultConfigurationObjectFactory(IDiagnosticsTracingService diagnosticsTracingService, IAzureKeyVaultService keyVaultService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
            this._keyVaultService = keyVaultService;

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
        public virtual T Provision<T>(T target, string prefix = null, bool skipIfAlreadyHasValue=true) where T : class
        {
            
            var objectType = target.GetType();

            var validSources = new[]
                {ConfigurationSettingSource.SourceType.Any, ConfigurationSettingSource.SourceType.KeyVault};

            
            // Iterate over the public properties of the target object
            // using the property's name, o
            foreach (var propertyInfo in typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public |
                                                                 BindingFlags.IgnoreCase))
            {



                var hostKey = propertyInfo.Name;

                
                // Determine if we should look for this value here:
                var sourceAttribute = propertyInfo.GetCustomAttribute<ConfigurationSettingSource>();

                if (sourceAttribute == null)
                {
                    var o = propertyInfo.GetValue(target, null);
                    if ((!o.IsDefault()) && (skipIfAlreadyHasValue))
                    {
                        //Already set, move on to next property.
                        this._diagnosticsTracingService.Trace(TraceLevel.Verbose,
                            $"Setting {objectType}.{propertyInfo.Name} is already set via AppHost. Skipping setting it by KeyVault.");
                        continue;
                    }
                }
                else
                {
                    switch (sourceAttribute.Source)
                    {
                        case ConfigurationSettingSource.SourceType.AppSetting:
                            //For sure it was suppossed to not be set here:
                            continue;
                        case ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline:
                            //For sure it was suppossed to not be set here:
                            continue;
                        case ConfigurationSettingSource.SourceType.Any:
                            var o = propertyInfo.GetValue(target, null);
                            if ((!o.IsDefault()) && (skipIfAlreadyHasValue))
                            {
                                //Already set, move on to next property.
                                this._diagnosticsTracingService.Trace(TraceLevel.Verbose,
                                    $"Setting {objectType}.{propertyInfo.Name} is already set via AppHost. Skipping setting it by KeyVault.");
                                continue;
                            }
                            break;
                        case ConfigurationSettingSource.SourceType.KeyVault:
                            //For sure it was suppossed to be obtained here:
                            break;
                        default:
                            break;
                    }
                }


                // Use aliases first, as they can be richer, if there are any:
                var alias = propertyInfo.GetAlias();

                if (alias != null)
                {
                    hostKey = alias;
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
                    try
                    {
                        // OffLoad the getting of the Key
                        s = GetAppSetting(tmp);
                        set = true;
                    }
                    catch
                    {
                        // key does not exist.
                    }
                }
                // If not set/not found, work with just the key
                // without prefix:
                if (!set)
                {
                    var tmp = hostKey;
                    try
                    {
                        // OffLoad the getting of the Key
                        s = GetAppSetting(tmp);
                        set = true;
                    }
                    catch
                    {
                        //key does not exist.
                    }
                }

                if (set)
                {
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
                }
            }//~ iterate to the next property

            return target;
        }





        /// <summary>
        /// Helper method to gets the application setting (as a string, 
        /// to be subseqently Typed).
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        protected string GetAppSetting(string key)
        {
            // No longer needed -- done within KeyVaultService:
            //var key = this._keyVaultService.CleanKeyName(key);

            try
            {
                var result = this._keyVaultService.RetrieveSecretAsync(key).Result;
                return result;
            }
            catch (AggregateException e)
            {
                this._diagnosticsTracingService.Trace(TraceLevel.Info, $"Did not find an KeyVault Secret with id '{key}'.");
                this._diagnosticsTracingService.Trace(TraceLevel.Debug, e.Message);
                this._diagnosticsTracingService.Trace(TraceLevel.Debug, e.StackTrace);
                
                if (e.InnerExceptions != null)
                {
                    foreach (var ex in e.InnerExceptions)
                    {
                        this._diagnosticsTracingService.Trace(TraceLevel.Debug, ex.Message);
                        this._diagnosticsTracingService.Trace(TraceLevel.Debug, ex.StackTrace);
                    }
                    
                }
                throw;
            }
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

    }

}
