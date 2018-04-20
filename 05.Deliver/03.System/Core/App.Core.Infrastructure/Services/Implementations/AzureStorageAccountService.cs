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
    using App.Core.Shared.Models.ConfigurationSettings;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;


    /// <summary>
    /// Dependencies:
    /// * Nuget Packages:   
    ///   * WindowsAzure.Storage" version="8.6.0" 
    ///    * Microsoft.WindowsAzure.ConfigurationManager" version="3.2.3" 
    /// </summary>
    public abstract class AzureStorageAccountServiceBase : AppCoreServiceBase, IAzureStorageServiceBase
    {

        private Dictionary<string, CloudBlobContainer> _containersCache = new Dictionary<string, CloudBlobContainer>();

        public AzureStorageAccountServiceConfigurationBase Configuration
        {
            get;
            private set;
        }

        private CloudBlobClient CloudBlobClient { get; set; }



        protected AzureStorageAccountServiceBase(AzureStorageAccountServiceConfigurationBase configuration)
        {
            Configuration = configuration;
            Initialize();
        }

        private void Initialize()
        {
            string connString = this.Configuration.ConnectionString;
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(connString);
            this.CloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
        }

        public void EnsureContainer(string containerName, BlobContainerPublicAccessType BlobContainerPublicAccessTypeIfNew = BlobContainerPublicAccessType.Blob)
        {
            var result = this.CloudBlobClient.GetContainerReference(containerName);
            result.EnsureContainer(BlobContainerPublicAccessTypeIfNew);
        }

        private CloudBlobContainer GetContainer(string containerName, bool createIfNotExists, BlobContainerPublicAccessType blobContainerPublicAccessType = BlobContainerPublicAccessType.Off)
        {
            // If you don't clean name first you will get a 400
            // when creating the container.
            containerName = CleanContainerName(containerName);

            CloudBlobContainer result = null;

            if (this._containersCache.TryGetValue(containerName, out result))
            {
                return result;
            }

            // Retrieve a reference to a container.
            result = this.CloudBlobClient.GetContainerReference(containerName);


            if (createIfNotExists)
            {
                //Create a new container, if it does not exist
                result.CreateIfNotExists(blobContainerPublicAccessType);
            }

            //Cache:
            this._containersCache[containerName] = result;

            return result;
        }

        private static string CleanContainerName(string containerName)
        {
            containerName = containerName.ToLower().Substring(0, 63);
            return containerName;
        }


        public void UploadAFile(string containerName, string localFilePath, bool createContainerIfNotExists=true, BlobContainerPublicAccessType blobContainerPublicAccessType = BlobContainerPublicAccessType.Off)
        {
            string remoteFileName = Path.GetFileName(localFilePath);

            var container = GetContainer(containerName,createContainerIfNotExists);
            CloudBlockBlob blob = container.GetBlockBlobReference(remoteFileName);

            blob.UploadFromFile(localFilePath);
        }


        public void UploadAText(string containerName, string remoteBlobName, string text, bool createContainerIfNotExists = true, BlobContainerPublicAccessType blobContainerPublicAccessType = BlobContainerPublicAccessType.Off)
        {

            var container = GetContainer(containerName,createContainerIfNotExists);

            CloudBlockBlob blob =
                container.GetBlockBlobReference(remoteBlobName);

            blob.UploadText(text);
        }


        public string DownloadAText(string containerName, string remoteBlobBame)
        {
            var container = GetContainer(containerName, false);

            CloudBlockBlob blob =
                container.GetBlockBlobReference(remoteBlobBame);

            var result = blob.DownloadText();

            return result;

        }


    }
}
