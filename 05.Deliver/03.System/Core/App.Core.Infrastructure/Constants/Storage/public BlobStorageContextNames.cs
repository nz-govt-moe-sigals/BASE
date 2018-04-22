namespace App.Core.Infrastructure.Constants.Storage
{
    public static class BlobStorageAccountNames
    {
        // For now, only one db per Module, but could be more at some point:
        public const string Default = Constants.Module.Names.ModuleKey + ".Default";
    }
}
