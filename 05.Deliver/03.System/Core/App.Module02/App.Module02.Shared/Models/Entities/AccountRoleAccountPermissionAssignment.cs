namespace App.Module02.Shared.Models.Entities
{
    using App.Core.Shared.Models.Entities;
    using System;

    public class AccountRoleAccountPermissionAssignment : TenantFKAuditedRecordStatedTimestampedNoIdEntityBase
    {
        public Guid RoleFK { get; set; }
        public AccountRole Role { get; set; }

        public Guid PermissionFK { get; set; }
        public AccountPermission Permission { get; set; }

        public AssignmentType AssignmentType { get; set; }
    }

}

