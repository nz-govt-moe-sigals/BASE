using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Application.API.Controllers.Base.Base;
using App.Core.Application.Filters.WebApi;
using App.Core.Infrastructure.Services;
using App.Module32.Shared.Constants;

namespace App.Module32.Application.API.Controllers.Base
{
    [WebApiAppAuthorize(Roles = AppModuleApiScopes.ReadScope)]
    public abstract class ApiModuleControllerBase : ApiControllerCommonBase
    {
        protected ApiModuleControllerBase(IPrincipalService principalService) : base(principalService)
        {
        }
    }
}
