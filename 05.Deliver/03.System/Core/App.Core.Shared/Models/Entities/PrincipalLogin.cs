using System;

namespace App.Core.Shared.Models.Entities
{
    /// <summary>
    /// A Principal can login from several foreign IdPs (FB, Google, ML, thisApp...).
    /// The user will be known by the remote Idp under a different login (eg: foo@google.com)
    /// as well as a unique reference id for the user (often a guid, but can be anything, hence string storage is best).
    /// When an IdP sends back the response, it has to be correlated back to a System Principal.
    /// That's done via this object.
    /// </summary>
    public class PrincipalLogin : UntenantedTimestampedAuditedRecordStatedGuidIdEntityBase, IHasEnabled , IHasOwnerFK
    {

        public Guid OwnerFK { get; set; }

        /// <summary>
        /// Can be used to disallow an external IdP login that was previsoulsy trusted.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The Credential Name/Login the external IdP uses to distinguish users by (eg: 'joeblow', 'joeblow@google.com', etc.).
        /// </summary>
        public string IdPLogin { get; set; }

        /// <summary>
        /// Last datetime the user signed in via this login.
        /// </summary>
        public DateTime LastLoggedInUtc { get; set; }

    }
}
