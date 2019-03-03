using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Application.API.Controllers.Base.Base;
using App.Core.Application.Filters.WebApi;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Constants;

namespace App.Core.Application.API.Controllers.Base.CoreModule
{
    [WebApiAppAuthorize(Roles = AppModuleApiScopes.ReadScope)]
    public class CoreODataControllerBase : CommonODataControllerBase
    {
        public CoreODataControllerBase(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService) 
            : base(diagnosticsTracingService, principalService)
        {
        }
    }
}
