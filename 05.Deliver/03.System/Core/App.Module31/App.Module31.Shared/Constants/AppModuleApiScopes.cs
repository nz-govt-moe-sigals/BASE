namespace App.Module31.Shared.Constants
{
    public class AppModuleApiScopes
    {
        public const string ServiceUrl = App.Core.Shared.Constants.ConfigurationKeys.SystemIntegrationKeyPrefix
                                         + Core.Shared.Constants.ConfigurationKeys.SystemModuleApiScopeServiceUrl;

        public const string ReadScope = "App-Module31_Read";
        public const string WriteScope = "App-Module31_Write";
    }
}




