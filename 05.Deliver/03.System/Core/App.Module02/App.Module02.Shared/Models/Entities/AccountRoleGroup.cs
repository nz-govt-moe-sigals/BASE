namespace App.Module02.Shared.Models.Entities
{
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class AccountRoleGroup :TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase , IHasTitle, IHasTitleAndDescription, IHasParentFK, IHasParent<AccountRoleGroup>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Guid? ParentFK { get; set; }
        public AccountRoleGroup Parent { get; set; }

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

        //TODO: Could get large. Do we want this? Maybe it should only be on Account.
        //public ICollection<Account> Accounts { get; set; } 

    }

}

