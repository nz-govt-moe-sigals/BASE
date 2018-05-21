
namespace App.Core.Shared.Models.Entities.Base
{
    /// <summary>
    /// <para>
    /// Note that this Base runs parrallel to
    /// <see cref="UntenantedAuditedRecordStatedTimestampedGuidIdReferenceDataEntityBase"/>
    /// (inheritence line is based on Id Type).
    /// </para>
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public abstract class UntenantedAuditedRecordStatedTimestampedCustomIdReferenceDataEntityBase<TId> :
        UntenantedAuditedRecordStatedTimestampedCustomIdEntityBase<TId>,
        /*Enherited: IHasId<Guid>, IHasTimestamp, IHasInRecordAuditability, IHasRecordState*/
        IHasEnabled,
        IHasText,
        IHasDisplayOrderHint,
        IHasDisplayStyleHint
        where TId : struct
    {
        protected UntenantedAuditedRecordStatedTimestampedCustomIdReferenceDataEntityBase()
        {
            //As the Id is custom, cannot set:
            // NO: Id = GuidFactory.NewGuid();
        }



        public virtual bool Enabled { get; set; }

        public virtual string Text { get; set; }

        /// <summary>
        /// Higher numbers are displayed at top.
        /// </summary>
        public virtual int DisplayOrderHint { get; set; }

        // A convention based hint as to display (could be a class name, or icon, CSV or both, DSL, etc.)
        public virtual string DisplayStyleHint { get; set; }
    }


}
