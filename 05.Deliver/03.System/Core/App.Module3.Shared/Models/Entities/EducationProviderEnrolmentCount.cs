namespace App.Module3.Shared.Models.Entities
{
    using System;
    using App.Core.Shared.Models.Entities;

    public class EducationProviderEnrolmentCount : TenantFKTimestampedAuditedRecordStatedGuidIdEntityBase, IHasSourceSystemKey
    {

        /// <summary>
        /// Gets or sets the owner school FK.
        /// </summary>
        /// <value>
        /// The school fk.
        /// </value>
        public Guid SchoolFK
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

        /// <summary>
        /// The Reference(record) Id that was received from the source 
        /// </summary>
        public string SourceSystemKey { get; set; }

        public string SourceSystemName { get; set; }
    }
}