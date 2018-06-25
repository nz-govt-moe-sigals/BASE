namespace App.Core.Shared.Models.Entities.TenancySpecific
{
    using System;

    public class PrincipalProfileProperty : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase, IHasOwnerFK
    {
        public virtual string Key { get; set; }
        public virtual string Value { get; set; }
        public virtual Guid OwnerFK { get; set; }
    }
}