using App.Core.Shared.Models;

namespace App.Module3.Shared.Models.Messages.APIs.SIF.V0100
{

    public class EducationProviderLevelGenderDto
    {

        public Guid Id
        {
            get; set;
        }

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