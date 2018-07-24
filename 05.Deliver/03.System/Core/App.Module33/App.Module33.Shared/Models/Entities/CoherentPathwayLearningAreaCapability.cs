using System;
using App.Core.Shared.Models.Entities.Base;

namespace App.Module33.Shared.Models.Entities
{
    using App.Core.Shared.Models.Entities;

    public class CoherentPathwayLearningAreaCapability : TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataEntityBase
    {
        public Guid CoherentPathwayLearningAreaStepFK { get; set; }

        public CoherentPathwayLearningAreaStep CoherentPathwayLearningAreaStep { get; set; }
    }
}

