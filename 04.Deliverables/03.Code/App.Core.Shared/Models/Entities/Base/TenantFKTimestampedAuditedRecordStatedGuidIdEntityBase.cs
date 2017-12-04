namespace App.Core.Shared.Models.Entities
{
    using System;


    public abstract class TenantFKTimestampedAuditedRecordStatedGuidIdEntityBase :
        UntenantedTimestampedAuditedRecordStatedGuidIdEntityBase,
        IHasTenantFK
    {
        public virtual Guid TenantFK { get; set; }
    }
}