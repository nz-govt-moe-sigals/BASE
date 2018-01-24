namespace App.Core.Infrastructure.Services
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Interception;

    /// <summary>
    /// Contract for an Infrastructure Service to 
    /// pre-process all new/updated/modified entities
    /// belonging to a specific DbContext, before 
    /// they are saved.
    /// <para>
    /// This service implementation is invoked because
    /// the various DbContext implementations (eg: AppDbContext)
    /// override their SaveChanges method to do so
    /// TODO: currently it's not automatically handled from the IUnitOfWorkService implementation.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.IHasAppCoreService" />
    public interface IDbContextPreCommitService : IHasAppCoreService
    {
        /// <summary>
        /// Pass all entities belonging to the specified DbContext
        /// through all implementations of 
        /// <see cref="IDbCommitPreCommitProcessingStrategy"/>
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        void PreProcess(DbContext dbContext);
    }
}