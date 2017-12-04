namespace App.Module1.Infrastructure.Initialization.DependencyResolution
{
    using System;
    using App.Module1.Infrastructure.Initialization.Db;

    public static class AppModule1ServiceLocatorInitializer
    {
        public static Type[] ScanForCoreInitializers()
        {
            return new[]
            {
                typeof(IHasAppModule1DbContextModelBuilderInitializer),
                typeof(IHasAppModule1DbContextSeedInitializer)
            };
        }
    }
}