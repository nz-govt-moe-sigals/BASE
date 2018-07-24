using System;
using System.Collections.Generic;

namespace App.Module33.Shared.Models.Entities
{
    using App.Core.Shared.Models.Entities;

    public class CoherentPathway : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase
    {
        public Guid CommunityFK { get; set; }

        public Community Community { get; set; }

        public string Strategy { get; set; }

        public virtual ICollection<CoherentPathwayStep> CoherentPathwaySteps { get; set; }
    }
}

