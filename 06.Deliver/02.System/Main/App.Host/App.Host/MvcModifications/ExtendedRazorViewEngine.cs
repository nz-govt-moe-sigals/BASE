using System.Collections.Generic;
using System.Web.Mvc;

namespace App.Host.MvcModifications
{
    public class ExtendedRazorViewEngine : RazorViewEngine
    {
        public void AddMasterLocationFormat(string paths)
        {
            var tmp = new List<string>(this.MasterLocationFormats);
            tmp.Add(paths);
            this.MasterLocationFormats = tmp.ToArray();
        }

        public void AddViewLocationFormat(string paths)
        {
            var tmp = new List<string>(this.ViewLocationFormats);
            tmp.Add(paths);

            this.ViewLocationFormats = tmp.ToArray();
        }

        public void AddPartialViewLocationFormat(string paths)
        {
            var tmp = new List<string>(this.PartialViewLocationFormats);
            tmp.Add(paths);

            this.PartialViewLocationFormats = tmp.ToArray();
        }
    }
}