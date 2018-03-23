

namespace App.Core.Infrastructure.Services.Configuration.Implementations
{
    using App.Core.Shared.Models.Configuration;

    /// <summary>
    /// Configuration object to be injected into the 
    /// implementation of <see cref="IAzureKeyVaultService"/>
    /// </summary>
    public class AzureKeyVaultServiceConfiguration : IServiceConfigurationObject
    {
        public string KeyVaultUrl;

        public readonly AadApplicationRegistrationInformation AADClientInfo;

        public AzureKeyVaultConfiguration Configuration;

        public AzureKeyVaultServiceConfiguration(IHostSettingsService hostSettingsService)
        {
            this.AADClientInfo = hostSettingsService.GetObject<AadApplicationRegistrationInformation>();
            this.Configuration = hostSettingsService.GetObject<AzureKeyVaultConfiguration>();


        }

    }
}
