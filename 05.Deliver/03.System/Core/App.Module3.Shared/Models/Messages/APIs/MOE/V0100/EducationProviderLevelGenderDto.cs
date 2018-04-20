namespace App.Module3.Shared.Models.Messages.APIs.MOE.V0100
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using App.Module3.Shared.Models.Entities;

    public class EducationProviderLevelGenderDto
    {
        //public Guid Id
        //{
        //    get;
        //    set;
        //}


        /// <summary>
        /// Gets or sets the parent <see cref="EducationProviderProfile"/>'s Id.
        /// </summary>
        public string EducationProviderFK
        {
            get; set;
        }


        public string GenderCode
        {
            get; set;
        }
        public virtual ICollection<EducationProviderGenderDto> Gender
        {
            get;
            set;
        }


        public int LevelFK
        {
            get; set;
        }
        public virtual ICollection<EducationProviderYearLevelDto> Level
        {
            get;
            set;
        }



    }
}