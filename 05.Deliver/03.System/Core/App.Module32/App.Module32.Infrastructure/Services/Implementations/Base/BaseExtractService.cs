using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.DependencyResolution;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.Entities;
using App.Module32.Shared.Models.Entities;
using App.Module32.Shared.Models.Messages.Extract;
using App.Module32.Shared.Models.Messages.Extract.Base;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace App.Module32.Infrastructure.Services.Implementations.Base
{

    public abstract class BaseExtractService<T, TEntity> : IBaseExtractService
        where T: BaseMessage
    {
        protected readonly string _sourceTableName;
        protected readonly IExtractAzureDocumentDbService _documentDbService;
        protected readonly IDiagnosticsTracingService _tracingService;
        protected readonly IExtractRepositoryService _repositoryService;

        public BaseExtractService(IDiagnosticsTracingService tracingService, IExtractAzureDocumentDbService documentDbService,
            IExtractRepositoryService repositoryService)
        {
            _documentDbService = documentDbService;
            _sourceTableName = ExtractConstants.LookupTableNameList(typeof(T));
            _tracingService = tracingService;
            _repositoryService = repositoryService;
        }

        public string SourceTableName { get { return _sourceTableName; } }


        public virtual void Process()
        {
            var existingWaterMark = GetWatermark(_repositoryService);
            var rowcount = GetDataCount(existingWaterMark);
            DateTime? updatedWaterMark = Task.Run(() => ProcessAllRecordsAsync(existingWaterMark, rowcount)).Result;
     
            UpdateWaterMark(_repositoryService, existingWaterMark, updatedWaterMark);
            _repositoryService.CommitResults();
        }

        private async Task<DateTime?> ProcessAllRecordsAsync(DateTime watermark, int rowcount)
        {
            if (rowcount == 0) { return null;}

            DateTime? updatedWaterMark = null;
            int take = _documentDbService.PageQuerySize;
            var iterationCount = (double)rowcount / (double)take;
            using (SemaphoreSlim concurrencySemaphore = new SemaphoreSlim(10))
            {
                var tasks = new List<Task<DateTime?>>();
                for (var i = 0; i <= iterationCount; i++)
                {
                    concurrencySemaphore.Wait();
                    var skip = i * take;
                    var task = Task<DateTime?>.Factory.StartNew(() =>
                    {
                        try
                        {
                            return ProcessRecordsAsync(watermark).Result;
                        }
                        finally
                        {
                            // ReSharper disable once AccessToDisposedClosure
                            concurrencySemaphore.Release();
                        }
                    });

                    tasks.Add(task);
                }
                var results = await Task.WhenAll(tasks);
                updatedWaterMark = results.Max();
            }
           
            return updatedWaterMark;
        }

        private async Task<DateTime?> ProcessRecordsAsync(DateTime watermark)
        {
            var datatoUpdate = await GetDataToUpdateAsync(watermark);
            var repo = _repositoryService; // AppDependencyLocator.Current.GetInstance<IExtractRepositoryService>(); 
            var updatedWaterMark = GetMaxTime(datatoUpdate);
            if (datatoUpdate == null || datatoUpdate.Count == 0) { return updatedWaterMark; }
            ProcessLocalDataList(repo, datatoUpdate);
            repo.CommitResults();
            return updatedWaterMark;
        }

        protected virtual Task<IEnumerable<T>> GetDataQueryToUpdateAsync(DateTime watermark)
        {
            return _documentDbService.ExecuteGetDocumentsAsync<T>(_sourceTableName, watermark);
           
        }

        protected virtual async Task<IList<T>> GetDataToUpdateAsync(DateTime watermark)
        {
            var x = await _documentDbService.ExecuteGetDocumentsAsync<T>(_sourceTableName, watermark);
            return x.ToList();
        }

        public virtual int GetDataCount(DateTime watermark)
        {
            return _documentDbService.GetDocuments<T>(_sourceTableName, watermark).Count();
        }


        public virtual DateTime GetWatermark(IExtractRepositoryService repositoryService)
        {
            //need to extract this out into a method so i can test 
            var record = repositoryService.GetWaterMarkTimestamp(SourceTableName);
            if (record != null)
            {
                return record.Watermark;
            }
            return new DateTime(2001, 01, 01);
        }



        /// <summary>
        /// Get the maxTime from the list
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public virtual DateTime? GetMaxTime(IList<T> list)
        {
            if (list == null || list.Count == 0){ return null;}

            return list.Max(x => x.ModifiedDate);
        }

        /// <summary>
        /// Protect the method  so it doesn't do anything dumb 
        /// </summary>
        /// <param name="repositoryService"></param>
        /// <param name="list"></param>
        protected virtual void ProcessLocalDataList(IExtractRepositoryService repositoryService, IList<T> list)
        {
            if (list == null || list.Count == 0) { return; }
            var entityList = new List<TEntity>(); 
            foreach (var item in list) //
            {
                try
                {
                    var mappedItem = MapLocalDataToEntity(item);
                    entityList.Add(mappedItem);
                }
                catch (Exception e)
                {
                   HandleConversionException(e, item);
                }
            }

            AddOrUpdateList(repositoryService, entityList);
        }

        protected abstract void AddOrUpdateList(IExtractRepositoryService repositoryService, IList<TEntity> entityList);
        //{
        //    // always override for now as I think I should create a repo per Service so Can Just execute
        //}


        /// <summary>
        /// shouldn't need to write any guard clauses or if you do oveerride the UpdateLocalDataWithGuard method
        /// </summary>
        /// <param name="item">update each item</param>
        public virtual TEntity MapLocalDataToEntity(T item)
        {
            return AutoMapper.Mapper.Map<T, TEntity>(item);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="repositoryService">repo</param>
        /// <param name="extistingWatermark">the existing watermark</param>
        /// <param name="updatedWaterMark">should be the value that we are to update to</param>
        public virtual void UpdateWaterMark(IExtractRepositoryService repositoryService, DateTime extistingWatermark, DateTime? updatedWaterMark)
        {
            //need to extract this out into a method so i can test 
            if (!updatedWaterMark.HasValue) { return; }
            if (extistingWatermark > updatedWaterMark.Value) { return; }

            var entity = new ExtractWatermark()
            {
                Watermark = updatedWaterMark.Value,
                SourceTableName = SourceTableName
            };

            repositoryService.UpdateWaterMarkTimeStamp(entity);
        }

        public void HandleConversionException(Exception ex, object item)
        {
            _tracingService.Trace(TraceLevel.Error, $"{ex.Message}, source: {JsonConvert.SerializeObject(item)}");
        }


    }
}





