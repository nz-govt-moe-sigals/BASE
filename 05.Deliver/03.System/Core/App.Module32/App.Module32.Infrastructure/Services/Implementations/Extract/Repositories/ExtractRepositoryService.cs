using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public ExtractRepositoryService(IDiagnosticsTracingService diagnosticsTracingService,
            IBatchRepositoryService repositoryService)
        {
            _diagnosticsTracingService = diagnosticsTracingService;
            _repositoryService = repositoryService;
            _repositoryService.ConfigureBatchProcessing();
        }

        public ExtractWatermark GetWaterMarkTimestamp(string sourceTableName)
        {
            return _repositoryService.GetSingle<ExtractWatermark>(_dbKey, x => x.SourceTableName == sourceTableName);
        }

        public void UpdateWaterMarkTimeStamp(ExtractWatermark watermark)
        {
            _repositoryService.AddOrUpdate<ExtractWatermark>(_dbKey, x => x.SourceTableName, watermark);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// TODO seperate this class to abstract and then use repo per service? Possibly some shared db cache object between them
        public void AddOrUpdate(EducationSchoolProfile model) 
        {
            //write lock around this possibly
            var existingItem = _repositoryService.GetSingle<EducationSchoolProfile>(_dbKey, x => x.SchoolId == model.SchoolId);
            if (existingItem != null)
            {
                UpdateOnCommit(existingItem);
                Mapper.Map<EducationSchoolProfile, EducationSchoolProfile>(model, existingItem);
            }
            else
            {
                AddOnCommit(model);
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
