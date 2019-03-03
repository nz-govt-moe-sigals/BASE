namespace App.Core.Shared.Models.Entities
{
    using System;

    /// <summary>
    /// <para>
    /// Note that this Base runs parrallel to
    /// <see cref="TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase"/>
    /// (inheritence line is based on Id Type).
    /// </para>
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public abstract class TenantFKAuditedRecordStatedTimestampedCustomIdEntityBase<TId> :
        UntenantedAuditedRecordStatedTimestampedCustomIdEntityBase<TId>,
        /* Enherited: , IHasTimestamp, IHasInRecordAuditability, IHasRecordState */
        IHasTenantFK
        where TId: struct
    {

        public TenantFKAuditedRecordStatedTimestampedCustomIdEntityBase() : base()
        {
            //REMEMBER: As not a Guid ID Must be provided somehow...
        }

        public virtual Guid TenantFK { get; set; }
    }
}