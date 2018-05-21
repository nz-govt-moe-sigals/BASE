using App.Core.Infrastructure.Services;
using App.Module31.Infrastructure.Services.Configuration;
using App.Module31.Shared.Models.Entities;
using App.Module31.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module31.Infrastructure.Services.Implementations.Extract.ReferenceServices
{
    public class ReferenceAreaUnitExtractService : BaseExtractService<ReferenceAreaUnit>
    {
        public ReferenceAreaUnitExtractService(BaseExtractServiceConfiguration configuration, IDiagnosticsTracingService tracingService, IExtractAzureDocumentDbService documentDbService)
            :base(configuration, tracingService, documentDbService)
        {

        }

        public override void UpdateLocalData(IExtractRepositoryService repositoryService, ReferenceAreaUnit item)
        {
            var mappedEntity = Mapper.Map<ReferenceAreaUnit, AreaUnit>(item);
            repositoryService.AddOrUpdateSifData(mappedEntity);
        }
    }
}





