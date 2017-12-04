namespace App.Core.Application.Presentation.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(string message, string description = null)
        {
            this.ViewBag.Message = message;
            this.ViewBag.Description = description;

            return View("Error");
        }
    }
}