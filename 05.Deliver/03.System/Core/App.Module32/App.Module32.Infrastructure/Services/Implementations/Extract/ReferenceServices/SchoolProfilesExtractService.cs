using App.Core.Infrastructure.Services;
using App.Module32.Infrastructure.Services.Implementations.Base;
using App.Module32.Infrastructure.Services.Interfaces.Extract;
using App.Module32.Shared.Models.Entities;
using App.Module32.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module32.Infrastructure.Services.Implementations.Extract.ReferenceServices
{
    public class SchoolProfilesExtractService :  BaseExtractService<SchoolProfile, EducationSchoolProfile>
    {
        public SchoolProfilesExtractService(IDiagnosticsTracingService tracingService, ISchoolExtractAzureDocumentDbService documentDbService, 
            ISchoolExtractRepositoryService repositoryService) 
            : base(tracingService, documentDbService, repositoryService)
        {
        }



        public override EducationSchoolProfile MapLocalDataToEntity(SchoolProfile item)
        {
            var mappedEntity = Mapper.Map<SchoolProfile, EducationSchoolProfile>(item);
            mappedEntity.Name = mappedEntity.Name.Trim();
            return mappedEntity;
        }



    }
}
