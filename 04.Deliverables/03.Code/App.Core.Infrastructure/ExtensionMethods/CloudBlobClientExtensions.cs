using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.ExtensionMethods
{
    using Microsoft.WindowsAzure.Storage.Blob;

    public static class CloudBlobClientExtensions
    {
        public static CloudBlobContainer GetContainer(this CloudBlobClient cloudBlobClient, string containerName, bool ensureExists = true, BlobContainerPublicAccessType BlobContainerPublicAccessTypeIfNew = BlobContainerPublicAccessType.Blob)
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

    }
}
