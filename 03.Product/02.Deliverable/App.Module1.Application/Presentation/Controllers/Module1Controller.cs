namespace App.Module1.Application.Presentation.Controllers
{
    using System.Web.Mvc;
    using App.Module1.Application.Services;

    public class Module1Controller : Controller
    {
        private readonly IApplicationService _applicationService;

        public Module1Controller(IApplicationService applicationService)
        {
            this._applicationService = applicationService;
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}