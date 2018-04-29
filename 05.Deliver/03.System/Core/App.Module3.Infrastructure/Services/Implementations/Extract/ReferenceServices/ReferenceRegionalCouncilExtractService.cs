using System;
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
    public class ReferenceRegionalCouncilExtractService
        : BaseExtractService<ReferenceRegionalCouncil>
    {
        public ReferenceRegionalCouncilExtractService(BaseExtractServiceConfiguration configuration, IDiagnosticsTracingService tracingService, IExtractAzureDocumentDbService documentDbService)
            : base(configuration, tracingService, documentDbService)
        {

        }

        public override void UpdateLocalData(IExtractRepositoryService repositoryService, ReferenceRegionalCouncil item)
        {
            var mappedEntity = Mapper.Map<ReferenceRegionalCouncil, RegionalCouncil>(item);
            var areaUnitsLookup = repositoryService.GetSifCachedData< RegionalCouncil>(); // is CACHED DATA
            if (areaUnitsLookup.TryGetValue(mappedEntity.SourceSystemKey, out var existingEntity))
            {
                repositoryService.UpdateSifData(existingEntity, mappedEntity);
            }
            else
            {
                repositoryService.AddSifData(mappedEntity);
            }
            //_repositoryService.UpdateOnCommit(_dbKey, );
            // Some Sky Magic Code
        }
    }
}
