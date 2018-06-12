namespace App.Module02.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedTenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Module02.AccountRoleAccountPermissionAssignments", newName: "TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments");
            RenameIndex(table: "Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", name: "IX_AccountRoleAccountPermissionAssignment_RecordState", newName: "IX_TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment_RecordState");
            RenameIndex(table: "Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", name: "IX_AccountRoleAccountPermissionAssignment_LastModifiedOnUtc", newName: "IX_TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment_LastModifiedOnUtc");
            RenameIndex(table: "Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", name: "IX_AccountRoleAccountPermissionAssignment_LastModifiedByPrincipalId", newName: "IX_TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment_LastModifiedByPrincipalId");
            RenameIndex(table: "Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", name: "IX_AccountRoleAccountPermissionAssignment_TenantFK", newName: "IX_TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment_TenantFK");
        }
        
        public override void Down()
        {
            RenameIndex(table: "Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", name: "IX_TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment_TenantFK", newName: "IX_AccountRoleAccountPermissionAssignment_TenantFK");
            RenameIndex(table: "Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", name: "IX_TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment_LastModifiedByPrincipalId", newName: "IX_AccountRoleAccountPermissionAssignment_LastModifiedByPrincipalId");
            RenameIndex(table: "Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", name: "IX_TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment_LastModifiedOnUtc", newName: "IX_AccountRoleAccountPermissionAssignment_LastModifiedOnUtc");
            RenameIndex(table: "Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", name: "IX_TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment_RecordState", newName: "IX_AccountRoleAccountPermissionAssignment_RecordState");
            RenameTable(name: "Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", newName: "AccountRoleAccountPermissionAssignments");
        }
    }
}
