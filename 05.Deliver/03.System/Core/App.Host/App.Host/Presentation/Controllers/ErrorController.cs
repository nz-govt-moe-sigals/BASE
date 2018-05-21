using System.Web.Mvc;

namespace App.Host.Presentation.Controllers
{
    [AllowAnonymous]
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