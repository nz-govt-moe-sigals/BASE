using App.Core.Shared.Models;
using App.Core.Shared.Models.Entities;
using App.Module1.Shared.Models.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace App.Module1.Shared.Models.Entities
{

    /// <summary>
    /// A <see cref="CourseDepartment"/>
    /// has a budget to provide 0 or more <see cref="Course"/>s.
    /// It has Members assigned by Roles (Administrator, etc).
    /// </summary>
    public class CourseDepartment : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase, IHasTitle, IHasDescription
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

        /// <summary>
        /// The unique Key for the Department.
        /// </summary>
        public virtual string Key { get; set; }

        /// <summary>
        /// The displayable Title of the Department.
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// The displayable description of the Department.
        /// </summary>
        public virtual string Description { get; set; }

        public virtual decimal Budget { get; set; }



        /// <summary>
        /// THe collection of courses offered by this <see cref="CourseDepartment"/>.
        /// </summary>
        /// Map defined on <see cref="Courses"/>
        public ICollection<Course> Courses {
            get
            {
                if (_courses == null) { _courses = new Collection<Course>(); }
                return _courses; 
            }
        }
        ICollection<Course> _courses;
    }




}
