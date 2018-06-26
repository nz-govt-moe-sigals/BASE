using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Shared.Models.Entities;

namespace App.Module80.Shared.Models.Entities
{
    public class LargeItem : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase
    {
        public string Code { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }
    }
}
