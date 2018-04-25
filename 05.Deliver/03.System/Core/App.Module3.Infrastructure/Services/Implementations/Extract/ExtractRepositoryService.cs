﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services;
using App.Module3.Infrastructure.Services.Implementations.Configuration;
using App.Module3.Shared.Models;
using App.Module3.Shared.Models.Entities;
using AutoMapper;

namespace App.Module3.Infrastructure.Services.Implementations.Extract
{
    public class ExtractRepositoryService : IExtractRepositoryService
    {
        private string _dbKey = Constants.Db.AppModule3DbContextNames.Module3;
        private readonly IModule3RepositoryService _repositoryService;
        private readonly ExtractCachedRepoObject _repoObject;
        private readonly IUnitOfWorkService _unitOfWorkService;
        private bool? _educationProviderProfileHasData;

        public ExtractRepositoryService(ExtractCachedRepoObject repoObject, IModule3RepositoryService repositoryService, IUnitOfWorkService unitOfWorkService)
        {
            _repositoryService = repositoryService;
            _repoObject = repoObject ?? new ExtractCachedRepoObject();
            _unitOfWorkService = unitOfWorkService;
        }


        public ExtractWatermark GetWaterMarkTimestamp(string sourceTableName)
        {
            return _repositoryService.GetSingle<ExtractWatermark>(_dbKey, x => x.SourceTableName == sourceTableName);
        }

        public void UpdateWaterMarkTimeStamp(ExtractWatermark watermark)
        {
            _repositoryService.AddOrUpdate<ExtractWatermark>(_dbKey, x => x.SourceTableName, watermark);
        }

        public IDictionary<string, SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase> GetSifCachedData<T>()
            where T : SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase
        {
            var cache = _repoObject.GetCachedLookUpData<T>();
            if (cache == null)
            {
                cache = new ConcurrentDictionary<string, SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase>(_repositoryService.GetQueryableSet<T>(_dbKey)
                    .ToDictionary(x => x.SourceSystemKey, x => (SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase) x));
                _repoObject.CacheLookUpData<T>(cache);
            }
            return cache;
        }

        //Hmmm probably should make this baseReference but ontodo list;
        public void AddSifData<T>(T newAreaUnit)
            where T : SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase
        {
            GetSifCachedData<T>().Add(newAreaUnit.SourceSystemKey, newAreaUnit); 
            AddOnCommit(newAreaUnit);
        }

        public void UpdateSifData<T>(T exisitingAreaUnit, T newAreaUnit)
            where T : SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase
        {
            exisitingAreaUnit.Text = newAreaUnit.Text;
            UpdateOnCommit(exisitingAreaUnit);
        }

        public void CommitResults()
        {
            _unitOfWorkService.CommitBatch(_dbKey);
        }


        public EducationProviderProfile GetEducationProviderProfile(string schoolId)
        {
            EducationProviderProfile profile;
            if (!_repoObject.EducationProviderProfiles.TryGetValue(schoolId, out profile))
            {
                if (EducationProviderProfileHasData())
                {
                    profile = _repositoryService.GetSingle<EducationProviderProfile>(_dbKey, x => x.SourceSystemKey == schoolId);
                    if (profile != null)
                    {
                        _repoObject.EducationProviderProfiles.Add(profile.SourceSystemKey, profile);
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
                _educationProviderProfileHasData = false;
                var count = _repositoryService.Count<EducationProviderProfile>(_dbKey);
                if (count > 0)
                {
                    _educationProviderProfileHasData = true;
                }
            }
            return _educationProviderProfileHasData.Value;

        }


        public void AddOrUpdateEducationProfile(EducationProviderProfile profile)
        {
            var profileToUpdate = GetEducationProviderProfile(profile.SourceSystemKey);
            if (profileToUpdate != null)
            {
                Mapper.Map<EducationProviderProfile, EducationProviderProfile>(profile, profileToUpdate);
                _repositoryService.UpdateOnCommit(_dbKey, profileToUpdate);
            }
            else
            {
                _repoObject.EducationProviderProfiles.Add(profile.SourceSystemKey, profile);
               _repositoryService.AddOnCommit(_dbKey, profile);
            }
        }


        public void AddOrUpdate<TModel>(TModel model) where TModel : class, IHasSourceSystemKey
        {
            _repositoryService.AddOrUpdate<TModel>(_dbKey, x => x.SourceSystemKey == model.SourceSystemKey, model);
        }

        private void AddOnCommit<TModel>(TModel model) where TModel : class
        {
            _repositoryService.AddOnCommit(_dbKey, model);
        }

        private void UpdateOnCommit<TModel>(TModel model) where TModel : class
        {
            _repositoryService.UpdateOnCommit(_dbKey, model);
        }

    }
}
