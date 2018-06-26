using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Shared.Models.Entities;
using App.Module80.Shared.Models.Entities.Enums;

namespace App.Module80.Shared.Models.Entities
{
    public class SurveyLargeItem : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase
    {
        public SurveyLargeItem()
        {
            Count = 1;
        }

        public Guid SurveyFK { get; set; }

        public Guid LargeItemFK { get; set; }

        public LargeItem LargeItem { get; set; }

        public int Count { get; set; }

        public decimal? Longitude { get; set; }

        public decimal? Latitude { get; set; }

        public LargeItemStatus Status { get; set; }

        public string DetailedDescription { get; set; }
    }
}
