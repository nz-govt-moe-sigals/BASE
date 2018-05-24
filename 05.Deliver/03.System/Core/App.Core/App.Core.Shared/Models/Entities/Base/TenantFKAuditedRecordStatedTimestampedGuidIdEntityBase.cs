namespace App.Core.Shared.Models.Entities
{
    using System;


    /// <summary>
    /// <para>
    /// Note that this Base runs parrallel to
    /// <see cref="TenantFKAuditedRecordStatedTimestampedCustomIdEntityBase{TId}"/>
    /// (inheritence line is based on Id Type).
    /// </para>
    /// <para>
    /// Implements
    /// <see cref="IHasTenantFK"/>
    /// <see cref="IHasGuidId"/>,
    /// <see cref="IHasId{T}"/>,
    /// <see cref="IHasTimestamp"/>
    /// <see cref="IHasInRecordAuditability"/>
    /// <see cref="IHasRecordState"/>
    /// </para>    
    /// </summary>
    /// <seealso cref="App.Core.Shared.Models.Entities.UntenantedAuditedRecordStatedTimestampedGuidIdEntityBase" />
    /// <seealso cref="App.Core.Shared.Models.IHasTenantFK" />
    public abstract class TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase :
        UntenantedAuditedRecordStatedTimestampedCustomIdEntityBase<Guid>,
        IHasTenantFK,
        IHasGuidId
        
    {
        /// <summary>
        /// Gets or sets the FK of the Tenancy this mutable model belongs to.
        /// </summary>
        public virtual Guid TenantFK { get; set; }
    }


}