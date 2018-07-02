using App.Core.Infrastructure.Services.Configuration.Implementations;
using App.Core.Shared.Models.ConfigurationSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Implementations
{
    public class AzureDeploymentEnvironmentService : AppCoreServiceBase, IAzureDeploymentEnvironmentService
    {
        Guid _subscriptionId = Guid.Empty;
        Guid _tenantId = Guid.Empty;
        AzureEnvironmentSettings _settings;

        public AzureDeploymentEnvironmentService(AzureDeploymentEnvironmentServiceConfiguration azureDeploymentEnvironmentServiceConfiguration)
        {
            _settings = azureDeploymentEnvironmentServiceConfiguration.Settings;

            Guid.TryParse(_settings.SubscriptionId, out _subscriptionId);
            Guid.TryParse(_settings.TenantId, out _tenantId);

        }

        /// <summary>
        /// The Key to the Subscription within which 
        /// this system was deployed to.
        /// </summary>
        public Guid SubscriptionId { get
            {
                return SubscriptionId;
            }
        }

        public Guid TenantId
        {
            get
            {
                return _tenantId;
            }
        }

        /// <summary>
        /// The name of the ResourceString to which thi
        /// </summary>
        public string ResourceGroupName { get {
                return _settings.ResourceGroupName;
            }
        }

        /// <summary>
        /// The name of the ResourceString to which thi
        /// </summary>
        public string ResourceGroupLocation
        {
            get
            {
                return _settings.ResourceGroupName;
            }
        }

    }
}
