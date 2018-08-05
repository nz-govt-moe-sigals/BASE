using System;
using System.Linq;
using System.Web.Http;
using App.Core.Application.Filters.WebApi;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.Entities;
using App.Module32.Application.API.Controllers.Base;
using App.Module32.Shared.Constants;
using App.Module32.Shared.Models.Entities;
using App.Module32.Shared.Models.Messages.API.V0100;

namespace App.Module32.Application.API.Controllers.V0100
{
    public class StudentsController : ActiveRecordStateODataControllerBase<EducationStudentProfile,StudentDto>
    {
        public StudentsController(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService, IRepositoryService repositoryService, IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute) 
            : base(diagnosticsTracingService, principalService, repositoryService, objectMappingService, secureApiMessageAttribute)
        {
        }

        [WebApiAppAuthorize(Roles = AppModuleApiScopes.WriteScope)]
        public void Post([FromBody] StudentDto dto)
        {
            _diagnosticsTracingService.Trace(TraceLevel.Info, "Test Student data being inserted");
            var newProperty = AutoMapper.Mapper.Map<StudentDto, EducationStudentProfile>(dto);
            //TODO : MOVE All repo logic out
            var exisitng = _repositoryService.GetQueryableSingle<EducationStudentProfile>(_dbContextIdentifier,
                x => x.NSN == newProperty.NSN).FirstOrDefault();
            var school = _repositoryService.GetQueryableSingle<EducationSchoolProfile>(_dbContextIdentifier,
                x => x.SchoolId == dto.SchoolId).FirstOrDefault();
            if (school == null) throw new Exception("no school found");
            if (exisitng == null)
            {

                newProperty.EducationSchoolProfileFK = school.Id;
                _repositoryService.AddOnCommit(_dbContextIdentifier, newProperty);
            }
            else
            {
                newProperty.EducationSchoolProfileFK = school.Id;
                AutoMapper.Mapper.Map<EducationStudentProfile, EducationStudentProfile>(newProperty, exisitng); 
                _repositoryService.UpdateOnCommit(_dbContextIdentifier, exisitng);
            }
        }
    }
}
