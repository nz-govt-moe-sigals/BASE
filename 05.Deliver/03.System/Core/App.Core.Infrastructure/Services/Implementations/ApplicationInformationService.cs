

namespace App.Core.Infrastructure.Services.Implementations
{
    using App.Core.Infrastructure.Services.Configuration.Implementations;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;

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

        public ApplicationDescriptionConfigurationSettings GetApplicationInformation()
        {
            return this._applicationInformationServiceConfiguration.ApplicationInformation;
        }
        public ApplicationCreatorInformationConfigurationSettings GetApplicationCreatorInformation()
        {
            return this._applicationInformationServiceConfiguration.ApplicationCreatorInformation;
        }
        public ApplicationDistributorInformationConfigurationSettings GetApplicationDistributorInformation()
        {
            return this._applicationInformationServiceConfiguration.ApplicationDistributorInformation;
        }
    }
}
