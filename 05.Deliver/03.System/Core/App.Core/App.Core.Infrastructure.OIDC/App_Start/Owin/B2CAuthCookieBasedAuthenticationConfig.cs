using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using App.Core.Application.Oidc;
using App.Core.Infrastructure.IDA.Models;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.Messages;
using global::Owin;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Notifications;
using Microsoft.Owin.Security.OpenIdConnect;
using App.Core.Infrastructure.IDA.Models.Implementations.WebApp;

namespace App.Core.Infrastructure.IDA.Owin
{

    /// <summary>
    ///     Helper class to be invoked from within Application's Startup Configuration method,
    ///     in order to configure Cookie Based Authentication, as is required to authenticate
    ///     access to Server generated View Controllers (ie MVC pages).
    ///     For configuring for BearerTokens as is required for controlling access to API Controllers
    ///     see B2COAuthBearerTokenAuthenticationConfiguration
    /// </summary>
    public class B2CAuthCookieBasedAuthenticationConfig
    {
        // These values are pulled from web.config
        private static IB2COidcConfidentialClientSettingsConfiguration _ib2COidcConfidentialClientSettingsConfiguration;

        // The scopes of the remote api to ask for.
        private static string[] _fullyQualifiedScopesRequiredByTargetApi;

        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly IAzureKeyVaultService _keyHostSettingsService;
        private static IOIDCNotificationHandlerService _oidcNotificationHandlerService;

        public B2CAuthCookieBasedAuthenticationConfig(IDiagnosticsTracingService diagnosticsTracingService,
            IAzureKeyVaultService keyVaultService,
            IOIDCNotificationHandlerService oidcNotificationHandlerService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
            this._keyHostSettingsService = keyVaultService;

            //NOTE: static!
            _oidcNotificationHandlerService = oidcNotificationHandlerService;
        }


        /// <summary>
        ///     Configure the OWIN MiddleWare
        ///     <para>
        ///         Note how Scopes are FQ'ed, with the Service Identifier prefix (with slash)
        ///         to look like "https://fabrikamb2c.onmicrosoft.com/tasks/read"
        ///         or "https://fabrikamb2c.onmicrosoft.com/tasks/write"
        ///     </para>
        /// </summary>
        /// <param name="app"></param>
        /// <param name="fullyQualifiedScopesRequiredByTargetApi"></param>
        public void Configure(IAppBuilder app, string[] fullyQualifiedScopesRequiredByTargetApi)
        {
            _fullyQualifiedScopesRequiredByTargetApi = fullyQualifiedScopesRequiredByTargetApi;
            // Retrieve settings from web.settings (actually, web.settings.appSettings.exclude):
            _ib2COidcConfidentialClientSettingsConfiguration = this._keyHostSettingsService
                .GetObject<B2COidcConfidentialSettingsClientConfiguration>("cookieAuth:");


            // IMPORTANT:
            // Differences between AAD and B2C include:
            // * differnt Uri (not AuthorityUri -- using AuthorityCookieConfigurationUri).


            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            // Specify the claims to validate
            var tokenValidationParameters = new TokenValidationParameters
            {
                //// The signing key must match!
                //ValidateIssuerSigningKey = true,
                //IssuerSigningKey = signingKey,

                //// Validate the JWT Issuer (iss) claim
                //ValidateIssuer = true,
                //ValidIssuer = "ExampleIssuer",

                //// Validate the JWT Audience (aud) claim
                //ValidateAudience = true,
                //ValidAudience = "ExampleAudience",

                ClockSkew = TimeSpan.FromSeconds(30),

                NameClaimType = "name"
            };

            var openIdConnectAuthenticationOptions =
                new OpenIdConnectAuthenticationOptions
                {
                    // Whereas AAD V2 login does not require this, need to set for B2C.
                    MetadataAddress = _ib2COidcConfidentialClientSettingsConfiguration.AuthorityUri,

                    ClientId = _ib2COidcConfidentialClientSettingsConfiguration.ClientId,
                    RedirectUri = _ib2COidcConfidentialClientSettingsConfiguration.ClientRedirectUri,
                    PostLogoutRedirectUri = _ib2COidcConfidentialClientSettingsConfiguration.ClientPostLogoutUri,

                    // Specify the scope by appending all of the scopes requested into one string (separated by a blank space)
                    Scope =
                        $"{OpenIdConnectScope.OpenIdProfile} {OpenIdConnectScope.OfflineAccess} {OpenIdConnectScope.Email}  {string.Join(" ", _fullyQualifiedScopesRequiredByTargetApi).TrimEnd()}",


                    // For AAD, ResponseType was set to OpenIdConnectResponseTypes.IdToken
                    // For B2C, left as defaul, which is OpenIdConnectResponseTypes.CodeIdToken
                    ResponseType = OpenIdConnectResponseType.CodeIdToken,

                    TokenValidationParameters = tokenValidationParameters,

                    // Specify the callbacks for each type of notifications
                    Notifications = new OpenIdConnectAuthenticationNotifications
                    {
                        RedirectToIdentityProvider = OnRedirectToIdentityProvider,
                        AuthorizationCodeReceived = OnAuthorizationCodeReceived,
                        AuthenticationFailed = OnAuthenticationFailed,

                        //this.MessageReceived = (Func<MessageReceivedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions>, Task>)(notification => (Task)Task.FromResult<int>(0));
                        //this.SecurityTokenReceived = (Func<SecurityTokenReceivedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions>, Task>)(notification => (Task)Task.FromResult<int>(0));
                        SecurityTokenValidated = OnAuthenticated
                    }
                };

            app.UseOpenIdConnectAuthentication(openIdConnectAuthenticationOptions);
        }

