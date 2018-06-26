using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Shared.Models.Entities;

namespace App.Module80.Shared.Models.Entities
{
    public class Organisation : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase
    {
        public string Name { get; set; }

        public string ContactNumber { get; set; }


        public ICollection<Survey> Surveys { get; set; }
    }
}
