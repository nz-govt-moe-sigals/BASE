namespace App.Module32.Infrastructure.Db.Context
{
    using System.Data.Entity;


    public class AppModuleDatabaseInitializerConfigurer: IHasModuleSpecificIdentifier
    {
        /// <summary>
        ///     Can be Invoked and set from within App_Startup.
        ///     but better if done in web.config.
        /// </summary>
        public static void Configure()
        {
            // Cam ne hard coded, as follows, or - prefereably - done 
            // solely via web.config as per bottom of
            // https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application
            Database.SetInitializer(new AppModuleDatabaseInitializer());
        }
    }
}

