namespace App.Core.Shared.Models.Entities.TenancySpecific
{
    using App.Core.Shared.Models.Entities;
    using System;

    public class PrincipalSecurityProfile_Permission_Assignment : TenantFKAuditedRecordStatedTimestampedNoIdEntityBase
    {
        public Guid AccountFK { get; set; }
        public PrincipalSecurityProfile Account { get; set; }

        public Guid PermissionFK { get; set; }
        public PrincipalSecurityProfilePermission Permission { get; set; }

        /// <summary>
        /// Whether the Assignment is additive, or subtractive
        /// (an Account can be added to Groups to which Roles have been assigned,
        /// or assigned directly to Roles,
        /// and can be assigned Permissions that remove Permissions assigned by 
        /// one of the previous two methods.
        /// </summary>
        public AssignmentType AssignmentType { get; set; }
    }

}

