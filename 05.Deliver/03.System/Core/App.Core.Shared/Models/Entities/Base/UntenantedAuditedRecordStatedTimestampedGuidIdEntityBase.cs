namespace App.Core.Shared.Models.Entities
{
    using System;
    using App.Core.Shared.Factories;

    /// <summary>
    /// <para>
    /// Note that this Base runs parrallel to
    /// <see cref="UntenantedAuditedRecordStatedTimestampedCustomIdEntityBase{TId}"/>
    /// (inheritence line is based on Id Type).
    /// </para>
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
    public abstract class UntenantedAuditedRecordStatedTimestampedGuidIdEntityBase : 
        UntenantedAuditedRecordStatedTimestampedCustomIdEntityBase<Guid>,
        IHasGuidId 
        /*Enherited: IHasId<Guid>, IHasTimestamp, IHasInRecordAuditability, IHasRecordState*/
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UntenantedAuditedRecordStatedTimestampedGuidIdEntityBase"/> class.
        /// </summary>
        protected UntenantedAuditedRecordStatedTimestampedGuidIdEntityBase()
        {
            this.Id = GuidFactory.NewGuid();
        }
   }
}