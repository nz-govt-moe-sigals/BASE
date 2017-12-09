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
        private readonly AppCoreDbContextModelBuilderDefineExceptionRecord _appCoreDbContextModelBuilderDefineExceptionRecord;
        private readonly AppCoreDbContextModelBuilderDefineDataClasssification _appCoreDbContextModelBuilderDefineDataClasssification;
        private readonly AppCoreDbContextModelBuilderDefineDataToken _appCoreDbContextModelBuilderDefineDataToken;
        private readonly AppCoreDbContextModelBuilderDefineNotification _appCoreDbContextModelBuilderDefineNotification;
        private readonly AppCoreDbContextModelBuilderDefineSystemRole _appCoreDbContextModelBuilderDefineSystemRole;
        private readonly AppCoreDbContextModelBuilderDefinePrincipalCategory _appCoreDbContextModelBuilderDefinePrincipalCategory;
        private readonly AppCoreDbContextModelBuilderDefinePrincipalTag _appCoreDbContextModelBuilderDefinePrincipalTag;
        private readonly AppCoreDbContextModelBuilderDefinePrincipal _appCoreDbContextModelBuilderDefinePrincipal;
        private readonly AppCoreDbContextModelBuilderDefinePrincipalClaim _appCoreDbContextModelBuilderDefinePrincipalClaim;
        private readonly AppCoreDbContextModelBuilderDefinePrincipalProperty _appCoreDbContextModelBuilderDefinePrincipalProperty;
        private readonly AppCoreDbContextModelBuilderDefinePrincipalLogin _appCoreDbContextModelBuilderDefinePrincipalLogin;
        private readonly AppCoreDbContextModelBuilderDefinePrincipal2Role _appCoreDbContextModelBuilderDefinePrincipal2Role;
        private readonly AppCoreDbContextModelBuilderDefineSession _appCoreDbContextModelBuilderDefineSession;
        private readonly AppCoreDbContextModelBuilderDefineSessionOperationLog _appCoreDbContextModelBuilderDefineSessionOperationLog;
        private readonly AppCoreDbContextModelBuilderDefineTenant _appCoreDbContextModelBuilderDefineTenant;
        private readonly AppCoreDbContextModelBuilderDefineTenantClaim _appCoreDbContextModelBuilderDefineTenantClaim;
        private readonly AppCoreDbContextModelBuilderDefineTenantProperty _appCoreDbContextModelBuilderDefineTenantProperty;

        public AppCoreModelBuilderOrchestrator(
            AppCoreDbContextModelBuilderDefineExceptionRecord appCoreDbContextModelBuilderDefineExceptionRecord,
            AppCoreDbContextModelBuilderDefineDataClasssification appCoreDbContextModelBuilderDefineDataClasssification,
            AppCoreDbContextModelBuilderDefineDataToken appCoreDbContextModelBuilderDefineDataToken,
            AppCoreDbContextModelBuilderDefineNotification appCoreDbContextModelBuilderDefineNotification,

            AppCoreDbContextModelBuilderDefineSystemRole appCoreDbContextModelBuilderDefineSystemRole,

            AppCoreDbContextModelBuilderDefinePrincipalCategory appCoreDbContextModelBuilderDefinePrincipalCategory,
            AppCoreDbContextModelBuilderDefinePrincipalTag appCoreDbContextModelBuilderDefinePrincipalTag,
            AppCoreDbContextModelBuilderDefinePrincipal appCoreDbContextModelBuilderDefinePrincipal,
            AppCoreDbContextModelBuilderDefinePrincipalClaim appCoreDbContextModelBuilderDefinePrincipalClaim,
            AppCoreDbContextModelBuilderDefinePrincipalProperty appCoreDbContextModelBuilderDefinePrincipalProperty,
            AppCoreDbContextModelBuilderDefinePrincipalLogin appCoreDbContextModelBuilderDefinePrincipalLogin,
            AppCoreDbContextModelBuilderDefinePrincipal2Role appCoreDbContextModelBuilderDefinePrincipal2Role,


            AppCoreDbContextModelBuilderDefineSession appCoreDbContextModelBuilderDefineSession,
            AppCoreDbContextModelBuilderDefineSessionOperationLog appCoreDbContextModelBuilderDefineSessionOperationLog,

            AppCoreDbContextModelBuilderDefineTenant appCoreDbContextModelBuilderDefineTenant,
            AppCoreDbContextModelBuilderDefineTenantClaim appCoreDbContextModelBuilderDefineTenantClaim,
            AppCoreDbContextModelBuilderDefineTenantProperty appCoreDbContextModelBuilderDefineTenantProperty
            )
        {
            this._appCoreDbContextModelBuilderDefineExceptionRecord = appCoreDbContextModelBuilderDefineExceptionRecord;
            this._appCoreDbContextModelBuilderDefineDataClasssification = appCoreDbContextModelBuilderDefineDataClasssification;
            this._appCoreDbContextModelBuilderDefineDataToken = appCoreDbContextModelBuilderDefineDataToken;
            this._appCoreDbContextModelBuilderDefineNotification = appCoreDbContextModelBuilderDefineNotification;
            this._appCoreDbContextModelBuilderDefineSystemRole = appCoreDbContextModelBuilderDefineSystemRole;
            this._appCoreDbContextModelBuilderDefinePrincipalCategory = appCoreDbContextModelBuilderDefinePrincipalCategory;
            this._appCoreDbContextModelBuilderDefinePrincipalTag = appCoreDbContextModelBuilderDefinePrincipalTag;
            this._appCoreDbContextModelBuilderDefinePrincipal = appCoreDbContextModelBuilderDefinePrincipal;
            this._appCoreDbContextModelBuilderDefinePrincipalClaim = appCoreDbContextModelBuilderDefinePrincipalClaim;
            this._appCoreDbContextModelBuilderDefinePrincipalProperty = appCoreDbContextModelBuilderDefinePrincipalProperty;
            this._appCoreDbContextModelBuilderDefinePrincipalLogin = appCoreDbContextModelBuilderDefinePrincipalLogin;
            this._appCoreDbContextModelBuilderDefinePrincipal2Role = appCoreDbContextModelBuilderDefinePrincipal2Role;
            this._appCoreDbContextModelBuilderDefineSession = appCoreDbContextModelBuilderDefineSession;
            this._appCoreDbContextModelBuilderDefineSessionOperationLog = appCoreDbContextModelBuilderDefineSessionOperationLog;
            this._appCoreDbContextModelBuilderDefineTenant = appCoreDbContextModelBuilderDefineTenant;
            this._appCoreDbContextModelBuilderDefineTenantClaim = appCoreDbContextModelBuilderDefineTenantClaim;
            this._appCoreDbContextModelBuilderDefineTenantProperty = appCoreDbContextModelBuilderDefineTenantProperty;
        }

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
            this._appCoreDbContextModelBuilderDefineExceptionRecord.Define(modelBuilder);
            this._appCoreDbContextModelBuilderDefineDataClasssification.Define(modelBuilder);
            this._appCoreDbContextModelBuilderDefineDataToken.Define(modelBuilder);
            this._appCoreDbContextModelBuilderDefineNotification.Define(modelBuilder);

            this._appCoreDbContextModelBuilderDefineSystemRole.Define(modelBuilder);

            this._appCoreDbContextModelBuilderDefinePrincipalCategory.Define(modelBuilder);
            this._appCoreDbContextModelBuilderDefinePrincipalTag.Define(modelBuilder);
            this._appCoreDbContextModelBuilderDefinePrincipal.Define(modelBuilder);
            this._appCoreDbContextModelBuilderDefinePrincipalClaim.Define(modelBuilder);
            this._appCoreDbContextModelBuilderDefinePrincipalProperty.Define(modelBuilder);
            this._appCoreDbContextModelBuilderDefinePrincipalLogin.Define(modelBuilder);
            this._appCoreDbContextModelBuilderDefinePrincipal2Role.Define(modelBuilder);


            this._appCoreDbContextModelBuilderDefineSession.Define(modelBuilder);
            this._appCoreDbContextModelBuilderDefineSessionOperationLog.Define(modelBuilder);

            this._appCoreDbContextModelBuilderDefineTenant.Define(modelBuilder);
            this._appCoreDbContextModelBuilderDefineTenantClaim.Define(modelBuilder);
            this._appCoreDbContextModelBuilderDefineTenantProperty.Define(modelBuilder);

        }
    }
}