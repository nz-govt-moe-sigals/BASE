namespace App.Module3.Shared.Models.Messages.APIs.SIF.V0100
{
    using App.Module3.Shared.Models.Messages.APIs.SIF.V0100.Base;

    /// <summary>
    /// The authority by which the provider is authorised to provide education services. A valid value per 2.4.7.
    /// <para>
    /// Note that this PK is *not* mapped to the 
    /// the internal Guid DatastorageId
    /// of the Entity - it is mapped to a UNIQUE KEY
    /// of the entity, it's SIFKey.
    /// </para>
    /// </summary>
    /// <seealso cref="SIFReferenceDtoBase" />
    public class AuthorityTypeDto : SIFReferenceDtoBase
    {
    }
}