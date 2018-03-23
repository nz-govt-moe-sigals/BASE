namespace App.Core.Application
{
    using System.Web.Mvc;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Messages;
    using Owin;

    /// <summary>
    /// An <see cref="StartupExtended"/> invoked class to configure 
    /// the specified application builder.
    /// </summary>
    public class ResponseHeaderConfig
    {

        /// <summary>
        /// Configures the specified application builder.
        /// <para>
        /// Invoked from <see cref="StartupExtended.Configure"/>
        /// </para>
        /// </summary>
        /// <param name="appBuilder">The application builder.</param>
        public static void Configure(IAppBuilder appBuilder)
        {
            // SETUP STEP: Remove the X-AspNetMvc-Version Header disclosing too much:
            MvcHandler.DisableMvcResponseHeader = true;

            AppDependencyLocator.Current.GetInstance<IConfigurationStepService>()
                .Register(
                    ConfigurationStepType.Security,
                    ConfigurationStepStatus.Green,
                    "Verbose Headers",
                    "X-AspNetMvc-Version removed.");


        }
    }
}