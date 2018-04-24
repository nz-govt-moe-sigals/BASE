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

namespace App.Module3.Infrastructure.Services.Implementations.Extract.ReferenceServices
{
    public class ReferenceSchoolYearLevelExtractService
        : BaseExtractService<ReferenceSchoolYearLevel>
    {
        public ReferenceSchoolYearLevelExtractService(BaseExtractServiceConfiguration configuration, IExtractRepositoryService reposorityService,IExtractAzureDocumentDbService documentDbService)
            : base(configuration, reposorityService,documentDbService)
        {

        }

        public override void UpdateLocalData(ReferenceSchoolYearLevel item)
        {
            var mappedEntity = Mapper.Map<ReferenceSchoolYearLevel, EducationProviderYearLevel>(item);
            var areaUnitsLookup = _repositoryService.GetSifCachedData< EducationProviderYearLevel>(); // is CACHED DATA
            if (areaUnitsLookup.TryGetValue(mappedEntity.SourceSystemKey, out var existingEntity))
            {
                _repositoryService.UpdateSifData(existingEntity, mappedEntity);
            }
            else
            {
                _repositoryService.AddSifData(mappedEntity);
            }
            //_repositoryService.UpdateOnCommit(_dbKey, );
            // Some Sky Magic Code
        }
    }
}
