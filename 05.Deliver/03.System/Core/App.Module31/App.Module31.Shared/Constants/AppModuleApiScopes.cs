namespace App.Module31.Shared.Constants
{
    public class AppModuleApiScopes
    {
        public const string ServiceUrl = App.Core.Shared.Constants.ConfigurationKeys.SystemIntegrationKeyPrefix
                                         + Core.Shared.Constants.ConfigurationKeys.SystemModuleApiScopeServiceUrl;

        public const string ReadScope = "module31_read";
        public const string WriteScope = "module31_write";
    }
}




