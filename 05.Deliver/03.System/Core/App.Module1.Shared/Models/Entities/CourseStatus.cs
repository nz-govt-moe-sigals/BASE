using App.Core.Shared.Models.Entities.Base;
using App.Module1.Shared.Models.Entities.Enums;

namespace App.Module1.Shared.Models.Entities
{

    public class CourseStatus  : TenantFKAuditedRecordStatedTimestampedCustomIdReferenceDataEntityBase<CourseStatusType>
    {
        public virtual string Description { get; set; }
    }


}
