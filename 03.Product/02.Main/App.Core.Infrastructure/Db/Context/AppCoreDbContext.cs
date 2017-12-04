namespace App.Core.Infrastructure.Db.Context
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using App.Core.Infrastructure.Db.Schema;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.DependencyResolution;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;

    public class AppCoreDbContext : DbContext
    {
        public const string SchemaKey = "Core";

        static AppCoreDbContext()
        {
            PowershellServiceLocatorConfig.Initialize();
            //AppCoreDatabaseInitializerConfigurer.Configure();
        }


        // Constructor invokes base with Key used to find the ConnectionString in web.config
        public AppCoreDbContext() : base("AppCoreDbContext")
        {
        }

        public AppCoreDbContext(string connectionStringOrName) : base(connectionStringOrName)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionOperation> SessionOperations { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<MediaMetadata> MediaMetadata { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SchemaKey);

            new AppCoreModelBuilderOrchestrator().Initialize(modelBuilder);
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