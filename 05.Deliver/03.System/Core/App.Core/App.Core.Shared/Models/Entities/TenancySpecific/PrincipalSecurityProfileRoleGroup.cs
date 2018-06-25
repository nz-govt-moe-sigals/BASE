namespace App.Core.Shared.Models.Entities.TenancySpecific
{
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    
    public class PrincipalSecurityProfileRoleGroup :TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase , IHasTitle, IHasTitleAndDescription, IHasOptionalParentFK, IHasParent<PrincipalSecurityProfileRoleGroup>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Guid? ParentFK { get; set; }
        public PrincipalSecurityProfileRoleGroup Parent { get; set; }

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

        //TODO: Could get large. Do we want this? Maybe it should only be on Account.
        //public ICollection<Account> Accounts { get; set; } 

    }

}

