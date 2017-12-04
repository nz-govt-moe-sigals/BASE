namespace App.Core.Infrastructure.IDA.Constants
{
    public static class Uris
    {
        // TODO: Not sure why the difference yet.

        // Url to use within WebMVC App.
        public static string WebMVCAadInstance =
            "https://login.microsoftonline.com/tfp/{0}/{1}/v2.0/.well-known/openid-configuration";

        // Url to use for tokens
        public static string WebAPIAadInstance =
            "https://login.microsoftonline.com/{0}/v2.0/.well-known/openid-configuration?p={1}";
    }
}