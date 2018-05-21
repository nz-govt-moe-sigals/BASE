using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services;
using App.Module31.Infrastructure.Services.Configuration;
using App.Module31.Shared.Models.Entities;
using App.Module31.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module31.Infrastructure.Services.Implementations.Extract.ReferenceServices
{
    public class ReferenceTerritorialAuthorityExtractService
        : BaseExtractService<ReferenceTerritorialAuthority>
    {
        public ReferenceTerritorialAuthorityExtractService(BaseExtractServiceConfiguration configuration, IDiagnosticsTracingService tracingService, IExtractAzureDocumentDbService documentDbService)
            : base(configuration, tracingService, documentDbService)
        {

        }

        public override void UpdateLocalData(IExtractRepositoryService repositoryService, ReferenceTerritorialAuthority item)
        {
            var mappedEntity = Mapper.Map<ReferenceTerritorialAuthority, TerritorialAuthority>(item);
            repositoryService.AddOrUpdateSifData(mappedEntity);
        }
    }
}





