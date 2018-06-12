using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services;
using App.Module32.Infrastructure.Services.Implementations.Base;
using App.Module32.Shared.Models.Entities;
using App.Module32.Shared.Models.Messages.Extract;

namespace App.Module32.Infrastructure.Services.Implementations.Extract.DataServices
{
    public class StudentProfilesExtractService : BaseExtractService<StudentProfile, EducationStudentProfile>
    {
        public StudentProfilesExtractService(IDiagnosticsTracingService tracingService, IExtractAzureDocumentDbService documentDbService, IExtractRepositoryService repositoryService) 
            : base(tracingService, documentDbService, repositoryService)
        {
        }


        protected override void AddOrUpdateList(IExtractRepositoryService repositoryService, IList<EducationStudentProfile> entityList)
        {
            
            //throw new NotImplementedException();
        }
    }
}
