using System.Web.Http;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.Messages;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace App.Host.Extended.WebApi
{
    /// <summary>
    /// An <see cref="StartupExtended"/> invoked class to configure 
    /// the specified HTTP configuration.
    /// </summary>
    public class WebApiJsonSerializerConfig
    {

        /// <summary>
        /// Configures the specified HTTP configuration.
        /// <para>
        /// Invoked from <see cref="StartupExtended.Configure"/>.
        /// </para>
        /// </summary>
        /// <param name="httpConfiguration">The HTTP configuration.</param>
        public static void Configure(HttpConfiguration httpConfiguration)
        {
            using (var elapsedTime = new ElapsedTime())
            {

                // JSON chokes on most EF models:
                httpConfiguration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =
                    ReferenceLoopHandling.Ignore;
                // note: this is required to make the default swagger json settings match the odata conventions applied by EnableLowerCamelCase()
                httpConfiguration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                AppDependencyLocator.Current.GetInstance<IConfigurationStepService>()
                    .Register(
                        ConfigurationStepType.Security,
                        ConfigurationStepStatus.White,
                        "JSON Serializer",
                        $"ReferenceLoopHandling set to Ignore. Took {elapsedTime.ElapsedText}");
            }

        }
    }
}