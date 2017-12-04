namespace App.Core.Infrastructure.Db.Migrations.Seeding
{
    using System;
    using System.Diagnostics;
    using App.Core.Infrastructure.Db.Context;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;

    // Invoked from within AppCoreDbMigrationsConfiguration.Seed method, 
    public class AppCoreDbContextSeedingOrchestrator
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppCoreDbContextSeedingOrchestrator(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        // This method will be called after migrating to the latest version.
        public void Initialize(AppCoreDbContext context)
        {
            //if (!PowershellServiceLocatorConfig.Activated)
            //{
            //    //Actually, Seeding needs to be done in a specific order
            //    //so for now ByHand is preferable 
            //    SeedByReflection(context);
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
        private void SeedByReflection(AppCoreDbContext context)
        {
            AppDependencyLocator.Current.GetAllInstances<IHasAppCoreDbContextSeedInitializer>()
                .ForEach(x => x.Seed(context));
        }

        private void SeedByHand(AppCoreDbContext dbContext)
        {
            AttachDebuggerWhenRunningUnderPowershell();

            // Ensure sequence is DataClassification, Tenant, Principal, Role, Session, then Etc.
            App.AppDependencyLocator.Current.GetInstance<AppCoreDbContextSeederExceptionRecord>().Seed(dbContext);
            App.AppDependencyLocator.Current.GetInstance<AppCoreDbContextSeederDataClassification>().Seed(dbContext);

            App.AppDependencyLocator.Current.GetInstance<AppCoreDbContextSeederSystemRole>().Seed(dbContext);

            SeedTenants(dbContext);
            SeedPrincipals(dbContext);


            App.AppDependencyLocator.Current.GetInstance<AppCoreDbContextSeederSession>().Seed(dbContext);
            //After Tenant
            App.AppDependencyLocator.Current.GetInstance<AppCoreDbContextSeederNotification>().Seed(dbContext);
        }

        private static void SeedTenants(AppCoreDbContext dbContext)
        {
            App.AppDependencyLocator.Current.GetInstance<AppCoreDbContextSeederTenant>().Seed(dbContext);
            App.AppDependencyLocator.Current.GetInstance<AppCoreDbContextSeederTenantProperty>().Seed(dbContext);
            App.AppDependencyLocator.Current.GetInstance<AppCoreDbContextSeederTenantClaim>().Seed(dbContext);
        }

        private static void SeedPrincipals(AppCoreDbContext dbContext)
        {
            App.AppDependencyLocator.Current.GetInstance<AppCoreDbContextSeederPrincipalTag>().Seed(dbContext);
            App.AppDependencyLocator.Current.GetInstance<AppCoreDbContextSeederPrincipalCategory>().Seed(dbContext);
            App.AppDependencyLocator.Current.GetInstance<AppCoreDbContextSeederPrincipal>().Seed(dbContext);
            App.AppDependencyLocator.Current.GetInstance<AppCoreDbContextSeederPrincipalLogin>().Seed(dbContext);
            App.AppDependencyLocator.Current.GetInstance<AppCoreDbContextSeederPrincipalProperty>().Seed(dbContext);
            App.AppDependencyLocator.Current.GetInstance<AppCoreDbContextSeederPrincipalClaim>().Seed(dbContext);
        }

        private void AttachDebuggerWhenRunningUnderPowershell()
        {
            var debuggerConfiguration = this._hostSettingsService.GetObject<CodeFirstMigrationConfiguration>();
            if (debuggerConfiguration.CodeFirstAttachDebugger)
            {
                // You'll *REALLY* like this piece of code if you are having trouble
                // with seeding:
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                if (Debugger.IsAttached == false)
                {
                    Debugger.Launch();
                }
            }
        }
    }
}