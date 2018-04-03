namespace App.Core.Infrastructure.Services.Implementations
{
    using System.Data.Entity;


    /// <summary>
    ///     Implementation of the
    ///     <see cref="IUnitOfWorkService" />
    ///     Infrastructure Service Contract
    /// for a generic unit of work service
    /// which manages the persistence of entities
    /// using one or more channels (note 
    /// that in most apps, this is usually just wrapping
    /// one -- the DbContext client). 
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.IUnitOfWorkService" />
    public class UnitOfWorkService : AppCoreServiceBase, IUnitOfWorkService
    {
        /// <summary>
        /// Commits a single specific named repository, or all of pending changes.
        /// </summary>
        /// <param name="contextName"></param>
        /// <returns></returns>
        public int Commit(string contextName = null)
        {
            var result = 0;
            
            foreach (var dbContext in AppDependencyLocator.Current.GetAllInstances<DbContext>())
            {
                try
                {
                    // Note that I've sort of forgetten how, 
                    // it's wired up, but this will trigger 
                    // calls to all instances of 
                    // IDbCommitPreCommitProcessingStrategy
                    // via IDbContextPreCommitService
                    result += dbContext.SaveChanges();
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
            return result;
        }
    }
}