using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using App.Module32.Ux.Tests.Models;
using App.Module32.Ux.Tests.Utility;
using Microsoft.Identity.Client;

namespace App.Module32.Ux.Tests.Fixture
{
    public class TokenFixture : IDisposable
    {
        //private string _token;

        private AuthenticationResult _authenticationResult;
        //
        // The Client ID is used by the application to uniquely identify itself to Azure AD.
        // The App Key is a credential used by the application to authenticate to Azure AD.
        // The Tenant is the name of the Azure AD tenant in which this application is registered.
        // The AAD Instance is the instance of Azure, for example public Azure or Azure China.
        // The Authority is the sign-in URL of the tenant.
        //
        private string aadInstance = Configuration.Instance.AadInstance;
        private string tenant = Configuration.Instance.Tenant;
        private string clientId = Configuration.Instance.ClientId;
        private string appKey = Configuration.Instance.Appkey;

        private readonly HttpClient _httpClient;
        SemaphoreSlim _mutex = new SemaphoreSlim(1);

        private  string redirectUri = Configuration.Instance.RedirectUri;

        private string authority;

        //
        // To authenticate to the To Do list service, the client needs to know the service's App ID URI.
        // To contact the To Do list service we need it's URL as well.
        //
        private static string todoListResourceId = "https://BaseCommonTest.onmicrosoft.com/ADBaseTestWebApi";

        public TokenFixture()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            authority= String.Format(CultureInfo.InvariantCulture, aadInstance, tenant);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                                                   SecurityProtocolType.Tls11 |
                                                   SecurityProtocolType.Tls12;
        }

        public string GetAuthToken()
        {
            if (_authenticationResult == null)
            {
                var clientCredential = new ClientCredential(appKey);
                //am not bothering with inbuilt caching mech, as tests won't take that that long to run
                ConfidentialClientApplication daemonClient = new ConfidentialClientApplication(clientId, authority, redirectUri, clientCredential, null, new TokenCache());
                _authenticationResult = daemonClient.AcquireTokenForClientAsync(new string[] { todoListResourceId + "/.default" }).Result;
            }
            return _authenticationResult.AccessToken;
        }

        /// <summary>
        /// Testing Purposes only, This will not be available to be used live, as permissions will differ
        /// </summary>
        /// <param name="studentDto"></param>
        public void InsertStudent(StudentDto studentDto)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var url = Configuration.Instance.DefaultUrl + "/odata/ate/v1/students";
                var dto = Newtonsoft.Json.JsonConvert.SerializeObject(studentDto);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", GetAuthToken());
                // Add token to the Authorization header and make the request
                var content = new StringContent(dto, Encoding.UTF8, "application/json");
                var response = client.PostAsync(new Uri(url), content).Result;
                if (!response.IsSuccessStatusCode) throw new Exception($"response {response.StatusCode}");
            }
        }

        /// <summary>
        /// Testing Purposes only, This will not be available to be used live, as permissions will differ
        /// </summary>
        /// <param name="schoolDto"></param>
        public void InsertSchool(SchoolDto schoolDto)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var url = Configuration.Instance.DefaultUrl + "/odata/ate/v1/schools";
                var dto = Newtonsoft.Json.JsonConvert.SerializeObject(schoolDto);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetAuthToken());
                // Add token to the Authorization header and make the request
                var content = new StringContent(dto, Encoding.UTF8, "application/json");
                var response = client.PostAsync(new Uri(url), content).Result;
                if (!response.IsSuccessStatusCode) throw new Exception($"response {response.StatusCode}");
            }
                
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
