using System;
using System.Collections.Generic;
using System.Linq;
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

    public abstract class BaseExtractService<T> : IBaseExtractService
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


        public void Process()
        {
            var existingWaterMark = GetWatermark(_repositoryService);
            var rowcount = GetDataCount(existingWaterMark);
            DateTime? updatedWaterMark = Task.Run(() => ProcessAllRecordsAsync(existingWaterMark, rowcount)).Result;
     
            UpdateWaterMark(_repositoryService, existingWaterMark, updatedWaterMark);
            _repositoryService.CommitResults();
        }

        private async Task<DateTime?> ProcessAllRecordsAsync(DateTime watermark, int rowcount)
        {
            DateTime? updatedWaterMark = null;
            if (rowcount > 0)
            {
                var list = new List<Task<DateTime?>>();
                int take = 500;
                var iterationCount = (double) rowcount / (double) take;
                for (var i = 0; i <= iterationCount; i++)
                {
                    var skip = i * take;
                    var task = Task.Run(() => ProcessRecordsAsync(watermark, skip , take));
                    list.Add(task);
                }

                var results = await Task.WhenAll(list);
                updatedWaterMark = results[list.Count - 1]; // get the last one because its ordered
            }

            return updatedWaterMark;
        }

        private async Task<DateTime?> ProcessRecordsAsync(DateTime watermark, int skip, int take)
        {
            var datatoUpdate = await _documentDbService.ExecuteDocumentDbWithRetries(() => Task.Run(() =>GetDataToUpdate(watermark,skip, take)));
            var repo = AppDependencyLocator.Current.GetInstance<IExtractRepositoryService>();
            var updatedWaterMark = GetMaxTime(datatoUpdate);
            UpdateLocalDataList(repo, datatoUpdate);
            repo.CommitResults();
            return updatedWaterMark;
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

        private IEnumerable<T> _enumerable;
        private object lockobj = new object();

        protected virtual IEnumerable<T> GetQueryForDataToUpdate(DateTime watermark)
        {
            // connnect to document DB and retrieve data
            // timestamp should be Greater than the watermark gotten from  the DB
            if (_enumerable == null)
            {
                lock (lockobj)
                {
                    if (_enumerable == null)
                    {
                        _enumerable = _documentDbService.GetDocuments<T>(_sourceTableName, watermark)
                            .OrderBy(x => x.ModifiedDate)
                            .ToList(); // execute right here right now so it doesn't go off everytime
                    }
                }
            }
            
            // IDEALLY we wouldn't have to do this but it seems that Doucment DB Does not support GroupBy
            // Doesnt support Skip or Take either... Microsoft products are truely the worst
            return _enumerable;
        }


        /// <summary>
        /// returns a list of 
        /// </summary>
        /// <param name="watermark">Get data after this point</param>
        /// <param name="skip">Skip these Many</param>
        /// <param name="take">Select these Many e.g. Top</param>
        /// <returns></returns>
        public virtual IList<T> GetDataToUpdate(DateTime watermark, int? skip = null, int? take = null)
        {
            var queryable = GetQueryForDataToUpdate(watermark);
            if (skip.HasValue)
            {
                queryable = queryable.Skip(skip.Value);
            }
            if (take != null)
            {
                queryable = queryable.Take(take.Value);
            }
            return queryable.ToList();// Want to invoke at the moment, might just leave it to the end
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
        protected virtual void UpdateLocalDataList(IExtractRepositoryService repositoryService, IList<T> list)
        {
            if (list == null || list.Count == 0) { return; }

            foreach (var item in list) //
            {
                try
                {
                    UpdateLocalData(repositoryService, item);
                }
                catch (Exception e)
                {
                   HandleConversionException(e, item);
                }
            }
            
        }

        /// <summary>
        /// shouldn't need to write any guard clauses or if you do oveerride the UpdateLocalDataWithGuard method
        /// </summary>
        /// /// <param name="repositoryService"></param>
        /// <param name="item">update each item</param>
        public abstract void UpdateLocalData(IExtractRepositoryService repositoryService, T item);



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





