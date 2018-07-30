namespace App.Module11.Shared.Models.Entities
{
    using System;
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;

    public class BodyClaim : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase, IHasOwnerFK
    {
        public virtual string Authority { get; set; }
        public virtual string AuthoritySignature { get; set; }
        public virtual string Key { get; set; }
        public virtual string Value { get; set; }
        public virtual Guid BodyFK { get; set; }

        public Guid GetOwnerFk()
        {
            return BodyFK;
        }
    }
}





