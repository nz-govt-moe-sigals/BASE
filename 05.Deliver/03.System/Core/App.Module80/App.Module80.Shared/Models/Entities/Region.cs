using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Shared.Models.Entities;

namespace App.Module80.Shared.Models.Entities
{
    public class Region : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase
    {
        public int RegionId { get; set; }

        public string Name { get; set; }

        public ICollection<SurveyLocation> Beaches { get; set; }

    }
}
