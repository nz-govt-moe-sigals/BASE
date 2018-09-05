using System;
using System.Configuration;

namespace App.Module32.Ux.Tests.Utility
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



    }
}
