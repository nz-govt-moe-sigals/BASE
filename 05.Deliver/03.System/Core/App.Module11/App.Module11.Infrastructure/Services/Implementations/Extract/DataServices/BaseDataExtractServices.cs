using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services;
using App.Module11.Infrastructure.Services.Configuration;
using App.Module11.Shared.Models.Entities;
using App.Module11.Shared.Models.Messages.Extract;

namespace App.Module11.Infrastructure.Services.Implementations.Extract.DataServices
{
    public abstract class BaseDataExtractServices<T> : BaseExtractService<T>
        where T : BaseMessage
    {
        public BaseDataExtractServices(BaseExtractServiceConfiguration configuration, IDiagnosticsTracingService tracingService, IExtractAzureDocumentDbService documentDbService)
            :base(configuration, tracingService, documentDbService)
        {

        }

        public Guid LookUp<Y>(IExtractRepositoryService repositoryService, string code)
            where Y : SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase
        {
            var value = NullableLookUp<Y>(repositoryService, code);
            if (value.HasValue)
            {
                return value.Value;
            }
            throw new ArgumentException($"code expected but not found for type : {typeof(Y)}");
        }

        public Guid? NullableLookUp<Y>(IExtractRepositoryService repositoryService, string code)
            where Y : SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase
        {
            if (string.IsNullOrWhiteSpace(code)) { return null; }
            var areaUnitsLookup = repositoryService.GetSifCachedData<Y>();
            if (areaUnitsLookup.TryGetValue(code, out var existingEntity))
            {
                return existingEntity.Id;
            }
            throw new ArgumentException($"Has code : {code} not found for type : {typeof(Y)}");
        }


    }
}
