using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using App.Core.Application.Initialization;

namespace App.Host.Presentation.Controllers
{
    [System.Web.Mvc.AllowAnonymous]
    public class DocumentationController : Controller
    {
        // GET: Documentation
        public ActionResult Index()
        {
            var explorer = HttpConfigurationLocator.Current.Services.GetApiExplorer();
            return View(explorer);
        }
    }
}