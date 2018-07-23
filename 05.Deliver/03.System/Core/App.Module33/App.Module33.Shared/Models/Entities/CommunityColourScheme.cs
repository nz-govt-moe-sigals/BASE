using System;
using System.Collections.Generic;
using App.Core.Shared.Models.Entities.Base;

namespace App.Module33.Shared.Models.Entities
{
    using App.Core.Shared.Models.Entities;

    public class CommunityColourScheme : TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataEntityBase
    {
        public virtual ICollection<Community> Communities { get; set; }
    }
}

