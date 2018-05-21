namespace App.Module11.Shared.Models.Messages.APIs.SIF.V0100
{
    using System;
    using App.Core.Shared.Models;
    using App.Module11.Shared.Models.Enums;

    public class EducationProviderLocationDto : IHasGuidId
    {

        /// <summary>
        /// Gets or sets the identifier of this record.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id
        {
            get; set;
        }


        /// <summary>
        /// Gets or sets the EducationProfile record's Identifier <see cref="EducationProviderDto.Id"/> as FK.
        /// </summary>
        public string EducationProviderFK
        {
            get; set;
        }


        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public virtual LocationType Type
        {
            get; set;
        }

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
