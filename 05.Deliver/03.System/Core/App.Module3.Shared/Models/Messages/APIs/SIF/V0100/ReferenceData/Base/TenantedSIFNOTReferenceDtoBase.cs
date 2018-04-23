namespace App.Module3.Shared.Models.Messages.APIs.SIF.V0100.Base
{
    using System;
    using App.Core.Shared.Models;
    using App.Module3.Shared.Models.Entities;

    /// <summary>
    /// Abstract base class for ReferenceData 
    /// that is used in the SIF API, but does
    /// not have a SIF code...so is falling back
    /// to MOE/FIRST/LEGACY Codes.
    /// <para>
    /// Note that this PK is *not* mapped to the 
    /// the internal Guid DatastorageId
    /// of the Entity - it is mapped to a UNIQUE KEY
    /// of the entity, it's SIFKey....
    /// ... although in this instance it will be a copy 
    /// of the record's FIRST key (since we don't have
    /// a SIF key).
    /// </para>
    /// </summary>
    /// <seealso cref="App.Core.Shared.Models.IHasId{String}" />
    /// <seealso cref="App.Core.Shared.Models.IHasTenantFK" />
    /// <seealso cref="App.Module3.Shared.Models.Entities.IHasSIFIdAsStringId" />
    /// <seealso cref="App.Module3.Shared.Models.Entities.IHasSIFNOTIdAsStringId" />
    public abstract class TenantedSIFNOTReferenceDtoBase :
        TenantedSIFReferenceDtoBase,
        IHasId<string>,
        IHasSIFNOTIdAsStringId
    {

    }
}