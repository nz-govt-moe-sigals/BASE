using App.Module01;

namespace App.Module01.Infrastructure.IDA.Constants.HostSettingsKeys
{
    public class AppModuleApiScopes: IHasModuleSpecificIdentifier
    {
        public static string ApiExampleReadScope = "example:read";
        public static string ApiExampleWriteScope = "example:write";
    }
}