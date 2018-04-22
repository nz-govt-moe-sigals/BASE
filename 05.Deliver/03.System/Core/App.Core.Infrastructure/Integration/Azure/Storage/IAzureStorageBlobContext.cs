using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Integration.Azure.Storage
{
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;

    public interface IAzureStorageBlobContext
    {

        CloudBlobClient Client { get; }

        CloudBlobContainer GetContainer(string containerName);

        void EnsureContainer(CloudBlobContainer cloudBlobContainer, BlobContainerPublicAccessType blobContainerPublicAccessType = BlobContainerPublicAccessType.Off);
    }
}
