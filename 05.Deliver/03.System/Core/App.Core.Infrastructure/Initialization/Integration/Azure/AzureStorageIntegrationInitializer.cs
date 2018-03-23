using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Initialization.Integration.Azure
{
    using App.Core.Infrastructure.Constants.Exceptions;
    using App.Core.Infrastructure.Services;
    using App.Core.Infrastructure.Services.Configuration.Implementations;
    using App.Core.Shared.Models.Configuration;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;

    public class AzureStorageIntegrationInitializer : IHasAppCoreInitializer
    {
        private readonly AzureStorageManangementServiceConfiguration _azureStorageServiceConfiguration;

        //private readonly IAzureStorageManagementService _azureStorageManagementService;

        public AzureStorageIntegrationInitializer(
            AzureStorageManangementServiceConfiguration azureStorageServiceConfiguration,
            IAzureStorageManagementService azureStorageManagementService)
        {
            this._azureStorageServiceConfiguration = azureStorageServiceConfiguration;
            //this._azureStorageManagementService = azureStorageManagementService;

        }

        public void Initialize()
        {
            if (string.IsNullOrWhiteSpace(this._azureStorageServiceConfiguration.AzureStorageAccountConfiguration.PublicBlobContainerName))
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Azure  Storage Public Blob is not correctly configured (has no value).");
            }
            if (string.IsNullOrWhiteSpace(this._azureStorageServiceConfiguration.AzureStorageAccountConfiguration.PrivateBlobContainerName))
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Azure  Storage Private Blob is not correctly configured (has no value).");
            }

            //TODO_azureStorageServiceConfiguration.AzureStorageAccountConfiguration.

            //The Application has at least the following storage scenarios:

            //* Uploaded media that is viewable on the web (if you know the url)
            //ie: Avatar images, etc.
            //* Uploaded media that is only downloadable via this app acting as a
            //stream proxy (ie, classified documents that are not rendered to the web
            //directly)
            if (_azureStorageServiceConfiguration.AzureStorageAccountConfiguration.EnsureContainers)
            {
                EnsureAzureContainers();
            }
            else
            {
                var publicContainerUrl =
                    _azureStorageServiceConfiguration.AzureStorageAccountConfiguration.Url
                    + this._azureStorageServiceConfiguration.AzureStorageAccountConfiguration.PublicBlobContainerName
                    + this._azureStorageServiceConfiguration.AzureStorageAccountConfiguration.AccountSharedAccessSignatureToken;

                var blobContainer = new CloudBlobContainer(new Uri(publicContainerUrl));
                bool check = blobContainer.Exists();


            }

        }

        public void EnsureAzureContainers()
        {
            var _storageAccount =
                CloudStorageAccount.Parse(_azureStorageServiceConfiguration.AzureStorageAccountConfiguration.ConnectionString);

            var cloudBlobClient = _storageAccount.CreateCloudBlobClient();

            EnsureContainer(cloudBlobClient, _azureStorageServiceConfiguration.AzureStorageAccountConfiguration.PublicBlobContainerName,
                BlobContainerPublicAccessType.Blob);

            EnsureContainer(cloudBlobClient, _azureStorageServiceConfiguration.AzureStorageAccountConfiguration.PrivateBlobContainerName,
                BlobContainerPublicAccessType.Off);
        }


        public CloudBlobContainer EnsureContainer(CloudBlobClient cloudBlobClient, string containerName,
            BlobContainerPublicAccessType accessType)
        {
            throw new ToDoException("EnsureContainer");
            //var cloudBlobContainer = this._azureStorageManagementService.GetContainer(
            //    cloudBlobClient,
            //    containerName,
            //    true,
            //    //Blob-level public access. Anonymous clients can read blob data within this container, but not container data.
            //    accessType
            //);
            //return null /*cloudBlobContainer*/;
        }

    }

}
