using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Shared.Models.Entities;
using App.Core.Shared.Models.Entities.Base;
using Newtonsoft.Json;

namespace App.Module32.Shared.Models.Entities
{
    public class EducationSchoolProfile : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase
    {
        public int SchoolId { get; set; }

        public string Name { get; set; }


    }
}
