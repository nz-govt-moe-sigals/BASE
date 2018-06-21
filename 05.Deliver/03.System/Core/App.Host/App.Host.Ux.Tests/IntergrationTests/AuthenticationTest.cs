using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using FluentAssertions;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xbehave;

namespace App.Host.Ux.Tests.IntergrationTests
{
    public class AuthenticationTest
    {

        //
        // The Client ID is used by the application to uniquely identify itself to Azure AD.
        // The App Key is a credential used by the application to authenticate to Azure AD.
        // The Tenant is the name of the Azure AD tenant in which this application is registered.
        // The AAD Instance is the instance of Azure, for example public Azure or Azure China.
        // The Authority is the sign-in URL of the tenant.
        // https://github.com/azure-samples/active-directory-dotnet-daemon#step-2--register-the-sample-with-your-azure-active-directory-tenant
        private static string aadInstance = "https://login.microsoftonline.com/{0}";
        private static string tenant = "BaseCommonConsumerTest.onmicrosoft.com";
        private static string clientId = "4aeeb16c-e95b-4a98-89e9-defd2d01090a";
        private static string appKey = "zX1GziuGWDWIZX4e4T8xLwgnViL+RrkFyq6khmlr1Ak=";

        static string authority = String.Format(CultureInfo.InvariantCulture, aadInstance, tenant);

        //
        // To authenticate to the To Do list service, the client needs to know the service's App ID URI.
        // To contact the To Do list service we need it's URL as well.
        //
        private static string todoListResourceId = "https://BaseCommonConsumerTest.onmicrosoft.com/9dc80431-8f1d-49bb-960d-c70bc96ef87f";
       // private static string todoListBaseAddress = ConfigurationManager.AppSettings["todo:TodoListBaseAddress"];

        private readonly string _baseurl;

        public AuthenticationTest()
        {
            _baseurl = Configuration.Instance.DefaultUrl;
        }


        [Scenario(DisplayName = "Get a AuthenticationToken from Azure")]
        public void GetTokenFromAzure()
        {
            AuthenticationResult token = null;
            "Given a ser"
                .x(async () =>
                {
                    var authContext = new AuthenticationContext(authority);
                    var clientCredential = new ClientCredential(clientId, appKey);
                    // ADAL includes an in memory cache, so this call will only send a message to the server if the cached token is expired.
                    token = await authContext.AcquireTokenAsync(todoListResourceId, clientCredential);

                });
            "When a user requests the secure home page"
                .x(() =>
                {
                    
                });
            "Then the response should not have a Server header"
                .x(() =>
                {
                    token.Should().NotBeNull(because: "I Just got it no?");
                });
        }

    }
}
