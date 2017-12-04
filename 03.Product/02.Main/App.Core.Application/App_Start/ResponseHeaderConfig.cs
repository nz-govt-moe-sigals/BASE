namespace App.Core.Application
{
    using System.Web.Mvc;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Messages;
    using Owin;

    public class ResponseHeaderConfig
    {
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