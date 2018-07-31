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
                var value = Environment.GetEnvironmentVariable("custom_vars_defaultUrl");
                if (value == null)
                {
                    value = ConfigurationManager.AppSettings["custom_vars_defaultUrl"];
                }
                if (!value.EndsWith("/")) { value += "/"; }
                return value;
            }
        }
    }
}
