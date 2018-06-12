namespace App.Module02.Shared.Models.Entities
{
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class TenancySecurityProfileAccountRole : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase, IHasTitleAndDescription
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<TenancySecurityProfilePermission> Permissions { get
            {
                return _permissions ?? (_permissions = new Collection<TenancySecurityProfilePermission>());
            }
            set
            {
                _permissions = value;
            }
        }
        public ICollection<TenancySecurityProfilePermission> _permissions;



        public ICollection<TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment> PermissionsAssignments
        {
            get
            {
                return _permissionsAssignments ?? (_permissionsAssignments = new Collection<TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment>());
            }
            set
            {
                _permissionsAssignments = value;
            }
        }
        public ICollection<TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment> _permissionsAssignments;

    }

}

