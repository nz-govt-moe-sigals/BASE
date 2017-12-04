namespace App
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Factories;
    using App.Core.Infrastructure.Initialization.DependencyResolution;
    using StructureMap;
    using StructureMap.Configuration.DSL.Expressions;
    using StructureMap.Web.Pipeline;

    public static class RegistryExtensions
    {
        public static void RegisterDbContextInHttpContext<TDbContext>(this Registry registry, string key)
            where TDbContext : DbContext, new()
        {
            if (!PowershellServiceLocatorConfig.Activated)
            {
                //Register it under DbContext context, but named:
                new CreatePluginFamilyExpression<DbContext>(registry,
                    new HttpContextLifecycle()).Use(y => DbContextFactory.Create<TDbContext>()).Named(key);

                //Register it under specific TDbContext, without name:
                new CreatePluginFamilyExpression<TDbContext>(registry,
                    new HttpContextLifecycle()).Use(y => DbContextFactory.Create<TDbContext>());
            }
            else
            {
                //Register it under DbContext context, but named:
                new CreatePluginFamilyExpression<DbContext>(registry,
                    new HybridLifecycle()).Use(y => DbContextFactory.Create<TDbContext>()).Named(key);

                //Register it under specific TDbContext, without name:
                new CreatePluginFamilyExpression<TDbContext>(registry,
                    new HybridLifecycle()).Use(y => DbContextFactory.Create<TDbContext>());

            };
        }
    }
}