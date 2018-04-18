namespace App.Module3.Shared.Models.Entities
{
    using System;
    using App.Core.Shared.Models.Entities;
    using App.Module3.Shared.Models.Enums;

    public class EducationProviderLocation : TenantFKTimestampedAuditedRecordStatedGuidIdEntityBase
    {

        public Guid EducationProviderFK { get; set; }

        public virtual LocationType Type
        {
            get; set;
        }
        //public virtual Guid OwnerFK { get; set; }        
        /// <summary>
        /// Gets or sets the latitude (the 0 to 90 North or South).
        /// </summary>
        public virtual decimal Latitude
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the longitude (the 0 to +/-180).
        /// </summary>
        public virtual decimal Longitude
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the altitude.
        /// </summary>
        public virtual decimal? Altitude
        {
            get; set;
        }


    }
}