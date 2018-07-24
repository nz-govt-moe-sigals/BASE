using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services;
using App.Module32.Infrastructure.Services.Interfaces.Extract;
using App.Module32.Shared.Models.Entities;
using App.Module32.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module32.Infrastructure.Services.Implementations.Extract.Repositories
{
    public abstract class ExtractRepositoryService<T> : IExtractRepositoryService<T>
    {
        protected const string DbKey = Constants.Db.AppModuleDbContextNames.Default;
        protected IDiagnosticsTracingService DiagnosticsTracingService;
        protected readonly IBatchRepositoryService RepositoryService;

        protected SemaphoreSlim Mutex;


        protected ExtractRepositoryService(IDiagnosticsTracingService diagnosticsTracingService,
            IBatchRepositoryService repositoryService)
        {
            DiagnosticsTracingService = diagnosticsTracingService;
            RepositoryService = repositoryService;
            Mutex = new SemaphoreSlim(1);
            RepositoryService.ConfigureBatchProcessing();
        }


        public virtual ExtractWatermark GetWaterMarkTimestamp(string sourceTableName)
        {
            return RepositoryService.GetSingle<ExtractWatermark>(DbKey, x => x.SourceTableName == sourceTableName);
        }

        public virtual void UpdateWaterMarkTimeStamp(ExtractWatermark watermark)
        {
            RepositoryService.AddOrUpdate<ExtractWatermark>(DbKey, x => x.SourceTableName, watermark);
        }


        public virtual void AddOrUpdateList(IList<T> list)
        {
            //write lock around this possibly
            Mutex.Wait();
            try
            {
                AddOrUpdateListThrottled(list);
            }
            finally
            {
                Mutex.Release();
            }

        }

        public abstract IQueryable<T> GetFilteredExistingData(IList<T> list);

        protected abstract void AddOrUpdateListThrottled(IList<T> list);

        protected abstract void CommitResults(IList<T> addList, IList<T> updateList);



        protected void AddOnCommit<TModel>(TModel model) where TModel : class
        {
            RepositoryService.AddOnCommit(DbKey, model);
        }

        protected void UpdateOnCommit<TModel>(TModel model) where TModel : class
        {
            RepositoryService.AttachOnCommit(DbKey, model);
        }

        public void CommitResults()
        {
            RepositoryService.CommitBatch();
        }

     
    }
}
