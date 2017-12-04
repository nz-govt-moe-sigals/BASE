namespace App.Core.Infrastructure.Services
{
    // The contract for a generic unit of work service
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