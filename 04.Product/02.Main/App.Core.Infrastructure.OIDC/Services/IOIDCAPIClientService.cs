namespace App.Core.Infrastructure.IDA.Services
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web;
    using App.Core.Infrastructure.IDA.Models;

    /// <summary>
    ///     Contract for a Service to manage API Calls,
    ///     while handling the pre-attachment of BearerTokens.
    /// </summary>
    public interface IOIDCAPIClientService
    {
        Task<HttpResponseMessage> MakeRequestAsync(
            IOIDCConfidentialClientConfiguration oidcConfidentialClientConfiguration,
            string authorityUriOverride,
            HttpContextBase httpContextBase,
            string[] fqScopes,
            HttpMethod verb,
            Uri apiUri);

        Task<HttpResponseMessage> MakeRequestAsync(
            IOIDCConfidentialClientConfiguration oidcConfidentialClientConfiguration,
            string authorityUriOverride,
            HttpContextBase httpContextBase,
            string[] fqScopes,
            HttpRequestMessage httpRequestMessage);
    }
}