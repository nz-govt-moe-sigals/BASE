using System;
using System.Collections.Generic;
using App.Core.Shared.Models.Entities.Base;

namespace App.Module33.Shared.Models.Entities
{
    using App.Core.Shared.Models.Entities;

    public class CoherentPathwayStep : TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataEntityBase
    {
        public Guid CoherentPathwayFK { get; set; }

        public CoherentPathway CoherentPathway { get; set; }

        public virtual ICollection<CoherentPathwayOverarchingCapability> CoherentPathwayOverarchingCapabilities { get; set; }

        public virtual ICollection<CoherentPathwayLearningAreaStep> CoherentPathwayLearningAreaSteps { get; set; }
    }
}

