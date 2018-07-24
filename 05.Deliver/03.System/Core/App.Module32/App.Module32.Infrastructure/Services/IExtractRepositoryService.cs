using System.Collections.Generic;
using System.Linq;
using App.Module32.Shared.Models.Entities;

namespace App.Module32.Infrastructure.Services
{
    public interface IExtractRepositoryService<T>
    {
        ExtractWatermark GetWaterMarkTimestamp(string sourceTableName);

        void UpdateWaterMarkTimeStamp(ExtractWatermark watermark);


        IQueryable<T> GetFilteredExistingData(IList<T> list);


        void CommitResults();

        void AddOrUpdateList(IList<T> list);

    }
}





