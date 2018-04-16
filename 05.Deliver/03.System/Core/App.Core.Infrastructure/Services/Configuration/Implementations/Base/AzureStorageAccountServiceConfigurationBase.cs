using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Configuration.Implementations
{
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.ConfigurationSettings;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;


    public abstract class AzureStorageAccountServiceConfigurationBase : IServiceConfigurationObject
    {
        private readonly IAzureKeyVaultService _keyVaultService;

        public string ConnectionString {get; set;}

        protected AzureStorageAccountServiceConfigurationBase(IAzureKeyVaultService keyVaultService)
        {
            this._keyVaultService = keyVaultService;
        }

        protected void Initialize(IStorageAccountConfigurationSettings settings)
        {
            var commonConfiguration =
                _keyVaultService.GetObject<AzureCommonConfigurationSettings>();

            if (string.IsNullOrEmpty(settings.ResourceName))
            {
                settings.ResourceName = commonConfiguration.RootResourceName;
            }

            ConnectionString = $"DefaultEndpointsProtocol=https;AccountName={settings.ResourceName};AccountKey={settings.Key}";



        }


    }

}
