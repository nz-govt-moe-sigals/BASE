using App.Core.Application.API.Controllers.Base.CoreModule;

namespace App.Core.Application.API.Controllers.V0100
{
    using App.Core.Application.Attributes;
    using App.Core.Application.API.Controllers.Base.Base;
    using App.Core.Infrastructure.Services;

    /// <summary>
    /// Controller to return Creator, Distributor, Vendor information 
    /// </summary>
    [ODataPath(Constants.Api.ApiControllerNames.SystemDeveloper)]
    public class SystemDeveloperController : CoreODataControllerBase
    {
        public SystemDeveloperController(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService) : base(diagnosticsTracingService, principalService)
        {
            throw new ToDoException("SystemDeveloperController");
        }
    }
}