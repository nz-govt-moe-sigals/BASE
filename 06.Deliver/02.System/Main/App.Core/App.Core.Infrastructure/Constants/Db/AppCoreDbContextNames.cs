namespace App.Core.Infrastructure.Constants.Db
{
    using System;

    public static class AppCoreDbConnectionStringNames
    {
        public const string Default = "Default";
    }

    public static class AppCoreDbContextNames
    {
        // For now, only one db per Module, but could be more at some point:
        public const string Core = Constants.Module.Names.ModuleKey;
    }
}