
namespace App.Core.Infrastructure.Services
{
    using App.Core.Infrastructure.Services.Configuration.Implementations;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;

    /// <summary>
        /// Contract for an Infrastructure Service to 
        /// manage access to Azure Storage Accounts
        /// and the Storage Containers and Blobs within.
        /// </summary>
        public interface IAzureBlobStorageService : IHasAppCoreService
    {

        //AzureBlobStorageServiceConfiguration Configuration
        //{
        //    get;
        //}

        void EnsureContainer(string storageAccountContextKey, string containerName,
            BlobContainerPublicAccessType BlobContainerPublicAccessTypeIfNew = BlobContainerPublicAccessType.Blob);

        void UploadAText(string storageAccountContextKey, string containerName, string remoteBlobName, string text);

        string DownloadAText(string storageAccountContextKey, string containerName, string remoteBlobBame);

        void UploadAFile(string storageAccountContextKey, string containerName, string localFilePath);



        //void Persist(byte[] bytes, string targetRelativePath);
        //void Persist(Stream contents, string targetRelativePath);

    }
}
