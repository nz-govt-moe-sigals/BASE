namespace App.Core.Application.ServiceFacade.API.Controllers.V0100
{
    using App.Core.Infrastructure.Services;

    /// <summary>
    /// Controller to return System Description (Name/Subtitle/About)
    /// </summary>
    public class SystemInformationController : ODataControllerBase
    {
        public SystemInformationController(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService) : base(diagnosticsTracingService, principalService)
        {
            throw new ToDoException("SystemInformationController");
        }
    }
}