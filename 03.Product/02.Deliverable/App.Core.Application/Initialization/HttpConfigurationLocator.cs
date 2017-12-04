namespace App.Core.Application.Initialization
{
    using System.Web.Http;

    public static class HttpConfigurationLocator
    {
        private static HttpConfiguration _current;
        public static HttpConfiguration Current => _current ?? (_current = new HttpConfiguration());
    }
}