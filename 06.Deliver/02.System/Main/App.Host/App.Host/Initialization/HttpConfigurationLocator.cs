namespace App.Core.Application.Initialization
{
    using System.Diagnostics;
    using System.Web.Http;

    public static class HttpConfigurationLocator
    {
        private static HttpConfiguration _current;

        public static HttpConfiguration Current
        {
            get
            {
                if (_current == null)
                {
                    // Want to see when it is created:
                    Debug.WriteLine("Creating alternate HttpConfiguration now...");
                    _current = new HttpConfiguration();
                }
                return _current;
            }
            set { _current = value; }
        }
        public static HttpConfiguration Global
        {
            get
            {
                return GlobalConfiguration.Configuration;
            }
        }
    }
}