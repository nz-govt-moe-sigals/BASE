namespace App.Core.Infrastructure.Db.Context.Default
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Infrastructure.Db.Schema;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.DependencyResolution;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Attributes;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Entities.TenancySpecific;

    /// <summary>
    /// The Module specific DbContext (notice is has it's own Schema).
    /// <para>
    /// Inherits from the common <see cref="AppDbContextBase"/> 
    /// where <see cref="AppDbContextBase.SaveChanges"/>
    /// and <see cref="AppDbContextBase.SaveChangesAsync"/>
    /// intercept the save operation, to clean up new/updated objects
    /// </para>
    /// <para>
    /// Also (and very importantly) the base class' static Constructor 
    /// ensures its migration capabilities work from the commandline.
    /// </para>
    /// </summary>
    /// <seealso cref="AppDbContextBase" />

    [Alias(Constants.Db.AppCoreDbContextNames.Core)]
    public class AppCoreDbContext : AppDbContextBase
    {
        public const string SchemaKey = Constants.Module.Names.ModuleKey;

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionOperation> SessionOperations { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<MediaMetadata> MediaMetadata { get; set; }



        // already being called from base class:
        //static AppCoreDbContext()
        //{
        //    // This static constructor is only called once.
        //    // So that Migrations can work, when outside of
        //    // runtime, ensure the following:
        //    PowershellServiceLocatorConfig.Initialize();

        //    //AppCoreDatabaseInitializerConfigurer.Configure();
        //}


        // Constructor invokes base with Key ('AppCoreDbContext') used to find the ConnectionString in web.config
        public AppCoreDbContext() : base(AppCoreDbConnectionStringNames.Default)
        {
        }

        public AppCoreDbContext(string connectionStringOrName) : base(AppDependencyLocator.Current.GetInstance<OpenDbConnectionBuilder>().CreateAsync(connectionStringOrName).Result, true)
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }



        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SchemaKey);

            AppDependencyLocator.Current.GetInstance<AppCoreModelBuilderOrchestrator>()
                .Initialize(modelBuilder);
        }

    }
}