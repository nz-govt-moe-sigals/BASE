using App.Core.Shared.Models.Entities;

namespace App.Module22.Shared.Models.Entities
{
    public class CourseCredit : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase
    {
        public virtual string Key { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }

    }




}


