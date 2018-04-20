using System;
using System.Collections.Generic;
using App.Core.Infrastructure.Services;
using App.Module3.Infrastructure.Services.Configuration;
using App.Module3.Shared.Models.Entities;
using App.Module3.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module3.Infrastructure.Services.Implementations.Extract
{
    public class ReferenceAreaUnitExtractService : BaseExtractService<ReferenceAreaUnit>
    {
        public ReferenceAreaUnitExtractService(BaseExtractServiceConfiguration configuration, IExtractRepositoryService reposorityService, 
            IUnitOfWorkService unitOfWorkService, IExtractAzureDocumentDbService documentDbService)
            :base(configuration, reposorityService, unitOfWorkService, documentDbService)
        {

        }

        public override void UpdateLocalData(ReferenceAreaUnit item)
        {
            var mappedEntity = Mapper.Map<ReferenceAreaUnit, AreaUnit>(item);
            var areaUnitsLookup = _repositoryService.GetAreaUnits(); // is CACHED DATA
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
