
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using App.Core.Infrastructure.Services;
 using App.Module11.Infrastructure.Services.Configuration;
using App.Module11.Shared.Models.Entities;
using App.Module11.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module11.Infrastructure.Services.Implementations.Extract.DataServices
{
    public class SchoolEnrolExtractService : BaseDataExtractServices<SchoolEnrol>
    {
        public SchoolEnrolExtractService(BaseExtractServiceConfiguration configuration, IDiagnosticsTracingService tracingService, IExtractAzureDocumentDbService documentDbService)
            : base(configuration, tracingService, documentDbService)
        {

        }

        public override void UpdateLocalData(IExtractRepositoryService repositoryService, SchoolEnrol item)
        {
            var mappedEntity = Mapper.Map<SchoolEnrol, EducationProviderEnrolmentCount>(item);
            var educationProviderProfile = repositoryService.GetEducationProviderProfile(item.SchoolId);
            if(educationProviderProfile == null) { throw new ArgumentException($"SchoolId - {item.SchoolId} does not match any EducationProvider Profiles");}
            mappedEntity.EducationProviderFK = educationProviderProfile.Id;
            repositoryService.AddOrUpdateNonCachedData(mappedEntity);

        }
    }
}
