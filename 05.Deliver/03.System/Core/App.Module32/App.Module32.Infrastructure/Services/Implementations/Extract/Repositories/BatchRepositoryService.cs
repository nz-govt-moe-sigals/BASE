using System;
using System.Collections.Generic;
using App.Core.Infrastructure.Services.Implementations;
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
        public BatchRepositoryService()
        {
            //_dbContext = base.GetDbContext(_dbKey);
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





