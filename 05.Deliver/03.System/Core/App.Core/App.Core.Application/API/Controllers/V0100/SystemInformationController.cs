namespace App.Core.Application.API.Controllers.V0100
{
    using App.Core.Application.Attributes;
    using App.Core.Application.API.Controllers.Base.Base;
    using App.Core.Infrastructure.Services;

    /// <summary>
    /// Controller to return System Description (Name/Subtitle/About)
    /// </summary>
    [ODataPath(Constants.Api.ApiControllerNames.SystemInformation)]
    public class SystemInformationController : CommonODataControllerBase
    {
        public SystemInformationController(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService) : base(diagnosticsTracingService, principalService)
        {
            throw new ToDoException("SystemInformationController");
        }
    }
}