namespace App.Module3.Shared.Models.Messages.APIs.V0100
{
    using System;
    using App.Core.Shared.Models;
    using App.Module3.Shared.Models.Entities;

    public class EducationProviderEnrolmentCountDto : IHasGuidId
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
        /// Gets or sets the EducationProfile record's Identifier 
        /// <see cref="EducationProviderDto.Id"/> as FK.
        /// </summary>
        public string EducationProviderFK
        {
            get; set;
        }





        /// <summary>
        /// Gets or sets the Date of the last roll.
        /// </summary>
        /// <value>
        /// The effective date.
        /// </value>
        public DateTime Date
        {
            get; set;
        }

        public int TotalRoll
        {
            get; set;
        }
        public int International
        {
            get; set;
        }
        public int European
        {
            get; set;
        }
        public int Maori
        {
            get; set;
        }
        public int Pasifika
        {
            get; set;
        }
        public int Asian
        {
            get; set;
        }
        public int MELAA
        {
            get; set;
        }
        public int Other
        {
            get; set;
        }

    }
}