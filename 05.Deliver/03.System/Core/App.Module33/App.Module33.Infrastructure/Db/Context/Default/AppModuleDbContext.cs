using App.Module33.Infrastructure.Initialization.Db.Schema;
using App.Module33.Shared.Models.Messages.API.V0100;

namespace App.Module33.Infrastructure.Db.Context.Default
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Infrastructure.Db.Context;
    using App.Core.Infrastructure.Db.Context.Default;
    using App.Core.Infrastructure.Db.Schema;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.DependencyResolution;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Attributes;
    using App.Module33.Shared.Models.Entities;


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
    /// <seealso cref="App.Core.Infrastructure.Db.Context.AppDbContextBase" />
    [Alias(Constants.Db.AppModuleDbContextNames.Default)]
    public class AppModuleDbContext : AppDbContextBase, IHasModuleSpecificIdentifier
    {
        // IMPORTANT: Notice that each Module DbContext
        // gets its own Schema, keeping it nice and separate
        // from other Modules, and Core:
        public const string SchemaKey = Constants.Module.Names.ModuleKey;

        // Already being called from base class:
        //static AppModuleDbContext()
        //{
        //    PowershellServiceLocatorConfig.Initialize();
        //    //Database.SetInitializer(new AppModuleDatabaseInitializer());
        //    //AppModuleDatabaseInitializerConfigurer.Configure();
        //}

        // Constructor invokes base with Key used to find the ConnectionString in web.config
        // Note use of same db, but different schema
        public AppModuleDbContext() : base(AppCoreDbConnectionStringNames.Default)
        {
        }

        public AppModuleDbContext(string connectionStringOrName) : base(connectionStringOrName)
        {
    
        }

        public DbSet<Community> Communities { get; set; }
        public DbSet<CoherentPathway> CoherentPathways { get; set; }
        public DbSet<CoherentPathwayStep> CoherentPathwaySteps { get; set; }
        public DbSet<CoherentPathwayLearningAreaStep> CoherentPathwayLearningAreaSteps { get; set; }
        public DbSet<CoherentPathwayLearningAreaCapability> CoherentPathwayLearningAreaCapabilities { get; set; }
        public DbSet<CoherentPathwayOverarchingCapability> CoherentPathwayOverarchingCapabilities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Ensures all tables that belong to this Module have a prefix other than 'dbo'.
            modelBuilder.HasDefaultSchema(SchemaKey);

            //Ignore Core tables that this DbContext references. 
            // ie: Tenant, Principal, Session, Notifications, Media, etc.
            AppModuleModelBuilderCommonConfiguration.Initialize(modelBuilder);

            // Initialize tables specific to this object:
            AppDependencyLocator.Current.GetInstance<AppModuleDbModelBuilderOrchestrator>()
                .Initialize(modelBuilder);
        }

        // Intercept all saves in order to clean up loose ends in the base Class' SaveChanges/SaveChangesAsync
    }
}

