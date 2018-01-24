

namespace App.Core.Infrastructure.Services.Implementations
{
    using App.Core.Shared.Models.Configuration;

    public class ApplicationInformationService : IApplicationInformationService
    {
        private readonly ApplicationInformationServiceConfiguration _applicationInformationServiceConfiguration;

        public ApplicationInformationService(ApplicationInformationServiceConfiguration applicationInformationServiceConfiguration)
        {
            this._applicationInformationServiceConfiguration = applicationInformationServiceConfiguration;
        }

        public ApplicationDescription GetApplicationInformation()
        {
            return this._applicationInformationServiceConfiguration.ApplicationInformation;
        }
        public ApplicationCreatorInformation GetApplicationCreatorInformation()
        {
            return this._applicationInformationServiceConfiguration.ApplicationCreatorInformation;
        }
        public ApplicationDistributorInformation GetApplicationDistributorInformation()
        {
            return this._applicationInformationServiceConfiguration.ApplicationDistributorInformation;
        }
    }
}
