
using App.Core.Infrastructure.Services;
using App.Module3.Infrastructure.Db.Context;
using App.Module3.Shared.Models.Entities;
using App.Module3.Shared.Models.Messages.Extract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using App.Core.Shared.Models.Entities;


namespace App.Module3.Infrastructure.Services.Implementations.Extract
{
    using App.Module3.Infrastructure.Services.Configuration;

    public class BaseExtractService<T> : IBaseExtractService
        where T: BaseMessage
    {
        private readonly BaseExtractServiceConfiguration _configuration;
        protected readonly string _sourceTableName;
        protected readonly IExtractAzureDocumentDbService _documentDbService;
        protected readonly IDiagnosticsTracingService _tracingService;


        public BaseExtractService(BaseExtractServiceConfiguration configuration, IDiagnosticsTracingService tracingService, IExtractAzureDocumentDbService documentDbService)
        {
            this._configuration = configuration;
            _documentDbService = documentDbService;
            _sourceTableName = ExtractConstants.LookupTableNameList(typeof(T));
            _tracingService = tracingService;
        }

        public string SourceTableName { get { return _sourceTableName; } }


        public void Process(IExtractRepositoryService repositoryService)
        {
            var existingWaterMark = GetWatermark(repositoryService);
            var datatoUpdate = GetDataToUpdate(existingWaterMark);
            var updatedWaterMark = GetMaxTime(datatoUpdate);
            UpdateLocalDataList(repositoryService, datatoUpdate);
            UpdateWaterMark(repositoryService, existingWaterMark, updatedWaterMark);
            repositoryService.CommitResults();
            //_unitOfWorkService.Commit(_dbKey);
            //Ideally call some sort of Save here!
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
        /// returns a list of 
        /// </summary>
        /// <param name="watermark">Get data after this point</param>
        /// <returns></returns>
        public virtual IList<T> GetDataToUpdate(DateTime watermark)
        {
            // connnect to document DB and retrieve data
            // timestamp should be Greater thjan the watermark gotten from  the DB
            var queryable = _documentDbService.GetDocuments<T>(_sourceTableName, watermark);

            return queryable.ToList();// Want to invoke at the moment, might just leave it to the end
        }

        public virtual DateTime? GetMaxTime(IList<T> list)
        {
            if (list == null || list.Count == 0){ return null;}

            return list.Max(x => x.ModifiedDate);
        }

        /// <summary>
        /// Protect the method  so it doesn't do anything dumb 
        /// </summary>
        /// <param name="list"></param>
        protected virtual void UpdateLocalDataList(IExtractRepositoryService repositoryService, IList<T> list)
        {
            if (list == null || list.Count == 0) { return; }

            var count = 0;
            foreach (var item in list.OrderBy(x => x.ModifiedDate)) // Order by modified date so that if we get a duplicate record it should get to the latest version last
            {
                try
                {
                    UpdateLocalData(repositoryService, item);
                }
                catch (Exception e)
                {
                   HandleConversionException(e, item);
                }
                count++;
            }
            
        }

        /// <summary>
        /// shouldn't need to write any guard clauses or if you do oveerride the UpdateLocalDataWithGuard method
        /// </summary>
        /// <param name="item">update each item</param>
        public virtual void UpdateLocalData(IExtractRepositoryService repositoryService, T item)
        {
        }


        /// <summary>
        /// 
        /// </summary>
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
