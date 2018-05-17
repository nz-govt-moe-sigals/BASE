namespace App.Core.Shared.Models.Entities
{
    /// <summary>
    /// <para>
    /// Note that this Base runs parrallel to
    /// <see cref="UntenantedAuditedRecordStatedTimestampedGuidIdEntityBase"/>
    /// (inheritence line is based on Id Type).
    /// </para>
    /// <para>
    /// Implements
    /// <see cref="IHasId{T}"/>,
    /// <see cref="IHasTimestamp"/>
    /// <see cref="IHasInRecordAuditability"/>
    /// <see cref="IHasRecordState"/>
    /// </para>
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    /// <seealso cref="App.Core.Shared.Models.IHasId{TId}" />
    /// <seealso cref="App.Core.Shared.Models.IHasTimestamp" />
    /// <seealso cref="App.Core.Shared.Models.IHasInRecordAuditability" />
    /// <seealso cref="App.Core.Shared.Models.IHasRecordState" />
    public abstract class UntenantedAuditedRecordStatedTimestampedCustomIdEntityBase<TId> : 
        UntenantedAuditedRecordStatedTimestampedNoIdEntityBase,
        IHasId<TId>
        /* Inherited:  IHasTimestamp, IHasInRecordAuditability, IHasRecordState */
        where TId : struct
    {
        protected UntenantedAuditedRecordStatedTimestampedCustomIdEntityBase()
        {
            //REMEMBER: ID MUST BE PROVIDED IN THIS CASE...
        }

        public virtual TId Id { get; set; }
    }
}