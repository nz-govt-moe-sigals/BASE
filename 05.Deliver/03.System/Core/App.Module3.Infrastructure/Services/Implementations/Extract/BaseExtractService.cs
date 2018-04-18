using App.Core.Infrastructure.Services;
using App.Module3.Infrastructure.Db.Context;
using App.Module3.Infrastructure.Initialization.ObjectMaps.Messages.Extract;
using App.Module3.Shared.Models.Messages.Extract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;


namespace App.Module3.Infrastructure.Services.Implementations.Extract
{
    public class BaseExtractService<T> : IBaseExtractService
        where T: BaseMessage
    {
        protected readonly AppModule3DbContext _dbContext;
        private readonly string _sourceTableName;
        private JsonSerializerSettings _jsonSerializerSettings;
        protected readonly IExtractAzureDocumentDbService _documentDBService;

        public BaseExtractService(AppModule3DbContext dbContext, IExtractAzureDocumentDbService documentDBService)
        {
            _dbContext = dbContext;
            _documentDBService = documentDBService;
            _sourceTableName = ExtractConstants.LookupTableNameList(typeof(T));
        }

        public string SourceTableName { get { return _sourceTableName; } }


        public void Process()
        {
            var watermarkTime = GetWatermark();
            var datatoUpdate = GetDataToUpdate(watermarkTime);
            UpdateLocalData(datatoUpdate);
            UpdateWaterMark(watermarkTime);
            //Ideally call some sort of Save here!
        }



        public virtual DateTime GetWatermark()
        {
            //need to extract this out into a method so i can test 
            var record =  _dbContext.ExtractWatermarks.SingleOrDefault(x => x.SourceTableName == SourceTableName);
            if(record != null)
            {
                return record.Watermark;
            }
            return new DateTime(2001, 01, 01);
        }

        protected JsonSerializerSettings GetJsonSerializerSettings()
        {
            if(_jsonSerializerSettings == null)
            {
                _jsonSerializerSettings = new JsonSerializerSettings()
                {
                    ContractResolver = ContractResolverFactory.GetContractResolver<T>()
                };
            }
            return _jsonSerializerSettings;
        }

        /// <summary>
        /// returns a list of 
        /// </summary>
        /// <param name="watermark">Get data after this point</param>
        /// <returns></returns>
        public virtual List<T> GetDataToUpdate(DateTime watermark)
        {
            // connnect to document DB and retrieve data
            // timestamp should be Greater thjan the watermark gotten from  the DB
            var queryable = _documentDBService.GetDocuments<T>(GetJsonSerializerSettings(), _sourceTableName);

            return queryable.ToList();// Want to invoke at the moment, might just leave it to the end
        }

        public virtual void UpdateLocalData(List<T> list)
        {
            // Some Sky Magic Code
        }

        public virtual void UpdateWaterMark(DateTime watermark)
        {
            //need to extract this out into a method so i can test 
            var record = _dbContext.ExtractWatermarks.SingleOrDefault(x => x.SourceTableName == SourceTableName);
            if(record == null)
            {
                _dbContext.ExtractWatermarks.Add(new Shared.Models.Entities.ExtractWatermark()
                {
                    Watermark = watermark,
                    SourceTableName = SourceTableName
                });
            }
            else
            {
                record.Watermark = watermark;
            }
        }


    }
}
