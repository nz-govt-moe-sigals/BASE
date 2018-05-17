namespace App.Core.Shared.Models.Entities.Base
{
    /// <summary>
    /// Whereas <see cref="TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataEntityBase"/>
    /// is all about DocuemntStore Id/Text, <see cref="TenantFKKeyedAuditedTimestampedRecordStatedGuidIdReferenceDataEntityBase"/>
    /// is about DocumentStoreId for storage, and Key/Text.
    /// <para>
    /// Note that this Base runs parrallel to
    /// <see cref="TenantFKKeyedAuditedRecordStatedTimestampedCustomIdReferenceDataEntityBase{TId}"/>
    /// (inheritence line is based on Id Type).
    /// </para>
    /// </summary>
    /// <seealso cref="App.Core.Shared.Models.Entities.Base.TenantFKTimestampedAuditedRecordStatedCustomIdReferenceDataEntityBase" />
    /// <seealso cref="App.Core.Shared.Models.IHasKey" />
    public abstract class TenantFKKeyedAuditedRecordStatedTimestampedGuidIdReferenceDataEntityBase
        : TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataEntityBase, IHasKey
    {
        public string Key { get; set; }
    }
}