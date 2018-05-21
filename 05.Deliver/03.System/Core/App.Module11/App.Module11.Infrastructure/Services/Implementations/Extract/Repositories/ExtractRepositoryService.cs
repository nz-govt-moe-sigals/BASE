using System;
using System.Collections.Concurrent;
using System.Linq;
using App.Core.Infrastructure.Services;
using App.Module11.Infrastructure.Services.Implementations.Configuration;
using App.Module11.Shared.Models;
using App.Module11.Shared.Models.Entities;
using AutoMapper;

namespace App.Module11.Infrastructure.Services.Implementations.Extract.Repositories
{
    public class ExtractRepositoryService : IExtractRepositoryService
    {
        private string _dbKey = Constants.Db.AppModuleDbContextNames.Module11;
        private readonly IModule11RepositoryService _repositoryService;
        private readonly ExtractCachedRepoObject _repoObject;
        private readonly IExtractSifRepositoryService _extractSifRepositoryService;
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private bool? _educationProviderProfileHasData;
        private object _lock = new Object();

        public ExtractRepositoryService(ExtractCachedRepoObject repoObject, IDiagnosticsTracingService diagnosticsTracingService, 
            IModule11RepositoryService repositoryService, IExtractSifRepositoryService extractSifRepositoryService)
        {
            _repositoryService = repositoryService;
            _repositoryService.ConfigureBatchProcessing();
            _repoObject = repoObject ?? new ExtractCachedRepoObject();
            _extractSifRepositoryService = extractSifRepositoryService;
            _diagnosticsTracingService = diagnosticsTracingService;
        }


        public ExtractWatermark GetWaterMarkTimestamp(string sourceTableName)
        {
            return _repositoryService.GetSingle<ExtractWatermark>(_dbKey, x => x.SourceTableName == sourceTableName);
        }

        public void UpdateWaterMarkTimeStamp(ExtractWatermark watermark)
        {
            _repositoryService.AddOrUpdate<ExtractWatermark>(_dbKey, x => x.SourceTableName, watermark);
        }

        public ConcurrentDictionary<string, SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase> GetSifCachedData<T>()
            where T : SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase
        {
            var cache = _repoObject.GetCachedLookUpData<T>();
            if (cache == null)
            {
                lock (_lock) 
                {
                    cache = _repoObject.GetCachedLookUpData<T>();
                    if (cache == null)
                    {
                        cache = new ConcurrentDictionary<string, SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase>(_repositoryService.GetQueryableSet<T>(_dbKey)
                           .ToDictionary(x => x.SourceSystemKey, x => (SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase)x));
                        _repoObject.CacheLookUpData<T>(cache);
                    }
                    
                }
            }
            return cache;
        }

        public T LookupSifReference<T>(string id, SifLookup enumSifLookup)
            where T : SifSouceDataBase
        {
            if (enumSifLookup == SifLookup.EvaId)
            {
                return _extractSifRepositoryService.GetSingle<T>(_dbKey, x => x.EvaId == id);
            }
            if (enumSifLookup == SifLookup.FirstId)
            {
                return _extractSifRepositoryService.GetSingle<T>(_dbKey, x => x.FirstId == id);
            }
            return _extractSifRepositoryService.GetSingle<T>(_dbKey, x => x.SifId == id);
        }

        public void AddOrUpdateSifData<T>(T entity) where T : SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase
        {
            var lookup = GetSifCachedData<T>(); // is CACHED DATA
            if (lookup.TryGetValue(entity.SourceSystemKey, out var existingEntity))
            {
                UpdateSifData(existingEntity as T, entity);
            }
            else
            {
                AddSifData(entity);
            }
        }

        public void AddSifData<T>(T newAreaUnit)
            where T : SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase
        {
            GetSifCachedData<T>().TryAdd(newAreaUnit.SourceSystemKey, newAreaUnit); 
            AddOnCommit(newAreaUnit);
        }

        public void UpdateSifData<T>(T exisitingAreaUnit, T newAreaUnit)
            where T : SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase
        {
            UpdateOnCommit(exisitingAreaUnit);
            Mapper.Map<T, T>(newAreaUnit, exisitingAreaUnit);
        }

        public void CommitResults()
        {
            _repositoryService.CommitBatch();
        }


        public EducationProviderProfile GetEducationProviderProfile(int schoolId)
        {
            EducationProviderProfile profile;
            if (!_repoObject.EducationProviderProfiles.TryGetValue(schoolId, out profile))
            {
                if (EducationProviderProfileHasData())
                {
                    lock (_lock)
                    {
                        if (!_repoObject.EducationProviderProfiles.TryGetValue(schoolId, out profile))
                        {
                            profile = _repositoryService.GetSingle<EducationProviderProfile>(_dbKey,
                                x => x.SchoolId == schoolId);
                            if (profile != null)
                            {
                                _repoObject.EducationProviderProfiles.TryAdd(profile.SchoolId, profile);
                            }
                        }
                    }
                    
                }
                
            }
            return profile;
        }

        /// <summary>
        /// Check to see if any rows exist, that way i know If doing a quick import or not, 
        /// </summary>
        /// <returns></returns>
        public bool EducationProviderProfileHasData()
        {
            if (_educationProviderProfileHasData == null)
            {
                
                lock (_lock)
                {
                    if (_educationProviderProfileHasData == null)
                    {
                        _educationProviderProfileHasData = false;
                        var count = _repositoryService.Count<EducationProviderProfile>(_dbKey);
                        if (count > 0)
                        {
                            _educationProviderProfileHasData = true;
                        }
                    }
                }
            }
            return _educationProviderProfileHasData.Value;

        }


        public void AddOrUpdateEducationProfile(EducationProviderProfile profile)
        {
            var existingProfile = GetEducationProviderProfile(profile.SchoolId);
            if (existingProfile != null)
            {
                UpdateOnCommit(existingProfile);
                Mapper.Map<EducationProviderProfile, EducationProviderProfile>(profile, existingProfile);
            }
            else
            {
                _repoObject.EducationProviderProfiles.TryAdd(profile.SchoolId, profile);
                 AddOnCommit(profile);
            }
        }


        public void AddOrUpdateNonCachedData<TModel>(TModel model) where TModel : class, IHasSourceSystemKey
        {
            //write lock around this possibly
            var existingItem = _repositoryService.GetSingle<TModel>(_dbKey, x => x.SourceSystemKey == model.SourceSystemKey);
            if (existingItem != null)
            {
                UpdateOnCommit(existingItem);
                Mapper.Map<TModel, TModel>(model, existingItem);
            }
            else
            {
                AddOnCommit(model);
            }
        }

        private void AddOnCommit<TModel>(TModel model) where TModel : class
        {
            _repositoryService.AddOnCommit(_dbKey, model);
        }

        private void UpdateOnCommit<TModel>(TModel model) where TModel : class
        {
            _repositoryService.AttachOnCommit(_dbKey, model);
        }


    }

}
