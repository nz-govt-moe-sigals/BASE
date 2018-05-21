using App.Core.Shared.Models.Entities;
using System;

namespace App.Module01.Shared.Models.Entities
{
    /// <summary>
    /// A Course is an assembly of
    /// * Time slots, 
    /// * Location (Classroom, Gym, Playing Field, Town swimming pool, etc.), 
    /// * General Attendee resources (Hired Bus, School Van, Chairs, Projector, controlling Computer, etc.)
    /// * Specific Attendee resources (Computers for each) (?)
    /// </summary>
    public class CourseResourceAssignment : TenantFKAuditedRecordStatedTimestampedNoIdEntityBase
    {
        // TODO: May need an Id...in order to work with OData. But I think OData can handle Composite Keys.

        //TODO: May need an Id...in order to work with OData.

        public Guid CourseFK { get; set; }
        public Course Course { get; set; }

        public Guid ResourceFK { get; set; }
        public CourseResource Resource { get; set; }


        public string Notes { get; set; }

    }







}
