using App.Module3.Shared.Models.Messages.Extract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Infrastructure.Initialization.ObjectMaps.Messages.Extract
{
    public class ContractResolverSchoolLevelGender : BaseMessageContractResolver<SchoolLevelGender>
    {

        public ContractResolverSchoolLevelGender() : base()
        {
            AddMap(x => x.LevelGenderId, "Level_Gender_Id");
            AddMap(x => x.SchoolId, "School_Id");
            AddMap(x => x.YearValueId, "YearValue_ID");
            AddMap(x => x.GenderValueId, "GenderValue_ID");
        }



    }
}
