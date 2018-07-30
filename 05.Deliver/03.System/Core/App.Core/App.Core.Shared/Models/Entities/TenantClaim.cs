namespace App.Core.Shared.Models.Entities
{
    using System;

    public class TenantClaim : UntenantedAuditedRecordStatedTimestampedGuidIdEntityBase, IHasOwnerFK
    {
        public virtual string Authority { get; set; }
        public virtual string AuthoritySignature { get; set; }
        public virtual string Key { get; set; }
        public virtual string Value { get; set; }
        public virtual Guid TenantFK { get; set; }

        public Guid GetOwnerFk()
        {
            return TenantFK;
        }
    }
}