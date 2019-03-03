namespace App.Core.Shared.Models.Entities
{
    using System;

    public abstract class TenantFKAuditedRecordStatedTimestampedNoIdEntityBase :
        UntenantedAuditedRecordStatedTimestampedNoIdEntityBase,
        IHasTenantFK
    {
        /// <summary>
        /// Gets or sets the FK of the Tenancy this mutable model belongs to.
        /// </summary>
        public virtual Guid TenantFK { get; set; }
    }


}