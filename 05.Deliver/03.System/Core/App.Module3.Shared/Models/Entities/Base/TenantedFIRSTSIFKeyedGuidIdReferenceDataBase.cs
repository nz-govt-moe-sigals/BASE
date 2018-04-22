

namespace App.Module3.Shared.Models.Entities
{
    using App.Core.Shared.Models.Entities.Base;

    public class TenantedFIRSTSIFKeyedGuidIdReferenceDataBase : TenantedFIRSTKeyedGuidIdReferenceDataBase,  IHasSIFKey
    {
       
        public int SIFKey { get; set; }
    }
}
