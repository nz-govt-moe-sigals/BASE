namespace App.Core.Shared.Models.Entities
{
    using System;
    using App.Core.Shared.Factories;

    /// <summary>
    /// <para>
    /// Implements
    /// <see cref="IHasGuidId"/>,
    /// <see cref="IHasId{T}"/>,
    /// <see cref="IHasTimestamp"/>
    /// <see cref="IHasInRecordAuditability"/>
    /// <see cref="IHasRecordState"/>
    /// </para>    
    /// </summary>
    /// <seealso cref="Guid" />
    /// <seealso cref="App.Core.Shared.Models.IHasGuidId" />
    /// <seealso cref="App.Core.Shared.Models.IHasTimestamp" />
    /// <seealso cref="App.Core.Shared.Models.IHasInRecordAuditability" />
    /// <seealso cref="App.Core.Shared.Models.IHasRecordState" />
    public abstract class UntenantedTimestampedAuditedRecordStatedGuidIdEntityBase : UntenantedTimestampedAuditedRecordStatedCustomIdEntityBase<Guid>,IHasId<Guid> ,IHasGuidId, IHasTimestamp,
        IHasInRecordAuditability, IHasRecordState
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UntenantedTimestampedAuditedRecordStatedGuidIdEntityBase"/> class.
        /// </summary>
        protected UntenantedTimestampedAuditedRecordStatedGuidIdEntityBase()
        {
            this.Id = GuidFactory.NewGuid();
        }
   }
}