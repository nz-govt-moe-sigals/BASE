using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Shared.Models.Entities.Base;

namespace App.Module3.Shared.Models.Entities
{
    public class TenantedFIRSTKeyedGuidIdReferenceDataBase : TenantedGuidIdReferenceDataBase, IHasFIRSTKey
    {
        public string FIRSTKey { get; set; }
    }
}
