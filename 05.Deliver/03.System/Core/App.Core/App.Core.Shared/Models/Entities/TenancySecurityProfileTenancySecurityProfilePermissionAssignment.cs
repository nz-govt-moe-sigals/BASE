namespace App.Core.Shared.Models.Entities
{
    using App.Core.Shared.Models.Entities;
    using System;

    public class TenancySecurityProfileTenancySecurityProfilePermissionAssignment : TenantFKAuditedRecordStatedTimestampedNoIdEntityBase
    {
        public Guid AccountFK { get; set; }
        public TenancySecurityProfile Account { get; set; }

        public Guid PermissionFK { get; set; }
        public TenancySecurityProfilePermission Permission { get; set; }

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

