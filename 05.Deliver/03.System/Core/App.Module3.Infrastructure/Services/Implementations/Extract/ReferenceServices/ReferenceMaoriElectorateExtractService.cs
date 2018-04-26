
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
    public class ReferenceMaoriElectorateExtractService
        : BaseExtractService<ReferenceMaoriElectorate>
    {
        public ReferenceMaoriElectorateExtractService(BaseExtractServiceConfiguration configuration, IExtractRepositoryService reposorityService, IExtractAzureDocumentDbService documentDbService)
            : base(configuration, reposorityService, documentDbService)
        {

        }

        public override void UpdateLocalData(ReferenceMaoriElectorate item)
        {
            var mappedEntity = Mapper.Map<ReferenceMaoriElectorate, MaoriElectorate>(item);
            var areaUnitsLookup = _repositoryService.GetSifCachedData< AreaUnit>(); // is CACHED DATA
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
