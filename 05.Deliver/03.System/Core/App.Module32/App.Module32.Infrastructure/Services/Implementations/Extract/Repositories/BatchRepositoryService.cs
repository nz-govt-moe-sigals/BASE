using System;
using System.Collections.Generic;
using App.Core.Infrastructure.Services;
using App.Core.Infrastructure.Services.Implementations;
using App.Core.Shared.Models;
using App.Module32.Infrastructure.Db.Context;
using EntityFramework.Utilities;

namespace App.Module32.Infrastructure.Services.Implementations.Extract.Repositories
{
    public class BatchRepositoryService : RepositoryService, IBatchRepositoryService
    {
       // private DbContext _dbContext;
        private string _dbKey = App.Module32.Infrastructure.Constants.Db.AppModuleDbContextNames.Default;
        private bool _batched = false;
        private Guid _id;
        private IUniversalDateTimeService _dateTimeService;
        private IPrincipalService _principalService;

        public BatchRepositoryService(
            IUniversalDateTimeService dateTimeService,
            IPrincipalService principalService)
        {
            //_dbContext = base.GetDbContext(_dbKey);
            _dateTimeService = dateTimeService;
            _principalService = principalService;
            _id = Guid.NewGuid();
        }

        /*
        protected override DbContext GetDbContext(string contextKey)
        {
            return _dbContext;
        }
        */
        public void ConfigureBatchProcessing(bool batched = true)
        {
            var dbContext = base.GetDbContext(_dbKey);
            _batched = batched;
            dbContext.Configuration.AutoDetectChangesEnabled = !batched;
            dbContext.Configuration.ValidateOnSaveEnabled = !batched;
            dbContext.Configuration.LazyLoadingEnabled = !batched;
        }


        public void PreProcessEntity(IHasInRecordAuditability entity)
        {
            if (!entity.CreatedOnUtc.HasValue)
            {
                entity.CreatedOnUtc = this._dateTimeService.NowUtc().UtcDateTime;
            }

            if (entity.CreatedByPrincipalId == null)
            {
                entity.CreatedByPrincipalId = this._principalService.CurrentPrincipalIdentifier ?? "ANON";
            }

            entity.LastModifiedOnUtc = this._dateTimeService.NowUtc().UtcDateTime;
            entity.LastModifiedByPrincipalId = this._principalService.CurrentPrincipalIdentifier ?? "ANON";

        }

        public void UpdateAll<TEntity>(IEnumerable<TEntity> list, Action<UpdateSpecification<TEntity>> updateSpec)
            where TEntity : class
        {
            var batchOp = EFBatchOperation.For(base.GetDbContext(_dbKey), base.GetDbSet<TEntity>(_dbKey));
            batchOp.UpdateAll(list, updateSpec);
        }

        public void InsertAll<TEntity>(IEnumerable<TEntity> list)
            where TEntity : class
        {
            var batchOp = EFBatchOperation.For(base.GetDbContext(_dbKey), base.GetDbSet<TEntity>(_dbKey));
            batchOp.InsertAll(list);
        }


        public int CommitBatch()
        {
            var dbContext = base.GetDbContext(_dbKey);
            if (_batched)
            {
               dbContext.ChangeTracker.DetectChanges();
            }

            try
            {
                var result = dbContext.SaveChanges();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                ConfigureBatchProcessing();
            }
            
            
        }
    }
}





