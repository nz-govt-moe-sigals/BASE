namespace App.Core.Infrastructure.Services
{
    /// <summary>
    /// Contract for an Infrastructure Service 
    /// for a generic unit of work service
    /// which manages the persistence of entities
    /// using one or more channels (note 
    /// that in most apps, this is usually just wrapping
    /// one -- the DbContext client). 
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.IHasAppCoreService" />
    public interface IUnitOfWorkService : IHasAppCoreService
    {
        /// <summary>
        ///     Commits a single specific named repository, or all of pending changes.
        /// </summary>
        /// <param name="contextName">An optional specific repository name.</param>
        /// <returns>The number of changed records (in most cases ignore).</returns>
        int Commit(string contextName = null);
    }
}