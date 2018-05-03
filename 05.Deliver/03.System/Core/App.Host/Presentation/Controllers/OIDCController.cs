namespace App.Core.Application.Presentation.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    ///     Controller to demonstrate Claims returned from remote OIDC IdC.
    /// </summary>
    public class OIDCController : Controller
    {
        [Authorize]
        public ActionResult Claims()
        {
            this.ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}