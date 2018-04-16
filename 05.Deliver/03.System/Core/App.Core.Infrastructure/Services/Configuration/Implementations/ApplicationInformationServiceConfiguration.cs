namespace App.Core.Infrastructure.Services.Configuration.Implementations
{
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;

    /// <summary>
    /// Configuration object to be injected into the 
    /// implementation of <see cref="IApplicationInformationService"/>
    /// </summary>
    public class ApplicationInformationServiceConfiguration : IServiceConfigurationObject
    {

        public ApplicationDescriptionConfigurationSettings ApplicationInformation;

        public ApplicationCreatorInformationConfigurationSettings ApplicationCreatorInformation;

        public ApplicationDistributorInformationConfigurationSettings ApplicationDistributorInformation;

        public ApplicationInformationServiceConfiguration(IAzureKeyVaultService keyVaultService)
        {
            this.ApplicationInformation = keyVaultService.GetObject<ApplicationDescriptionConfigurationSettings>();
            this.ApplicationCreatorInformation = keyVaultService.GetObject<ApplicationCreatorInformationConfigurationSettings>();
            this.ApplicationDistributorInformation = keyVaultService.GetObject<ApplicationDistributorInformationConfigurationSettings>();
        }
    }
}