using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Configuration.Implementations
{
    using App.Core.Shared.Models.Configuration;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;

    /// <summary>
    /// Configuration object to be injected into the 
    /// implementation of <see cref="IAzureStorageManagementService"/>
    /// </summary>
    public class AzureStorageManangementServiceConfiguration : IServiceConfigurationObject
    {
        public readonly AzureStorageAccountConfiguration AzureStorageAccountConfiguration;
        //CloudBlobClient 

        public AzureStorageManangementServiceConfiguration(IHostSettingsService hostSettingsService)
        {
            this.AzureStorageAccountConfiguration =
                hostSettingsService.GetObject<AzureStorageAccountConfiguration>();
        }



        public CloudStorageAccount BuildCloudStorageAccount(string storageAccountName, string storageAccountKey)
        {

            var connectionString = string.Format(@"DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}",
                storageAccountName, storageAccountKey);

            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(connectionString);
            return cloudStorageAccount;
        }

        public CloudStorageAccount BuildCloudStorageAccount(string connectionString)
        {
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(connectionString);
            return cloudStorageAccount;
        }


        public CloudBlobClient BuildCloudBlobClient(string connectionString)
        {
            var storageAccount = this.BuildCloudStorageAccount(connectionString);

            return BuildCloudBlobClient(storageAccount);
        }

        public CloudBlobClient BuildCloudBlobClient(CloudStorageAccount cloudStorageAccount)
        {
            var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            return cloudBlobClient;
        }
    }
}
