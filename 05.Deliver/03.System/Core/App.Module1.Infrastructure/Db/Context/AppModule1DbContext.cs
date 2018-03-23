namespace App.Module1.Infrastructure.Db.Context
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using App.Core.Infrastructure.Db.Schema;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.DependencyResolution;
    using App.Core.Infrastructure.Services;
    using App.Module1.Infrastructure.Db.Schema;
    using App.Module1.Shared.Models.Entities;

    public class AppModule1DbContext : DbContext
    {
        public const string SchemaKey = "Module1";

        static AppModule1DbContext()
        {
            PowershellServiceLocatorConfig.Initialize();
            //Database.SetInitializer(new AppModule1DatabaseInitializer());
            //AppModule1DatabaseInitializerConfigurer.Configure();
        }

        // Constructor invokes base with Key used to find the ConnectionString in web.config
        // Note use of same db, but different schema
        public AppModule1DbContext() : base("AppCoreDbContext")
        {
        }

        public AppModule1DbContext(string connectionStringOrName) : base(connectionStringOrName)
        {
        }

        public DbSet<Example> Examples { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Ensures all tables that belong to this Module have a prefix other than 'dbo'.
            modelBuilder.HasDefaultSchema(SchemaKey);

            //Ignore Core tables that this DbContext references. 
            // ie: Tenant, Principal, Session, Notifications, Media, etc.
            AppModuleModelBuilderCommonConfiguration.Initialize(modelBuilder);

            // Initialize tables specific to this object:
            AppDependencyLocator.Current.GetInstance<AppModule1DbModelBuilderOrchestrator>()
                .Initialize(modelBuilder);
        }

        // Intercept all saves in order to clean up loose ends
        public override int SaveChanges()
        {
            var dbContextPreCommitService =
                AppDependencyLocator.Current.GetInstance<IDbContextPreCommitService>();

            dbContextPreCommitService.PreProcess(this);

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            var dbContextPreCommitService =
                AppDependencyLocator.Current.GetInstance<IDbContextPreCommitService>();

            dbContextPreCommitService.PreProcess(this);

            return base.SaveChangesAsync();
        }
    }
}