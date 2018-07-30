namespace App.Module11.Shared.Models.Entities
{
    using System;
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;

    public class BodyAlias : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase, IHasOwnerFK, IHasDisplayOrderHint,
        IHasTitle
    {
        // Display if Type=Organisation
        public virtual string Name { get; set; }

        public virtual string Prefix { get; set; }
        public virtual string GivenName { get; set; }
        public virtual string MiddleNames { get; set; }
        public virtual string SurName { get; set; }
        public virtual string Suffix { get; set; }

        public virtual int DisplayOrderHint { get; set; }
        public virtual Guid BodyFK { get; set; }

        //Label to identify it (Alias, etc.)
        public virtual string Title { get; set; }
        public Guid GetOwnerFk()
        {
            return BodyFK;
        }
    }
}





