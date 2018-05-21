using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services;
using App.Module11.Infrastructure.Services.Configuration;
using App.Module11.Shared.Models.Entities;
using App.Module11.Shared.Models.Entities.Sif;
using App.Module11.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module11.Infrastructure.Services.Implementations.Extract.ReferenceServices
{
    public class ReferenceOrganisationStatusExtractService
        : BaseExtractService<ReferenceOrganisationStatus>
    {
        public ReferenceOrganisationStatusExtractService(BaseExtractServiceConfiguration configuration, IDiagnosticsTracingService tracingService, IExtractAzureDocumentDbService documentDbService)
            : base(configuration, tracingService, documentDbService)
        {

        }

        public override void UpdateLocalData(IExtractRepositoryService repositoryService, ReferenceOrganisationStatus item)
        {
            var mappedEntity = Mapper.Map<ReferenceOrganisationStatus, EducationProviderStatus>(item);
            var sifData = repositoryService.LookupSifReference<SifOrganisationStatus>(mappedEntity.SourceSystemKey, SifLookup.FirstId);
            if (sifData != null)
            {
                mappedEntity.SIFKey = sifData.SifId;
            }
            repositoryService.AddOrUpdateSifData(mappedEntity);
        }
    }
}
