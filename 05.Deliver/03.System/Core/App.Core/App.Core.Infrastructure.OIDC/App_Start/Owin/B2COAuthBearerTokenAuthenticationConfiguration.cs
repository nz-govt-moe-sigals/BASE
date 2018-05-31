namespace App.Core.Infrastructure.IDA.Owin
{
    using System.IdentityModel.Tokens;
    using App.Core.Application.Oidc;
    using App.Core.Infrastructure.IDA.Models;
    using App.Core.Infrastructure.IDA.Services;
    using App.Core.Infrastructure.Services;
    using global::Owin;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.Owin.Security.Jwt;
    using Microsoft.Owin.Security.OAuth;

    /// <summary>
    ///     Helper class to be invoked from within Application's Startup Configuration method,
    ///     to configure BearerToken Based Authentication, as is required to authenticate
    ///     requests to APIs (as oppossed to configuring for Cookies which is more in line
    ///     with ViewControllers. For that, see B2COAuthCookieBasedAuthenticationConfig).
    /// </summary>
    public class B2COAuthBearerTokenAuthenticationConfiguration
    {
        // These values are pulled from web.config
        private static IB2COidcConfidentialClientConfiguration _b2cOidcConfidentialClientConfiguration;

        private readonly IAzureKeyVaultService _keyVaultService;
        private readonly IOIDCNotificationHandlerService _oidcNotificationHandlerService;
        private IDiagnosticsTracingService _diagnosticsTracingService;


        public B2COAuthBearerTokenAuthenticationConfiguration(IDiagnosticsTracingService diagnosticsTracingService,
            IAzureKeyVaultService keyVaultService, IOIDCNotificationHandlerService oidcNotificationHandlerService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
            this._keyVaultService = keyVaultService;
            this._oidcNotificationHandlerService = oidcNotificationHandlerService;
        }


        /*
         * Configure the authorization OWIN middleware 
         */
        public void Configure(IAppBuilder app)
        {
            // Retrieve settings from web.settings (actually, web.settings.appSettings.exclude):
            // We want the ClientId / CallbackUri relevent to this API service
            _b2cOidcConfidentialClientConfiguration = this._keyVaultService
                .GetObject<B2COidcConfidentialClientConfiguration>("bearerTokenAuth:");

            // TokenValidationParameters: parameters used by System.IdentityModel.Tokens.SecurityTokenHandler validating System.IdentityModel.Tokens.SecurityToken.
            var tvps =
                new TokenValidationParameters
                {
                    // Accept only those tokens where the audience of the token is equal to the client ID of this app
                    ValidAudience = _b2cOidcConfidentialClientConfiguration.ClientId,

                    AuthenticationType = _b2cOidcConfidentialClientConfiguration.DefaultPolicyId
                };

            var defaultIssuer = tvps.ValidateIssuer;
            var defaultAudience = tvps.ValidateAudience;

            // Configuring with an B2C url similar to:
            // https://login.microsoftonline.com/{authorityTenantName}/v2.0/.well-known/openid-configuration?p={policyId}
            var openIdConnectCachingSecurityTokenProvider =
                new OpenIdConnectCachingSecurityTokenProvider(
                    _b2cOidcConfidentialClientConfiguration.AuthorityBearerTokenConfigurationPolicyUri);
    

            var accessTokenFormat = new JwtFormat(tvps, openIdConnectCachingSecurityTokenProvider);

            // We're using OIDC, but that's really just a formal extension to OAuth, so tell the OWIN 
            // pipeline that we're adding an auth handler.
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {
                // This SecurityTokenProvider fetches the Azure AD B2C metadata & signing keys from the OpenIDConnect metadata endpoint
                AccessTokenFormat = accessTokenFormat
            });
        }
    }
}