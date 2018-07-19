using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Identity.Client;
using Xbehave;

namespace App.Core.Infrastructure.IDA.v2.Ux.Tests
{
    public class TokenV2Test
    {
        //
        // The Client ID is used by the application to uniquely identify itself to Azure AD.
        // The App Key is a credential used by the application to authenticate to Azure AD.
        // The Tenant is the name of the Azure AD tenant in which this application is registered.
        // The AAD Instance is the instance of Azure, for example public Azure or Azure China.
        // The Authority is the sign-in URL of the tenant.
        //
        private static string aadInstance = "https://login.microsoftonline.com/{0}/v2.0/";
        private static string tenant = "BaseCommonTest.onmicrosoft.com";
        private static string clientId = "965b20c2-d1a1-44ad-8c5d-e426dfcddae0";
        private static string appKey = "H6Ynryccyl7X3tuo11eZ5ycbhOfiaLVQUpGkjGqY48g=";
        
        
        private static string redirectUri = "https://basecommontest.onmicrosoft.com/ADDaemon";

        static string authority = String.Format(CultureInfo.InvariantCulture, aadInstance, tenant);

        //
        // To authenticate to the To Do list service, the client needs to know the service's App ID URI.
        // To contact the To Do list service we need it's URL as well.
        //
        private static string todoListResourceId = "https://BaseCommonTest.onmicrosoft.com/ADBaseTestWebApi";
        // private static string todoListBaseAddress = ConfigurationManager.AppSettings["todo:TodoListBaseAddress"];

        private readonly string _baseurl;

        public TokenV2Test()
        {
            _baseurl = Configuration.Instance.DefaultUrl;
        }


        [Scenario(DisplayName = "Get a AuthenticationToken from Azure")]
        public void GetTokenFromAzure()
        {
            AuthenticationResult token = null;
            "When I request a Token"
                .x(async () =>
                {
                    var clientCredential = new ClientCredential(appKey);
                    ConfidentialClientApplication daemonClient = new ConfidentialClientApplication(clientId, authority, redirectUri, clientCredential, null, new TokenCache());
                    token = await daemonClient.AcquireTokenForClientAsync(new string[] { "https://graph.microsoft.com/.default" });
                });
            "Then the token should not not be null"
                .x(() =>
                {
                    token.Should().NotBeNull(because: "I Just got it no?");
                });
        }

        [Scenario(DisplayName = "Call a webservice that is protected With Token")]
        public void CallWebServiceWithToken()
        {
            AuthenticationResult token = null;
            HttpResponseMessage response = null;
            "When I request a Token"
                .x(async () =>
                {
                    var clientCredential = new ClientCredential(appKey);
                    ConfidentialClientApplication daemonClient = new ConfidentialClientApplication(clientId, authority, redirectUri, clientCredential, null, new TokenCache());
                    token = await daemonClient.AcquireTokenForClientAsync(new string[] { todoListResourceId + "/.default" });
                });
            "And I make a Http Request to a restricted API"
                .x(async () =>
                {
                    HttpClient client = new HttpClient();
                    HttpRequestMessage request =
                        new HttpRequestMessage(HttpMethod.Get, "https://localhost:44332/api/tasks");
                                                                                              //_baseurl + "OData/core/v1/tenant");

                    // Add token to the Authorization header and make the request
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
                    response = await client.SendAsync(request);
                });
            "Then the response should not be null and successful"
                .x(() =>
                {
                    response.Should().NotBeNull();
                    response.IsSuccessStatusCode.Should().BeTrue();
                });
        }

        [Scenario(DisplayName = "Call a webservice that is protected Without Token Forbidden")]
        public void CallWebServiceForbidden()
        {
            HttpResponseMessage response = null;
            "When I make a Http Request to a restricted API"
                .x(async () =>
                {
                    HttpClient client = new HttpClient();
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _baseurl + "OData/core/v1/tenant");
                    response = await client.SendAsync(request);
                });
            "Then the response should not be null but forbidden successful"
                .x(() =>
                {
                    response.Should().NotBeNull();
                    response.IsSuccessStatusCode.Should().BeFalse();
                    response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
                });
        }

    }
}
