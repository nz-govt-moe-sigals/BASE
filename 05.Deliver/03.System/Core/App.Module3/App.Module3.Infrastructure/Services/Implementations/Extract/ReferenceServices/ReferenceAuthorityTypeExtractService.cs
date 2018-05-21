using App.Module3.Infrastructure.Services.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services;
using App.Module3.Shared.Models.Entities;
using App.Module3.Shared.Models.Entities.Sif;
using App.Module3.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module3.Infrastructure.Services.Implementations.Extract.ReferenceServices
{
    public class ReferenceAuthorityTypeExtractService : BaseExtractService<ReferenceAuthorityType>
    {
        public ReferenceAuthorityTypeExtractService(BaseExtractServiceConfiguration configuration, IDiagnosticsTracingService tracingService, IExtractAzureDocumentDbService documentDbService)
            : base(configuration, tracingService, documentDbService)
        {

        }

        public override void UpdateLocalData(IExtractRepositoryService repositoryService,  ReferenceAuthorityType item)
        {
            var mappedEntity = Mapper.Map<ReferenceAuthorityType, AuthorityType>(item);
            var sifData = repositoryService.LookupSifReference<SifAuthorityType>(mappedEntity.SourceSystemKey, SifLookup.FirstId);
            if (sifData != null)
            {
                mappedEntity.SIFKey = sifData.SifId;
            }
            repositoryService.AddOrUpdateSifData(mappedEntity);
        }
    }
}
