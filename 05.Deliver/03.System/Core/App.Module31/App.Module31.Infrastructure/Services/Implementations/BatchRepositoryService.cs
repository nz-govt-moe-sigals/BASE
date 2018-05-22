using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Constants.Db;
using App.Core.Infrastructure.Services.Implementations;
using App.Module31.Infrastructure.Db.Context;

namespace App.Module31.Infrastructure.Services.Implementations
{
    public class BatchRepositoryService : RepositoryService, IBatchRepositoryService
    {
       // private DbContext _dbContext;
        private string _dbKey = Constants.Db.AppModuleDbContextNames.Module11;
        private bool _batched = false;
        public BatchRepositoryService()
        {
            //_dbContext = base.GetDbContext(_dbKey);
        }

        /*
        protected override DbContext GetDbContext(string contextKey)
        {
            return _dbContext;
        }
        */
        public void ConfigureBatchProcessing(bool batched = true)
        {
            var _dbContext = base.GetDbContext(_dbKey);
            _batched = batched;
            _dbContext.Configuration.AutoDetectChangesEnabled = !batched;
            _dbContext.Configuration.ValidateOnSaveEnabled = !batched;
            _dbContext.Configuration.LazyLoadingEnabled = !batched;
        }



        public int CommitBatch()
        {
            var _dbContext = base.GetDbContext(_dbKey);
            if (_batched)
            {
               _dbContext.ChangeTracker.DetectChanges();
            }

            try
            {

                var result = _dbContext.SaveChanges();
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





