using App.Core.Shared.Models.Entities;
using App.Module01.Shared.Models.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace App.Module01.Shared.Models.Entities
{
    public class CourseInstructor: TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase
    {
        public CourseStatusType StatusFK { get; set; }
        public CourseStatus Status { get; set; }

        
        /// <summary>
        /// Name of Instructor 
        /// TODO: Make it Alias able.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A costomizable description. 
        /// Possibly describing when one can find the <see cref="CourseInstructor"/> 
        /// in their office, etc. 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The date when the <see cref="CourseInstructor"/> begun/will begin.
        /// </summary>
        public DateTimeOffset? Begin { get; set; }



        /// <summary>
        /// An Office can be assigned to one or more <see cref="CourseInstructor"/>s
        /// at different times.
        /// </summary>
        public virtual ICollection<CourseInstructorOfficeAssignment> OfficeAssignments {
            get
            {
                if (_officeAssignments == null)
                {
                    _officeAssignments = new Collection<CourseInstructorOfficeAssignment>();
                }
                return _officeAssignments;
            }
            set
            {
                _officeAssignments = value;
            }
        }
        ICollection<CourseInstructorOfficeAssignment> _officeAssignments;

        /// <summary>
        /// An Instructor can teach multiple <see cref="Course"/>s.
        /// Or none (*-* relationship).
        /// </summary>
        /// <internal>
        /// Map defined on <see cref="Course"/>.
        /// </internal>
        public virtual ICollection<CourseInstructorAssignment> CourseRoles
        {
            get
            {
                if (_courseRoles == null)
                {
                    _courseRoles = new Collection<CourseInstructorAssignment>();
                }
                return _courseRoles;
            }
            set
            {
                _courseRoles = value;
            }
        }
        ICollection<CourseInstructorAssignment> _courseRoles;
    }
}
