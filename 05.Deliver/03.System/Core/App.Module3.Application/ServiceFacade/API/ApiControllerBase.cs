namespace App.Module3.Application.ServiceFacade.API.Controllers
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using App.Core.Infrastructure.Services;

    public abstract class ApiControllerBase : ApiController
    {
        protected readonly IPrincipalService _principalService;

        protected ApiControllerBase(IPrincipalService principalService)
        {
            this._principalService = principalService;
        }

        // Validate to ensure the necessary scopes are present.
        protected void HasRequiredScopes(string permission)
        {
            //The base method just verifies scope
            if (!this._principalService.HasRequiredScopes(permission))
            {
                // this controller still has to raise an exception
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    ReasonPhrase = $"The Scope claim does not contain the {permission} permission."
                });
            }
        }
    }
}