namespace App.Module3.Application.Presentation.Controllers
{
    using System.Web.Mvc;
    using App.Module3.Application.Services;

    public class Module3Controller : Controller
    {
        private readonly IApplicationService _applicationService;

        public Module3Controller(IApplicationService applicationService)
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