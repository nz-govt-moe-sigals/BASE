using App.Core.Application.Services;
using App.Core.Infrastructure.Db.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models;

namespace App.Core.Application.Presentation.Controllers
{
    /// <summary>
    /// Controller for the Views that explain how to use this framework.
    /// </summary>
    public class UsageController : Controller
    {

        public UsageController(IDiagnosticsTracingService diagnosticsTracingService, IExampleApplicationService exampleApplicationService)
        {
            // Tip: Being a template, it is preferable that the HomeController/Default Route does not get injected with a
            // DbContext, as that implies a correct Connection string and/or Authentication, that may fail the first
            // time deployed to Azure.
            diagnosticsTracingService.Trace(TraceLevel.Verbose, "Hi");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCodeBase()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Prerequisites()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ConfigureOIDC()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


    }
}