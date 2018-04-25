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
        private readonly AppModule3DbContext _dbContext;

        public Module3RepositoryService(AppModule3DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override DbContext GetDbContext(string contextKey)
        {
            return _dbContext;
        }
    }
}
