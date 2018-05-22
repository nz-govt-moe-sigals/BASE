using App.Core.Shared.Models;
using App.Core.Shared.Models.Entities.Base;

namespace App.Module01.Shared.Models.Entities
{
    /// <summary>
    /// Grades will not always be A, B, C.
    /// Depends on language and establishment preferences (eg: Pass/Fail)
    /// </summary>
    public class CourseGrade : TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataEntityBase, IHasDescription
    {
        // Text is already part of the underlying object.

        /// <summary>
        /// 
        /// </summary>
        public virtual string Description { get; set; }
    }




}
