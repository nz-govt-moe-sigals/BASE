namespace App.Module01.Shared.Constants
{
    public class AppModuleApiScopes
    {
        public const string ServiceUrl = App.Core.Shared.Constants.ConfigurationKeys.SystemIntegrationKeyPrefix + "Oauth-Client-AuthorityUri";

        public const string ReadScope = "App-Module01_Read";
        public const string WriteScope = "App-Module01_Write";
    }
}




