using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using App.Core.Infrastructure.Services;
using App.Module80.Application.API.Controllers.Base;
using App.Module80.Shared.Models.Entities;
using App.Module80.Shared.Models.Messages.API;

namespace App.Module80.Application.API.Controllers.V0100
{
    public class SurveyLocationsController : ActiveRecordStateODataControllerBase
        <SurveyLocation, SurveyLocationDto>
    {
        public SurveyLocationsController(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService, IRepositoryService repositoryService, IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute) 
            : base(diagnosticsTracingService, principalService, repositoryService, objectMappingService, secureApiMessageAttribute)
        {
        }

        [AllowAnonymous]
        [EnableQuery()]
        public IQueryable<SurveyLocationDto> Get()
        {
            return InternalGet();
        }
    }
}
