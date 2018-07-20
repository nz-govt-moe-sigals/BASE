using System;
using System.Collections.Generic;
using App.Core.Shared.Models.Entities.Base;

namespace App.Module33.Shared.Models.Entities
{
    using App.Core.Shared.Models.Entities;

    public class CoherentPathwayLearningAreaStep : TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataEntityBase
    {
        public Guid CoherentPathwayStepFK { get; set; }

        public CoherentPathwayStep CoherentPathwayStep { get; set; }

        public bool CurriculumArea { get; set; }

        public virtual ICollection<CoherentPathwayLearningAreaCapability> CoherentPathwayLearningAreaCapabilities { get; set; }
    }
}

