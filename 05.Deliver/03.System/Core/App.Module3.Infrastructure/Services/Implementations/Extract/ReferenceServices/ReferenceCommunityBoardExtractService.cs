﻿using System;
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
    public class ReferenceCommunityBoardExtractService : BaseExtractService<ReferenceCommunityBoard>
    {
        public ReferenceCommunityBoardExtractService(BaseExtractServiceConfiguration configuration, IDiagnosticsTracingService tracingService, IExtractAzureDocumentDbService documentDbService)
            : base(configuration, tracingService, documentDbService)
        {

        }

        public override void UpdateLocalData(IExtractRepositoryService repositoryService, ReferenceCommunityBoard item)
        {
            var mappedEntity = Mapper.Map<ReferenceCommunityBoard, CommunityBoard>(item);
            repositoryService.AddOrUpdateSifData(mappedEntity);
        }
    }
}
