namespace App.Core.Infrastructure.Services.Implementations
{
    using App.Core.Shared.Models.Configuration;

    public class ApplicationInformationServiceConfiguration
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