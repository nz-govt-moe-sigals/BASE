using App.Core.Infrastructure.Initialization.DependencyResolution;

namespace App.Core.Application.Filters.WebApi
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;

    // Not that this WebAPI appropriate filter is derived from the 
    // System.Web.Http.Filters namespace (System.Web.Http.Filters.AuthorizationFilterAttribute : System.Web.Http.Filters.FiltersAttribute, System.Web.Http.Filters.IAuthorizationFilter)
    // whereas the MVC appropriate filter is derived from the System.Web.Mvc namespace (System.Web.Mvc.FilterAttribute:Attribute, System.Web.Mvc.IMvcFilter)
    // Note as well that as we're talking about an API, there is no redirection (the client can't handle it).
    // Instead we just return errors that the developer has to use to get the client code right.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class RequireHttpsWebApiFilterAttribute : AuthorizationFilterAttribute
    {
        private IDiagnosticsTracingService DiagnosticsTracingService
        {
             get { return AppDependencyLocator.Current.GetInstance<IDiagnosticsTracingService>(); }

        }


        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var request = actionContext.Request;

            if (request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                if (request.Headers.GetCookies().Any(x => !x.Secure))
                {
                    //If we're in HTTP and not HTTPS, and there is a cookie
                    //it means the cookie was developed without the secure flag.
                    // And that's a big big no-no.
                    DiagnosticsTracingService.Trace(TraceLevel.Error, "Insecure Cookies are being used.");
                    throw new Exception("Insecure Cookies");
                }

                HttpResponseMessage response;
                var uri = new UriBuilder(request.RequestUri);
                uri.Scheme = Uri.UriSchemeHttps;
                uri.Port = 443;
                var body = string.Format("<p>The resource can be found at <a href=\"{0}\">{0}</a>.</p>",
                    uri.Uri.AbsoluteUri);
                if (request.Method.Equals(HttpMethod.Get) || request.Method.Equals(HttpMethod.Head))
                {
                    response = request.CreateResponse(HttpStatusCode.Found);
                    response.Headers.Location = uri.Uri;
                    if (request.Method.Equals(HttpMethod.Get))
                    {
                        response.Content = new StringContent(body, Encoding.UTF8, "text/html");
                    }
                }
                else
                {
                    response = request.CreateResponse(HttpStatusCode.NotFound);
                    response.Content = new StringContent(body, Encoding.UTF8, "text/html");
                }

                actionContext.Response = response;
            }
        }
    }
}