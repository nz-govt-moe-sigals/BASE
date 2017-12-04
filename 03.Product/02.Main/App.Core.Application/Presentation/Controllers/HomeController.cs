namespace App.Core.Application.Presentation.Controllers
{
    using System.Web.Mvc;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;

    public class HomeController : Controller
    {
        public HomeController(IDiagnosticsTracingService diagnosticsTracingService)
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

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return View();
        }

        //public ActionResult Error(string message,string description=null)
        //{
        //    ViewBag.Message = message;
        //    ViewBag.Description = description;

        //    return View("Error");
        //}
    }
}