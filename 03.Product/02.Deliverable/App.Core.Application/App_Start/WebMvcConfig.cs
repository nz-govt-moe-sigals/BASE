namespace App.Core.Application
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using App.Core.Application.MvcModifications;
    using Owin;

    public class WebMvcConfig
    {
        private readonly WebMvcFilterConfig _webMvcFilterConfig;

        public WebMvcConfig(WebMvcFilterConfig webMvcFilterConfig)
        {
            this._webMvcFilterConfig = webMvcFilterConfig;
        }

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