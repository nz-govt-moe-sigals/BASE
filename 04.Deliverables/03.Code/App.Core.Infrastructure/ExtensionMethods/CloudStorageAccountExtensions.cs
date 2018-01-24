namespace App
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;

    public static class CloudStorageAccountExtensions
    {
        public static CloudBlobClient BuildCloudBlobClient(this CloudStorageAccount cloudStorageAccount)
        {
            var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            return cloudBlobClient;
        }
    }
}
