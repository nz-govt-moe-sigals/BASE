namespace App.Core.Infrastructure.Services.Configuration.Implementations
{
    using App.Core.Shared.Models.Configuration;

    /// <summary>
    /// Configuration object to be injected into the 
    /// implementation of <see cref="IApplicationInformationService"/>
    /// </summary>
    public class ApplicationInformationServiceConfiguration : IServiceConfigurationObject
    {

        public ApplicationDescription ApplicationInformation;

        public ApplicationCreatorInformation ApplicationCreatorInformation;

        public ApplicationDistributorInformation ApplicationDistributorInformation;

        public ApplicationInformationServiceConfiguration(IHostSettingsService hostSettingsService)
        {
            this.ApplicationInformation = hostSettingsService.GetObject<ApplicationDescription>();
            this.ApplicationCreatorInformation = hostSettingsService.GetObject<ApplicationCreatorInformation>();
            this.ApplicationDistributorInformation = hostSettingsService.GetObject<ApplicationDistributorInformation>();
        }
    }
}