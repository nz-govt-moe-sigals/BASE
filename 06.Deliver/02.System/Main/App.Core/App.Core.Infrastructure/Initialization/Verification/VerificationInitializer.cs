﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Initialization.Verification
{
    using App.Core.Infrastructure.Initialization.Integration.Scanii;
    using App.Core.Shared.Contracts;

    public class VerificationInitializer : IHasAppModuleInitializer, IHasInitialize
    {
        private readonly ApplicationSettingsInitializer _applicationSettingsInitializer;
        private readonly ScaniiIntegrationInitializer _scaniiIntegrationInitializer;

        public VerificationInitializer(ApplicationSettingsInitializer applicationSettingsInitializer,
            ScaniiIntegrationInitializer scaniiIntegrationInitializer)
        {
            this._applicationSettingsInitializer = applicationSettingsInitializer;
            this._scaniiIntegrationInitializer = scaniiIntegrationInitializer;
        }

        public void Initialize()
        {
            // Verify name of application, creator, etc. info is set.
            this._applicationSettingsInitializer.Initialize();

            // Verify if malware scanner service is configured.
            this._scaniiIntegrationInitializer.Initialize();



        }
    }
}
