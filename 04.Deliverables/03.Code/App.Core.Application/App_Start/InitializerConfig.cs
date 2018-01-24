using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Core.Application.App_Start
{
    using App.Core.Infrastructure.Initialization.Integration;
    using App.Core.Infrastructure.Initialization.Integration.Azure;
    using Owin;

    public class InitializerConfig
    {
        private readonly AzureStorageIntegrationInitializer _azureStorage;
        private readonly Spikes _spikes;

        public InitializerConfig(AzureStorageIntegrationInitializer azureStorage, Spikes spikes)
        {
            this._azureStorage = azureStorage;
            this._spikes = spikes;
        }
        public void Configure(IAppBuilder appBuilder)
        {
            _azureStorage.Initialize();

            this._spikes.Initialize();
        }
    }
}