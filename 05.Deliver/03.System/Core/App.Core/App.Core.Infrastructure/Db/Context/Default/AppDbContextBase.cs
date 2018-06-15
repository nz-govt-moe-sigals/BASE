namespace App.Core.Infrastructure.Db.Context.Default
{
    using System.Data.Common;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Infrastructure.Initialization.DependencyResolution;
    using App.Core.Infrastructure.Services;

    public abstract class AppDbContextBase : DbContext
    {
        static AppDbContextBase()
        {
            // This static constructor is only called once.
            // So that Migrations can work, when outside of
            // runtime, ensure the following:
            PowershellServiceLocatorConfig.Initialize();

            //AppCoreDatabaseInitializerConfigurer.Configure();

            //            //Database.SetInitializer(new AppModuleDatabaseInitializer());
            //AppModuleDatabaseInitializerConfigurer.Configure();

        }

        // Constructor invokes base with Key used to find the ConnectionString in web.config
        protected AppDbContextBase() : this(AppCoreDbConnectionStringNames.Default)
        {
        }

        protected AppDbContextBase(string connectionStringOrName) : this(AppDependencyLocator.Current.GetInstance<OpenDbConnectionBuilder>().CreateAsync(connectionStringOrName).Result, true)
        {
        }

        protected AppDbContextBase(DbConnection dbConnection, bool contextOwnsConnection) : base(dbConnection, contextOwnsConnection)
        {
            Database.CommandTimeout = System.Math.Max(dbConnection.ConnectionTimeout,30);


            this.Database.Log = s => Trace.WriteLine(s);
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