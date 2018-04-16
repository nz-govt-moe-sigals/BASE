using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Initialization.Integration
{
    using App.Core.Infrastructure.Services;

    public class IntegrationSpikes : IHasAppCoreInitializer
    {
        //private readonly AzureIntegrationInitializer _azureIntegrationInitializer;

        public IntegrationSpikes()
        {
            //this._azureIntegrationInitializer = azureIntegrationInitializer;
        }


        public void Initialize()
        {
           // this._azureIntegrationInitializer.Initialize();
        }

    }
}
