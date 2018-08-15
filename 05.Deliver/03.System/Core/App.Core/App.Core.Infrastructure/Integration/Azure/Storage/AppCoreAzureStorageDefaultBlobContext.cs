using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Shared.Models.Entities;

namespace App.Core.Infrastructure.Integration.Azure.Storage
{
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Attributes;
    using App.Core.Shared.Models.ConfigurationSettings;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;

    // End developers care about Containers at best.
    // An App keeps most of its containers in one Service Account.
    // A Container Context

    [Key(Constants.Storage.StorageAccountNames.Default)]
    public class AppCoreAzureStorageDefaultBlobContext : IAzureStorageBlobContext
    {
        private readonly string ConnectionString;

        private static object _lock = new Object();
        private static Dictionary<string, CloudBlobContainer> ContainersCache = new Dictionary<string, CloudBlobContainer>();
        private static bool ContainersInitialized;
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;

        public CloudBlobClient Client
        {
            get
            {
                return this._client ?? (this._client = Initialize());
            }
        }
        private CloudBlobClient _client;


        /// <summary>
        /// Initializes a new instance of the <see cref="AppCoreAzureStorageDefaultBlobContext"/> class.
        /// </summary>
        /// <param name="keyVaultService">The key vault service.</param>
        public AppCoreAzureStorageDefaultBlobContext(IAzureKeyVaultService keyVaultService, IDiagnosticsTracingService diagnosticsTracingService)
        {
            _diagnosticsTracingService = diagnosticsTracingService;
            var configuration =
                keyVaultService.GetObject<AzureStorageAccountDefaultConfigurationSettings>();


            var commonConfiguration =
                keyVaultService.GetObject<AzureCommonConfigurationSettings>();

            if (string.IsNullOrEmpty(configuration.ResourceName))
            {
                configuration.ResourceName = commonConfiguration.RootResourceName;
            }

            ConnectionString = $"DefaultEndpointsProtocol=https;AccountName={configuration.ResourceName}{configuration.ResourceNameSuffix};AccountKey={configuration.Key};EndpointSuffix=core.windows.net";

            if (!ContainersInitialized)
            {
                CreateContainers();
            }
        }

        public CloudBlobClient Initialize()
        {
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(this.ConnectionString);

            return _client = cloudStorageAccount.CreateCloudBlobClient();
        }

        public void CreateContainers()
        {
            lock (_lock)
            {
                try
                {
                    // Develop any known required Containers, with rights as needed:
                    EnsureContainer(GetContainer(Constants.Storage.BlobStorageContainers.Public),
                        BlobContainerPublicAccessType.Blob);
                    EnsureContainer(GetContainer(Constants.Storage.BlobStorageContainers.Private),
                        BlobContainerPublicAccessType.Off);
                    EnsureContainer(GetContainer(Constants.Storage.BlobStorageContainers.Testing),
                        BlobContainerPublicAccessType.Blob);
                }
                catch (System.Exception ex)

                {
                    _diagnosticsTracingService.Trace(TraceLevel.Error, ConnectionString); //dont do this normally but am really 
                    _diagnosticsTracingService.Trace(TraceLevel.Error, ex.Message);
                    _diagnosticsTracingService.Trace(TraceLevel.Error, ex.StackTrace);
                    throw;
                }

                ContainersInitialized = true;
            }
        }


        public CloudBlobContainer GetContainer(string containerName)
        {

            // If you don't clean name first you will get a 400
            // when creating the container.
            containerName = CleanContainerName(containerName);

            CloudBlobContainer result = null;

            if (ContainersCache.TryGetValue(containerName, out result))
            {
                return result;
            }

            // Retrieve a reference to a container.
            result = this.Client.GetContainerReference(containerName);

            //Cache:
            lock (this)
            {
                ContainersCache[containerName] = result;
            }

            return result;
        }

        public void EnsureContainer(CloudBlobContainer container, BlobContainerPublicAccessType blobContainerPublicAccessType = BlobContainerPublicAccessType.Off)
        {
            container.CreateIfNotExists(blobContainerPublicAccessType);
        }


        private static string CleanContainerName(string containerName)
        {
            containerName = containerName.ToLower().Substring(0, Math.Min(containerName.Length, 63));

            return containerName;
        }
    }
}
