using App.Core.Shared.Models.Entities;
using System;
using System.Collections.Generic;

namespace App.Module1.Shared.Models.Entities
{
    public class CourseOccurance : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase
    {
        /// <summary>
        /// Owner <see cref="Course"/>
        /// </summary>
        public Guid OwnerFK { get; set; }
        public Course Course {get;set;}


        /// <summary>
        /// When this <see cref="CourseOccurance"/> occurs.
        /// </summary>
        public virtual DateTimeOffset When { get; set; }

        public virtual TimeSpan Duration { get; set; }

        public virtual string Notes { get; set; }

        ///// <summary>
        ///// The <see cref="CourseResource"/>s required by this <see cref="Course"/>.
        ///// </summary>
        //public virtual ICollection<CourseResource> Resource { get; set; }

    }




}
