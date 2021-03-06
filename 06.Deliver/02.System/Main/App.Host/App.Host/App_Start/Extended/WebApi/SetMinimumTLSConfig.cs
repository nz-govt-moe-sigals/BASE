﻿using System;
using System.Net;
using App.Core.Infrastructure.Initialization.DependencyResolution;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Constants;
using App.Core.Shared.Models.Messages;

namespace App.Host.Extended.WebApi
{
    /// <summary>
    /// An <see cref="StartupExtended"/> invoked class to configure
    /// disable weak TLS for both incoming and outgoing connections.
    /// </summary>
    public class SetMinimumTLSConfig
    {
        private readonly IConfigurationStepService _configurationStepService;
        private readonly IHostSettingsService _hostSettingsService;

        public SetMinimumTLSConfig(IConfigurationStepService configurationStepService, IHostSettingsService hostSettingsService)
        {
            this._configurationStepService = configurationStepService;
            this._hostSettingsService = hostSettingsService;
        }

        /// <summary>
        /// Configurations this instance.
        /// <para>
        /// Invoked from <see cref="StartupExtended.Configure"/>.
        /// </para>
        /// </summary>
        public void Config()
        {
            DisableWeakTLSForIncoming();
            DisableWeakTLSForOutgoing();
        }

        private void DisableWeakTLSForIncoming()
        {
            // Regarding ensuring that TLS1.2 or higher is used for incoming traffic, 
            // when hosted in Standard Azure... without more infrastructure around it...
            // then the answer is ... you can't.
            // https://feedback.azure.com/forums/169385-web-apps/suggestions/11533680-disable-tls-1-0-in-azure-website-to-pass-pci-compl
            // And requires you to move up to a premium layout:
            // https://blogs.msdn.microsoft.com/benjaminperkins/2017/04/11/how-to-disable-tls-1-0-on-an-azure-app-service-web-app/
            // Or install and configure an Application Gateway:
            // https://www.leowkahman.com/2017/07/04/how-to-disable-tls-1-0-on-an-azure-app-service/
            // Other relevent threads are:
            // https://forums.asp.net/t/2069611.aspx?I+need+to+disable+TLS+1+0+via+code+Is+it+possible+
            // As per Microsoft's response:
            // "we can't disable TLS 1.0 in azure web app at currently, 
            // please submit a feedback in azure feedback 
            // forum: http://feedback.azure.com/forums/34192--general-feedback, 
            // if disable TLS 1.0 is your requirement, please try to use 
            // azure cloud service web role to host your application."


            _configurationStepService
                .Register(
                    ConfigurationStepType.Security,
                    ConfigurationStepStatus.Orange,
                    "TLS",
                    "Limiting to > TLS 1.0 for incoming is dependent on host environment. Azure's mininum is 1.1. Default for new App Services is 1.2.");

        }

        private void DisableWeakTLSForOutgoing()
        {
            //To ensure *OUTBOUND* connections are over TLS1.2:

            //Must be the very first thing the application does because ServicePointManager will initialize only once. 
            using (var elapsedTime = new ElapsedTime())
            {

                SecurityProtocolType setting;

                string key = ConfigurationKeys.SystemKeyPrefix + "TLS-SecurityProtocol";

                var tmp = this._hostSettingsService.GetObject<string>(key);

                if (!Enum.TryParse(tmp, out setting))
                {
                    _configurationStepService
                        .Register(
                            ConfigurationStepType.Security,
                            ConfigurationStepStatus.Orange,
                            "TLS",
                            $"Unable to parse {key} for outbound traffic. Took {elapsedTime.ElapsedText}");
                    return;
                }
                //setting will be one of "Ssl3", "Tls", "Tls11", "Tls12"
                //Starting with .NET4.7 the default value is set to a new value "Default"
                ServicePointManager.SecurityProtocol = setting;

                _configurationStepService
                    .Register(
                        ConfigurationStepType.Security,
                        ConfigurationStepStatus.White,
                        "TLS",
                        $"TLS11 and lower is disallowed for outgoing. Took {elapsedTime.ElapsedText}");
            }
        }
    }
}