using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Core.Application.Presentation.Controllers
{
    using System.Web.Mvc;

    partial class UsageController
    {
        public ActionResult Person()
        {
            return View();
        }

        public ActionResult Organisation()
        {
            return View();
        }


        public ActionResult EducationOrganisation()
        {
            return View();
        }

    }
}