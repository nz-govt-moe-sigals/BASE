namespace App.Core.Shared.Models.Entities.Base
{
    /// <summary>
    /// Whereas <see cref="TenantFKAuditedRecordStatedTimestampedCustomIdReferenceDataEntityBase{TId}"/>
    /// is all about DocuemntStore Id/Text, <see cref="TenantFKKeyedAuditedRecordStatedTimestampedCustomIdReferenceDataEntityBase{TId}"/>
    /// is about DocumentStoreId for storage, and Key/Text.
    /// <para>
    /// Note that this Base runs parrallel to
    /// <see cref="TenantFKKeyedAuditedTimestampedRecordStatedGuidIdReferenceDataEntityBase"/>
    /// (inheritence line is based on Id Type).
    /// </para>
    /// </summary>
    /// <seealso cref="App.Core.Shared.Models.Entities.Base.TenantFKAuditedRecordStatedTimestampedCustomIdReferenceDataEntityBase{TId}" />
    /// <seealso cref="App.Core.Shared.Models.IHasKey" />
    public abstract class TenantFKKeyedAuditedRecordStatedTimestampedCustomIdReferenceDataEntityBase<TId> 
        : TenantFKAuditedRecordStatedTimestampedCustomIdReferenceDataEntityBase<TId>, IHasKey
        where TId : struct
    {
        public string Key { get; set; }
    }
}