using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services;
using App.Module31.Infrastructure.Services.Configuration;
using App.Module31.Shared.Models.Entities;
using App.Module31.Shared.Models.Entities.Sif;
using App.Module31.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module31.Infrastructure.Services.Implementations.Extract.ReferenceServices
{
    public class ReferenceTeacherEducationExtractService
        : BaseExtractService<ReferenceTeacherEducation>
    {
        public ReferenceTeacherEducationExtractService(BaseExtractServiceConfiguration configuration, IDiagnosticsTracingService tracingService, IExtractAzureDocumentDbService documentDbService)
            : base(configuration, tracingService, documentDbService)
        {

        }

        public override void UpdateLocalData(IExtractRepositoryService repositoryService, ReferenceTeacherEducation item)
        {
            var mappedEntity = Mapper.Map<ReferenceTeacherEducation, TeacherEducation>(item);
            var sifData = repositoryService.LookupSifReference<SifSchoolTeacherEducation>(mappedEntity.SourceSystemKey, SifLookup.FirstId);
            if (sifData != null)
            {
                mappedEntity.SIFKey = sifData.SifId;
            }
            repositoryService.AddOrUpdateSifData(mappedEntity);
        }
    }
}





