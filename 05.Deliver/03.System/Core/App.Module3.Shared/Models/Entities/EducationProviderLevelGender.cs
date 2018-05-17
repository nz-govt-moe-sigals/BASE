using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Shared.Models.Entities
{
    using System.Collections.ObjectModel;
    using App.Core.Shared.Models.Entities;

    public class EducationProviderLevelGender : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase, IHasSourceSystemKey
    {
        /// <summary>
        /// Gets or sets the parent <see cref="EducationProviderProfile"/>'s Id.
        /// </summary>
        public Guid EducationProviderFK
        {
            get; set;
        }


        public Guid GenderFK
        {
            get; set;
        }

        public virtual EducationProviderGender Gender { get; set; }


        public Guid YearFK
        {
            get; set;
        }
        public virtual EducationProviderYearLevel Level { get; set; }

        /// <summary>
        /// The Reference(record) Id that was received from the source 
        /// </summary>
        public string SourceSystemKey { get; set; }

        public string SourceSystemName { get; set; }

    }
}
