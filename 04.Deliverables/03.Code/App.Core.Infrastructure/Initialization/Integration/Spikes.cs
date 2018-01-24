using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Initialization.Integration
{
    using App.Core.Infrastructure.Services;

    public class Spikes : IHasAppCoreInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;
        //private readonly IAzureStorageManagementService _azureStorageManagementService;

        public Spikes(IHostSettingsService hostSettingsService
            //, IAzureStorageManagementService azureStorageManagementService
            )
        {
            this._hostSettingsService = hostSettingsService;
           // this._azureStorageManagementService = azureStorageManagementService;
        }

        public void Initialize()
        {

        }

    }
}
