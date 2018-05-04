namespace App.Core.Application.ServiceFacade.API.Controllers
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.OData;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;


    public abstract class ODataControllerCommonBase : ODataController
    {
        protected readonly IDiagnosticsTracingService _diagnosticsTracingService;
        protected readonly IPrincipalService _principalService;

        protected ODataControllerCommonBase(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
            this._principalService = principalService;

            this._diagnosticsTracingService.Trace(TraceLevel.Debug, $"{this.GetType().Name} created.");

        }


        // Validate to ensure the necessary scopes are present.
        protected void HasRequiredScopes(string permission)
        {

            this._diagnosticsTracingService.Trace(TraceLevel.Debug, $"HasRequiredScopes: checking: {permission}.");
            
            //The base method just verifies scope
            if (!this._principalService.HasRequiredScopes(permission))
            {
                this._diagnosticsTracingService.Trace(TraceLevel.Debug, $"Throwing exception: The Scope claim does not contain the {permission} permission.");
 
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