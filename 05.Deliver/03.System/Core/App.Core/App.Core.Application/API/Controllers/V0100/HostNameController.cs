using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using App.Core.Application.API.Controllers.Base.Base;
using App.Core.Infrastructure.Services;
using App.Core.Infrastructure.Services.Implementations;

namespace App.Core.Application.API.Controllers.V0100
{
    [AllowAnonymous]
    public class HostNameController : ApiControllerCommonBase
    {
        private IAppHostNamesService _hostNamesService;

        public HostNameController(IPrincipalService principalService, IDiagnosticsTracingService diagnosticsTracingService,
         IAppHostNamesService host) 
            : base(principalService)
        {
            _hostNamesService = host;
        }

        [HttpGet]
        public string GetHostNames()
        {
            return _hostNamesService.GetAppHostNames();
        }

     
    }
}
