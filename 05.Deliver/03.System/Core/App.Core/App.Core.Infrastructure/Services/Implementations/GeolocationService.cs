using App.Core.Infrastructure.Services.Configuration.Implementations;
using App.Core.Shared.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace App.Core.Infrastructure.Services.Implementations
{
    public class GeoIPService : AppCoreServiceBase, IGeoIPService
    {
        private readonly GeoIPServiceConfiguration _geolocationServiceConfiguration;

        public GeoIPService(GeoIPServiceConfiguration geolocationServiceConfiguration)
        {
            _geolocationServiceConfiguration = geolocationServiceConfiguration;
        }

        public GeoInformation Get(string ip)
        {
            using (var httpClient = new HttpClient())
            {
                var url = _geolocationServiceConfiguration.Configuration.BaseUri + CreateQueryString(ip);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = httpClient.SendAsync(request).Result;
                var json = response.Content.ReadAsStringAsync().Result;
                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<GeoInformation>(json);
                return obj;
            }
                
        }

        public string CreateQueryString(string ip)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["subscription-key"] = _geolocationServiceConfiguration.Configuration.Secret;
            query["api-version"] = "1.0";
            query["ip"] = ip;
            return "?" + query.ToString();
        }


    }
}
