namespace App.Module02.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedTenancySecurityProfileRoleGroup : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Module02.AccountRoleGroups", newName: "TenancySecurityProfileRoleGroups");
            RenameTable(name: "Module02.TenancySecurityProfile__AccountRoleGroup", newName: "TenancySecurityProfile__TenancySecurityProfileRoleGroup");
            RenameTable(name: "Module02.AccountRoleGroup__TenancySecurityProfileAccountRole", newName: "TenancySecurityProfileRoleGroup__TenancySecurityProfileAccountRole");
            RenameIndex(table: "Module02.TenancySecurityProfileRoleGroups", name: "IX_AccountRoleGroup_TenantFK", newName: "IX_TenancySecurityProfileRoleGroup_TenantFK");
            RenameIndex(table: "Module02.TenancySecurityProfileRoleGroups", name: "IX_AccountRoleGroup_RecordState", newName: "IX_TenancySecurityProfileRoleGroup_RecordState");
            RenameIndex(table: "Module02.TenancySecurityProfileRoleGroups", name: "IX_AccountRoleGroup_LastModifiedOnUtc", newName: "IX_TenancySecurityProfileRoleGroup_LastModifiedOnUtc");
            RenameIndex(table: "Module02.TenancySecurityProfileRoleGroups", name: "IX_AccountRoleGroup_LastModifiedByPrincipalId", newName: "IX_TenancySecurityProfileRoleGroup_LastModifiedByPrincipalId");
            RenameIndex(table: "Module02.TenancySecurityProfileRoleGroups", name: "IX_AccountRoleGroup_Title", newName: "IX_TenancySecurityProfileRoleGroup_Title");
        }
        
        public override void Down()
        {
            RenameIndex(table: "Module02.TenancySecurityProfileRoleGroups", name: "IX_TenancySecurityProfileRoleGroup_Title", newName: "IX_AccountRoleGroup_Title");
            RenameIndex(table: "Module02.TenancySecurityProfileRoleGroups", name: "IX_TenancySecurityProfileRoleGroup_LastModifiedByPrincipalId", newName: "IX_AccountRoleGroup_LastModifiedByPrincipalId");
            RenameIndex(table: "Module02.TenancySecurityProfileRoleGroups", name: "IX_TenancySecurityProfileRoleGroup_LastModifiedOnUtc", newName: "IX_AccountRoleGroup_LastModifiedOnUtc");
            RenameIndex(table: "Module02.TenancySecurityProfileRoleGroups", name: "IX_TenancySecurityProfileRoleGroup_RecordState", newName: "IX_AccountRoleGroup_RecordState");
            RenameIndex(table: "Module02.TenancySecurityProfileRoleGroups", name: "IX_TenancySecurityProfileRoleGroup_TenantFK", newName: "IX_AccountRoleGroup_TenantFK");
            RenameTable(name: "Module02.TenancySecurityProfileRoleGroup__TenancySecurityProfileAccountRole", newName: "AccountRoleGroup__TenancySecurityProfileAccountRole");
            RenameTable(name: "Module02.TenancySecurityProfile__TenancySecurityProfileRoleGroup", newName: "TenancySecurityProfile__AccountRoleGroup");
            RenameTable(name: "Module02.TenancySecurityProfileRoleGroups", newName: "AccountRoleGroups");
        }
    }
}
