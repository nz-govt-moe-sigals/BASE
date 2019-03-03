using System.Web.Http;
using App.Core.Infrastructure.Initialization.DependencyResolution;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.Messages;

namespace App.Host.Extended.WebApi
{
    /// <summary>
    /// An <see cref="StartupExtended"/> invoked class to configure 
    /// the handling of Static Files. 
    /// Specifically, Assets (images, etc.) and 
    /// Uploads (although that is not used in Cloud environments, 
    /// where BlobStorage is the norm).
    /// </summary>
    public class StaticFileHandlingConfig
    {

        /// <summary>
        /// Configures the specified HTTP configuration.
        /// <para>
        /// Invoked from <see cref="StartupExtended.Configure"/>
        /// </para>
        /// </summary>
        /// <param name="httpConfiguration">The HTTP configuration.</param>
        public static void Configure(HttpConfiguration httpConfiguration)
        {
            using (var elapsedTime = new ElapsedTime())
            {

                // SETUP STEP: Allow for static resources (eg: Avatar images) to be 
                // served without being processed slowed down by routing.
                httpConfiguration.Routes.IgnoreRoute("Assets", "Assets/{*pathInfo}");
                httpConfiguration.Routes.IgnoreRoute("Uploads", "Uploads/{*pathInfo}");

                AppDependencyLocator.Current.GetInstance<IConfigurationStepService>()
                    .Register(
                        ConfigurationStepType.General,
                        ConfigurationStepStatus.White,
                        "Static File Handler Enabled.",
                        $"Path: '/Assets/'. Took {elapsedTime.ElapsedText}");

            }
        }
    }
}