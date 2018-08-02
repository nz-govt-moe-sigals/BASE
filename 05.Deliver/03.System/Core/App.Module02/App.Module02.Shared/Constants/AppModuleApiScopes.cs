namespace App.Module02.Shared.Constants
{
    public class AppModuleApiScopes
    {
        public const string ServiceUrl = App.Core.Shared.Constants.ConfigurationKeys.SystemIntegrationKeyPrefix
                                         + Core.Shared.Constants.ConfigurationKeys.SystemModuleApiScopeServiceUrl;

        public const string ReadScope = "module02_read";
        public const string WriteScope = "module02_write";
    }
}




