using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Initialization.Verification
{
    using App.Core.Infrastructure.Constants.Exceptions;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Contracts;

    public class ApplicationSettingsInitializer :IHasAppCoreInitializer, IHasInitialize
    {
        private readonly IApplicationInformationService _applicationInformationService;

        public ApplicationSettingsInitializer(IApplicationInformationService applicationInformationService)
        {
            this._applicationInformationService = applicationInformationService;
        }
        public void Initialize()
        {
            if (string.IsNullOrWhiteSpace(this._applicationInformationService.GetApplicationInformation().Name))
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Application Name not configured (has no value).");
            }
            if (string.IsNullOrWhiteSpace(this._applicationInformationService.GetApplicationInformation().Description))
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Application Description not configured (has no value).");
            }


            if (string.IsNullOrWhiteSpace(this._applicationInformationService.GetApplicationCreatorInformation().Name))
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Application Creator Name not configured (has no value).");
            }
            if (string.IsNullOrWhiteSpace(this._applicationInformationService.GetApplicationCreatorInformation().Description))
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Application Creator Description not configured (has no value).");
            }
            if (string.IsNullOrWhiteSpace(this._applicationInformationService.GetApplicationCreatorInformation().SiteUrl))
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Application Creator SiteUrl not configured (has no value).");
            }
            if (string.IsNullOrWhiteSpace(this._applicationInformationService.GetApplicationCreatorInformation().ContactUrl))
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Application Creator ContactUrl not configured (has no value).");
            }


            if (string.IsNullOrWhiteSpace(this._applicationInformationService.GetApplicationDistributorInformation().Name))
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Application Distributor Name not configured (has no value).");
            }
            if (string.IsNullOrWhiteSpace(this._applicationInformationService.GetApplicationDistributorInformation().Description))
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Application Distributor Description not configured (has no value).");
            }
            if (string.IsNullOrWhiteSpace(this._applicationInformationService.GetApplicationDistributorInformation().SiteUrl))
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Application Distributor SiteUrl not configured (has no value).");
            }
            if (string.IsNullOrWhiteSpace(this._applicationInformationService.GetApplicationDistributorInformation().ContactUrl))
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Application Distributor ContactUrl not configured (has no value).");
            }










            const string NOTDONE = "TODO";


            if (this._applicationInformationService.GetApplicationInformation().Name == NOTDONE)
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Application Name not configured (has no value).");
            }
            if (this._applicationInformationService.GetApplicationInformation().Description == NOTDONE)
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Application Description not configured (has no value).");
            }


            if (this._applicationInformationService.GetApplicationCreatorInformation().Name == NOTDONE)
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Application Creator Name not configured (has no value).");
            }
            if (this._applicationInformationService.GetApplicationCreatorInformation().Description == NOTDONE)
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Application Creator Description not configured (has no value).");
            }
            if (this._applicationInformationService.GetApplicationCreatorInformation().SiteUrl == NOTDONE)
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Application Creator SiteUrl not configured (has no value).");
            }
            if (this._applicationInformationService.GetApplicationCreatorInformation().ContactUrl == NOTDONE)
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Application Creator ContactUrl not configured (has no value).");
            }


            if (this._applicationInformationService.GetApplicationDistributorInformation().Name == NOTDONE)
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Application Distributor Name not configured (has no value).");
            }
            if (this._applicationInformationService.GetApplicationDistributorInformation().Description == NOTDONE)
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Application Distributor Description not configured (has no value).");
            }
            if (this._applicationInformationService.GetApplicationDistributorInformation().SiteUrl == NOTDONE)
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Application Distributor SiteUrl not configured (has no value).");
            }
            if (this._applicationInformationService.GetApplicationDistributorInformation().ContactUrl == NOTDONE)
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Application Distributor ContactUrl not configured (has no value).");
            }


        }
    }
}
