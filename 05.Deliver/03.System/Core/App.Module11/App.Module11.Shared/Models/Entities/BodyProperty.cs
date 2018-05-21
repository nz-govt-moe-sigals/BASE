namespace App.Module11.Shared.Models.Entities
{
    using System;
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;

    public class BodyProperty : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase, IHasOwnerFK
    {
        public virtual string Key { get; set; }
        public virtual string Value { get; set; }
        public virtual Guid OwnerFK { get; set; }
    }
}





