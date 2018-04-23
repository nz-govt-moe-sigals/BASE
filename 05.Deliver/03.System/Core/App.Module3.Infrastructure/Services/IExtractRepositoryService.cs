using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Module3.Shared.Models.Entities;

namespace App.Module3.Infrastructure.Services
{
    public interface IExtractRepositoryService
    {
        ExtractWatermark GetWaterMarkTimestamp(string sourceTableName);

        void UpdateWaterMarkTimeStamp(ExtractWatermark watermark);

        IDictionary<string, SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase> GetAreaUnits<T>()
            where T : SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase;
 


        void AddAreaUnit<T>(T newAreaUnit) where T : SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase;

        void UpdateAreaUnit<T>(T exisitingAreaUnit, T newAreaUnit) where T : SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase;

        void CommitResults();
    }
}
