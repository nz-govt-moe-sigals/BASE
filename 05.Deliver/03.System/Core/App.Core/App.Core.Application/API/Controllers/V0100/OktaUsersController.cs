using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.OData;
using App.Core.Application.API.Controllers.Base.Base;
using App.Core.Infrastructure.IDA.Models;
using App.Core.Infrastructure.IDA.Services;
using App.Core.Infrastructure.Services;

namespace App.Core.Application.API.Controllers.V0100
{
    public class OktaUsersController : CommonODataControllerBase
    {

        private readonly IOktaUserService _oktaUserService;
        public OktaUsersController(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService,
            IOktaUserService oktaUserService) 
            : base(diagnosticsTracingService, principalService)
        {
            _oktaUserService = oktaUserService;
        }

        [EnableQuery(PageSize = 100)]
        public IQueryable<OktaUser> Get()
        {
            return _oktaUserService.GetUserOktaUsers().AsQueryable();
        }
    }
}
