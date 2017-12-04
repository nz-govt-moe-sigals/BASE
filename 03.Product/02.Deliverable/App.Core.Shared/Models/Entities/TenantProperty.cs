﻿namespace App.Core.Shared.Models.Entities
{
    using System;

    public class TenantProperty : UntenantedTimestampedAuditedRecordStatedGuidIdEntityBase, IHasOwnerFK
    {
        public virtual string Key { get; set; }
        public virtual string Value { get; set; }
        public virtual Guid OwnerFK { get; set; }
    }
}