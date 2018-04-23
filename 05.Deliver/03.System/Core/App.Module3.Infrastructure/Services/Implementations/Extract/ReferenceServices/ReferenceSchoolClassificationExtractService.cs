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
    public class ReferenceSchoolClassificationExtractService
        : BaseExtractService<ReferenceSchoolClassification>
    {
        public ReferenceSchoolClassificationExtractService(BaseExtractServiceConfiguration configuration, IExtractRepositoryService reposorityService, IExtractAzureDocumentDbService documentDbService)
            : base(configuration, reposorityService, documentDbService)
        {

        }

        public override void UpdateLocalData(ReferenceSchoolClassification item)
        {
            var mappedEntity = Mapper.Map<ReferenceSchoolClassification, EducationProviderClassification>(item);
            var areaUnitsLookup = _repositoryService.GetAreaUnits< EducationProviderClassification>(); // is CACHED DATA
            if (areaUnitsLookup.TryGetValue(mappedEntity.FIRSTKey, out var existingEntity))
            {
                _repositoryService.UpdateAreaUnit(existingEntity, mappedEntity);
            }
            else
            {
                _repositoryService.AddAreaUnit(mappedEntity);
            }
            //_repositoryService.UpdateOnCommit(_dbKey, );
            // Some Sky Magic Code
        }
    }
}
