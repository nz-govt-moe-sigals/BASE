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
    public class Account : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase, IHasKey
    {

        public bool Enabled { get; set; }

        /// <summary>
        /// The unique key of this user (ie, the UserName).
        /// </summary>
        public string Key { get; set; }


        public ICollection<AccountRoleGroup> AccountGroups
        {
            get
            {
                return _accountGroups ?? (_accountGroups = new Collection<AccountRoleGroup>());
            }
            set
            {
                _accountGroups = value;
            }
        }
        public ICollection<AccountRoleGroup> _accountGroups;


        public ICollection<AccountRole> Roles
        {
            get
            {
                return _roles ?? (_roles = new Collection<AccountRole>());
            }
            set
            {
                _roles = value;
            }
        }
        public ICollection<AccountRole> _roles;


        public ICollection<AccountAccountPermissionAssignment> PermissionsAssignments
        {
            get
            {
                return _permissionsAssignments ?? (_permissionsAssignments = new Collection<AccountAccountPermissionAssignment>());
            }
            set
            {
                _permissionsAssignments = value;
            }
        }
        public ICollection<AccountAccountPermissionAssignment> _permissionsAssignments;



    }
}
