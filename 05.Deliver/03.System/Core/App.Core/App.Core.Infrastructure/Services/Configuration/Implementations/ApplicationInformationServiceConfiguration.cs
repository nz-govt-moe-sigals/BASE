namespace App.Core.Infrastructure.Services.Configuration.Implementations
{
    using App.Core.Shared.Contracts;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;

    /// <summary>
    /// Configuration object to be injected into the 
    /// implementation of <see cref="IApplicationInformationService"/>
    /// <para>
    /// Inherits from <see cref="ICoreServiceConfigurationObject"/>
    /// whic inherits from <see cref="IHasSingletonLifecycle"/>
    /// to hint at startup that the Configuration object should be 
    /// IoC registered for the duration of the application (not the thread).
    /// as some configuration hits remote services (eg: Azure KeyVault)
    /// which would be rather slow.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.Configuration.ICoreServiceConfigurationObject" />
    public class ApplicationInformationServiceConfiguration : ICoreServiceConfigurationObject
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