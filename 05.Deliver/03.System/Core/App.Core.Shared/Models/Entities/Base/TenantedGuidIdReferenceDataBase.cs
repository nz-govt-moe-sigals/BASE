namespace App.Core.Shared.Models.Entities.Base
{
    using System;
    using App.Core.Shared.Factories;
    using App.Core.Shared.Models.Contracts;


    /// <summary>
    /// Base abstract class for Mutable 
    /// Reference data. 
    /// <para>
    /// Being mutable by end users, it has a Guid id and is specific to a single Tenant.
    /// </para>
    /// <para>
    /// Refer to <see cref="UntenantedGuidIdReferenceDataBase"/> for Reference data that is shared across Tenants.</para>
    /// </summary>
    /// <seealso cref="App.Core.Shared.Models.Entities.TenantFKTimestampedAuditedRecordStatedGuidIdEntityBase" />
    /// <seealso cref="App.Core.Shared.Models.IHasEnabled" />
    /// <seealso cref="App.Core.Shared.Models.IHasText" />
    /// <seealso cref="App.Core.Shared.Models.IHasDisplayOrderHint" />
    public abstract class TenantedGuidIdReferenceDataBase : TenantFKTimestampedAuditedRecordStatedGuidIdEntityBase,
        IHasMutableReferenceData
    {

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TenantedGuidIdReferenceDataBase"/> is enabled.
        /// </summary>
        public virtual bool Enabled
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the reference data's displayed text.
        /// </summary>
        public virtual string Text
        {
            get; set;
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
        /// Initializes a new instance of the <see cref="TenantedGuidIdReferenceDataBase"/> class.
        /// </summary>
        protected TenantedGuidIdReferenceDataBase()
        {
            Id = GuidFactory.NewGuid();
        }



    }
}