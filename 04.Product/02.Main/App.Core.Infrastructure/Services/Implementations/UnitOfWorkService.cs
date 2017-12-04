namespace App.Core.Infrastructure.Services.Implementations
{
    using System.Data.Entity;

    public class UnitOfWorkService : IUnitOfWorkService
    {
        /// <summary>
        ///     Commit the specific DbContext.
        /// </summary>
        /// <param name="contextName"></param>
        /// <returns></returns>
        public int Commit(string contextName = null)
        {
            var result = 0;
            foreach (var dbContext in AppDependencyLocator.Current.GetAllInstances<DbContext>())
            {
                result += dbContext.SaveChanges();
            }
            return result;
        }
    }
}