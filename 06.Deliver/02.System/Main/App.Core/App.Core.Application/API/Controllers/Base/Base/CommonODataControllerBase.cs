namespace App.Core.Application.API.Controllers.Base.Base
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.OData;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;

    /// <summary>
    /// All Controllers, whatever module,  *should* inherit in one way or another
    /// from this base controller.
    /// <para>
    /// The advantages include:
    /// * only one class that needs to be updated to .NET Core when we get there.
    /// * ensures that all classes are injected with an implementation of 
    /// <see cref="IDiagnosticsTracingService"/> and <see cref="IPrincipalService"/>
    /// so there is absolutely no excuse for poor diagnostics logs, or security...
    /// (that said, still don't trust developers rushing to meet deadlines to take 
    /// care of ISO-25010/Maintainability or ISO-25010/Security, so we handle 
    /// Security and Logging as GLobal Filters anyway).
    /// </para>
    /// </summary>
    /// <seealso cref="System.Web.OData.ODataController" />
    public abstract class CommonODataControllerBase : ODataController
    {
        protected readonly IDiagnosticsTracingService _diagnosticsTracingService;
        protected readonly IPrincipalService _principalService;

        protected CommonODataControllerBase(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService)
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