namespace App.Core.Application.Extended
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
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly IConfigurationStepService _configurationStepService;

        public ResponseHeaderConfig(
            IDiagnosticsTracingService diagnosticsTracingService,
            IConfigurationStepService configurationStepService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
            this._configurationStepService = configurationStepService;
        }
        /// <summary>
        /// Configures the specified application builder.
        /// <para>
        /// Invoked from <see cref="StartupExtended.Configure"/>
        /// </para>
        /// </summary>
        /// <param name="appBuilder">The application builder.</param>
        public void Configure(IAppBuilder appBuilder)
        {
            using (var elapsedTime = new ElapsedTime())
            {

                // SETUP STEP: Remove the X-AspNetMvc-Version Header disclosing too much:
                MvcHandler.DisableMvcResponseHeader = true;

                _configurationStepService
                    .Register(
                        ConfigurationStepType.Security,
                        ConfigurationStepStatus.White,
                        "Verbose Headers",
                        $"X-AspNetMvc-Version removed. Took {elapsedTime.ElapsedText}");
            }

        }
    }
}