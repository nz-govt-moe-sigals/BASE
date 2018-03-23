namespace App.Core.Application.Presentation.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.Cookies;
    using Microsoft.Owin.Security.OpenIdConnect;

    /// <summary>
    ///     A Controller to handle sign in via AAD (V2).
    /// </summary>
    public class AadLoginController : Controller
    {
        /// <summary>
        ///     Send an OpenID Connect sign-in request.
        ///     Alternatively, you can just decorate the SignIn method with the [Authorize] attribute
        /// </summary>
        public void SignIn()
        {
            if (!this.Request.IsAuthenticated)
            {
                this.HttpContext.GetOwinContext().Authentication.Challenge(
                    new AuthenticationProperties {RedirectUri = "/"},
                    OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
        }

        /// <summary>
        ///     Send an OpenID Connect sign-out request.
        /// </summary>
        public void SignOut()
        {
            this.HttpContext.GetOwinContext().Authentication.SignOut(
                OpenIdConnectAuthenticationDefaults.AuthenticationType,
                CookieAuthenticationDefaults.AuthenticationType);
        }
    }
}