using System.Web.Mvc;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.Entities;

namespace App.Host.Presentation.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        public AboutController(IDiagnosticsTracingService diagnosticsTracingService)
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

   

        //public ActionResult Error(string message,string description=null)
        //{
        //    ViewBag.Message = message;
        //    ViewBag.Description = description;

        //    return View("Error");
        //}

        public ActionResult Purpose()
        {
            return View();
        }
        public ActionResult Security()
        {
            return View();
        }
        public ActionResult OIDC()
        {
            return View();
        }

        public ActionResult APIFirst()
        {
            return View();
        }
        public ActionResult Versioning()
        {
            return View();
        }
        public ActionResult ODATA()
        {
            return View();
        }

        public ActionResult SPA()
        {
            return View();
        }
        public ActionResult NoMVC()
        {
            return View();
        }
        public ActionResult Design()
        {
            return View();
        }
        public ActionResult Development()
        {
            return View();
        }

    }
}