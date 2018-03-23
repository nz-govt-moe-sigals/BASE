namespace App.Module2.Shared.Models.Entities
{
    using System;
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;

    public class BodyLocation : TenantFKTimestampedAuditedRecordStatedGuidIdEntityBase //, IHasOwnerFK
    {
        //public virtual Guid OwnerFK { get; set; }
        public virtual decimal Latitude { get; set; }
        public virtual decimal Longitude { get; set; }
    }
}