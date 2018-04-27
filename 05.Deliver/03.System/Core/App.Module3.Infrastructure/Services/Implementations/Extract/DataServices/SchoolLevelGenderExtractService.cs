
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using App.Core.Infrastructure.Services;
 using App.Module3.Infrastructure.Services.Configuration;
using App.Module3.Shared.Models.Entities;
using App.Module3.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module3.Infrastructure.Services.Implementations.Extract.DataServices
{
    public class SchoolLevelGenderExtractService : BaseDataExtractServices<SchoolLevelGender>
    {
        public SchoolLevelGenderExtractService(BaseExtractServiceConfiguration configuration, IDiagnosticsTracingService tracingService, IExtractAzureDocumentDbService documentDbService)
            : base(configuration, tracingService, documentDbService)
        {

        }

        public override void UpdateLocalData(IExtractRepositoryService repositoryService,  SchoolLevelGender item)
        {
            var mappedEntity = Mapper.Map<SchoolLevelGender, EducationProviderLevelGender>(item);
            var educationProviderProfile = repositoryService.GetEducationProviderProfile(item.SchoolId);
            if (educationProviderProfile == null) { throw new ArgumentException($"SchoolId - {item.SchoolId} does not match any EducationProvider Profiles"); }
            mappedEntity.EducationProviderFK = educationProviderProfile.Id;
            mappedEntity.GenderFK = LookUp<EducationProviderGender>(repositoryService, item.GenderValueId);
            mappedEntity.YearFK = LookUp<EducationProviderYearLevel>(repositoryService, item.YearValueId);
            repositoryService.AddOrUpdate(mappedEntity);
        }
    }
}

