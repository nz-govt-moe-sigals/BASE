using System;
using App.Core.Shared.Models.Entities.Base;

namespace App.Module33.Shared.Models.Entities
{
    using App.Core.Shared.Models.Entities;

    public class CoherentPathwayOverarchingCapability : TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataEntityBase
    {
        public Guid CoherentPathwayStepFK { get; set; }

        public CoherentPathwayStep CoherentPathwayStep { get; set; }
    }
}

