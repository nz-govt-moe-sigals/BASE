//namespace App.Module3.Shared.Models.Messages.APIs.V0100
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Collections.ObjectModel;
//    using App.Module3.Shared.Models.Entities;
//    using App.Module3.Shared.Models.Messages.V0100;

//    public class EducationProviderLevelGenderDto 
//    {
//        //public Guid Id
//        //{
//        //    get;
//        //    set;
//        //}
        

//            /// <summary>
//            /// Gets or sets the parent <see cref="EducationProviderProfile"/>'s Id.
//            /// </summary>
//            public string SchoolProfileCode
//        {
//            get; set;
//        }


//        public string GenderCode
//        {
//            get; set;
//        }
//        public virtual ICollection<EducationProviderGenderDto> Gender
//        {
//            get
//            {
//                return this._genders ?? (this._genders = new Collection<EducationProviderGenderDto>());
//            }
//        }
//        private ICollection<EducationProviderGenderDto> _genders;


//        public int YearFK
//        {
//            get; set;
//        }
//        public virtual ICollection<EducationProviderYearLevelDto> Year
//        {
//            get
//            {
//                return this._schoolYear ?? (this._schoolYear = new Collection<EducationProviderYearLevelDto>());
//            }
//            //set => this._schoolYear = value;
//        }
//        private ICollection<EducationProviderYearLevelDto> _schoolYear;



//    }
//}