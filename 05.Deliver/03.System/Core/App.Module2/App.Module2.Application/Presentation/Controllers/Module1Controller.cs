namespace App.Module02.Application.Presentation.Controllers
{
    using System.Web.Mvc;

    public class Module2Controller : Controller
    {
        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}