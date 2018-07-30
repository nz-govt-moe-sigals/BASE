using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using App.Core.Infrastructure.IDA.Models;
using App.Core.Infrastructure.IDA.Models.Implementations;
using App.Core.Infrastructure.IDA.Oidc;
using App.Core.Infrastructure.Services;
using global::Owin;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;

namespace App.Core.Infrastructure.IDA.Owin
{

    /// <summary>
    ///     Helper class to be invoked from within Application's Startup Configuration method,
    ///     to configure BearerToken Based Authentication, as is required to authenticate
    ///     requests to APIs (as oppossed to configuring for Cookies which is more in line
    ///     with ViewControllers. For that, see B2COAuthCookieBasedAuthenticationConfig).
    /// </summary>
    public class AuthBearerTokenAuthenticationConfiguration
    {
        // These values are pulled from web.config
        private static IAuthBearerTokenSettingsConfiguration _ib2COidcConfidentialClientSettingsConfiguration;

        private readonly IAzureKeyVaultService _keyVaultService;
        private readonly IOIDCNotificationHandlerService _oidcNotificationHandlerService;
        private IDiagnosticsTracingService _diagnosticsTracingService;


        public AuthBearerTokenAuthenticationConfiguration(IDiagnosticsTracingService diagnosticsTracingService,
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
            _ib2COidcConfidentialClientSettingsConfiguration = this._keyVaultService
                .GetObject<AuthBearerTokenSettingsConfiguration>("bearerTokenAuth:");


            // Configuring with an B2C url similar to:
            // https://login.microsoftonline.com/{authorityTenantName}/v2.0/.well-known/openid-configuration
            var openIdConnectCachingSecurityTokenProvider =
                new OpenIdConnectCachingSecurityTokenProvider(
                    _ib2COidcConfidentialClientSettingsConfiguration.AuthorityUri, 
                    _ib2COidcConfidentialClientSettingsConfiguration.PolicyIdB2C);
            


            // TokenValidationParameters: parameters used by System.IdentityModel.Tokens.SecurityTokenHandler validating System.IdentityModel.Tokens.SecurityToken.
            var tvps = new TokenValidationParameters()
            {
                // Accept only those tokens where the audience of the token is equal to the client ID of this app
                ValidAudiences = GetValidAudiences(), 
                // ensure that issuers are only what we deem are necessary, maybe dont want this in the future
                ValidIssuers = GetValidIssuers(openIdConnectCachingSecurityTokenProvider.Issuer),
                
            };


            var accessTokenFormat = new JwtFormat(tvps, openIdConnectCachingSecurityTokenProvider);

            // We're using OIDC, but that's really just a formal extension to OAuth, so tell the OWIN 
            // pipeline that we're adding an auth handler.
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {
                // This SecurityTokenProvider fetches the Azure AD B2C metadata & signing keys from the OpenIDConnect metadata endpoint
                AccessTokenFormat = accessTokenFormat,
                Provider = new OAuthBearerUserAuthenticationProvider(_oidcNotificationHandlerService)
            });
        }

        private HashSet<string> GetValidAudiences()
        {
            var validAudiences = new HashSet<string>
            {
                _ib2COidcConfidentialClientSettingsConfiguration.ClientId,
                _ib2COidcConfidentialClientSettingsConfiguration.AppIdUrl,
            };
            if (_ib2COidcConfidentialClientSettingsConfiguration.ClientIdB2C != null)
            {
                validAudiences.Add(_ib2COidcConfidentialClientSettingsConfiguration.ClientIdB2C);
                validAudiences.Add(_ib2COidcConfidentialClientSettingsConfiguration.AppIdUrlB2C);
            }

            return validAudiences;
        }


        /// <summary>
        /// The https://login.microsoftonline.com/ or https://sts.windows.net/ are both valid microsoft issuers for the same place 
        /// </summary>
        /// <param name="issuer"></param>
        /// <returns></returns>
        private HashSet<string> GetValidIssuers(string issuer)
        {
            var list = new HashSet<string>();
            string login = "https://login.microsoftonline.com";
            string sts = "https://sts.windows.net";
            if (issuer.Contains(login, StringComparison.InvariantCultureIgnoreCase) ||
                issuer.Contains(sts, StringComparison.InvariantCultureIgnoreCase))
            {
                
                MatchCollection guids = Regex.Matches(issuer, @"(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}"); //Match all substrings in findGuid
                if (guids.Count > 0)
                {
                    string guidIssuer = guids[0].Value;
                    list.Add($"{login}/{guidIssuer}/"); // add login
                    list.Add($"{login}/{guidIssuer}/v2.0/"); // prob come in as v2 but just to make sure
                    list.Add($"{sts}/{guidIssuer}/"); // add Sts
                }
            }

            if (list.Count == 0)
            {
                list.Add(issuer);
            }
            return list;
        }
    }
}