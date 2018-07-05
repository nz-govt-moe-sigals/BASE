using System.Threading.Tasks;
using App.Core.Infrastructure.IDA.Models;
using App.Core.Infrastructure.IDA.Models.Implementations;
using App.Core.Infrastructure.Services;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;

namespace App.Core.Infrastructure.IDA.Owin
{
    public class OktaOAuthBearerTokenAuthenticationConfig
    {
        private readonly IAzureKeyVaultService _keyHostSettingsService;
        private static IOktaOidcConfidentialClientConfiguration _oktaOidcConfidentialClientConfiguration;

        public OktaOAuthBearerTokenAuthenticationConfig(IAzureKeyVaultService keyVaultService)
        {
            this._keyHostSettingsService = keyVaultService;
        }

        public void Configure(IAppBuilder app)
        {
            _oktaOidcConfidentialClientConfiguration = this._keyHostSettingsService
                .GetObject<OktaOidcConfidentialClientConfiguration>("bearerAuth:");

            var authority = _oktaOidcConfidentialClientConfiguration.AuthorityUri;

            var configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                authority + "/.well-known/openid-configuration",
                new OpenIdConnectConfigurationRetriever(),
                new HttpDocumentRetriever());

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidAudience = "api://default",
                    ValidIssuer = authority,
                    IssuerSigningKeyResolver = (token, securityToken, identifier, parameters) =>
                    {
                        var discoveryDocument = Task.Run(() => configurationManager.GetConfigurationAsync()).GetAwaiter().GetResult();
                        return discoveryDocument.SigningKeys;
                    }
                }
            });
        }

    }
}
