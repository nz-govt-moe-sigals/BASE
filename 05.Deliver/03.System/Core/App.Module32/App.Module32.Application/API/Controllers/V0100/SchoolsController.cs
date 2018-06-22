
using System.Linq;
using System.Web.Http;
using System.Web.OData;
using App.Core.Infrastructure.Services;
using App.Module32.Application.API.Controllers.Base;
using App.Module32.Shared.Models.Entities;
using App.Module32.Shared.Models.Messages.API.V0100;

namespace App.Module32.Application.API.Controllers.V0100
{
    public class SchoolsController : ActiveRecordStateODataControllerBase
        <EducationSchoolProfile,SchoolDto>
    {
        public SchoolsController(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService, 
            IRepositoryService repositoryService, IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute)
            : base(diagnosticsTracingService, principalService, repositoryService, objectMappingService, secureApiMessageAttribute)
        {

        }

        [AllowAnonymous]
        [EnableQuery()]
        public IQueryable<SchoolDto> Get()
        {
            return InternalGet();
        }

        [AllowAnonymous]
        public void Post(SchoolDto dto)
        {

        }

    }
}
