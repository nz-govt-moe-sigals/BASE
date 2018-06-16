namespace App.Core.Shared.Models.Entities.TenancySpecific
{
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;

    public class PrincipalSecurityProfilePermission : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase, IHasTitleAndDescription
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

}

