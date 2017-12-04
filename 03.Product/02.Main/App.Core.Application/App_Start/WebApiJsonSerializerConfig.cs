namespace App.Core.Application.App_Start
{
    using System.Web.Http;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Messages;
    using Newtonsoft.Json;

    public class WebApiJsonSerializerConfig
    {
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