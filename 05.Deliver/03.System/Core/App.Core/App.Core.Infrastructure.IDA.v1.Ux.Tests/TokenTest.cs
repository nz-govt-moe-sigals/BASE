using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using FluentAssertions;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xbehave;

namespace App.Core.Infrastructure.IDA.v1.Ux.Tests
{
    public class TokenTest
    {
        //
        // The Client ID is used by the application to uniquely identify itself to Azure AD.
        // The App Key is a credential used by the application to authenticate to Azure AD.
        // The Tenant is the name of the Azure AD tenant in which this application is registered.
        // The AAD Instance is the instance of Azure, for example public Azure or Azure China.
        // The Authority is the sign-in URL of the tenant.
        //
        private static string aadInstance = "https://login.microsoftonline.com/{0}";
        private static string tenant = "BaseCommonTest.onmicrosoft.com";
        //private static string clientId = "2c72f81f-d82c-4b66-9cb9-cf689a177a24";
        //private static string appKey = "Pb&\"L6]F7588\"75]fSqieA0%";

        private static string clientId = "965b20c2-d1a1-44ad-8c5d-e426dfcddae0";
        private static string appKey = "H6Ynryccyl7X3tuo11eZ5ycbhOfiaLVQUpGkjGqY48g=";

        static string authority = String.Format(CultureInfo.InvariantCulture, aadInstance, tenant);

       
        //should match web.config is App.Host
        private static string resourceIdOfAppToConnectTo = "https://BaseCommonTest.onmicrosoft.com/ADBaseTestWebApi"; 


        private readonly string _baseurl;

        public TokenTest()
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
                    var authContext = new AuthenticationContext(authority);
                    var clientCredential = new ClientCredential(clientId, appKey);
                    //var x = await authContext.GetAuthorizationRequestUrlAsync(resourceIdOfAppToConnectTo, clientId, new Uri("https://localhost/"), UserIdentifier.AnyUser, );
                    // ADAL includes an in memory cache, so this call will only send a message to the server if the cached token is expired.
                    token = await authContext.AcquireTokenAsync(resourceIdOfAppToConnectTo, clientCredential);
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
                    var authContext = new AuthenticationContext(authority);
                    var clientCredential = new ClientCredential(clientId, appKey);
                    // ADAL includes an in memory cache, so this call will only send a message to the server if the cached token is expired.
                    token = await authContext.AcquireTokenAsync(resourceIdOfAppToConnectTo, clientCredential);
                });
            "And I make a Http Request to a restricted API"
                .x(async () =>
                {
                    HttpClient client = new HttpClient();
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                        "https://localhost:44311/OData/core/v1/tenant");
                    //"https://localhost:44324/api/todolist");
                    //"https://localhost:44321/api/todolist");
                    //"https://localhost:44332" + "/api/tasks");

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

