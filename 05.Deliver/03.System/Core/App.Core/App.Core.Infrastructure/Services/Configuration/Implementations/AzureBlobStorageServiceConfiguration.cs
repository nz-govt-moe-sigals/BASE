using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Configuration.Implementations
{
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.ConfigurationSettings;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;


    public class AzureBlobStorageServiceConfiguration : ICoreServiceConfigurationObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureBlobStorageServiceConfiguration"/> class.
        /// </summary>
        public AzureBlobStorageServiceConfiguration()
        {
        }
    }
}
