using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Module3.Infrastructure.Services.Configuration;
using App.Module3.Shared.Models.Entities;
using App.Module3.Shared.Models.Messages.Extract;

namespace App.Module3.Infrastructure.Services.Implementations.Extract.DataServices
{
    public abstract class BaseDataExtractServices<T> : BaseExtractService<T>
        where T : BaseMessage
    {
        public BaseDataExtractServices(BaseExtractServiceConfiguration configuration, IExtractRepositoryService reposorityService, IExtractAzureDocumentDbService documentDbService)
            :base(configuration, reposorityService, documentDbService)
        {

        }

        public Guid LookUp<T>(string code)
            where T : SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase
        {
            var value = NullableLookUp<T>(code);
            if (value.HasValue)
            {
                return value.Value;
            }
            throw new ArgumentException($"code expected but not found for type : {typeof(T)}");
        }

        public Guid? NullableLookUp<T>(string code)
            where T : SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase
        {
            if (string.IsNullOrWhiteSpace(code)) { return null; }
            var areaUnitsLookup = _repositoryService.GetSifCachedData<T>();
            if (areaUnitsLookup.TryGetValue(code, out var existingEntity))
            {
                return existingEntity.Id;
            }
            throw new ArgumentException($"Has code : {code} not found for type : {typeof(T)}");
        }


    }
}
