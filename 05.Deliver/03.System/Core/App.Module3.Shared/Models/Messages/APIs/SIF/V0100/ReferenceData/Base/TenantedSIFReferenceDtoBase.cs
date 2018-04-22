namespace App.Module3.Shared.Models.Messages.APIs.SIF.V0100.Base
{
    using System;
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;
    using App.Module3.Shared.Models.Entities;


    /// <summary>
    /// The abstract base class for Clients that use SIF codes
    /// for their publcy visible Model PK.
    /// <para>
    /// Note that this PK is *not* mapped to the 
    /// the internal Guid DatastorageId
    /// of the Entity - it is mapped to a UNIQUE KEY
    /// of the entity, it's SIFKey.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Core.Shared.Models.IHasId{String}" />
    /// <seealso cref="App.Core.Shared.Models.IHasTenantFK" />
    /// <seealso cref="App.Module3.Shared.Models.Entities.IHasSIFIdAsStringId" />
    public abstract class TenantedSIFReferenceDtoBase  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : 
        IHasId<string>, 
        IHasTenantFK, 
        IHasSIFIdAsStringId
    {

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="TenantedSIFReferenceDtoBase"/> class.
        /// </summary>
        protected TenantedSIFReferenceDtoBase()
        {
            //this.Id = GuidFactory.NewGuid();
        }

        /// <summary>
        /// Gets or sets the publicy viewable Identifier
        /// for the record.
        /// <para>
        /// It is *not* the internal Entity Guid.
        /// </para>
        /// <para>
        /// It is not the SIF code.
        /// </para>
        /// </summary>
        public virtual string Id
        {
            get; set;
        }


        /// <summary>
        /// Gets or sets the FK of the Tenancy this mutable model belongs to.
        /// <para>
        /// When referenced from within the Core Module's DbContext
        /// the TenantFK is logically enforced by the database (normalized),
        /// whereas from other DbContexts it is not.
        /// The Logic behind this choice stems from the understanding that
        /// a Business Model (eg: Foo) has no need to Navigate to a Tenant to which
        /// the Business Model belongs. It's actually a different Domain Context (System).
        /// The above logic is actually enforced in EF's natural constraint that a Model
        /// belong to only one DbContext (one Bounded Context).
        /// The advantage is natural Domain Separation. In the same way as we trust external
        /// IdP Services to manage Users.
        /// THe consideration is that Application logic is required to ensure TenantId
        /// is applied at the Application Logic tier, as it is not enforced at the database.
        /// TenantFK is not required on anything else but the TenantProperties entity, and Users
        /// in order to know which Tenant a user is allowed to be a member of.
        /// </para>
        /// </summary>
        /// <value>
        /// The tenant fk.
        /// </value>
        public virtual Guid TenantFK
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the publicly viewable Reference data text/description. 
        /// <para>
        /// This is the information that is viewable in a client UI dropdown.
        /// </para>
        /// </summary>
        public virtual string Text
        {
            get; set;
        }

    }

}
