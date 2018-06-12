namespace App.Module02.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedTenancySecurityProfileTenancySecurityProfilePermissionAssignment : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Module02.AccountAccountPermissionAssignments", newName: "TenancySecurityProfileTenancySecurityProfilePermissionAssignments");
            RenameIndex(table: "Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", name: "IX_AccountAccountPermissionAssignment_RecordState", newName: "IX_TenancySecurityProfileTenancySecurityProfilePermissionAssignment_RecordState");
            RenameIndex(table: "Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", name: "IX_AccountAccountPermissionAssignment_LastModifiedOnUtc", newName: "IX_TenancySecurityProfileTenancySecurityProfilePermissionAssignment_LastModifiedOnUtc");
            RenameIndex(table: "Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", name: "IX_AccountAccountPermissionAssignment_LastModifiedByPrincipalId", newName: "IX_TenancySecurityProfileTenancySecurityProfilePermissionAssignment_LastModifiedByPrincipalId");
            RenameIndex(table: "Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", name: "IX_AccountAccountPermissionAssignment_TenantFK", newName: "IX_TenancySecurityProfileTenancySecurityProfilePermissionAssignment_TenantFK");
        }
        
        public override void Down()
        {
            RenameIndex(table: "Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", name: "IX_TenancySecurityProfileTenancySecurityProfilePermissionAssignment_TenantFK", newName: "IX_AccountAccountPermissionAssignment_TenantFK");
            RenameIndex(table: "Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", name: "IX_TenancySecurityProfileTenancySecurityProfilePermissionAssignment_LastModifiedByPrincipalId", newName: "IX_AccountAccountPermissionAssignment_LastModifiedByPrincipalId");
            RenameIndex(table: "Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", name: "IX_TenancySecurityProfileTenancySecurityProfilePermissionAssignment_LastModifiedOnUtc", newName: "IX_AccountAccountPermissionAssignment_LastModifiedOnUtc");
            RenameIndex(table: "Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", name: "IX_TenancySecurityProfileTenancySecurityProfilePermissionAssignment_RecordState", newName: "IX_AccountAccountPermissionAssignment_RecordState");
            RenameTable(name: "Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", newName: "AccountAccountPermissionAssignments");
        }
    }
}
