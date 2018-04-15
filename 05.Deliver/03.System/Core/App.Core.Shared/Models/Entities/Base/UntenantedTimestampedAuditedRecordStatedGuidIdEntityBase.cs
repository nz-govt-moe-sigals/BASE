namespace App.Core.Shared.Models.Entities
{
    using System;
    using App.Core.Shared.Factories;

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