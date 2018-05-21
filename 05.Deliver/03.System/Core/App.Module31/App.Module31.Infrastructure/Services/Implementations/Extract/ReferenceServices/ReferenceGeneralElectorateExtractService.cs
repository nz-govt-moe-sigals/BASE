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
    public class ReferenceGeneralElectorateExtractService
        : BaseExtractService<ReferenceGeneralElectorate>
    {
        public ReferenceGeneralElectorateExtractService(BaseExtractServiceConfiguration configuration, IDiagnosticsTracingService tracingService, IExtractAzureDocumentDbService documentDbService)
            : base(configuration, tracingService, documentDbService)
        {

        }

        public override void UpdateLocalData(IExtractRepositoryService repositoryService,  ReferenceGeneralElectorate item)
        {
            var mappedEntity = Mapper.Map<ReferenceGeneralElectorate, GeneralElectorate>(item);
            repositoryService.AddOrUpdateSifData(mappedEntity);
        }

    }
}





