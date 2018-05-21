using App.Core.Shared.Models.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace App.Module01.Shared.Models.Entities
{

    /// <summary>
    /// An Office can only be assigned to a <see cref="CourseInstructor"/>
    /// </summary>
    public class CourseInstructorOffice: TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase
    {

        /// <summary>
        /// The displayable key for the Office (eg: "SI-103")
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// A customizable description of the Office. 
        /// Possibly describing access times and where to find it.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// An Office can be assigned to one or more <see cref="CourseInstructor"/>s
        /// at different times.
        /// </summary>
        public virtual ICollection<CourseInstructorOfficeAssignment> OfficeAssignments
        {
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



    }
}
