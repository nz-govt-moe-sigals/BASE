namespace App.Core.Infrastructure.Services
{
    using System.Data.Entity;

    public interface IDbContextPreCommitService : IHasAppCoreService
    {
        void PreProcess(DbContext dbContext);
    }
}