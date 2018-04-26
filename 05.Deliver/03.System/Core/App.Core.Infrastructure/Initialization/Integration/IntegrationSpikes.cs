using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Initialization.Integration
{
    using App.Core.Infrastructure.Constants.Storage;
    using App.Core.Infrastructure.Services;

    public class IntegrationSpikes : IHasAppCoreInitializer
    {
        private readonly IAzureBlobStorageService _azureStorageAccountBlobStorageService;

        public IntegrationSpikes(IAzureBlobStorageService azureStorageAccountBlobStorageService)
        {
            this._azureStorageAccountBlobStorageService = azureStorageAccountBlobStorageService;
        }


        public void Initialize()
        {
            var containerName = BlobStorageContainers.Testing;
            var fileName = "foo.txt";


            this._azureStorageAccountBlobStorageService.UploadAText(null, containerName,fileName,"bar");

            this._azureStorageAccountBlobStorageService.DownloadAText(null, containerName, fileName);
        }

    }
}
