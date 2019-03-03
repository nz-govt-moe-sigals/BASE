namespace App.Core.Shared.Models.Entities.Base
{
    using System;
    using App.Core.Shared.Factories;
    using App.Core.Shared.Models.Contracts;


    /// <summary>
    /// Base abstract class for Mutable 
    /// Reference data. 
    /// <para>
    /// Note that this Base runs parrallel to
    /// <see cref="TenantFKAuditedRecordStatedTimestampedCustomIdReferenceDataEntityBase{TId}"/>
    /// (inheritence line is based on Id Type).
    /// </para>
    /// <para>
    /// Being mutable by end users, it has a Guid id and is specific to a single Tenant.
    /// </para>
    /// <para>
    /// Implements
    /// <see cref="IHasEnabled"/>
    /// <see cref="IHasText"/>
    /// <see cref="IHasDisplayOrderHint"/>
    /// <see cref="IHasDisplayStyleHint"/>
    /// <see cref="IHasTenantFK"/>
    /// <see cref="IHasGuidId"/>,
    /// <see cref="IHasId{T}"/>,
    /// <see cref="IHasTimestamp"/>
    /// <see cref="IHasInRecordAuditability"/>
    /// <see cref="IHasRecordState"/>
    /// </para>    
    /// <para>
    /// Refer to <see cref="UntenantedAuditedRecordStatedTimestampedGuidIdReferenceDataEntityBase"/> for Reference data that is shared across Tenants.</para>
    /// </summary>
    /// <seealso cref="App.Core.Shared.Models.Entities.TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase" />
    /// <seealso cref="App.Core.Shared.Models.IHasEnabled" />
    /// <seealso cref="App.Core.Shared.Models.IHasText" />
    /// <seealso cref="App.Core.Shared.Models.IHasDisplayOrderHint" />
    public abstract class TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataEntityBase : 
        TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase,
        IHasMutableDisplayableReferenceData
    {

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataEntityBase"/> is enabled.
        /// </summary>
        public virtual bool Enabled
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the reference data's displayed text.
        /// </summary>
        public virtual string Title
        {
            get; set;
        }

        public virtual string Description
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets the display order hint.
        /// </summary>
        public virtual int DisplayOrderHint
        {
            get; set;
        }

        // A convention based hint as to display (could be a class name, or icon, CSV or both, DSL, etc.)
        public virtual string DisplayStyleHint
        {
            get; set;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataEntityBase"/> class.
        /// </summary>
        protected TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataEntityBase()
        {
            Id = GuidFactory.NewGuid();
        }



    }
}