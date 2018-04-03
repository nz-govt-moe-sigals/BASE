namespace App.Core.Application.Extended
{
    using System.Configuration;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Messages;
    using Microsoft.ApplicationInsights.Extensibility;
    using Owin;

    public class EnabledAnalytics
    {

        /// <summary>
        /// <para>
        /// Invoked from <see cref="StartupConfigure.Configure"/>
        /// </para>
        /// <para>
        /// Must be invoked before ServiceLocatorConfig is invoked.
        /// </para>
        /// </summary>
        /// <param name="appBuilder"></param>
        public static void Configure(IAppBuilder appBuilder)
        {
            using (var elapsedTime = new ElapsedTime())
            {

                var analyticsConfiguration =
                    AppDependencyLocator.Current.GetInstance<IHostSettingsService>()
                        .GetObject<ApplicationInsightsConfiguration>();

                if (string.IsNullOrWhiteSpace(analyticsConfiguration.Key))
                {
                    throw new ConfigurationErrorsException(
                        "Missing app setting 'App:Core:Integration:Azure:ApplicationInsights:InstrumentationKey' used for Application Insights.");
                }
                TelemetryConfiguration.Active.InstrumentationKey = analyticsConfiguration.Key;
                TelemetryConfiguration.Active.DisableTelemetry = analyticsConfiguration.DisableTelemetry;

                AppDependencyLocator.Current.GetInstance<IConfigurationStepService>()
                    .Register(
                        ConfigurationStepType.General,
                        ConfigurationStepStatus.Green,
                        "Telemetry",
                        $"Telemetry configured. Took {elapsedTime.ElapsedText}.");

            }


        }
}


}