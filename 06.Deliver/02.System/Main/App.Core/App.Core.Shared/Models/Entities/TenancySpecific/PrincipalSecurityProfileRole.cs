namespace App.Core.Shared.Models.Entities.TenancySpecific
{
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class PrincipalSecurityProfileRole : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase, IHasTitleAndDescription
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<PrincipalSecurityProfilePermission> Permissions { get
            {
                return _permissions ?? (_permissions = new Collection<PrincipalSecurityProfilePermission>());
            }
            set
            {
                _permissions = value;
            }
        }
        public ICollection<PrincipalSecurityProfilePermission> _permissions;



        public ICollection<PrincipalSecurityProfileRolePrincipalSecurityProfilePermissionAssignment> PermissionsAssignments
        {
            get
            {
                return _permissionsAssignments ?? (_permissionsAssignments = new Collection<PrincipalSecurityProfileRolePrincipalSecurityProfilePermissionAssignment>());
            }
            set
            {
                _permissionsAssignments = value;
            }
        }
        public ICollection<PrincipalSecurityProfileRolePrincipalSecurityProfilePermissionAssignment> _permissionsAssignments;

    }

}

