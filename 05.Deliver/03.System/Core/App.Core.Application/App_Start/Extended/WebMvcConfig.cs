namespace App.Core.Application.Extended
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using App.Core.Application.MvcModifications;
    using Owin;

    /// <summary>
    /// An <see cref="StartupExtended"/> invoked class to configure 
    /// MVC View management.
    /// <para>
    /// Note that it is injected with <see cref="WebMvcFilterConfig"/>
    /// </para>
    /// </summary>
    public class WebMvcConfig
    {
        private readonly WebMvcFilterConfig _webMvcFilterConfig;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebMvcConfig"/> class.
        /// <para>
        /// Invoked from <see cref="WebMvcConfig.Configure"/>.
        /// </para>
        /// </summary>
        /// <param name="webMvcFilterConfig">The web MVC filter configuration.</param>
        public WebMvcConfig(WebMvcFilterConfig webMvcFilterConfig)
        {
            this._webMvcFilterConfig = webMvcFilterConfig;
        }




        /// <summary>
        /// Configures the specified application builder.
        /// <para>
        /// Invoked from <see cref="StartupExtended.Configure"/>
        /// </para>
        /// </summary>
        /// <param name="appBuilder">The application builder.</param>
        public void Configure(IAppBuilder appBuilder)
        {
            ExtendRazorViewEngineUsedToLocateViews();

            AreaRegistration.RegisterAllAreas();

            // Register WebMvc Filters *before* defining WebMvc Routes.
            this._webMvcFilterConfig.RegisterWebMvcGlobalFilters(GlobalFilters.Filters);

            WebMvcRouteConfig.RegisterWebMvcRoutes(RouteTable.Routes);
            // Etc.
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ExtendRazorViewEngineUsedToLocateViews()
        {
// Customize the View Engine to add a new location to look for Views (under the Presentation Folder):
            var engine = new ExtendedRazorViewEngine();
            engine.AddMasterLocationFormat("~/Presentation/Views/{1}/{0}.cshtml");
            engine.AddMasterLocationFormat("~/Presentation/Shared/{0}.cshtml");
            engine.AddViewLocationFormat("~/Presentation/Views/{1}/{0}.cshtml");
            engine.AddViewLocationFormat("~/Presentation/Views/Shared/{0}.cshtml");
            engine.AddPartialViewLocationFormat("~/Presentation/Views/{1}/{0}.cshtml");
            engine.AddPartialViewLocationFormat("~/Presentation/Shared/{0}.cshtml");
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(engine);

            // Now add the following to any App.ModuleN.Application assembly where you put the Views.
            //
            //    < ItemGroup >
            //    < EmbeddedResource Include = "Views/**/*.cshtml" />
            //    </ ItemGroup >
        }
    }
}