        /*
         *  On each call to Azure AD B2C, check if a policy (e.g. the profile edit or password reset policy) 
         *  has been specified in the OWIN context.
         *  If so, use that policy when making the call. 
         *  Also, don't request a code (since it won't be needed).
         */
        private static Task OnRedirectToIdentityProvider(
            RedirectToIdentityProviderNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions>
                notification)
        {
            var policy = notification.OwinContext.Get<string>("Policy");

            if (!string.IsNullOrEmpty(policy) &&
                !policy.Equals(_ib2COidcConfidentialClientSettingsConfiguration.DefaultPolicyId))
            {
                notification.ProtocolMessage.Scope = OpenIdConnectScope.OpenId;
                notification.ProtocolMessage.ResponseType =
                    OpenIdConnectResponseType.IdToken /*ask directly for Token, not Code*/;
                //Will look like: https://login.microsoftonline.com/te/{authorityTenantName}/{policyId}/oauth2/v2.0/authorize
                notification.ProtocolMessage.IssuerAddress = notification.ProtocolMessage.IssuerAddress.ToLower()
                    .Replace(_ib2COidcConfidentialClientSettingsConfiguration.DefaultPolicyId.ToLower(), policy.ToLower());
            }

            return Task.FromResult(0);
        }

        /// <summary>
        ///     This event happens when the user has authenticated
        ///     so if you want to add a claim, now is the time.
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        private static Task OnAuthenticated(
            SecurityTokenValidatedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> notification)
        {

            var protocolMessage = notification.ProtocolMessage;

            var authenticationSuccessMessage = new AuthenticationSuccessMessage()
            {
                UserId = protocolMessage.UserId,
                Identity = notification.AuthenticationTicket.Identity
            };

            _oidcNotificationHandlerService.OnAuthenticationSuccess(authenticationSuccessMessage);

            return Task.FromResult(0);
        }

        /*
         * Catch any failures received by the authentication middleware and handle appropriately
         */
        private static Task OnAuthenticationFailed(AuthenticationFailedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> notification)
        {
            var protocolMessage = notification.ProtocolMessage;

            var authenticationErrorMessage = new AuthenticationErrorMessage()
            {
                Error = protocolMessage.Error,
                ErrorDescription = protocolMessage.ErrorDescription,
                ErrorUri = protocolMessage.ErrorUri
            };

            _oidcNotificationHandlerService.OnAuthenticationError(authenticationErrorMessage);

            notification.HandleResponse();

            // Handle the error code that Azure AD B2C throws when trying to reset a password from the login page 
            // because password reset is not supported by a "sign-up or sign-in policy"
            if (notification.ProtocolMessage.ErrorDescription != null &&
                notification.ProtocolMessage.ErrorDescription.Contains("AADB2C90118"))
            {
                // If the user clicked the reset password link, redirect to the reset password route
                notification.Response.Redirect("/Account/ResetPassword");
            }
            else if (notification.Exception.Message == "access_denied")
            {
                notification.Response.Redirect("/");
            }
            else
            {
                notification.Response.Redirect("/Error?message=" + notification.Exception.Message + "&description=" +
                                               notification.ProtocolMessage.ErrorDescription);
            }

            return Task.FromResult(0);
        }


        /*
         * Callback function when an authorization code is received. 
         */
        private static async Task OnAuthorizationCodeReceived(AuthorizationCodeReceivedNotification notification)
        {
            // Extract the code from the response notification
            var code = notification.Code;

            var authorizationCodeReceived = new AuthorizationCodeReceivedMessage()
            {
                SignedInUserNameIdentifier = notification.AuthenticationTicket.Identity.FindFirst(ClaimTypes.NameIdentifier).Value
            };

            _oidcNotificationHandlerService.OnAuthorizationCodeReceived(authorizationCodeReceived);



            var userTokenCache =
                new MSALSessionCache(
                    authorizationCodeReceived.SignedInUserNameIdentifier,
                    notification.OwinContext.Environment["System.Web.HttpContextBase"] as HttpContextBase
                ).GetMsalCacheInstance();

           // TokenCache appTokenCache = null;

            var cca =
                new ConfidentialClientApplication(
                    _ib2COidcConfidentialClientSettingsConfiguration.ClientId, 
                    _ib2COidcConfidentialClientSettingsConfiguration.AuthorityUri,// "https://login.microsoftonline.com/tfp/{tenantAuthorityName}/{defaultPolicyId}/v2.0/.well-known/openid-configuration"
                    _ib2COidcConfidentialClientSettingsConfiguration.ClientRedirectUri,// eg: "https://localhost:44311"
                    new ClientCredential(_ib2COidcConfidentialClientSettingsConfiguration.ClientSecret),
                    userTokenCache,
                    null);

      
            try
            {
                AuthenticationResult result = await cca.AcquireTokenByAuthorizationCodeAsync(code, _fullyQualifiedScopesRequiredByTargetApi);
                // this is actually wrong
                //if (result.Scopes != null && result.Scopes.Any())
                //{
                //    notification.AuthenticationTicket.Identity.AddClaim(new Claim(Infrastructure.Constants.IDA.ClaimTitles.ScopeElementId, string.Join(" ", result.Scopes).TrimEnd()));
                //}
                
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }
        }
    }
}