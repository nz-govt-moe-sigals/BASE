using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Shared.Models.Entities
{
    using System.Collections.ObjectModel;
    using App.Core.Shared.Models.Entities;

    public class EducationProviderLevelGender : TenantFKTimestampedAuditedRecordStatedGuidIdEntityBase
    {
        /// <summary>
        /// Gets or sets the parent <see cref="EducationProviderProfile"/>'s Id.
        /// </summary>
        public int SchoolProfileFK
        {
            get; set;
        }


        public Guid GenderFK
        {
            get; set;
        }
        public virtual ICollection<EducationProviderGender> Gender
        {
            get { return this._genders ?? (this._genders = new Collection<EducationProviderGender>()); }
            //set => this._genders = value;
        }
        private ICollection<EducationProviderGender> _genders;


        public Guid YearFK
        {
            get; set;
        }
        public virtual ICollection<EducationProviderYearLevel> Year
        {
            get { return this._schoolYear ?? (this._schoolYear = new Collection<EducationProviderYearLevel>()); }
            //set => this._schoolYear = value;
        }
        private ICollection<EducationProviderYearLevel> _schoolYear;

    }
}
