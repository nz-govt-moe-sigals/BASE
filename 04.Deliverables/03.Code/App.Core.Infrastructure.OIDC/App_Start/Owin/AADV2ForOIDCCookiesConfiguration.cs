namespace App.Core.Infrastructure.IDA.Owin
{
    using System;
    using System.IdentityModel.Tokens;
    using System.Threading.Tasks;
    using App.Core.Infrastructure.IDA.Models;
    using App.Core.Infrastructure.IDA.Services;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Messages;
    using global::Owin;
    using Microsoft.IdentityModel.Protocols;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.Cookies;
    using Microsoft.Owin.Security.Notifications;
    using Microsoft.Owin.Security.OpenIdConnect;

    public class AADV2ForOIDCCookiesConfiguration
    {
        //private IOIDCNotificationHandlerService _oidcNotificationHandlerService;

        /// <summary>
        ///     Helper class to be invoked from within Application's Startup Configuration method,
        ///     Configure the OWIN MiddleWare
        /// </summary>
        /// <param name="appBuilder"></param>
        /// <param name="hostSettingsService"></param>
        /// <param name="oidcNotificationHandlerService"></param>
        public void Configure(IAppBuilder appBuilder, IHostSettingsService hostSettingsService, IOIDCNotificationHandlerService oidcNotificationHandlerService)
        {
            //Get basic OIDC Config settings:
            IAADOidcConfidentialClientConfiguration aadOIDCConfidentialClientConfiguration =
                hostSettingsService.GetObject<AADOidcConfidentialClientConfiguration>();

            //Same for AAD as for OIDC:
            appBuilder.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            //Same for AAD as for OIDC:
            appBuilder.UseCookieAuthentication(new CookieAuthenticationOptions());

            var openIdConnectAuthenticationOptions = new OpenIdConnectAuthenticationOptions
            {
                //AAD does not need MetadataAddress (whereas B2C does)
                //MetadataAddress = ...

                // Sets the ClientId, authority, RedirectUri as obtained from web.config
                ClientId = aadOIDCConfidentialClientConfiguration.ClientId,
                Authority = aadOIDCConfidentialClientConfiguration.AuthorityUri,
                RedirectUri = aadOIDCConfidentialClientConfiguration.ClientRedirectUri,
                PostLogoutRedirectUri = aadOIDCConfidentialClientConfiguration.ClientPostLogoutUri,

                // Specify the scope by appending all of the scopes requested into one string (separated by a blank space)
                Scope = OpenIdConnectScopes.OpenIdProfile,

                // ResponseType [IdToken|CodeIdToken] is set to request the id_token - which 
                // contains basic information about the signed-in user
                ResponseType = OpenIdConnectResponseTypes.IdToken,

                // ValidateIssuer set to false to allow personal and work accounts from any organization 
                // to sign in to your application.
                // To only allow users from a single organizations, 
                // set ValidateIssuer to true and 'tenant' setting in web.config to the tenant name
                // To allow users from only a list of specific organizations, set ValidateIssuer to true and use ValidIssuers parameter 
                TokenValidationParameters =
                    new TokenValidationParameters
                    {
                        ValidateIssuer = false /*ValidIssuers = ...*/
                    },

                // OpenIdConnectAuthenticationNotifications configures OWIN 
                // to send notification of failed authentications 
                // to OnAuthenticationFailed method
                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    AuthenticationFailed = OnAuthenticationFailed
                }
            };

            appBuilder.UseOpenIdConnectAuthentication(openIdConnectAuthenticationOptions);
        }

        


        /// <summary>
        ///     Handle failed authentication requests by redirecting the user to the home page with an error in the query string
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private static Task OnAuthenticationFailed(
            AuthenticationFailedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> context)
        {
            AuthenticationErrorMessage message = new AuthenticationErrorMessage();

            //The reason:
            Exception exception = context.Exception;

            
            message.Error = context.ProtocolMessage.Error;

            AppDependencyLocator.Current.GetInstance<IOIDCNotificationHandlerService>().OnAuthenticationError(message);


            context.HandleResponse();
            context.Response.Redirect("/?errormessage=" + context.Exception.Message);
            return Task.FromResult(0);
        }
    }
}