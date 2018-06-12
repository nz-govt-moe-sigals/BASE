using App.Core.Shared.Models;
using App.Core.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module02.Shared.Models.Entities
{
    public class TenancySecurityProfile : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase, IHasKey
    {

        public bool Enabled { get; set; }

        /// <summary>
        /// The unique key of this user (ie, the UserName).
        /// </summary>
        public string Key { get; set; }


        public ICollection<TenancySecurityProfileRoleGroup> AccountGroups
        {
            get
            {
                return _accountGroups ?? (_accountGroups = new Collection<TenancySecurityProfileRoleGroup>());
            }
            set
            {
                _accountGroups = value;
            }
        }
        public ICollection<TenancySecurityProfileRoleGroup> _accountGroups;


        public ICollection<TenancySecurityProfileAccountRole> Roles
        {
            get
            {
                return _roles ?? (_roles = new Collection<TenancySecurityProfileAccountRole>());
            }
            set
            {
                _roles = value;
            }
        }
        public ICollection<TenancySecurityProfileAccountRole> _roles;


        public ICollection<TenancySecurityProfileTenancySecurityProfilePermissionAssignment> PermissionsAssignments
        {
            get
            {
                return _permissionsAssignments ?? (_permissionsAssignments = new Collection<TenancySecurityProfileTenancySecurityProfilePermissionAssignment>());
            }
            set
            {
                _permissionsAssignments = value;
            }
        }
        public ICollection<TenancySecurityProfileTenancySecurityProfilePermissionAssignment> _permissionsAssignments;



    }
}
