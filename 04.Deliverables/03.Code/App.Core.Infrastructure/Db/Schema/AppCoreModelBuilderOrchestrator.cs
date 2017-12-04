namespace App.Core.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Infrastructure.Initialization.DependencyResolution;

    // A specialised class to define a DbContext model. 
    // It's extracted from the DbContext itself for SOC
    // objectives (when done by manual method, can end up with
    // lots of models, and it gets unwieldy, making DbContext
    // hard to grock.
    public class AppCoreModelBuilderOrchestrator
    {
        //Invoked from AppCoreDbContext/OnModelCreating
        public void Initialize(DbModelBuilder modelBuilder)
        {
            if (!PowershellServiceLocatorConfig.Activated)
            {
                DefineByReflection(modelBuilder);
            }
            else
            {
                //Reflection does not work under Powershell, so:
                DefineByHand(modelBuilder);
            }
        }


        private void DefineByReflection(DbModelBuilder modelBuilder)
        {
            // You can initialize manually or by Convention over Configuration
            // using a combination of common interface and reflection.
            AppDependencyLocator.Current.GetAllInstances<IHasAppCoreDbContextModelBuilderInitializer>()
                .ForEach(x => x.Define(modelBuilder));
        }

        private void DefineByHand(DbModelBuilder modelBuilder)
        {
            new AppCoreDbContextModelBuilderDefineExceptionRecord().Define(modelBuilder);
            new AppCoreDbContextModelBuilderDefineDataClasssification().Define(modelBuilder);
            new AppCoreDbContextModelBuilderDefineDataToken().Define(modelBuilder);
            new AppCoreDbContextModelBuilderDefineNotification().Define(modelBuilder);

            new AppCoreDbContextModelBuilderDefineSystemRole().Define(modelBuilder);

            new AppCoreDbContextModelBuilderDefinePrincipalCategory().Define(modelBuilder);
            new AppCoreDbContextModelBuilderDefinePrincipalTag().Define(modelBuilder);
            new AppCoreDbContextModelBuilderDefinePrincipal().Define(modelBuilder);
            new AppCoreDbContextModelBuilderDefinePrincipalClaim().Define(modelBuilder);
            new AppCoreDbContextModelBuilderDefinePrincipalProperty().Define(modelBuilder);
            new AppCoreDbContextModelBuilderDefinePrincipalLogin().Define(modelBuilder);
            new AppCoreDbContextModelBuilderDefinePrincipal2Role().Define(modelBuilder);


            new AppCoreDbContextModelBuilderDefineSession().Define(modelBuilder);
            new AppCoreDbContextModelBuilderDefineSessionOperationLog().Define(modelBuilder);

            new AppCoreDbContextModelBuilderDefineTenant().Define(modelBuilder);
            new AppCoreDbContextModelBuilderDefineTenantClaim().Define(modelBuilder);
            new AppCoreDbContextModelBuilderDefineTenantProperty().Define(modelBuilder);

        }
    }
}