using App.Core.Shared.Models;
using App.Core.Shared.Models.Entities;
using App.Module22.Shared.Models.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace App.Module22.Shared.Models.Entities
{
    /// <summary>
    /// Course: A series of lectures or lessons  (see <see cref="CourseOccurance"/>) 
    /// in a particular subject, 
    /// leading to an examination or qualification.
    /// <para>
    /// </para>
    /// A <see cref="Course"/> can be enrolled by
    /// 0 or many <see cref="CourseEnrollee"/> Enrollees.
    /// (ie, has 1-* with <see cref="CourseEnrollment"/>). 
    /// </summary>
    public class Course : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase, IHasKey, IHasTitle, IHasDescription
    {
        /// <summary>
        /// The FK of 
        /// the Status of this <see cref="CourseResource"/>
        /// </summary>
        public virtual CourseStatusType StatusFK { get; set; }
        /// <summary>
        /// The Status of this <see cref="CourseResource"/>
        /// </summary>
        public virtual CourseStatus Status { get; set; }



        public virtual string Key { get; set; }
        /// <summary>
        /// The displayable name of the course.
        /// </summary>
        public virtual string Title { get; set; }
        /// <summary>
        /// The displayable description of the course.
        /// </summary>
        public virtual string Description { get; set; }



        /// <summary>
        /// The FK of 
        /// the Department providing this <see cref="Course"/>
        /// </summary>
        public virtual Guid DepartmentFK { get; set; }
        /// <summary>
        /// The Department providing this <see cref="Course"/>
        /// </summary>
        public virtual CourseDepartment Department { get; set; }



        /// <summary>
        /// The 1 or more <see cref="CourseCredit"/>s that can be assigned 
        /// to a <see cref="CourseEnrollee"/>
        /// Course Attendee.
        /// <para>
        /// Credits are not the same as Grade.
        /// </para>
        /// <para>
        /// Credits can be allocated to <see cref="CourseEnrollment"/>s 
        /// in whole or in part.
        /// </para>
        /// </summary>
        public int Credits { get; set; }



        /// <summary>
        /// The collection of 1 or more <see cref="CourseInstructorAssignment"/>s
        /// that teach this <see cref="Course"/>.
        /// </summary>
        /// <internal>
        /// https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-a-more-complex-data-model-for-an-asp-net-mvc-application
        /// </internal>
        public virtual ICollection<CourseInstructorAssignment> InstructorRoles {
            get
            {
                if (_instructorRoles == null) { _instructorRoles = new Collection<CourseInstructorAssignment>(); }
                return _instructorRoles;
            }
            set
            {
                _instructorRoles = value;
            }
        }
        ICollection<CourseInstructorAssignment> _instructorRoles;



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



        public virtual ICollection<CourseOccurance> Occurances
        {
            get
            {
                if (_courseOccurance == null) { _courseOccurance = new Collection<CourseOccurance>(); }
                return _courseOccurance;
            }
            set
            {
                _courseOccurance = value;
            }
        }
        ICollection<CourseOccurance> _courseOccurance;



        /// <summary>
        /// Collection of 0 or more enrollments to the <see cref="Course"/>.
        /// </summary>
        public virtual ICollection<CourseEnrollment> Enrollments
        {
            get
            {
                if (_courseEnrollments == null) { _courseEnrollments = new Collection<CourseEnrollment>(); }
                return _courseEnrollments;
            }
            set
            {
                _courseEnrollments = value;
            }
        }
        ICollection<CourseEnrollment> _courseEnrollments;

    }

}


