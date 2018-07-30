using System;

namespace App.Core.Infrastructure.IDA.v1.Ux.Tests
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
                var e = Environment.GetEnvironmentVariable("custom_vars_defaultUrl");
                if (e != null) { return e; }
                return "https://localhost:44311/";
            }
        }
    }
}
