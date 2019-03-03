namespace App.Core.Infrastructure.IDA.Services.Implementations
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web;
    using App.Core.Infrastructure.IDA.Models;
    using App.Core.Infrastructure.Services;

    public class OIDCAPIClientService : IOIDCAPIClientService
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;

        public OIDCAPIClientService(IDiagnosticsTracingService diagnosticsTracingService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
        }

        public Task<HttpResponseMessage> MakeRequestAsync(
            IOidcSettingsConfidentialClientConfiguration oidcSettingsConfidentialClientConfiguration,
            string authorityUriOverride,
            HttpContextBase httpContextBase,
            string[] fqScopes,
            HttpMethod verb,
            Uri apiUri)
        {
            var oidcRequestHelper = new OidcRequestHelper(this._diagnosticsTracingService);

            return oidcRequestHelper.MakeRequestAsync(
                oidcSettingsConfidentialClientConfiguration,
                authorityUriOverride,
                httpContextBase,
                fqScopes,
                verb,
                apiUri);
        }

        public Task<HttpResponseMessage> MakeRequestAsync(
            IOidcSettingsConfidentialClientConfiguration oidcSettingsConfidentialClientConfiguration,
            string authorityUriOverride,
            HttpContextBase httpContextBase,
            string[] fqScopes,
            HttpRequestMessage httpRequestMessage)
        {
            var oidcRequestHelper = new OidcRequestHelper(this._diagnosticsTracingService);

            return oidcRequestHelper.MakeRequestAsync(
                oidcSettingsConfidentialClientConfiguration,
                authorityUriOverride,
                httpContextBase,
                fqScopes,
                httpRequestMessage
            );
        }
        //        switch (response.StatusCode)


        //        // Handle the response
        //        {
        //            case HttpStatusCode.OK:
        //                String responseString = await response.Content.ReadAsStringAsync();
        //                return response;
        //                break;
        //            default:
        //                return response;
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var r = new HttpResponseMessage();
        //        r.StatusCode = HttpStatusCode.InternalServerError;
        //        return r;
        //    }
        //}
    }
}