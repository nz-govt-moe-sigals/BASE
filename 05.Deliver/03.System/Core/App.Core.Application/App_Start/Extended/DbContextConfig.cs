namespace App.Core.Application.Extended
{
    using Owin;

    /// <summary>
    /// An <see cref="StartupExtended"/> invoked class to configure
    /// DbContexts to handle code migrations.
    /// </summary>
    public static class DbContextConfig
    {

        /// <summary>
        /// Configures the specified application builder.
        /// <para>
        /// Invoked from <see cref="StartupExtended.Configure"/>
        /// </para>
        /// </summary>
        /// <param name="appBuilder">The application builder.</param>
        public static void Configure(IAppBuilder appBuilder)
        {
            // Used to set initializer.
            // Cam be hard coded, as follows, or done solely via web.config as per bottom of
            // https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application

            //AppCoreDatabaseInitializerConfigure.Configure();
            //AppModule1DatabaseInitializerConfigure.Configure();

            //Much prefer leaving it in the web.config to provide flexibility to your builde server on different builds
        }
    }
}