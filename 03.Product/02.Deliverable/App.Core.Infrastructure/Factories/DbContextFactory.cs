
namespace App.Core.Infrastructure.Factories
{
    using System.Data.Entity;

    // Why go through the bother of a class and method?
    // I needed a actual instance that I could breakpoint
    // to see how many times a DbContext was being built
    // in a single request.
    public static class DbContextFactory
    {
        public static TDbContext Create<TDbContext>() where TDbContext : DbContext,new()
        {
            return new TDbContext();
            //return AppDependencyLocator.Current.GetInstance<TDbContext>();
        }
    }
}
