namespace App.Module11.Infrastructure.Initialization.Implementations
{
    using System;
    using App.Module11.Infrastructure.Initialization.Db;

    public /*static*/ class AppModuleServiceLocatorInitializer: IHasModuleSpecificIdentifier
    {
        public static Type[] ScanForCoreInitializers()
        {
            return new[]
            {
                typeof(IHasAppModuleDbContextModelBuilderInitializer),
                typeof(IHasAppModuleDbContextSeedInitializer)
            };
        }
    }
}





