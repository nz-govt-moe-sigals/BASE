

namespace App.Module3.Shared.Models.Entities
{
    using App.Core.Shared.Models.Entities.Base;

    public class TenantedFIRSTSIFKeyedGuidIdReferenceDataBase : TenantedGuidIdReferenceDataBase, IHasFIRSTKey, IHasSIFKey
    {
        public string FIRSTKey {get; set;}

        public int SIFKey { get; set; }
    }
}
