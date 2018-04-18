using App.Module3.Shared.Models.Messages.Extract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Infrastructure.Initialization.ObjectMaps.Messages.Extract
{
    public class ContractResolverSchoolWGS : BaseMessageContractResolver<SchoolWGS>
    {
        public ContractResolverSchoolWGS() :base()
        {
            AddMap(x => x.WgsId, "WGS_Id");
            AddMap(x => x.InstitutionNumber, "Institution_Number");
            AddMap(x => x.WgsX, "WGS_X");
            AddMap(x => x.WgsY, "WGS_Y");
        }

    }
}
