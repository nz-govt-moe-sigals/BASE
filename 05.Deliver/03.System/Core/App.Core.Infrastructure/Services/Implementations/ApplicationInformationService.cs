

namespace App.Core.Infrastructure.Services.Implementations
{
    using App.Core.Infrastructure.Services.Configuration.Implementations;
    using App.Core.Shared.Models.Configuration;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="IApplicationInformationService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.IApplicationInformationService" />
    public class ApplicationInformationService : AppCoreServiceBase, IApplicationInformationService
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
