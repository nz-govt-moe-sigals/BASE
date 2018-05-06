using System.Configuration;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.ConfigurationSettings;
using App.Core.Shared.Models.Messages;
using Microsoft.ApplicationInsights.Extensibility;
using Owin;

namespace App.Host.Extended
{
    public class EnabledAnalytics
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly IAzureKeyVaultService _keyVaultService;

        public EnabledAnalytics(IDiagnosticsTracingService diagnosticsTracingService, IAzureKeyVaultService keyVaultService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
            this._keyVaultService = keyVaultService;
        }
        /// <summary>
        /// <para>
        /// Invoked from <see cref="StartupConfigure.Configure"/>
        /// </para>
        /// <para>
        /// Must be invoked before ServiceLocatorConfig is invoked.
        /// </para>
        /// </summary>
        /// <param name="appBuilder"></param>
        public void Configure(IAppBuilder appBuilder)
        {
            using (var elapsedTime = new ElapsedTime())
            {

                // This will be a first integration call...
                var analyticsConfiguration = this._keyVaultService
                    .GetObject<ApplicationInsightsConfigurationSettings>();


                TelemetryConfiguration.Active.DisableTelemetry = !analyticsConfiguration.Enabled;

                if (analyticsConfiguration.Enabled)
                {
                    if (string.IsNullOrWhiteSpace(analyticsConfiguration.Key))
                    {
                        throw new ConfigurationErrorsException(
                            $"Missing app setting '{App.Core.Shared.Constants.ConfigurationKeys.AppCoreIntegrationAzureApplicationInsightsInstrumentationKey}' used for Application Insights.");
                    }
                    TelemetryConfiguration.Active.InstrumentationKey = analyticsConfiguration.Key;
                }


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