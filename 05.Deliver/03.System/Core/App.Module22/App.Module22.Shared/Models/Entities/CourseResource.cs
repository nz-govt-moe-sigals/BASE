using App.Core.Shared.Models.Entities;
using App.Module22.Shared.Models.Entities.Enums;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace App.Module22.Shared.Models.Entities
{

    /// <summary>
    /// A Resource needed to teach <see cref="Course"/>s.
    /// * Time slots, 
    /// * Location (Classroom, Gym, Playing Field, Town swimming pool, etc.), 
    /// * General Attendee resources (Hired Bus, School Van, Chairs, Projector, controlling Computer, etc.)
    /// * Specific Attendee resources (Computers for each) (?)
    /// </summary>
    public class CourseResource : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase
    {

        /// <summary>
        /// The required unique key for the Resource.
        /// <para>
        /// TODO: Maybe not necessary.
        /// </para>
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The required displayable Title of the Resource.
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// The optional displayable Description of the Resource.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The required FK of 
        /// the Status of this <see cref="CourseResource"/>
        /// </summary>
        public virtual CourseStatusType StatusFK { get; set; }

        /// <summary>
        /// The required Navigation property to
        /// the Status of this <see cref="CourseResource"/>
        /// </summary>
        public virtual CourseStatus Status { get; set; }

        /// <summary>
        /// The required FK to
        /// the <see cref="CourseResourceType"/>.
        /// <para>
        /// A Resource may be a Time slot, Location, etc.
        /// </para>
        /// </summary>
        public virtual CourseResourceEnumType TypeFK { get; set; }

        /// <summary>
        /// The required Navigation property to
        /// the <see cref="CourseResourceType"/>.
        /// <para>
        /// A Resource may be a Time slot, Location, etc.
        /// </para>
        /// </summary>
        public virtual CourseResourceType Type { get; set; }



        public virtual ICollection<CourseResourceAssignment> ResourceAssignments
        {
            get
            {
                if (_courseResourceAssignment == null) { _courseResourceAssignment = new Collection<CourseResourceAssignment>(); }
                return _courseResourceAssignment;
            }
            set
            {
                _courseResourceAssignment = value;
            }
        }
        ICollection<CourseResourceAssignment> _courseResourceAssignment;

    }
}


