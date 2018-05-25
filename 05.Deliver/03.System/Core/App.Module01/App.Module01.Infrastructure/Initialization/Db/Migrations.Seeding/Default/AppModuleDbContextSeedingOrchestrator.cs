using App.Core.Infrastructure.Initialization.DependencyResolution;

namespace App.Module01.Infrastructure.Db.Migrations.Seeding
{
    using System;
    using System.Diagnostics;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;
    using App.Module01.Infrastructure.Db.Context;
    using App.Module01.Infrastructure.Initialization;
    using App.Module01.Infrastructure.Initialization.Db;

    // Invoked from within AppModuleDefaultDbMigrationsConfiguration.Seed method, 
    public class AppModuleDbContextSeedingOrchestrator: IHasModuleSpecificIdentifier
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModuleDbContextSeedingOrchestrator(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        // This method will be called after migrating to the latest version.
        public void Initialize(AppModuleDbContext context)
        {
            //    if (!PowershellServiceLocatorConfig.Activated)
            //    {
            //        // Actually, Seeding needs to be done in a specific order
            //        // so for now ByHand is preferable 
            //        SeedByReflection(context);
            //    }
            //    else
            //    {
            //        //Reflection does not work under Powershell, so:
            SeedByHand(context);
            //    }
        }

        // I spend ages on this...but it won't work. 
        // Even though Db Modeling can work via reflection
        // even when invoked from powershell (add-migration)
        // This approach will work from code, but not powershell (update-database)
        // You *have* to define Seed elements by hand.
        // In one way it's better. There's an order which must be followed
        // when seeding, that can be done via Attributes ([After/Before])
        // but for now this is ok.
        private void SeedByReflection(AppModuleDbContext context)
        {
            AppDependencyLocator.Current.GetAllInstances<IHasAppModuleDbContextSeedInitializer>()
                .ForEach(x => x.Seed(context));
        }

        private void SeedByHand(AppModuleDbContext dbContext)
        {
            AttachDebuggerWhenRunningUnderPowershell();
            AppDependencyLocator.Current.GetInstance<AppModuleDbContextSeederExample>().Seed(dbContext);
        }

        private void AttachDebuggerWhenRunningUnderPowershell()
        {
            var debuggerConfiguration = this._hostSettingsService.GetObject<CodeFirstMigrationConfigurationSettings>();

            if (debuggerConfiguration.CodeFirstAttachDebugger)
            {
                // You'll *REALLY* like this piece of code if you are having trouble
                // with seeding:
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                if (Debugger.IsAttached == false)
                {
                    // Don't comment this out -- there's a config file switch!
                    Debugger.Launch();
                }
            }
        }
    }
}