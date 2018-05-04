namespace App.Module1.Application.ServiceFacade.API.Controllers
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.OData;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;

    /// <summary>
    /// <para>
    /// At present this Assembly does not have a reference
    /// to App.Core.Assembly, so we don't enherit from anything
    /// there -- we just reimplement the same logic.
    /// </para>
    /// </summary>
    /// <seealso cref="System.Web.OData.ODataController" />
    public abstract class ODataControllerBase : ODataController
    {
        protected readonly IDiagnosticsTracingService _diagnosticsTracingService;
        protected readonly IPrincipalService _principalService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ODataControllerBase"/> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="principalService">The principal service.</param>
        protected ODataControllerBase(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
            this._principalService = principalService;

            this._diagnosticsTracingService.Trace(TraceLevel.Debug, "ApplicationDescriptionController.Get");
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