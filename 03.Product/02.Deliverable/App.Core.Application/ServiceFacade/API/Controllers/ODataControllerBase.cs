namespace App.Core.Application.ServiceFacade.API.Controllers
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.OData;
    using App.Core.Infrastructure.Services;

    public abstract class ODataControllerBase : ODataController
    {
        protected readonly IPrincipalService _principalService;

        protected ODataControllerBase(IPrincipalService principalService)
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