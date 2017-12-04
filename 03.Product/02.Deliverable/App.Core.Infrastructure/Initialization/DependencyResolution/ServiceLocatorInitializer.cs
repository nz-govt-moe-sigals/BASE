namespace App.Core.Infrastructure.Initialization.DependencyResolution
{
    using System;
    using App.Core.Infrastructure.Initialization.Db;

    public static class AppCoreServiceLocatorInitializer
    {
        public static Type[] ScanForCoreInitializers()
        {
            return new[]
            {
                typeof(IHasAppCoreDbContextModelBuilderInitializer),
                typeof(IHasAppCoreDbContextSeedInitializer)
            };
        }
    }
}