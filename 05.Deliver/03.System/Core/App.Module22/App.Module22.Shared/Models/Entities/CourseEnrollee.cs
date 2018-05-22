using App.Core.Shared.Models;
using App.Core.Shared.Models.Entities;
using System;
using System.Collections.Generic;


namespace App.Module22.Shared.Models.Entities
{

    /// <summary>
    /// A Student.
    /// <para>
    /// A Student can enroll for zero or more <see cref="Course"/>s.
    /// </para>
    /// </summary>
    public class CourseEnrollee: TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase, IHasKey
    {

        /// <summary>
        /// The primary business domain identifier of the Student.
        /// TODO: Move down to be a dynamic wrap around a Property.
        /// </summary>
        public virtual string Key { get; set; }

        /// <summary>
        /// Name of Student (till we get aliases, properties, etc. associated)
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// When did or will the student enroll with the organisation.
        /// <para>
        /// Note that students can arrive in mid-terms.
        /// </para>
        /// </summary>
        public DateTimeOffset Begin { get; set; }

        /// <summary>
        /// When did or will the student leave the organisation.
        /// <para>
        /// Note that students can leave in mid-terms.
        /// </para>
        /// </summary>
        public DateTimeOffset? End { get; set; }



        /// <summary>
        /// The collection of 0 or more courses enrollments associated to the 
        /// <see cref="CourseEnrollee"/>.
        /// </summary>
        public ICollection<CourseEnrollment> Enrollments { get; set; }
    }
}


