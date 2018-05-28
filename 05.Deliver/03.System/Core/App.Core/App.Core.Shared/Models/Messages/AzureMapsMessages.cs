using Newtonsoft.Json;
using System.Collections.Generic;

namespace App.Core.Shared.Models.Messages
{

    public class AzureMapsSearchResponse
    {
        [JsonProperty("results")]
        public AzureMapsSearchResponseResult[] Results { get; set; }
    }
    public class AzureMapsReverseSearchResponse
    {
        [JsonProperty("addresses")]
        public List<AzureMapsResponseAddress> Addresses
        {
            get { return _addresses ?? (_addresses = new List<AzureMapsResponseAddress>()); }
        }
        List<AzureMapsResponseAddress> _addresses;
    }


    public class AzureMapsSearchResponseResult
    {
        [JsonProperty("results")]
        string Type { get; set; }
        [JsonProperty("score")]
        string Score { get; set; }
        [JsonProperty("address")]
        public AzureMapsResponseAddress Address { get; set; }
        [JsonProperty("position")]
        public AzureMapResponsePosition Position { get; set; }
    }

    public class AzureMapResponsePosition
    {
        [JsonProperty("lat")]
        public string Latitude { get; set; }
        [JsonProperty("long")]
        public string Longitude { get; set; }
    }


    public class AzureMapsResponseAddress
    {
        [JsonProperty("buildingNumber")]
        public string BuildingNumber { get; set; }
        [JsonProperty("streetNumber")]
        public string StreetNumber { get; set; }
        [JsonProperty("street")]
        public string Street { get; set; }
        [JsonProperty("streetName")]
        public string StreetName { get; set; }
        [JsonProperty("streetNameAndNumber")]
        public string StreetNameAndNumber { get; set; }
        [JsonProperty("municipality")]
        public string Municipality { get; set; }
        [JsonProperty("countrySubdivision")]
        public string CountrySubdivision { get; set; }
        [JsonProperty("countrySubdivisionName")]
        public string CountrySubdivisionName { get; set; }
        [JsonProperty("countryCodeISO3")]
        public string CountryCodeISO3 { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
        [JsonProperty("extendedPostalCode")]
        public string PostalCodeExtended { get; set; }

        [JsonProperty("freeformAddress")]
        public string FreeFormAddress { get; set; }

        public string ExtendedFreeFormAddress { get {
            return this.FreeFormAddress  + ", " + this.Country;
            }
        }

        [JsonProperty("streetNumber")]
        public string[] RouteNumbers { get; set; }
    }


}

