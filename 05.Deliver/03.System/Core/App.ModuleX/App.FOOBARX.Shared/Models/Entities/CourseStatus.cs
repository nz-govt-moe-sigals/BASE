using App.Core.Shared.Models.Entities.Base;
using App.MODULETEMPLATE.Shared.Models.Entities.Enums;

namespace App.MODULETEMPLATE.Shared.Models.Entities
{

    public class CourseStatus  : TenantFKAuditedRecordStatedTimestampedCustomIdReferenceDataEntityBase<CourseStatusType>
    {
        public virtual string Description { get; set; }
    }


}















