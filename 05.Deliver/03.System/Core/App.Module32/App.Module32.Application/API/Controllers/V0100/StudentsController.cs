using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.Entities;
using App.Module32.Application.API.Controllers.Base;
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

        public void Post(StudentDto dto)
        {
            _diagnosticsTracingService.Trace(TraceLevel.Info, "Test Student data being inserted");
        }
    }
}
