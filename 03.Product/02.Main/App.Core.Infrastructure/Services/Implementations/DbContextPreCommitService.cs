//using App.Core.Infrastructure.Db.DbContextFactories;
//using App.Core.Infrastructure.Db.DbContextFactories.Implementations;

namespace App.Core.Infrastructure.Services
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Interception;

    public class DbContextPreCommitService : IDbContextPreCommitService
    {
        public void PreProcess(DbContext dbContext)
        {
            AppDependencyLocator.Current
                .GetAllInstances<IDbCommitPreCommitProcessingStrategy>()
                .ForEach(x => x.Process(dbContext));
        }
    }
}