using App.Core.Infrastructure.Services;
using App.Module3.Infrastructure.Services.Configuration;
using App.Module3.Shared.Models.Entities;
using App.Module3.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module3.Infrastructure.Services.Implementations.Extract.ReferenceServices
{
    public class ReferenceAreaUnitExtractService : BaseExtractService<ReferenceAreaUnit>
    {
        public ReferenceAreaUnitExtractService(BaseExtractServiceConfiguration configuration, IExtractRepositoryService reposorityService, IExtractAzureDocumentDbService documentDbService)
            :base(configuration, reposorityService,  documentDbService)
        {

        }

        public override void UpdateLocalData(ReferenceAreaUnit item)
        {
            var mappedEntity = Mapper.Map<ReferenceAreaUnit, AreaUnit>(item);
            var areaUnitsLookup = _repositoryService.GetAreaUnits<AreaUnit>(); // is CACHED DATA
            if (areaUnitsLookup.TryGetValue(mappedEntity.SourceSystemKey, out var existingEntity))
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
