namespace App.Module2.Infrastructure.Initialization.Implementations
{
    using System;
    using App.Module2.Infrastructure.Initialization.Db;

    public static class AppModule2ServiceLocatorInitializer
    {
        public static Type[] ScanForCoreInitializers()
        {
            return new[]
            {
                typeof(IHasAppModule2DbContextModelBuilderInitializer),
                typeof(IHasAppModule2DbContextSeedInitializer)
            };
        }
    }
}