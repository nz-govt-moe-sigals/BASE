using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services;
using App.Module32.Shared.Models.Entities;
using AutoMapper;

namespace App.Module32.Infrastructure.Services.Implementations.Extract.Repositories
{
    public class ExtractRepositoryService : IExtractRepositoryService
    {
        private string _dbKey = Constants.Db.AppModuleDbContextNames.Default;
        private IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly IBatchRepositoryService _repositoryService;
        private SemaphoreSlim _lockSemaphoreSlim;

        public ExtractRepositoryService(IDiagnosticsTracingService diagnosticsTracingService,
            IBatchRepositoryService repositoryService)
        {
            _diagnosticsTracingService = diagnosticsTracingService;
            _repositoryService = repositoryService;
            _repositoryService.ConfigureBatchProcessing();
            _lockSemaphoreSlim = new SemaphoreSlim(1);
        }

        public ExtractWatermark GetWaterMarkTimestamp(string sourceTableName)
        {
            return _repositoryService.GetSingle<ExtractWatermark>(_dbKey, x => x.SourceTableName == sourceTableName);
        }

        public void UpdateWaterMarkTimeStamp(ExtractWatermark watermark)
        {
            _repositoryService.AddOrUpdate<ExtractWatermark>(_dbKey, x => x.SourceTableName, watermark);
        }

        public IQueryable<EducationSchoolProfile> GetEducationSchoolProfiles(IList<EducationSchoolProfile> list)
        {
            if(list == null || !list.Any()) { return new List<EducationSchoolProfile>().AsQueryable();}
            var idList = list.Select(x => x.SchoolId);
            return _repositoryService.GetQueryableSet<EducationSchoolProfile>(_dbKey)
                .Where(p => idList.Contains(p.SchoolId)).AsNoTracking();
            ;
        }

        public IQueryable<EducationStudentProfile> GetEducationStudentProfiles(IList<EducationStudentProfile> list)
        {
            if (list == null || !list.Any()) { return new List<EducationStudentProfile>().AsQueryable(); }
            var idList = list.Select(x => x.NSN);
            return _repositoryService.GetQueryableSet<EducationStudentProfile>(_dbKey)
                .Where(p => idList.Contains(p.NSN)).AsNoTracking();
            ;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// TODO seperate this class to abstract and then use repo per service? Possibly some shared db cache object between them
        public void AddOrUpdateList(IList<EducationSchoolProfile> list) 
        {
            //write lock around this possibly
            _lockSemaphoreSlim.Wait();
            try
            {
                var exisitngItemsLookup = GetEducationSchoolProfiles(list).ToDictionary(x => x.SchoolId, x => x);
                var updateList = new List<EducationSchoolProfile>();
                var addList = new List<EducationSchoolProfile>();
                foreach (var model in list)
                {
                    if (exisitngItemsLookup.TryGetValue(model.SchoolId, out EducationSchoolProfile existingItem))
                    {
                        if (model.SourceModifiedDate >= existingItem.SourceModifiedDate) //TODO REMOVE =
                        {
                            Mapper.Map<EducationSchoolProfile, EducationSchoolProfile>(model, existingItem);
                            _repositoryService.PreProcessEntity(existingItem);
                            updateList.Add(existingItem);
                        }
                    }
                    else
                    {
                        _repositoryService.PreProcessEntity(model);
                        addList.Add(model);
                    }
                }

                CommitResults(addList, updateList);
            }
            finally
            {
                _lockSemaphoreSlim.Release();
            }
        }

        public void AddOrUpdateList(IList<EducationStudentProfile> list)
        {
            _lockSemaphoreSlim.Wait();
            try
            {
                var exisitngItemsLookup = GetEducationStudentProfiles(list).ToDictionary(x => x.NSN, x => x);
                var updateList = new List<EducationStudentProfile>();
                var addList = new List<EducationStudentProfile>();
                foreach (var model in list)
                {
                    if (exisitngItemsLookup.TryGetValue(model.NSN, out EducationStudentProfile existingItem))
                    {
                        if (model.SourceModifiedDate >= existingItem.SourceModifiedDate) //TODO REMOVE =
                        {
                            Mapper.Map<EducationStudentProfile, EducationStudentProfile>(model, existingItem);
                            _repositoryService.PreProcessEntity(existingItem);
                            updateList.Add(existingItem);
                        }
                    }
                    else
                    {
                        _repositoryService.PreProcessEntity(model);
                        addList.Add(model);
                    }
                }

                CommitResults(addList, updateList);
            }
            finally
            {
                _lockSemaphoreSlim.Release();
            }
        }

        private void CommitResults(IList<EducationStudentProfile> addList, IList<EducationStudentProfile> updateList)
        {
            if (addList != null && addList.Any())
            {
                var removedDuplicateAddList = addList
                    .GroupBy(x => x.NSN)
                    .Select(x => x.OrderByDescending(y => y.SourceModifiedDate).FirstOrDefault());
                _repositoryService.InsertAll(removedDuplicateAddList);
            }

            if (updateList != null && updateList.Any())
            {
                var removedDuplicateupdateList = updateList
                    .GroupBy(x => x.NSN)
                    .Select(x => x.OrderByDescending(y => y.SourceModifiedDate).FirstOrDefault());
                _repositoryService.UpdateAll(removedDuplicateupdateList, x => x.ColumnsToUpdate(
                    c => c.FullName,
                    c => c.Gender,
                    c => c.EducationSchoolProfileFK,
                    c => c.DateOfBirth,
                    c => c.SourceModifiedDate,
                    c => c.LastModifiedOnUtc,
                    c => c.LastModifiedByPrincipalId
                ));
            }

        }


        private void CommitResults(IList<EducationSchoolProfile> addList, IList<EducationSchoolProfile> updateList)
        {
            if (addList != null && addList.Any())
            {
                var removedDuplicateAddList = addList
                    .GroupBy(x => x.SchoolId)
                    .Select(x => x.OrderByDescending(y => y.SourceModifiedDate).FirstOrDefault());
                _repositoryService.InsertAll(removedDuplicateAddList);
            }

            if (updateList != null && updateList.Any())
            {
                var removedDuplicateupdateList = updateList
                    .GroupBy(x => x.SchoolId)
                    .Select(x => x.OrderByDescending(y => y.SourceModifiedDate).FirstOrDefault());
                _repositoryService.UpdateAll(removedDuplicateupdateList, x => x.ColumnsToUpdate(
                    c => c.Name,
                    c => c.SourceModifiedDate,
                    c => c.LastModifiedOnUtc,
                    c => c.LastModifiedByPrincipalId
                   ));
            }
         
        }

        protected void AddOnCommit<TModel>(TModel model) where TModel : class
        {
            _repositoryService.AddOnCommit(_dbKey, model);
        }

        protected void UpdateOnCommit<TModel>(TModel model) where TModel : class
        {
            _repositoryService.AttachOnCommit(_dbKey, model);
        }

        public void CommitResults()
        {
            _repositoryService.CommitBatch();
        }

     
    }
}
