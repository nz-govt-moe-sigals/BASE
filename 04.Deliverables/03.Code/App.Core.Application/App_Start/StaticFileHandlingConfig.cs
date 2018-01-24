namespace App.Core.Application
{
    using System.Web.Http;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Messages;

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
            // SETUP STEP: Allow for static resources (eg: Avatar images) to be 
            // served without being processed slowed down by routing.
            httpConfiguration.Routes.IgnoreRoute("Assets", "Assets/{*pathInfo}");
            httpConfiguration.Routes.IgnoreRoute("Uploads", "Uploads/{*pathInfo}");

            AppDependencyLocator.Current.GetInstance<IConfigurationStepService>()
                .Register(
                ConfigurationStepType.General, 
                ConfigurationStepStatus.White, 
                "Static File Handler Enabled.", 
                "Path: '/Assets/'");
        }
    }
}