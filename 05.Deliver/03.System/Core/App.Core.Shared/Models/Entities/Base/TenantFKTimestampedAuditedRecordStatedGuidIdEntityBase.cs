namespace App.Core.Shared.Models.Entities
{
    using System;


    /// <summary>
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
    /// <seealso cref="App.Core.Shared.Models.Entities.UntenantedTimestampedAuditedRecordStatedGuidIdEntityBase" />
    /// <seealso cref="App.Core.Shared.Models.IHasTenantFK" />
    public abstract class TenantFKTimestampedAuditedRecordStatedGuidIdEntityBase :
        UntenantedTimestampedAuditedRecordStatedGuidIdEntityBase,
        IHasTenantFK
    {
        /// <summary>
        /// Gets or sets the FK of the Tenancy this mutable model belongs to.
        /// </summary>
        public virtual Guid TenantFK { get; set; }
    }
}