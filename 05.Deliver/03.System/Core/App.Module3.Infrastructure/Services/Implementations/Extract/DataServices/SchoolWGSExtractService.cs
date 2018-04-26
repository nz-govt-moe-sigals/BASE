
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Module3.Infrastructure.Services.Configuration;
using App.Module3.Shared.Models.Entities;
using App.Module3.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module3.Infrastructure.Services.Implementations.Extract.DataServices
{
    public class SchoolWGSExtractService : BaseDataExtractServices<SchoolWGS>
    {
        public SchoolWGSExtractService(BaseExtractServiceConfiguration configuration, IExtractRepositoryService reposorityService, IExtractAzureDocumentDbService documentDbService)
            : base(configuration, reposorityService, documentDbService)
        {

        }

        public override void UpdateLocalData(SchoolWGS item)
        {
            var mappedEntity = Mapper.Map<SchoolWGS, EducationProviderLocation>(item);
            var educationProviderProfile = _repositoryService.GetEducationProviderProfile(item.InstitutionNumber.ToString());
            mappedEntity.EducationProviderFK = educationProviderProfile.Id;
            _repositoryService.AddOrUpdate(mappedEntity);
        }
    }
}

