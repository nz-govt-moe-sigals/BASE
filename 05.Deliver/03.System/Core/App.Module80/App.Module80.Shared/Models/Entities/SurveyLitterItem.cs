using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Shared.Models.Entities;

namespace App.Module80.Shared.Models.Entities
{
    public class SurveyLitterItem : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase
    {
        public SurveyLitterItem()
        {
            Count = 1;
        }

        public Guid SurveyFK { get; set; }

        public Guid LitterItemFK { get; set; }

        public LitterItem LitterItem { get; set; }

        public decimal Weight { get; set; }

        public int Count { get; set; }

    }
}
