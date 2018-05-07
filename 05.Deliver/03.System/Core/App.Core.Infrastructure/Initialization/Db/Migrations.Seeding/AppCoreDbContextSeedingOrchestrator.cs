namespace App.Core.Infrastructure.Db.Migrations.Seeding
{
    using System;
    using System.Diagnostics;
    using App.Core.Infrastructure.Db.Context;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;
    using App.Core.Shared.Models.Messages;
    using TraceLevel = App.Core.Shared.Models.Entities.TraceLevel;

    // Invoked from within AppCoreDbMigrationsConfiguration.Seed method, 
    public class AppCoreDbContextSeedingOrchestrator
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly IHostSettingsService _hostSettingsService;
        private readonly IConfigurationStepService _configurationStepService;

        public AppCoreDbContextSeedingOrchestrator(IDiagnosticsTracingService diagnosticsTracingService, IHostSettingsService hostSettingsService ,IConfigurationStepService configurationStepService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
            this._hostSettingsService = hostSettingsService;
            this._configurationStepService = configurationStepService;
        }

        // This method will be called after migrating to the latest version.
        public void Initialize(AppCoreDbContext context)
        {
            using (ElapsedTime elapsedTime = new ElapsedTime())
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

                var color = ConfigurationStepStatus.White;
                if (elapsedTime.Elapsed.TotalMilliseconds >= 5000)
                {
                    color = ConfigurationStepStatus.Orange;
                }
                if (elapsedTime.Elapsed.TotalMilliseconds >= 1000)
                {
                    color = ConfigurationStepStatus.Red;
                }
                this._configurationStepService.Register(ConfigurationStepType.General, color, "Seeding",$"Core seeding completed. Took {elapsedTime.ElapsedText}.");
                

            }
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
            _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding Exception Records. Start...");
            App.AppDependencyLocator.Current.GetInstance<AppCoreDbContextSeederExceptionRecord>().Seed(dbContext);
            _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding End. Start...");

            _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding Data Classifications. Start...");
            App.AppDependencyLocator.Current.GetInstance<AppCoreDbContextSeederDataClassification>().Seed(dbContext);
            _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding Data Classifications. End.");

            _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding System Roles. Start...");
            App.AppDependencyLocator.Current.GetInstance<AppCoreDbContextSeederSystemRole>().Seed(dbContext);
            _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding System Roles. End.");

            _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding Tenants. Start...");
            SeedTenants(dbContext);
            _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding Tenants. End.");


            _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding Pricipals. Start...");
            SeedPrincipals(dbContext);
            _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding Principals. End.");


            _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding Sessions. Start...");
            App.AppDependencyLocator.Current.GetInstance<AppCoreDbContextSeederSession>().Seed(dbContext);
            _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding Sessions. End.");

            //After Tenant
            _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding Notifications. Start...");
            App.AppDependencyLocator.Current.GetInstance<AppCoreDbContextSeederNotification>().Seed(dbContext);
            _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding Notifications. End.");
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