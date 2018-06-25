namespace App.Core.Shared.Models.Entities.TenancySpecific
{
    using App.Core.Shared.Models.Entities;
    using System;

    public class PrincipalSecurityProfileRolePrincipalSecurityProfilePermissionAssignment : TenantFKAuditedRecordStatedTimestampedNoIdEntityBase
    {
        public Guid RoleFK { get; set; }
        public PrincipalSecurityProfileRole Role { get; set; }

        public Guid PermissionFK { get; set; }
        public PrincipalSecurityProfilePermission Permission { get; set; }

        public AssignmentType AssignmentType { get; set; }
    }

}

