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
    using App.Core.Shared.Models.Entities;

    /// <summary>
    /// Controller for the Views that explain how to use this framework.
    /// </summary>
    public class UsageController : Controller
    {

        public UsageController(IDiagnosticsTracingService diagnosticsTracingService)
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
        public ActionResult Configuration()
        {
            return View();
        }
        public ActionResult Exception()
        {
            return View();
        }
        public ActionResult DataClassification()
        {
            return View();
        }
        public ActionResult Principal()
        {
            return View();
        }
        public ActionResult Role()
        {
            return View();
        }

        public ActionResult Tenant()
        {
            return View();
        }

        public ActionResult Session()
        {
            return View();
        }
        public ActionResult SessionOperation()
        {
            return View();
        }

        public ActionResult Notification()
        {
            return View();
        }

        public ActionResult MediaMetadata()
        {
            return View();
        }


    }
}