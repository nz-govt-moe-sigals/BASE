namespace App.Core.Application.App_Start
{
    using App.Core.Infrastructure.DependencyResolution;
    using Owin;

    // Class to initialize the Microsoft Common ServiceLocator
    // with the StructureMap service locator, so that one can 
    // other libraries can use IoC without having to have a direct
    // reference on any specific IoC lib provider/vendor (in this
    // case structure map)
    public class ServiceLocatorConfig
    {


        /// <summary>
        /// Configures the specified application builder.
        /// <para>
        /// Invoked from <see cref="Startup.Configuration"/>
        /// </para>
        /// </summary>
        /// <param name="appBuilder">The application builder.</param>
        public static void Configure(IAppBuilder appBuilder)
        {
            // Do the work down in Infrastructure, 
            // rather than up in Application, so that
            // DbContext Migrations can reuse the code
            // when you invoke 'add-migration' from the Powershell
            // command line.
            CommonServiceLocatorInitiator.Initialize();
        }
    }
}