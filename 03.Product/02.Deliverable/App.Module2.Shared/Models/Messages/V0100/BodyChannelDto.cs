namespace App.Module2.Shared.Models.Messages.V0100
{
    using System;
    using App.Core.Shared.Factories;
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;
    using App.Module2.Shared.Models.Entities;

    public class BodyChannelDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId, IHasTenantFK, IHasRecordState, IHasDisplayOrderHint
    {
        public BodyChannelDto()
        {
            this.Id = GuidFactory.NewGuid();
        }

        public virtual Guid BodyFK { get; set; }


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

        public virtual Guid Id { get; set; }
        public virtual RecordPersistenceState RecordState { get; set; }
        public virtual Guid TenantFK { get; set; }
    }
}