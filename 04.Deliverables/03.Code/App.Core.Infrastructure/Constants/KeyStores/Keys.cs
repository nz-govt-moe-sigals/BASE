namespace App.Core.Infrastructure.Constants.KeyStores
{
    /// <summary>
    /// Names of Keys within an KeyStore,
    /// where secrets were registered, in order to not have 
    /// security credentials in the AppConfig.
    /// </summary>
    public static class Keys
    {
        public static string MalwareServiceKey = "MalwareScaniiServiceKey";

        public static string MalwareServiceSecret = "MalwareScaniiServiceSecret";

        public static string AppInsightsInstrumentationKey = "AppInsightsInstrumentationKey";
    }
}