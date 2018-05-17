using App.Core.Shared.Models;
using App.Core.Shared.Models.Entities;
using App.Module1.Shared.Models.Entities.Enums;
using System;

namespace App.Module1.Shared.Models.Entities
{
    /// <summary>
    /// A single student's enrollment of a course.
    /// A <see cref="Course"/> has a 1-* relationship
    /// to <see cref="CourseEnrollment"/>
    /// </summary>
    public class CourseEnrollment : TenantFKAuditedRecordStatedTimestampedNoIdEntityBase
    {

        /// <summary>
        /// The FK to 
        /// the <see cref="CourseEnrollment"/>'s <see cref="CourseStatus"/>.
        /// </summary>
        public virtual CourseStatusType StatusFK { get; set; }
        /// <summary>
        /// The <see cref="CourseEnrollment"/>'s <see cref="CourseStatus"/>.
        /// </summary>
        public virtual CourseStatus Status { get; set; }

        /// <summary>
        /// Navigation property to the owning <see cref="Course"/>.
        /// </summary>
        public virtual Guid CourseFK { get; set; }
        public virtual Course Course { get; set; }


        public virtual Guid EnrolleeFK { get; set; }
        /// <summary>
        /// Navigation property to Enrollee <see cref="Enrollee"/>.
        /// Enrolled.
        /// </summary>
        public virtual CourseEnrollee Enrollee { get; set; }


        /// <summary>
        /// Note regarding the <see cref="CourseEnrollee"/>
        /// participation in this <see cref="Course"/>.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// The FK to 
        /// the <see cref="Grade"/>'s <see cref="CourseStatus"/>.
        /// </summary>
        public virtual Guid GradeFK { get; set; }

        /// <summary>
        /// The Enrollee's optional current <see cref="Grade"/>.
        /// </summary>
        public virtual CourseGrade Grade { get; set; }

        /// <summary>
        /// Additional notes about the circumstances of the 
        /// <see cref="CourseGrade"/> given.
        /// </summary>
        public string GradeComment { get; set; }

    }




}
