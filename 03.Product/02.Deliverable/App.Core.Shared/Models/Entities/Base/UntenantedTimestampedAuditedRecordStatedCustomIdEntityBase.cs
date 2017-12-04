namespace App.Core.Shared.Models.Entities
{
    using System;

    public abstract class UntenantedTimestampedAuditedRecordStatedCustomIdEntityBase<TId> : IHasId<TId>, IHasTimestamp,
        IHasInRecordAuditability, IHasRecordState
    {
        public TId Id { get; set; }

        protected UntenantedTimestampedAuditedRecordStatedCustomIdEntityBase()
        {
            //REMEMBER: ID MUST BE PROVIDED IN THIS CASE...
        }

        public virtual DateTime? CreatedOnUtc { get; set; }
        public virtual string CreatedByPrincipalId { get; set; }
        public virtual DateTime? LastModifiedOnUtc { get; set; }
        public virtual string LastModifiedByPrincipalId { get; set; }
        public virtual DateTime? DeletedOnUtc { get; set; }
        public virtual string DeletedByPrincipalId { get; set; }


        public virtual RecordPersistenceState RecordState { get; set; }

        /// <summary>
        ///     Gets or sets the datastore concurrency check timestamp.
        ///     <para>
        ///         Note that this is filled in when persisted in the db --
        ///         so it's usable to determine whether Record is New or not.
        ///     </para>
        /// </summary>
        public virtual byte[] Timestamp { get; set; }
    }
}