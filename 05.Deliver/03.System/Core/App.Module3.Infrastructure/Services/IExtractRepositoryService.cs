
﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Module3.Shared.Models;
using App.Module3.Shared.Models.Entities;

namespace App.Module3.Infrastructure.Services
{
    public interface IExtractRepositoryService
    {
        ExtractWatermark GetWaterMarkTimestamp(string sourceTableName);

        void UpdateWaterMarkTimeStamp(ExtractWatermark watermark);

        ConcurrentDictionary<string, SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase> GetSifCachedData<T>()
            where T : SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase;
 


        void AddSifData<T>(T newAreaUnit) where T : SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase;

        void UpdateSifData<T>(T exisitingAreaUnit, T newAreaUnit) where T : SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase;

        void AddOrUpdate<TModel>(TModel model) where TModel : class, IHasSourceSystemKey;

        EducationProviderProfile GetEducationProviderProfile(int schoolId);

        void AddOrUpdateEducationProfile(EducationProviderProfile profile);

        void CommitResults();
    }
}