namespace App.Core.Shared.Models.Entities
{
    using System;

    public abstract class TenantFkTimestampedAuditedRecordStatedCustomIdEntityBase<TId> :
        UntenantedTimestampedAuditedRecordStatedCustomIdEntityBase<TId>,
        IHasTenantFK
    {

        public TenantFkTimestampedAuditedRecordStatedCustomIdEntityBase() : base()
        {
            //REMEMBER: As not a Guid ID Must be provided somehow...
        }

        public virtual Guid TenantFK { get; set; }
    }
}