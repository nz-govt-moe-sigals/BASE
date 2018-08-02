namespace App.Module01.Shared.Constants
{
    public class AppModuleApiScopes
    {
        public const string ServiceUrl = App.Core.Shared.Constants.ConfigurationKeys.SystemIntegrationKeyPrefix 
                                         + Core.Shared.Constants.ConfigurationKeys.SystemModuleApiScopeServiceUrl;

        public const string ReadScope = "module01_read";
        public const string WriteScope = "module01_write";
    }
}




