namespace App.Core.Infrastructure.IDA.Owin
{
    using System;
    using System.IdentityModel.Tokens;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Web;
    using App.Core.Application.Oidc;
    using App.Core.Infrastructure.IDA.Models;
    using App.Core.Infrastructure.IDA.Services;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Messages;
    using global::Owin;
    using Microsoft.Identity.Client;
    using Microsoft.IdentityModel.Protocols;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.Cookies;
    using Microsoft.Owin.Security.Notifications;
    using Microsoft.Owin.Security.OpenIdConnect;

    /// <summary>
    ///     Helper class to be invoked from within Application's Startup Configuration method,
    ///     in order to configure Cookie Based Authentication, as is required to authenticate
    ///     access to Server generated View Controllers (ie MVC pages).
    ///     For configuring for BearerTokens as is required for controlling access to API Controllers
    ///     see B2COAuthBearerTokenAuthenticationConfiguration
    /// </summary>
    public class B2COAuthCookieBasedAuthenticationConfig
    {
        // These values are pulled from web.config
        private static IB2COidcConfidentialClientConfiguration _b2cOidcConfidentialClientConfiguration;

        // The scopes of the remote api to ask for.
        private static string[] _fullyQualifiedScopesRequiredByTargetAPI;

        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly IHostSettingsService _hostSettingsService;
        private static IOIDCNotificationHandlerService _oidcNotificationHandlerService;

        public B2COAuthCookieBasedAuthenticationConfig(IDiagnosticsTracingService diagnosticsTracingService,
            IHostSettingsService hostSettingsService,
            IOIDCNotificationHandlerService oidcNotificationHandlerService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
            this._hostSettingsService = hostSettingsService;

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
        public void Configure(IAppBuilder app, string[] fullyQualifiedScopesRequiredByTargetAPI)
        {
            _fullyQualifiedScopesRequiredByTargetAPI = fullyQualifiedScopesRequiredByTargetAPI;
            // Retrieve settings from web.settings (actually, web.settings.appSettings.exclude):
            _b2cOidcConfidentialClientConfiguration = this._hostSettingsService
                .GetObject<B2COidcConfidentialClientConfiguration>("cookieAuth:");


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

            //app.UseJwtBearerAuthentication(new JwtBearerOptions
            //{
            //    AutomaticAuthenticate = true,
            //    AutomaticChallenge = true,
            //    TokenValidationParameters = tokenValidationParameters
            //});


            var openIdConnectAuthenticationOptions =
                new OpenIdConnectAuthenticationOptions
                {
                    // Whereas AAD V2 login does not require this, need to set for B2C.
                    MetadataAddress = _b2cOidcConfidentialClientConfiguration.AuthorityCookieConfigurationPolicyUri,

                    ClientId = _b2cOidcConfidentialClientConfiguration.ClientId,
                    RedirectUri = _b2cOidcConfidentialClientConfiguration.ClientRedirectUri,
                    PostLogoutRedirectUri = _b2cOidcConfidentialClientConfiguration.ClientPostLogoutUri,

                    // Specify the scope by appending all of the scopes requested into one string (separated by a blank space)
                    Scope =
                        $"{OpenIdConnectScopes.OpenIdProfile} offline_access {string.Join(" ", _fullyQualifiedScopesRequiredByTargetAPI).TrimEnd()}",


                    // For AAD, ResponseType was set to OpenIdConnectResponseTypes.IdToken
                    // For B2C, left as defaul, which is OpenIdConnectResponseTypes.CodeIdToken
                    ResponseType = OpenIdConnectResponseTypes.CodeIdToken,

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
                !policy.Equals(_b2cOidcConfidentialClientConfiguration.DefaultPolicyId))
            {
                notification.ProtocolMessage.Scope = OpenIdConnectScopes.OpenId;
                notification.ProtocolMessage.ResponseType =
                    OpenIdConnectResponseTypes.IdToken /*ask directly for Token, not Code*/;
                //Will look like: https://login.microsoftonline.com/te/{authorityTenantName}/{policyId}/oauth2/v2.0/authorize
                notification.ProtocolMessage.IssuerAddress = notification.ProtocolMessage.IssuerAddress.ToLower()
                    .Replace(_b2cOidcConfidentialClientConfiguration.DefaultPolicyId.ToLower(), policy.ToLower());
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
            var authenticationTicket = notification.AuthenticationTicket;

            var check1 = protocolMessage.IdentityProvider;
            var check2 = protocolMessage.Iss;
            var check3 = protocolMessage.ClientId;
            var check4 = protocolMessage.UserId;

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
        private static Task OnAuthenticationFailed(
            AuthenticationFailedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> notification)
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

            TokenCache appTokenCache = null;

            var cca =
                new ConfidentialClientApplication(
                    _b2cOidcConfidentialClientConfiguration.ClientId,
                    // "https://login.microsoftonline.com/tfp/{tenantAuthorityName}/{defaultPolicyId}/v2.0/.well-known/openid-configuration"
                    _b2cOidcConfidentialClientConfiguration.AuthorityCookieConfigurationPolicyUri,
                    // eg: "https://localhost:44311"
                    _b2cOidcConfidentialClientConfiguration.ClientRedirectUri,
                    new ClientCredential(_b2cOidcConfidentialClientConfiguration.ClientSecret),
                    userTokenCache,
                    appTokenCache);

            AuthenticationResult result;

            try
            {
                result = await cca.AcquireTokenByAuthorizationCodeAsync(code, _fullyQualifiedScopesRequiredByTargetAPI);
            }
            catch (Exception ex)
            {
                //TODO: Handle
                throw;
            }
        }
    }
}