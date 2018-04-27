using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Constants.Db;
using App.Core.Infrastructure.Services.Implementations;
using App.Module3.Infrastructure.Db.Context;

namespace App.Module3.Infrastructure.Services.Implementations
{
    public class Module3RepositoryService : RepositoryService, IModule3RepositoryService
    {
        private DbContext _dbContext;
        private string _dbKey = Constants.Db.AppModule3DbContextNames.Module3;
        private bool _batched = false;
        public Module3RepositoryService()
        {
            _dbContext = base.GetDbContext(_dbKey);
        }

        protected override DbContext GetDbContext(string contextKey)
        {
            return _dbContext;
        }

        public void ConfigureBatchProcessing(bool batched = true)
        {
            _batched = batched;
            _dbContext.Configuration.AutoDetectChangesEnabled = !batched;
            _dbContext.Configuration.ValidateOnSaveEnabled = !batched;
        }

        public int CommitBatch()
        {
            //if (_batched)
            //{
            //    _dbContext.ChangeTracker.DetectChanges();
            //}
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
            
            
        }
    }
}
