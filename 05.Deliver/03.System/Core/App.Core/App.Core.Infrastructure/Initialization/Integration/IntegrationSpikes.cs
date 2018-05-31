using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Constants.Storage;

namespace App.Core.Infrastructure.Initialization.Integration
{
    using App.Core.Infrastructure.Constants.Storage;
    using App.Core.Infrastructure.Services;

    public class IntegrationSpikes : IHasAppCoreInitializer
    {
        private readonly IAzureBlobStorageService _azureStorageAccountBlobStorageService;
        private readonly IAzureRedisCacheService _azureRedisCacheService;
        private readonly IAzureMapsService _azureMapsService;

        public IntegrationSpikes(
            IAzureBlobStorageService azureStorageAccountBlobStorageService, 
            IAzureRedisCacheService azureRedisCacheService,
            IAzureMapsService azureMapsService
            )
        {
            this._azureStorageAccountBlobStorageService = azureStorageAccountBlobStorageService;
            this._azureRedisCacheService = azureRedisCacheService;
            this._azureMapsService = azureMapsService;
        }


        public void Initialize()
        {
            var containerName = BlobStorageContainers.Testing;
            var fileName = "foo.txt";


            this._azureStorageAccountBlobStorageService.UploadAText(null, containerName,fileName,"bar");

            this._azureStorageAccountBlobStorageService.DownloadAText(null, containerName, fileName);

            _azureRedisCacheService.Set("keyA", "Some Message", TimeSpan.FromMinutes(1));

            string result = _azureRedisCacheService.Get("keyA");


            var mapresult = _azureMapsService.AddressSearch("18 Upoko Road","NZ");
            var mapresult2 = _azureMapsService.AddressSearch("180 Upoko Road", "NZ");


        }

    }
}
