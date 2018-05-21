
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services;
using App.Module11.Infrastructure.Services.Configuration;
using App.Module11.Shared.Models.Entities;
using App.Module11.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module11.Infrastructure.Services.Implementations.Extract.ReferenceServices
{
    public class ReferenceMaoriElectorateExtractService
        : BaseExtractService<ReferenceMaoriElectorate>
    {
        public ReferenceMaoriElectorateExtractService(BaseExtractServiceConfiguration configuration, IDiagnosticsTracingService tracingService, IExtractAzureDocumentDbService documentDbService)
            : base(configuration, tracingService, documentDbService)
        {

        }

        public override void UpdateLocalData(IExtractRepositoryService repositoryService,  ReferenceMaoriElectorate item)
        {
            var mappedEntity = Mapper.Map<ReferenceMaoriElectorate, MaoriElectorate>(item);
            repositoryService.AddOrUpdateSifData(mappedEntity);
        }
    }
}
