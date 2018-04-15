namespace App.Core.Application.Filters.WebMvc
{
    using System;
    using System.Web.Mvc;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class MyRequireHttpsWebMvcFilterAttribute : RequireHttpsAttribute
    {

        private IDiagnosticsTracingService DiagnosticsTracingService
        {
            get
            {
                return App.AppDependencyLocator.Current.GetInstance<IDiagnosticsTracingService>();
            }

        }

        /// <summary>
        ///     Determines whether a request is secured (HTTPS) and, if it is not, calls the
        ///     <see cref="M:System.Web.Mvc.RequireHttpsAttribute.HandleNonHttpsRequest(System.Web.Mvc.AuthorizationContext)" />
        ///     method.
        /// </summary>
        /// <param name="filterContext">
        ///     An object that encapsulates information that is required in order to use the
        ///     <see cref="T:System.Web.Mvc.RequireHttpsAttribute" /> attribute.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="filterContext" /> parameter is null.</exception>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var request = filterContext.RequestContext.HttpContext;

            //request.Request.
            //if (request.RequestUri.Scheme != Uri.UriSchemeHttps)
            //{
            //    if (request.Headers.GetCookies().Any(x => !x.Secure))
            //    {
            //        //If we're in HTTP and not HTTPS, and there is a cookie
            //        //it means the cookie was developed without the secure flag.
            //        // And that's a big big no-no.
            //        DiagnosticsTracingService.Trace(TraceLevel.Error, "Insecure Cookies are being used.");
            //        throw new Exception("Insecure Cookies");
            //    }
            //}

            base.OnAuthorization(filterContext);
        }
    }
}