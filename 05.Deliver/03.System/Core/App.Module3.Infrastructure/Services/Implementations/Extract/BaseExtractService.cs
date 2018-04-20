﻿using App.Core.Infrastructure.Services;
using App.Module3.Infrastructure.Db.Context;
using App.Module3.Shared.Models.Entities;
using App.Module3.Shared.Models.Messages.Extract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;


namespace App.Module3.Infrastructure.Services.Implementations.Extract
{
    using App.Module3.Infrastructure.Services.Configuration;

    public class BaseExtractService<T> : IBaseExtractService
        where T: BaseMessage
    {
        private readonly BaseExtractServiceConfiguration _configuration;
        protected readonly IRepositoryService _repositoryService;
        protected readonly IUnitOfWorkService _unitOfWorkService;
        protected readonly string _sourceTableName;
        protected readonly IExtractAzureDocumentDbService _documentDBService;
        protected string _dbKey = Constants.Db.AppModule3DbContextNames.Module3;

        public BaseExtractService(BaseExtractServiceConfiguration configuration, IRepositoryService reposorityService, IUnitOfWorkService unitOfWorkService,  IExtractAzureDocumentDbService documentDBService)
        {
            this._configuration = configuration;
            _repositoryService = reposorityService;
            _documentDBService = documentDBService;
            _sourceTableName = ExtractConstants.LookupTableNameList(typeof(T));
        }

        public string SourceTableName { get { return _sourceTableName; } }


        public void Process()
        {
            var existingWaterMark = GetWatermark();
            var datatoUpdate = GetDataToUpdate(existingWaterMark);
            var updatedWaterMark = GetMaxTime(datatoUpdate);
            UpdateLocalData(datatoUpdate);
            UpdateWaterMark(existingWaterMark, updatedWaterMark);
            //_unitOfWorkService.Commit(_dbKey);
            //Ideally call some sort of Save here!
        }



        public virtual DateTime GetWatermark()
        {
            //need to extract this out into a method so i can test 
            
            var record =  _repositoryService.GetSingle<ExtractWatermark>(_dbKey, x => x.SourceTableName == SourceTableName);

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
            var queryable = _documentDBService.GetDocuments<T>(_sourceTableName, watermark);

            return queryable.ToList();// Want to invoke at the moment, might just leave it to the end
        }

        public virtual DateTime? GetMaxTime(IList<T> list)
        {
            if (list == null || list.Count == 0)
            {
                return null;
            }

            return list.Max(x => x.ModifiedDate);
        }

        public virtual void UpdateLocalData(IList<T> list)
        {
            if (list == null || list.Count == 0)
            {
                return;
            }
            // Some Sky Magic Code
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="updatedWaterMark">should be the value that we are to update to</param>
        public virtual void UpdateWaterMark(DateTime extistingWatermark, DateTime? updatedWaterMark)
        {
            //need to extract this out into a method so i can test 
            if (!updatedWaterMark.HasValue)
            {
                return;
            }

            if (extistingWatermark > updatedWaterMark.Value)
            {
                return;
            }

            var entity = new Shared.Models.Entities.ExtractWatermark()
            {
                Watermark = updatedWaterMark.Value,
                SourceTableName = SourceTableName
            };
            _repositoryService.AddOrUpdate<ExtractWatermark>(_dbKey, x => x.SourceTableName, entity);
        }


    }
}
