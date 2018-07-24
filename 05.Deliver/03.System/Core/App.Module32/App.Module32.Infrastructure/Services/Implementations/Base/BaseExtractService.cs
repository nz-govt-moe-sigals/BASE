using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.Entities;
using App.Module32.Infrastructure.Services.Interfaces.Extract;
using App.Module32.Shared.Models.Entities;
using App.Module32.Shared.Models.Messages.Extract;
using App.Module32.Shared.Models.Messages.Extract.Base;
using Newtonsoft.Json;

namespace App.Module32.Infrastructure.Services.Implementations.Base
{

    public abstract class BaseExtractService<T, TEntity> : IBaseExtractService
        where T: IExtractMessage
    {
        
        protected readonly IExtractAzureDocumentDbService<T> DocumentDbService;
        protected readonly IDiagnosticsTracingService TracingService;
        protected readonly IExtractRepositoryService<TEntity> RepositoryService;
        private readonly SemaphoreSlim _concurrencySemaphore = new SemaphoreSlim(10);

        protected BaseExtractService(IDiagnosticsTracingService tracingService, IExtractAzureDocumentDbService<T> documentDbService,
            IExtractRepositoryService<TEntity> repositoryService)
        {
            DocumentDbService = documentDbService;
            
            TracingService = tracingService;
            RepositoryService = repositoryService;
        }

        public virtual void Process()
        {
            var existingWaterMark = GetWatermark();
            var rowcount = GetDataCount(existingWaterMark);
            DateTime? updatedWaterMark = Task.Run(() => ProcessAllRecordsAsync(existingWaterMark, rowcount)).Result;
     
            UpdateWaterMark(existingWaterMark, updatedWaterMark);
            RepositoryService.CommitResults();
        }

        private async Task<DateTime?> ProcessAllRecordsAsync(DateTime watermark, int rowcount)
        {
            if (rowcount == 0) { return null;}

            DateTime? updatedWaterMark = null;
            int take = DocumentDbService.PageQuerySize;
            var iterationCount = (double)rowcount / (double)take;

            var tasks = new List<Task<DateTime?>>();
            for (var i = 0; i <= iterationCount; i++)
            {
                _concurrencySemaphore.Wait();
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
                        _concurrencySemaphore.Release();
                    }
                });

                tasks.Add(task);
            }

            try
            {
                var results = await Task.WhenAll(tasks);
                updatedWaterMark = results.Max();
            }
            catch (AggregateException e)
            {
                // catch whatever was thrown
                foreach (Exception ex in e.InnerExceptions)
                {
                    TracingService.Trace(TraceLevel.Error, $"Exception Message: {ex.Message}, Stack Trace: {ex.StackTrace}");
                }
            }

            return updatedWaterMark;
        }

        private async Task<DateTime?> ProcessRecordsAsync(DateTime watermark)
        {
            var datatoUpdate = await GetDataToUpdateAsync(watermark);; 
            var updatedWaterMark = GetMaxTime(datatoUpdate);
            if (datatoUpdate == null || datatoUpdate.Count == 0) { return updatedWaterMark; }
            ProcessDatatoCreateOrUpdate(datatoUpdate);
 
            return updatedWaterMark;
        }


        protected virtual async Task<IList<T>> GetDataToUpdateAsync(DateTime watermark)
        {
            var x = await DocumentDbService.ExecuteGetDocumentsAsync(watermark);
            return x.ToList();
        }

        public virtual int GetDataCount(DateTime watermark)
        {
            return DocumentDbService.GetDocumentCount(watermark);
        }


        public virtual DateTime GetWatermark()
        {
            //need to extract this out into a method so i can test 
            var record = RepositoryService.GetWaterMarkTimestamp(GetSourceTableName());
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
        /// <param name="list"></param>
        public virtual void ProcessDatatoCreateOrUpdate(IList<T> list)
        {
            if (list == null || list.Count == 0) { return; }

            var entityList = CreateEntities(list);
            AddOrUpdateList(entityList);
            RepositoryService.CommitResults();
        }

        public virtual List<TEntity> CreateEntities(IList<T> list)
        {
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

            return entityList;
        }

        public virtual void AddOrUpdateList(IList<TEntity> entityList)
        {
            RepositoryService.AddOrUpdateList(entityList);
        }


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
        /// <param name="extistingWatermark">the existing watermark</param>
        /// <param name="updatedWaterMark">should be the value that we are to update to</param>
        public virtual void UpdateWaterMark(DateTime extistingWatermark, DateTime? updatedWaterMark)
        {
            //need to extract this out into a method so i can test 
            if (!updatedWaterMark.HasValue) { return; }
            if (extistingWatermark > updatedWaterMark.Value) { return; }

            var entity = new ExtractWatermark()
            {
                Watermark = updatedWaterMark.Value,
                SourceTableName = GetSourceTableName()
            };

            RepositoryService.UpdateWaterMarkTimeStamp(entity);
        }

        public void HandleConversionException(Exception ex, object item)
        {
            TracingService.Trace(TraceLevel.Error, $"{ex.Message}, source: {JsonConvert.SerializeObject(item)}");
        }

        public void HandleConversionException(string message, object item)
        {
            TracingService.Trace(TraceLevel.Error, $"{message}, source: {JsonConvert.SerializeObject(item)}");
        }

        protected string GetSourceTableName()
        {
            return DocumentDbService.SourceTableName;
        }


    }
}





