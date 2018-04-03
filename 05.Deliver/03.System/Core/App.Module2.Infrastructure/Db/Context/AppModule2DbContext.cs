﻿/// <summary>
/// 
/// </summary>
namespace App.Module2.Infrastructure.Db.Context
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Infrastructure.Db.Context;
    using App.Core.Infrastructure.Db.Schema;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.DependencyResolution;
    using App.Core.Infrastructure.Services;
    using App.Module2.Infrastructure.Db.Schema;
    using App.Module2.Shared.Models.Entities;

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
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class AppModule2DbContext : AppDbContextBase
    {
        // IMPORTANT: Notice that each Module DbContext
        // gets its own Schema, keeping it nice and separate
        // from other Modules, and Core:
        public const string SchemaKey = "Module2";


        
        //Bodies is connected to Alias, Category, Channel, Claim, Property
        public DbSet<Body> Bodies { get; set; }
        public DbSet<EducationOrganisation> EducationOrganisations { get; set; }


        // already being called from base class:
        //static AppModule2DbContext()
        //{
        //    PowershellServiceLocatorConfig.Initialize();
        //    //Database.SetInitializer(new AppModule2DatabaseInitializer());
        //    //AppModule2DatabaseInitializerConfigurer.Configure();
        //}

        // Constructor invokes base with Key used to find the ConnectionString in web.config
        // Note use of same db, but different schema
        public AppModule2DbContext() : base(AppCoreDbConnectionStringNames.App)
        {
        }

        public AppModule2DbContext(string connectionStringOrName) : base(connectionStringOrName)
        {
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
            // Ensures all tables that belong to this Module have a prefix other than 'dbo'.
            modelBuilder.HasDefaultSchema(SchemaKey);

            //Ignore Core tables that this DbContext references. 
            // ie: Tenant, Principal, Session, Notifications, Media, etc.
            AppModuleModelBuilderCommonConfiguration.Initialize(modelBuilder);

            // Initialize tables specific to this object:
            AppDependencyLocator.Current.GetInstance<AppModule2DbModelBuilderOrchestrator>()
                .Initialize(modelBuilder);
        }

        // Intercept all saves in order to clean up loose ends in the base Class' SaveChanges/SaveChangeAsync

    }
}