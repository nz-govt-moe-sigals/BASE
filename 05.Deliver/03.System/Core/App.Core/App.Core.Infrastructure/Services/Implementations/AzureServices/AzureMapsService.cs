using System;
using App.Core.Infrastructure.Services.Configuration.Implementations;
using App.Core.Infrastructure.Services.Configuration.Implementations.AzureConfiguration;
using App.Core.Shared.Models.Messages;

namespace App.Core.Infrastructure.Services.Implementations.AzureServices
{
    public class AzureMapsService : AppCoreServiceBase, IAzureMapsService
    {
        private readonly AzureMapServiceConfiguration _azureMapServiceConfiguration;
        private readonly IAzureDeploymentEnvironmentService _azureDeploymentEnvironmentService;
        private readonly IRestService _restService;

        public AzureMapsService(AzureMapServiceConfiguration azureMapServiceConfiguration, IAzureDeploymentEnvironmentService azureDeploymentEnvironmentService, IRestService restService)
        {
            _azureMapServiceConfiguration = azureMapServiceConfiguration;
            _azureDeploymentEnvironmentService = azureDeploymentEnvironmentService;
            _restService = restService;
        }

            public AzureMapsSearchResponse AddressSearch(string searchTerm, string countrySetCsv, bool typeAhead = true)
        {

            string subscriptionKey = _azureMapServiceConfiguration.Key;

            Uri uri = new Uri(
                _azureMapServiceConfiguration.RootUri
                + $"/search/address/json?subscription-key={subscriptionKey}&api-version=1.0&query={searchTerm}&limit=10&countrySet={countrySetCsv}");

            //&typeahead ={ typeahead}
            //&limit ={ limit}
            //&ofs ={ ofs}
            //&countrySet ={ countrySet}
            //&lat ={ lat}
            //&lon ={ lon}
            //&radius ={ radius}
            //&topLeft ={ topLeft}
            //&btmRight ={ btmRight}
            //&language ={ language}
            //&extendedPostalCodesFor ={ extendedPostalCodesFor}

            AzureMapsSearchResponse result = _restService.Get<AzureMapsSearchResponse>(uri, null);

            return result;
        }


        public AzureMapsReverseSearchResponse ReverseAddressSearch(decimal latitude, decimal longtitude)
        {
            Guid subscriptionKey = _azureDeploymentEnvironmentService.SubscriptionId;


                Uri uri = new Uri(
                    _azureMapServiceConfiguration.RootUri 
                    + $"/search/address/reverse/json?subscription-key={subscriptionKey}&api-version=1.0&query={latitude},{longtitude}");

            AzureMapsReverseSearchResponse result = _restService.Get<AzureMapsReverseSearchResponse>(uri, null);

            return result;
        }


    }
}
