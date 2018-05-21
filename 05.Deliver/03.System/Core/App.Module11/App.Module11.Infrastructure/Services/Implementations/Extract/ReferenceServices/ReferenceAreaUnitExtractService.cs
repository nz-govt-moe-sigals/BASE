using App.Core.Infrastructure.Services;
using App.Module11.Infrastructure.Services.Configuration;
using App.Module11.Shared.Models.Entities;
using App.Module11.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module11.Infrastructure.Services.Implementations.Extract.ReferenceServices
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
