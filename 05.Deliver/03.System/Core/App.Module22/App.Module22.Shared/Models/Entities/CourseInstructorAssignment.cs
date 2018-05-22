using App.Core.Shared.Models.Entities;
using System;

namespace App.Module22.Shared.Models.Entities
{
    public class CourseInstructorAssignment :  TenantFKAuditedRecordStatedTimestampedNoIdEntityBase
    {
        //TODO: May need an Id...in order to work with OData.

        // Primary Key is CompositeKey (InstructorFK, CourseFK...Maybe also TenantFK if it works)

        // Lookup:
        public Guid RoleFK { get; set; }
        public CourseRole Role { get; set; }

        public Guid CourseInstructorFK { get; set; }
        public CourseInstructor CourseInstructor { get; set; }

        public Guid CourseFK { get; set; }
        public Course Course { get; set; }
    }

}


