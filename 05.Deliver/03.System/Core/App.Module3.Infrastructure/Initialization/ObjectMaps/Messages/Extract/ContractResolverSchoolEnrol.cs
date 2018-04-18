using App.Module3.Shared.Models.Messages.Extract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Infrastructure.Initialization.ObjectMaps.Messages.Extract
{
    public class ContractResolverSchoolEnrol : BaseMessageContractResolver<SchoolEnrol>
    {
        public ContractResolverSchoolEnrol() : base()
        {
            AddMap(x => x.EnrolId, "Enrol_Id");
            AddMap(x => x.SchoolId, "School_Id");
            AddMap(x => x.EffectiveDate, "Effective_Date");
            AddMap(x => x.International, "International");
            AddMap(x => x.European);
            AddMap(x => x.Maori);
            AddMap(x => x.Pasifika);
            AddMap(x => x.Asian);
            AddMap(x => x.Melaa);
            AddMap(x => x.Other);
        }


    }
}
