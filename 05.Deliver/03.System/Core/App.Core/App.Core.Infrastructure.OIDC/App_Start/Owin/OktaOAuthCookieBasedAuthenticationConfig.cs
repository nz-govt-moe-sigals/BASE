
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Configuration;
using System.Security.Claims;
using IdentityModel.Client;
using System;
using System.Collections.Generic;
using App.Core.Infrastructure.IDA.Models;
using App.Core.Infrastructure.IDA.Models.Implementations;
using App.Core.Infrastructure.Services;
using Microsoft.IdentityModel.Tokens;

namespace App.Core.Infrastructure.IDA.Owin
{
    public class OktaOAuthCookieBasedAuthenticationConfig
    {
        private readonly IAzureKeyVaultService _keyHostSettingsService;
        private static IOktaOidcConfidentialClientConfiguration _oktaOidcConfidentialClientConfiguration;

        public OktaOAuthCookieBasedAuthenticationConfig(IAzureKeyVaultService keyVaultService)
        {
            this._keyHostSettingsService = keyVaultService;
        }

        public void Configure(IAppBuilder app, string[] fullyQualifiedScopesRequiredByTargetAPI)
        {
            _oktaOidcConfidentialClientConfiguration = this._keyHostSettingsService
                .GetObject<OktaOidcConfidentialClientConfiguration>("cookieAuth:");

            string clientId = _oktaOidcConfidentialClientConfiguration.ClientId;
            string clientSecret = _oktaOidcConfidentialClientConfiguration.ClientSecret;
            string authority = _oktaOidcConfidentialClientConfiguration.AuthorityUri;
            string redirectUri = _oktaOidcConfidentialClientConfiguration.ClientRedirectUri;
            string postLogoutRedirectUri = _oktaOidcConfidentialClientConfiguration.ClientPostLogoutUri;


            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                Authority = authority,
                RedirectUri = redirectUri,
                ResponseType = OpenIdConnectResponseType.CodeIdToken,
                Scope = OpenIdConnectScope.OpenIdProfile,
                PostLogoutRedirectUri = postLogoutRedirectUri,
                TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name"
                },

                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    AuthorizationCodeReceived = async n =>
                    {
                        // Exchange code for access and ID tokens
                        var tokenClient = new TokenClient(authority + "/v1/token", clientId, clientSecret);
                        var tokenResponse = await tokenClient.RequestAuthorizationCodeAsync(n.Code, redirectUri);

                        if (tokenResponse.IsError)
                        {
                            throw new Exception(tokenResponse.Error);
                        }

                        var userInfoClient = new UserInfoClient(authority + "/v1/userinfo");
                        var userInfoResponse = await userInfoClient.GetAsync(tokenResponse.AccessToken);
                        var claims = new List<Claim>();
                        claims.AddRange(userInfoResponse.Claims);
                        claims.Add(new Claim("id_token", tokenResponse.IdentityToken));
                        claims.Add(new Claim("access_token", tokenResponse.AccessToken));

                        if (!string.IsNullOrEmpty(tokenResponse.RefreshToken))
                        {
                            claims.Add(new Claim("refresh_token", tokenResponse.RefreshToken));
                        }

                        n.AuthenticationTicket.Identity.AddClaims(claims);

                        return;
                    },

                    RedirectToIdentityProvider = n =>
                    {
                        // If signing out, add the id_token_hint
                        if (n.ProtocolMessage.RequestType == OpenIdConnectRequestType.Logout)
                        {
                            var idTokenClaim = n.OwinContext.Authentication.User.FindFirst("id_token");

                            if (idTokenClaim != null)
                            {
                                n.ProtocolMessage.IdTokenHint = idTokenClaim.Value;
                            }

                        }

                        return Task.CompletedTask;
                    }
                },
            });
        }
    }
}
