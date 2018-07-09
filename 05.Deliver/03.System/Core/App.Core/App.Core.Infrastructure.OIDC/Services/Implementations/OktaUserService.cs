using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.IDA.Models;
using App.Core.Infrastructure.IDA.Models.Implementations;
using App.Core.Infrastructure.Services;

namespace App.Core.Infrastructure.IDA.Services.Implementations
{
    public class OktaUserService : IOktaUserService
    {
        private readonly IOktaOidcConfidentialClientConfiguration _oktaConfig;

        public OktaUserService(IAzureKeyVaultService keyVaultService)
        {
            _oktaConfig = keyVaultService
                .GetObject<OktaOidcConfidentialClientConfiguration>("bearerAuth:");
            //Honestly DO better but I am lazy atm
        }

        public IList<OktaUser> GetUserOktaUsers()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("SSWS", _oktaConfig.ApiKey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, _oktaConfig.OktaApiUri + "api/v1/users?limit=200");
                var response = client.SendAsync(requestMessage).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    var s = Newtonsoft.Json.JsonConvert.DeserializeObject<List<OktaUser>>(result);
                    return s;
                }

                throw new Exception(response.ReasonPhrase);
            }
        }

    }
}
