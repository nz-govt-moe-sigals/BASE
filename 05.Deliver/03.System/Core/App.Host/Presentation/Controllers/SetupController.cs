using System.Web.Mvc;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.Entities;

namespace App.Host.Presentation.Controllers
{
    /// <summary>
    /// Controller for the Views that explain how to use this framework.
    /// </summary>
    [AllowAnonymous]
    public class SetupController : Controller
    {

        public SetupController(IDiagnosticsTracingService diagnosticsTracingService)
        {
            // Tip: Being a template, it is preferable that the HomeController/Default Route does not get injected with a
            // DbContext, as that implies a correct Connection string and/or Authentication, that may fail the first
            // time deployed to Azure.
            diagnosticsTracingService.Trace(TraceLevel.Verbose, "Hi");
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Setup";
            return View();
        }

        public ActionResult Background()
        {
            ViewBag.Title = "Background";
            ViewBag.Subtitle = "A short summary of why.";

            return View();
        }

        public ActionResult Prerequisites()
        {
            ViewBag.Title = "Prerequisites";
            ViewBag.Subtitle = "What environment, services, resources are needed...";

            return View();
        }

        public ActionResult PrerequisitesCodeBase()
        {
            ViewBag.Title = "CodeBase";
            ViewBag.Subtitle = "Clone the code base...";

            return View();
        }

        public ActionResult ConfigureAzureIntegration()
        {
            ViewBag.Title = "Azure";
            ViewBag.Subtitle = "Azure based Infrastructure, Storage, Services, etc.";

            return View();
        }

        public ActionResult ConfigureAzureApplicationInsightsIntegration()
        {
            ViewBag.Title = "Telemetry";
            ViewBag.Message = "Configure Azure based Diagnostics and Telemetry collection...";

            return View();
        }
        public ActionResult ConfigureAzureStorageIntegration()
        {
            ViewBag.Title = "Storage";
            ViewBag.Message = "Configure Azure based stream storage...";

            return View();
        }

        public ActionResult ConfigureAzureSqlDatabaseIntegration()
        {
            ViewBag.Title = "Sql Database";
            ViewBag.Message = "Configure Azure based Databases...";

            return View();
        }

        public ActionResult ConfigureOIDCIntegration()
        {
            ViewBag.Title = "OIDC";
            ViewBag.Message = "Configure OIDC Integration...";

            return View();
        }
        public ActionResult ConfigureOIDCB2CIntegration()
        {
            ViewBag.Title = "B2C";
            ViewBag.Message = "Configure B2C Integration...";

            return View();
        }

        public ActionResult ConfigureOIDCAADIntegration()
        {
            ViewBag.Title = "OIDC";
            ViewBag.Message = "Configure AAD Integration...";

            return View();
        }



    }
}