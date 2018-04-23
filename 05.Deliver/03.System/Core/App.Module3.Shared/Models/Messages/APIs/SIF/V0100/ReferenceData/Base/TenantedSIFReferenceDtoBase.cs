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
    // ReSharper disable once InconsistentNaming
    public abstract class TenantedSIFReferenceDtoBase  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : 
        IHasId<string>, 
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
