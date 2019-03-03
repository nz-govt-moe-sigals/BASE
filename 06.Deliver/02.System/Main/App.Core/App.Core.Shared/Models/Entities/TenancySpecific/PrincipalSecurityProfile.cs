using App.Core.Shared.Models;
using App.Core.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Shared.Models.Entities.TenancySpecific
{
    public class PrincipalSecurityProfile : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase, IHasKey
    {

        public bool Enabled { get; set; }

        /// <summary>
        /// The unique key of this user (ie, the UserName).
        /// </summary>
        public string Key { get; set; }


        public ICollection<PrincipalSecurityProfileRoleGroup> AccountGroups
        {
            get
            {
                return _accountGroups ?? (_accountGroups = new Collection<PrincipalSecurityProfileRoleGroup>());
            }
            set
            {
                _accountGroups = value;
            }
        }
        public ICollection<PrincipalSecurityProfileRoleGroup> _accountGroups;


        public ICollection<PrincipalSecurityProfileRole> Roles
        {
            get
            {
                return _roles ?? (_roles = new Collection<PrincipalSecurityProfileRole>());
            }
            set
            {
                _roles = value;
            }
        }
        public ICollection<PrincipalSecurityProfileRole> _roles;


        public ICollection<PrincipalSecurityProfile_Permission_Assignment> PermissionsAssignments
        {
            get
            {
                return _permissionsAssignments ?? (_permissionsAssignments = new Collection<PrincipalSecurityProfile_Permission_Assignment>());
            }
            set
            {
                _permissionsAssignments = value;
            }
        }
        public ICollection<PrincipalSecurityProfile_Permission_Assignment> _permissionsAssignments;



    }
}
