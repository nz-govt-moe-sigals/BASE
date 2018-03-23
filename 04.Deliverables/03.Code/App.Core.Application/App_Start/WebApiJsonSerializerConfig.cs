namespace App.Core.Application.App_Start
{
    using System.Web.Http;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Messages;
    using Newtonsoft.Json;

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
            // JSON chokes on most EF models:
            httpConfiguration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =
                ReferenceLoopHandling.Ignore;

            AppDependencyLocator.Current.GetInstance<IConfigurationStepService>()
                .Register(
                    ConfigurationStepType.Security,
                    ConfigurationStepStatus.White,
                    "JSON Serializer",
                    "ReferenceLoopHandling set to Ignore.");

        }
    }
}