
namespace App.Core.Application.Filters.WebApi
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    //public class AppAuthenticateFilterAttribute : AuthenticationFilterAttribute



    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AppAuthorizeFilterAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var request = actionContext.Request;


            ////The base method just verifies scope
            //if (!this._principalService.HasRequiredScopes(permission))
            //{
            //    // this controller still has to raise an exception
            //    actionContext.Response = new HttpResponseMessage
            //    {
            //        StatusCode = HttpStatusCode.Unauthorized,
            //        ReasonPhrase = $"The Scope claim does not contain the {permission} permission."
            //    };
            //}


            base.OnAuthorization(actionContext);
        }
    }

    //			AuthorizeAttribute




}


