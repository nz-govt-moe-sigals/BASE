namespace App.Module02.Shared.Models.Entities
{
    using App.Core.Shared.Models.Entities;
    using System;

    public class TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment : TenantFKAuditedRecordStatedTimestampedNoIdEntityBase
    {
        public Guid RoleFK { get; set; }
        public TenancySecurityProfileAccountRole Role { get; set; }

        public Guid PermissionFK { get; set; }
        public TenancySecurityProfilePermission Permission { get; set; }

        public AssignmentType AssignmentType { get; set; }
    }

}

