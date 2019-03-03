using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Host.Ux.Tests
{
    public class Configuration
    {
        private static Configuration _instance;

        private Configuration() { }

        public static Configuration Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Configuration();
                }
                return _instance;
            }
        }

        public string DefaultUrl
        {
            get
            {
                var value = Environment.GetEnvironmentVariable("custom_vars_default_website_Url");
                if (value == null)
                {
                    value = ConfigurationManager.AppSettings["custom_vars_default_website_Url"];
                }
                if (!value.EndsWith("/")) { value += "/"; }
                return value;
            }
        }

        public string AadInstance
        {
            get { return ConfigurationManager.AppSettings["AadInstance"]; }
        }

        public string Tenant
        {
            get { return ConfigurationManager.AppSettings["Tenant"]; }
        }

        public string ClientId
        {
            get { return ConfigurationManager.AppSettings["ClientId"]; }
        }

        public string Appkey
        {
            get { return ConfigurationManager.AppSettings["Appkey"]; }
        }

        public string RedirectUri
        {
            get { return ConfigurationManager.AppSettings["RedirectUri"]; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">back slashes</param>
        /// <returns></returns>
        public string GetExecutingAssemblyLocation(string path)
        {
            var baseLoc = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!baseLoc.EndsWith("\\")) baseLoc += "\\";
            if (string.IsNullOrWhiteSpace(path)) return baseLoc;
            if (path.StartsWith("\\")) path = path.Substring(1);
            return baseLoc + path;
        }


    }
}
