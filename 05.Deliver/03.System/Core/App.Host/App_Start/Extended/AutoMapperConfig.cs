namespace App.Core.Application.Extended
{
    using App.Core.Infrastructure.Initialization.ObjectMaps;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Messages;
    using AutoMapper;
    using Owin;

    /// <summary>
    /// An <see cref="StartupExtended"/> invoked class to configure
    /// Automapper using ServiceLocator discovered implementations
    /// of <see cref="IHasAutomapperInitializer"/>.
    /// </summary>
    public class AutoMapperConfig
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;

        public AutoMapperConfig(IDiagnosticsTracingService diagnosticsTracingService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
        }

        /// <summary>
        /// Configures the specified application builder.
        /// <para>
        /// Invoked from <see cref="StartupExtended.Configure"/>.
        /// </para>
        /// </summary>
        /// <param name="appBuilder">The application builder.</param>
        public void Configure(IAppBuilder appBuilder)
        {
            // DbContext Initializer (ie Automigrations onstartup) 
            // can be hard coded, as follows, or done solely via web.config as per bottom of
            // https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application

            using (var elapsedTime = new ElapsedTime())
            {

                Mapper.Initialize(cfg =>
                {
                    // You can initialize Map descriptions manually or by Convention over Configuration 
                    // using a combination of common interface and reflection.
                    AppDependencyLocator.Current.GetAllInstances<IHasAutomapperInitializer>()
                        .ForEach(x => x.Initialize(cfg));

                    // Or if convention/reflection/magic is not your cup of tea, you can do it the old way, creating lots of maps (
                    // one map for each direction for each model):
                    //ObjectMap_Example_ExampleDto.Initialize(cfg);
                    // etc... (more maps)
                });

                // Verify that model is coherent:
                Mapper.AssertConfigurationIsValid();
                //Make it go faster:
                Mapper.Configuration.CompileMappings();


                AppDependencyLocator.Current.GetInstance<IConfigurationStepService>()
                    .Register(
                        ConfigurationStepType.General,
                        ConfigurationStepStatus.White,
                        "Automapper",
                        $"Maps have been installed. Took {elapsedTime.ElapsedText}.");

            }
        }
    }
}