﻿using System.IO;
using App.Core.Infrastructure.ExtensionMethods;
using App.Core.Infrastructure.Initialization.DependencyResolution;
using App.Core.Infrastructure.Integration.Azure.Storage;
using App.Core.Shared.Models.Entities;
using Microsoft.WindowsAzure.Storage.Blob;

namespace App.Core.Infrastructure.Services.Implementations.AzureServices
{
    /// <summary>
    /// Dependencies:
    /// * Nuget Packages:   
    ///   * WindowsAzure.Storage" version="8.6.0" 
    ///    * Microsoft.WindowsAzure.ConfigurationManager" version="3.2.3" 
    /// </summary>
    public class AzureBlobStorageService : AppCoreServiceBase, IAzureBlobStorageService
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        //public AzureBlobStorageServiceConfiguration Configuration { get; private set; }

        public AzureBlobStorageService(IDiagnosticsTracingService diagnosticsTracingService
            /*,AzureBlobStorageServiceConfiguration configuration*/
            )
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
            // In this case, the configuration doesn't have much/any settings (it's all in the Context objects).
            //Configuration = configuration;
        }


        /// <summary>
        /// Use Service Locator to return specified context.
        /// </summary>
        /// <param name="storageAccountContextKey">The storage account context key.</param>
        /// <returns></returns>
        private IAzureStorageBlobContext GetStorageAccountContext(string storageAccountContextKey)
        {

            // If no name given, fall back to the default one:
            if (string.IsNullOrWhiteSpace(storageAccountContextKey))
            {
                storageAccountContextKey = Constants.Storage.StorageAccountNames.Default;
            }

            var result = AppDependencyLocator.Current.GetInstance<IAzureStorageBlobContext>(storageAccountContextKey);

            return result;

        }

        public void EnsureContainer(string storageAccountContextKey, string containerName, BlobContainerPublicAccessType BlobContainerPublicAccessTypeIfNew = BlobContainerPublicAccessType.Blob)
        {
            var storageAccountContext = GetStorageAccountContext(storageAccountContextKey);

            var result = storageAccountContext.Client.GetContainerReference(containerName);

            result.EnsureContainer(BlobContainerPublicAccessTypeIfNew);
        }


        public void UploadAText(string storageAccountContextKey, string containerName, string remoteBlobName,
            string text)
        {

            var storageAccountContext = GetStorageAccountContext(storageAccountContextKey);
            var cloudBlobContainer = storageAccountContext.GetContainer(containerName);

            CloudBlockBlob blob =
                cloudBlobContainer.GetBlockBlobReference(remoteBlobName);

            // It's faster to try to upload, and fallback to making the container if need be:
            try
            {
                blob.UploadText(text);
            }
#pragma warning disable 168
            catch (Microsoft.WindowsAzure.Storage.StorageException e)
#pragma warning restore 168
            {
                this._diagnosticsTracingService.Trace(TraceLevel.Error, $"Container '{containerName}' does not exist to upload to.");
            }
        }


        public string DownloadAText(string storageAccountContextKey, string containerName, string remoteBlobBame)
        {
            var storageAccountContext = GetStorageAccountContext(storageAccountContextKey);
            var cloudBlobContainer = storageAccountContext.GetContainer(containerName);

            CloudBlockBlob blob =
                cloudBlobContainer.GetBlockBlobReference(remoteBlobBame);

            var result = blob.DownloadText();

            return result;

        }

        public void UploadAFile(string storageAccountContextKey, string containerName, string localFilePath)
        {

            var storageAccountContext = GetStorageAccountContext(storageAccountContextKey);
            var cloudBlobContainer = storageAccountContext.GetContainer(containerName);

            string remoteFileName = Path.GetFileName(localFilePath);

            // It's faster to try to upload, and fallback to making the container if need be:
            CloudBlockBlob blob;
            blob = cloudBlobContainer.GetBlockBlobReference(remoteFileName);
            try
            {

                blob.UploadFromFile(localFilePath);
            }
#pragma warning disable 168
            catch (Microsoft.WindowsAzure.Storage.StorageException e)
#pragma warning restore 168
            {
                this._diagnosticsTracingService.Trace(TraceLevel.Error,
                    $"Container '{containerName}' does not exist to upload to.");
            }

        }



        //        public void Persist(byte[] bytes, string targetRelativePath)
        //        {
        //            using (MemoryStream stream = new MemoryStream(bytes))
        //            {
        //                {
        //                    Persist(stream, targetRelativePath);
        //                }
        //            }
        //        }

        //        public void Persist(Stream contents, string targetRelativePath)
        //        {

        //            // Retrieve reference to a blob named "myblob".
        //            CloudBlockBlob blockBlob = this._cloudBlobContainer.GetBlockBlobReference(targetRelativePath);

        //            // Create or overwrite the "myblob" blob with contents from a local file.
        //            blockBlob.UploadFromStream(contents);
        //        }








    }
}
