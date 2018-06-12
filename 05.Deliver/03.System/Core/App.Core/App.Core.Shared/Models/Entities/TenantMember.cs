namespace App.Core.Shared.Models.Entities
{
    using System;

    public class TenantMember : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase, IHasEnabled {

        public DateTime? EnabledBeginningUtc { get; set; }
        public DateTime? EnabledEndingUtc { get; set; }
        public virtual bool Enabled { get; set; }

        public virtual string DisplayName { get; set; }

        public virtual NZDataClassification? DataClassificationFK { get; set; }
        public virtual DataClassification DataClassification { get; set; }

        public virtual PrincipalCategory Category { get; set; }
        public virtual Guid CategoryFK { get; set; }


    }
}