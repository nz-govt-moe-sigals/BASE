
using System.Linq;
using System.Web.Http;
using System.Web.OData;
using App.Core.Application.Filters.WebApi;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.Entities;
using App.Module32.Application.API.Controllers.Base;
using App.Module32.Shared.Models.Entities;
using App.Module32.Shared.Models.Messages.API.V0100;

namespace App.Module32.Application.API.Controllers.V0100
{
    [WebApiAppAuthorize(Roles = "module32_read")]
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

        [WebApiAppAuthorize(Roles = "module32_write")]
        public void Post(SchoolDto dto)
        {
            _diagnosticsTracingService.Trace(TraceLevel.Info, "Test School data being inserted");
            var newProperty = AutoMapper.Mapper.Map<SchoolDto, EducationSchoolProfile>(dto);
            //TODO : MOVE All repo logic out
            var exisitng = _repositoryService.GetQueryableSingle<EducationSchoolProfile>(_dbContextIdentifier,
                x => x.SchoolId == newProperty.SchoolId).FirstOrDefault();
            
            if (exisitng == null)
            {
                _repositoryService.AddOnCommit(_dbContextIdentifier, newProperty);
            }
            else
            {
                exisitng.Name = newProperty.Name; // should probably use Automapper for this
                _repositoryService.UpdateOnCommit(_dbContextIdentifier, exisitng);
            }
        }

    }
}
