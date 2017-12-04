namespace App.Core.Application.Presentation.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using App.Core.Infrastructure.IDA.Models;
    using App.Core.Infrastructure.Services;
    using Microsoft.Owin.Security;

    //
    public class AccountController : Controller
    {
        private readonly IB2COidcConfidentialClientConfiguration _b2cOidcConfidentialClientConfiguration;
        private readonly IHostSettingsService _hostSettingsService;

        public AccountController(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
            this._b2cOidcConfidentialClientConfiguration = this._hostSettingsService
                .GetObject<B2COidcConfidentialClientConfiguration>("cookieAuth:");
        }

        /*
         *  Called when requesting to sign up or sign in
         */
        public void SignUpSignIn()
        {
            // Use the default policy to process the sign up / sign in flow
            if (!this.Request.IsAuthenticated)
            {
                this.HttpContext.GetOwinContext().Authentication.Challenge();
                return;
            }

            this.Response.Redirect("/");
        }

        /*
         *  Called when requesting to edit a profile
         */
        public void EditProfile()
        {
            if (this.Request.IsAuthenticated)
            {
                // Let the middleware know you are trying to use the edit profile policy (see OnRedirectToIdentityProvider in Startup.Auth.cs)
                this.HttpContext.GetOwinContext().Set("Policy",
                    this._b2cOidcConfidentialClientConfiguration.TenantEditProfilePolicyId);

                // Set the page to redirect to after editing the profile
                var authenticationProperties = new AuthenticationProperties {RedirectUri = "/"};
                this.HttpContext.GetOwinContext().Authentication.Challenge(authenticationProperties);

                return;
            }

            this.Response.Redirect("/");
        }

        /*
         *  Called when requesting to reset a password
         */
        public void ResetPassword()
        {
            // Let the middleware know you are trying to use the reset password policy (see OnRedirectToIdentityProvider in Startup.Auth.cs)
            this.HttpContext.GetOwinContext().Set("Policy",
                this._b2cOidcConfidentialClientConfiguration.TenantResetPasswordPolicyId);

            // Set the page to redirect to after changing passwords
            var authenticationProperties = new AuthenticationProperties {RedirectUri = "/"};
            this.HttpContext.GetOwinContext().Authentication.Challenge(authenticationProperties);
        }

        /*
         *  Called when requesting to sign out
         */
        public void SignOut()
        {
            // To sign out the user, you should issue an OpenIDConnect sign out request.
            if (this.Request.IsAuthenticated)
            {
                var authTypes = this.HttpContext.GetOwinContext().Authentication.GetAuthenticationTypes();
                this.HttpContext.GetOwinContext().Authentication
                    .SignOut(authTypes.Select(t => t.AuthenticationType).ToArray());
                this.Request.GetOwinContext().Authentication.GetAuthenticationTypes();
            }
        }
    }
}