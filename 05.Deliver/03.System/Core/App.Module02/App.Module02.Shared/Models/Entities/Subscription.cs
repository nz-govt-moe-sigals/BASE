namespace App.Module02.Shared.Models.Entities
{
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;
    using System;
    using System.Collections.Generic;


    public enum AssignmentType
    {
        Undefined = 0,
        //Unknown = 1,
        //Unspecified = 2,
        Assigned = 3,
        Denied = 4
    }

    public class Subscription : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase
    {

    }



    public class AccountGroup :TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase , IHasTitle, IHasTitleAndDescription, IHasParentFK, IHasParent<AccountGroup>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Guid? ParentFK { get; set; }
        public AccountGroup Parent { get; set; }

        //TODO: Could get large. Do we want this? Maybe it should only be on Account.
        public ICollection<Account> Accounts { get; set; } 

    }

    public class AccountGroupRoleAssignment : TenantFKAuditedRecordStatedTimestampedNoIdEntityBase {
        public Guid AccountGroupFK { get; set; }
        public AccountGroup AccountGroup {get;set;}

        public Guid RoleFK { get; set; }
        public Role Role { get; set; }
    }

    public class Role : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase {
        public string Title { get; set; }
        public string Description { get; set; }
    }


    public class RolePermissionAssignment : TenantFKAuditedRecordStatedTimestampedNoIdEntityBase
    {
        public Guid RoleFK { get; set; }
        public Role Role { get; set; }

        public Guid PermissionFK { get; set; }
        public Permission Permission { get; set; }

        //Not sure it should be here: public AssignmentType AssignmentType { get; set; }
    }

    public class Permission : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }


    public class AccountRoleAssignment : TenantFKAuditedRecordStatedTimestampedNoIdEntityBase
    {
        public Guid AccountFK { get; set; }
        public Account Account { get; set; }

        public Guid RoleFK { get; set; }
        public Role Role { get; set; }

        public AssignmentType AssignmentType { get; set; }
    }


    public class AccountPermissionAssignment : TenantFKAuditedRecordStatedTimestampedNoIdEntityBase
    {
        public Guid AccountFK { get; set; }
        public Account Account { get; set; }

        public Guid PermissionFK { get; set; }
        public Permission Permission { get; set; }

        public AssignmentType AssignmentType { get; set; }
    }

}

