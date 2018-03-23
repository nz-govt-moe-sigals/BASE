
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
    public interface IAzureStorageManagementService
    {

        AzureStorageManangementServiceConfiguration Configuration { get; }


        CloudStorageAccount BuildCloudStorageAccount(string storageAccountName, string storageAccountKey);

        CloudStorageAccount BuildCloudStorageAccount(string connectionString);

        CloudBlobClient BuildCloudBlobClient(string connectionString);
        CloudBlobClient BuildCloudBlobClient(CloudStorageAccount cloudStorageAccount);

        CloudBlobContainer GetContainer(CloudBlobClient cloudBlobClient, string containerName, bool ensureExists = true,
            BlobContainerPublicAccessType BlobContainerPublicAccessTypeIfNew = BlobContainerPublicAccessType.Blob);

    }
}
