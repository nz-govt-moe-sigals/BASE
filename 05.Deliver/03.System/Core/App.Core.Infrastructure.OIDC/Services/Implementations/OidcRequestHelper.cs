namespace App.Core.Infrastructure.IDA.Services
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Web;
    using App.Core.Application.Oidc;
    using App.Core.Infrastructure.IDA.Models;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;
    using Microsoft.Identity.Client;

    public class OidcRequestHelper
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;

        public OidcRequestHelper(IDiagnosticsTracingService diagnosticsTracingService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
        }
        public async Task<HttpResponseMessage> MakeRequestAsync(
            IOIDCConfidentialClientConfiguration oidcConfidentialClientConfiguration,
            string authorityUriOverride, HttpContextBase httpContextBase, string[] fqScopes, HttpMethod verb,
            Uri apiUri)
        {
            var httpRequestMessage = new HttpRequestMessage(verb, apiUri);

            return await MakeRequestAsync(oidcConfidentialClientConfiguration, authorityUriOverride, httpContextBase,
                fqScopes,
                httpRequestMessage);
        }

        public async Task<HttpResponseMessage> MakeRequestAsync(
            IOIDCConfidentialClientConfiguration oidcConfidentialClientConfiguration, string authorityUriOverride,
            HttpContextBase httpContextBase, string[] fqScopes, HttpRequestMessage httpRequestMessage)
        {
            var authorityUri = authorityUriOverride ?? oidcConfidentialClientConfiguration.AuthorityUri;

            var confidentialClientApplication =
                CreateConfidentialClientApplication(httpContextBase, authorityUriOverride,
                    oidcConfidentialClientConfiguration);

            var accessToken = await AcquireTokenSilently(confidentialClientApplication, authorityUri, fqScopes);

            var client = new HttpClient();

            AttachBearerToken(httpRequestMessage, accessToken);

            var response = await client.SendAsync(httpRequestMessage);
            return response;
        }

        /// <summary>
        ///     A helper method to create a ConfidentialClientApplication
        ///     required to retrieve the token that is needed to be attached
        ///     as a Bearer Token to a Request.
        ///     <para>
        ///         This code is for an AAD (it's using AuthenticationUri, rather than .AuthorityCookieConfigurationPolicyUri)
        ///     </para>
        /// </summary>
        public ConfidentialClientApplication CreateConfidentialClientApplication(
            HttpContextBase httpContextBase,
            string authorityUriOverride,
            IOIDCConfidentialClientConfiguration oidcConfidentialClientConfiguration,
            params string[] fqScopes)
        {
            // ** IMPORTANT**
            // The calls to AAD and B2C are mostly the same bar the following:
            // For AAD, use .AuthorityUri
            var authorityUri = authorityUriOverride ?? oidcConfidentialClientConfiguration.AuthorityUri;
            var signedInUserIdentifier = ClaimsPrincipal.Current.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userTokenCache = new MSALSessionCache(signedInUserIdentifier, httpContextBase).GetMsalCacheInstance();
            TokenCache appTokenCache = null;

            var confidentialClientApplication = new ConfidentialClientApplication(
                oidcConfidentialClientConfiguration.ClientId,
                authorityUri /*note...*/,
                oidcConfidentialClientConfiguration.ClientRedirectUri,
                new ClientCredential(oidcConfidentialClientConfiguration.ClientSecret),
                userTokenCache,
                appTokenCache);

            return confidentialClientApplication;
        }

        /// <summary>
        ///     Helper method to silently retrieve a valid Access Token
        ///     that contains the needed scope.
        /// </summary>
        /// <param name="confidentialClientApplication"></param>
        /// <param name="authority"></param>
        /// <param name="fqScopes"></param>
        /// <returns></returns>
        public async Task<string> AcquireTokenSilently(ConfidentialClientApplication confidentialClientApplication,
            string authority, string[] fqScopes)
        {
            var user = confidentialClientApplication.Users.FirstOrDefault();

            //        if (user == null)
            //        {
            //            throw new Exception(
            //                "The User is NULL.  Please clear your cookies and try again.  Specifically delete cookies for 'login.microsoftonline.com'.  See this GitHub issue for more details: https://github.com/Azure-Samples/active-directory-b2c-dotnet-webapp-and-webapi/issues/9");
            //        }
            using (ElapsedTime elapsedTime = new ElapsedTime())
            {
                var result = await confidentialClientApplication.AcquireTokenSilentAsync(
                    fqScopes,
                    user,
                    authority,
                    false
                );
                var elapsed = elapsedTime.ElapsedText;

                this._diagnosticsTracingService.Trace(TraceLevel.Debug, $"OidcRequestHelper.AcquireTokenSilently took {elapsed}.");
                return result.AccessToken;
            }


        }

        /// <summary>
        ///     Helper method to attach the given Access Token as a Bearer Token
        ///     to an outgoing API request.
        /// </summary>
        /// <param name="httpRequestMessage"></param>
        /// <param name="accessToken"></param>
        public void AttachBearerToken(HttpRequestMessage httpRequestMessage, string accessToken)
        {
            // Add token to the Authorization header and make the request
            httpRequestMessage.Headers.Authorization
                = new AuthenticationHeaderValue("Bearer", accessToken);

            //Alternatly, add it to the httpClient:
            //httpClient.DefaultRequestHeaders.Authorization =
            //    new System.Net.Http.Headers.AuthenticationHeaderValue("bearer",);
        }
    }
}