namespace App.Module2.Shared.Models.Entities
{
    using System;
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;

    public class BodyChannel : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase, IHasOwnerFK, IHasDisplayOrderHint
    {
        // Protocol: Phone, Email, Twitter, Instagram
        public virtual BodyChannelType Protocol { get; set; }

        // Home Address, Home Phone, Office Address, Office Email, etc.
        public virtual string Title { get; set; }

        // Email Address, etc. -- all except postal.
        public virtual string Address { get; set; }

        // Display these fields only if Protocol is Postal. Otherwise, Address is sufficient for all electronic protocols.
        public virtual string AddressStreetAndNumber { get; set; }

        public virtual string AddressSuburb { get; set; }
        public virtual string AddressCity { get; set; }
        public virtual string AddressRegion { get; set; }
        public virtual string AddressState { get; set; }

        public virtual string AddressCountry { get; set; }

        // Amazes me that in two centuries, Postal Codes have not progressed to include encoding of CountryId + PostalCode +  StreetId + StreetPosition + BlockId + UnitId
        public virtual string AddressPostalCode { get; set; }

        public virtual string AddressInstructions { get; set; }
        public virtual int DisplayOrderHint { get; set; }
        public virtual Guid OwnerFK { get; set; }
    }
}