namespace App.Core.Infrastructure.Services.Implementations
{
    using System.IO;
    using App.Core.Infrastructure.Services.Configuration.Implementations;
    using App.Core.Shared.Models.Configuration;
    using Microsoft.Azure;

    using Microsoft.WindowsAzure; // Namespace for CloudConfigurationManager
    using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
    using Microsoft.WindowsAzure.Storage.Blob; // Namespace for Blob storage types

    public class AzureStorageService : IAzureStorageService
    {
        private readonly AzureStorageManangementServiceConfiguration _azureStorageConfiguration;
        //private readonly IAzureStorageManagementService _azureStorageManagementService;

        private AzureStorageAccountConfiguration _azureStorageAccountConfiguration;
        private CloudBlobClient _blobClient;
        private CloudBlobContainer _cloudBlobContainer;

        public AzureStorageService(AzureStorageManangementServiceConfiguration  azureStorageConfiguration
            //, IAzureStorageManagementService azureStorageManagementService
            )
        {
            this._azureStorageConfiguration = azureStorageConfiguration;

            //this._azureStorageManagementService = azureStorageManagementService;


            //_blobClient = this._azureStorageManagementService.BuildCloudBlobClient(_azureStorageAccountConfiguration.ConnectionString);

            //_cloudBlobContainer = this._azureStorageManagementService.GetContainer(
            //    this._blobClient, 
            //    _azureStorageAccountConfiguration.PublicBlobContainerName,
            //    false
            //    );
        }



        public void Persist(byte[] bytes, string targetRelativePath)
        {
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                {
                    Persist(stream, targetRelativePath);
                }
            }
        }

        public void Persist(Stream contents, string targetRelativePath)
        {

            // Retrieve reference to a blob named "myblob".
            CloudBlockBlob blockBlob = this._cloudBlobContainer.GetBlockBlobReference(targetRelativePath);

            // Create or overwrite the "myblob" blob with contents from a local file.
            blockBlob.UploadFromStream(contents);
        }


    }
}