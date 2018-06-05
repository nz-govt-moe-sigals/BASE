namespace App.Module02.Shared.Constants
{
    public class AppModuleApiScopes
    {
        public const string ServiceUrl = App.Core.Shared.Constants.ConfigurationKeys.SystemIntegrationKeyPrefix + "Oauth-Client-AuthorityUri";

        public const string ReadScope = "App-Module02_Read";
        public const string WriteScope = "App-Module02_Write";
    }
}




