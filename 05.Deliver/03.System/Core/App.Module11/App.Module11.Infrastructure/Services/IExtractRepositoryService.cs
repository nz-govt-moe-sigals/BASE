
﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Module11.Shared.Models;
using App.Module11.Shared.Models.Entities;

namespace App.Module11.Infrastructure.Services
{
    public interface IExtractRepositoryService
    {
        ExtractWatermark GetWaterMarkTimestamp(string sourceTableName);

        void UpdateWaterMarkTimeStamp(ExtractWatermark watermark);

        ConcurrentDictionary<string, SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase> GetSifCachedData<T>()
            where T : SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase;
 
        void AddOrUpdateSifData<T>(T entity) where T : SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase;

        void AddSifData<T>(T newAreaUnit) where T : SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase;

        void UpdateSifData<T>(T exisitingAreaUnit, T newAreaUnit) where T : SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase;

        void AddOrUpdateNonCachedData<TModel>(TModel model) where TModel : class, IHasSourceSystemKey;

        EducationProviderProfile GetEducationProviderProfile(int schoolId);

        void AddOrUpdateEducationProfile(EducationProviderProfile profile);

        void CommitResults();

        T LookupSifReference<T>(string id, SifLookup enumSifLookup)
            where T : SifSouceDataBase;
    }
}
