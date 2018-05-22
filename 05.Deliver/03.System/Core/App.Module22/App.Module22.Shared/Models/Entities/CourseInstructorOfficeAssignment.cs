using App.Core.Shared.Models.Entities;
using System;

namespace App.Module22.Shared.Models.Entities
{
    public class CourseInstructorOfficeAssignment  : TenantFKAuditedRecordStatedTimestampedNoIdEntityBase
    {
        //TODO: May need an Id...in order to work with OData.
        
        // Using Composite key.

        public Guid CourseInstructorFK { get; set; }
        public CourseInstructor CourseInstructor { get; set; }

        public Guid CourseInstructorOfficeFK { get; set; }
        public CourseInstructorOffice CourseInstructorOffice { get; set; }

        public DateTimeOffset? Begin {get;set;}
        public DateTimeOffset? End { get; set; }

        public string Notes { get; set; }

    }
}


