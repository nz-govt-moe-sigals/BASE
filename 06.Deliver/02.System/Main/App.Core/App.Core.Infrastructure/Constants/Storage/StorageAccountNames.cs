namespace App.Core.Infrastructure.Constants.Storage
{
    /// <summary>
    /// The Azure Resource Name of a Storage Account. 
    /// <para>
    /// A System, or even a Module may use multiple Storage Accounts...but it's pretty
    /// uncommon. Generally, there's just need for StorageAccount 
    /// (<see cref="StorageAccountNames"/>), 
    /// within which multiple Containers 
    /// (<see cref="BlobStorageContainers"/>)
    /// are developed.
    /// </para>
    /// <para>
    /// Remember -- one backs up Containers, not Accounts.
    /// </para>
    /// </summary>
    public static class StorageAccountNames
    {
        // For now, only one db per Module, but could be more at some point:
        public const string Default = Constants.Module.Names.ModuleKey + ".Default";
    }
}
