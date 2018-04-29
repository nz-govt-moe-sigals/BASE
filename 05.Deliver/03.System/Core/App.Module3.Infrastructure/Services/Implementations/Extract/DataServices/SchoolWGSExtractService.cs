
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
    public class SchoolWGSExtractService : BaseDataExtractServices<SchoolWGS>
    {
        public SchoolWGSExtractService(BaseExtractServiceConfiguration configuration, IDiagnosticsTracingService tracingService, IExtractAzureDocumentDbService documentDbService)
            : base(configuration, tracingService, documentDbService)
        {

        }

        public override void UpdateLocalData(IExtractRepositoryService repositoryService, SchoolWGS item)
        {
            var mappedEntity = Mapper.Map<SchoolWGS, EducationProviderLocation>(item);
            var educationProviderProfile = repositoryService.GetEducationProviderProfile(item.InstitutionNumber);
            if (educationProviderProfile == null) { throw new ArgumentException($"SchoolId - {item.InstitutionNumber} does not match any EducationProvider Profiles"); }
            mappedEntity.EducationProviderFK = educationProviderProfile.Id;
            repositoryService.AddOrUpdate(mappedEntity);
        }
    }
}

