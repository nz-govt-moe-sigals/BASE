namespace App.Core.Shared.Models.Entities.Base
{
    /// <summary>
    /// Whereas <see cref="TenantedGuidIdReferenceDataBase"/>
    /// is all about DocuemntStore Id/Text, <see cref="TenantedKeyedGuidIdReferenceDataBase"/>
    /// is about DocumentStoreId for storage, and Key/Text.
    /// </summary>
    /// <seealso cref="App.Core.Shared.Models.Entities.Base.TenantedGuidIdReferenceDataBase" />
    /// <seealso cref="App.Core.Shared.Models.IHasKey" />
    public abstract class TenantedKeyedGuidIdReferenceDataBase : TenantedGuidIdReferenceDataBase, IHasKey
    {
        public string Key { get; set; }
    }
}