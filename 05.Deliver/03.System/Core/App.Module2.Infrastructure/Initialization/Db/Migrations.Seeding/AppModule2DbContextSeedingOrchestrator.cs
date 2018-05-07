using App.Core.Infrastructure.Initialization.DependencyResolution;

namespace App.Module2.Infrastructure.Db.Migrations.Seeding
{
    using System;
    using System.Diagnostics;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;
    using App.Module2.Infrastructure.Db.Context;
    using App.Module2.Infrastructure.Initialization;
    using App.Module2.Infrastructure.Initialization.Db;

    // Invoked from within AppModule2DbMigrationsConfiguration.Seed method, 
    public class AppModule2DbContextSeedingOrchestrator
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModule2DbContextSeedingOrchestrator(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        // This method will be called after migrating to the latest version.
        public void Initialize(AppModule2DbContext context)
        {
            //if (!PowershellServiceLocatorConfig.Activated)
            //{
            //    // Actually, Seeding needs to be done in a specific order
            //    // so for now ByHand is preferable 
            //    SeedByReflectionWontWorkFromPowershell(context);
            //}
            //else
            //{
            //    //Reflection does not work under Powershell, so:
            SeedByHand(context);
            //}
        }

        // I spend ages on this...but it won't work. 
        // Even though Db Modeling can work via reflection
        // even when invoked from powershell (add-migration)
        // This approach will work from code, but not powershell (update-database)
        // You *have* to define Seed elements by hand.
        // In one way it's better. There's an order which must be followed
        // when seeding, that can be done via Attributes ([After/Before])
        // but for now this is ok.
        private void SeedByReflectionWontWorkFromPowershell(AppModule2DbContext context)
        {
            AppDependencyLocator.Current.GetAllInstances<IHasAppModule2DbContextSeedInitializer>()
                .ForEach(x => x.Seed(context));
        }

        private void SeedByHand(AppModule2DbContext dbContext)
        {
            AttachDebuggerWhenRunningUnderPowershell();

            AppDependencyLocator.Current.GetInstance<AppModule2DbContextSeederBodyCategory>().Seed(dbContext);
            AppDependencyLocator.Current.GetInstance<AppModule2DbContextSeederBodyName>().Seed(dbContext);
            AppDependencyLocator.Current.GetInstance<AppModule2DbContextSeederBody>().Seed(dbContext);
            AppDependencyLocator.Current.GetInstance<AppModule2DbContextSeederBodyProperty>().Seed(dbContext);
            AppDependencyLocator.Current.GetInstance<AppModule2DbContextSeederBodyClaim>().Seed(dbContext);
            AppDependencyLocator.Current.GetInstance<AppModule2DbContextSeederEducationOrganisation>().Seed(dbContext);
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
                    //Debugger.Launch();
                }
            }
        }
    }
}