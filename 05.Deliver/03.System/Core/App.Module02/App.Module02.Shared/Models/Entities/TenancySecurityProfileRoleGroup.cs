namespace App.Module02.Shared.Models.Entities
{
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    
    public class TenancySecurityProfileRoleGroup :TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase , IHasTitle, IHasTitleAndDescription, IHasOptionalParentFK, IHasParent<TenancySecurityProfileRoleGroup>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Guid? ParentFK { get; set; }
        public TenancySecurityProfileRoleGroup Parent { get; set; }

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

        //TODO: Could get large. Do we want this? Maybe it should only be on Account.
        //public ICollection<Account> Accounts { get; set; } 

    }

}

