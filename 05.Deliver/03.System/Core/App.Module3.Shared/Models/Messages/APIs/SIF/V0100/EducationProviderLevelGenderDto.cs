namespace App.Module3.Shared.Models.Messages.APIs.SIF.V0100
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using App.Module3.Shared.Models.Entities;

    public class EducationProviderLevelGenderDto
    {

        public virtual EducationProviderSchoolingGenderDto Gender
        {
            get;
            set;
        }


        public virtual EducationProviderYearLevelDto Level
        {
            get;
            set;
        }



    }
}