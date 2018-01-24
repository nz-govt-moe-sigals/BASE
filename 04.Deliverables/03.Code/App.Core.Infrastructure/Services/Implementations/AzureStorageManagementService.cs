using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Implementations
{
    using System.IO;
    using App.Core.Infrastructure.ExtensionMethods;
    using App.Core.Infrastructure.Services.Configuration.Implementations;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;

    /// <summary>
    /// Dependencies:
    /// * Nuget Packages:   
    ///   * WindowsAzure.Storage" version="8.6.0" 
    ///    * Microsoft.WindowsAzure.ConfigurationManager" version="3.2.3" 
    /// </summary>
    public class AzureStorageManagementService : IAzureStorageManagementService
    {

        public AzureStorageManangementServiceConfiguration Configuration
        {
            get;
            private set;
        }


        public AzureStorageManagementService(AzureStorageManangementServiceConfiguration azureStorageManangementServiceConfiguration)
        {
            Configuration = azureStorageManangementServiceConfiguration;
        }



        public CloudStorageAccount BuildCloudStorageAccount(string storageAccountName, string storageAccountKey)
        {
            throw new NotImplementedException();
        }

        public CloudStorageAccount BuildCloudStorageAccount(string connectionString)
        {
            throw new NotImplementedException();
        }

        public CloudBlobClient BuildCloudBlobClient(string connectionString)
        {
            throw new NotImplementedException();
        }

        public CloudBlobClient BuildCloudBlobClient(CloudStorageAccount cloudStorageAccount)
        {
            throw new NotImplementedException();
        }


        public CloudBlobContainer GetContainer(CloudBlobClient cloudBlobClient, string containerName, bool ensureExists = true, BlobContainerPublicAccessType BlobContainerPublicAccessTypeIfNew = BlobContainerPublicAccessType.Blob)
        {
            // Retrieve a reference to a container.
            var result = cloudBlobClient.GetContainerReference(containerName);

            //Does not gurantee it exists:
            if (!ensureExists)
            {
                return result;
            }

            result.EnsureContainer(BlobContainerPublicAccessTypeIfNew);
            return result;
        }



        public void UploadAFile(CloudBlobContainer cloudBlobContainer, string localFilePath)
        {

            string remoteFileName = Path.GetFileName(localFilePath);

            CloudBlockBlob blob =
                cloudBlobContainer.GetBlockBlobReference(remoteFileName);

            blob.UploadFromFile(localFilePath);
        }


        public void UploadAText(CloudBlobContainer cloudBlobContainer, string remoteBlobName, string text)
        {


            CloudBlockBlob blob =
                cloudBlobContainer.GetBlockBlobReference(remoteBlobName);

            blob.UploadText(text);
        }



    }
}
