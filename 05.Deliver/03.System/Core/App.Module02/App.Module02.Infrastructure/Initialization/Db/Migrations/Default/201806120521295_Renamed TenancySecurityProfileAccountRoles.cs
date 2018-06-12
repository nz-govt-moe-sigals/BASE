namespace App.Module02.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedTenancySecurityProfileAccountRoles : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Module02.Accounts", newName: "TenancySecurityProfiles");
            RenameTable(name: "Module02.AccountRoles", newName: "TenancySecurityProfileAccountRoles");
            RenameTable(name: "Module02.AccountRoleGroup__AccountRole", newName: "AccountRoleGroup__TenancySecurityProfileAccountRole");
            RenameTable(name: "Module02.Account__AccountRoleGroup", newName: "TenancySecurityProfile__AccountRoleGroup");
            RenameTable(name: "Module02.Account__AccountRole", newName: "TenancySecurityProfile__TenancySecurityProfileAccountRole");
            RenameTable(name: "Module02.AccountRole__TenancySecurityProfilePermission", newName: "TenancySecurityProfileAccountRole__TenancySecurityProfilePermission");
            RenameIndex(table: "Module02.TenancySecurityProfiles", name: "IX_Account_TenantFK", newName: "IX_TenancySecurityProfile_TenantFK");
            RenameIndex(table: "Module02.TenancySecurityProfiles", name: "IX_Account_RecordState", newName: "IX_TenancySecurityProfile_RecordState");
            RenameIndex(table: "Module02.TenancySecurityProfiles", name: "IX_Account_LastModifiedOnUtc", newName: "IX_TenancySecurityProfile_LastModifiedOnUtc");
            RenameIndex(table: "Module02.TenancySecurityProfiles", name: "IX_Account_LastModifiedByPrincipalId", newName: "IX_TenancySecurityProfile_LastModifiedByPrincipalId");
            RenameIndex(table: "Module02.TenancySecurityProfileAccountRoles", name: "IX_AccountRole_TenantFK", newName: "IX_TenancySecurityProfileAccountRole_TenantFK");
            RenameIndex(table: "Module02.TenancySecurityProfileAccountRoles", name: "IX_AccountRole_RecordState", newName: "IX_TenancySecurityProfileAccountRole_RecordState");
            RenameIndex(table: "Module02.TenancySecurityProfileAccountRoles", name: "IX_AccountRole_LastModifiedOnUtc", newName: "IX_TenancySecurityProfileAccountRole_LastModifiedOnUtc");
            RenameIndex(table: "Module02.TenancySecurityProfileAccountRoles", name: "IX_AccountRole_LastModifiedByPrincipalId", newName: "IX_TenancySecurityProfileAccountRole_LastModifiedByPrincipalId");
            RenameIndex(table: "Module02.TenancySecurityProfileAccountRoles", name: "IX_AccountRole_Title", newName: "IX_TenancySecurityProfileAccountRole_Title");
        }
        
        public override void Down()
        {
            RenameIndex(table: "Module02.TenancySecurityProfileAccountRoles", name: "IX_TenancySecurityProfileAccountRole_Title", newName: "IX_AccountRole_Title");
            RenameIndex(table: "Module02.TenancySecurityProfileAccountRoles", name: "IX_TenancySecurityProfileAccountRole_LastModifiedByPrincipalId", newName: "IX_AccountRole_LastModifiedByPrincipalId");
            RenameIndex(table: "Module02.TenancySecurityProfileAccountRoles", name: "IX_TenancySecurityProfileAccountRole_LastModifiedOnUtc", newName: "IX_AccountRole_LastModifiedOnUtc");
            RenameIndex(table: "Module02.TenancySecurityProfileAccountRoles", name: "IX_TenancySecurityProfileAccountRole_RecordState", newName: "IX_AccountRole_RecordState");
            RenameIndex(table: "Module02.TenancySecurityProfileAccountRoles", name: "IX_TenancySecurityProfileAccountRole_TenantFK", newName: "IX_AccountRole_TenantFK");
            RenameIndex(table: "Module02.TenancySecurityProfiles", name: "IX_TenancySecurityProfile_LastModifiedByPrincipalId", newName: "IX_Account_LastModifiedByPrincipalId");
            RenameIndex(table: "Module02.TenancySecurityProfiles", name: "IX_TenancySecurityProfile_LastModifiedOnUtc", newName: "IX_Account_LastModifiedOnUtc");
            RenameIndex(table: "Module02.TenancySecurityProfiles", name: "IX_TenancySecurityProfile_RecordState", newName: "IX_Account_RecordState");
            RenameIndex(table: "Module02.TenancySecurityProfiles", name: "IX_TenancySecurityProfile_TenantFK", newName: "IX_Account_TenantFK");
            RenameTable(name: "Module02.TenancySecurityProfileAccountRole__TenancySecurityProfilePermission", newName: "AccountRole__TenancySecurityProfilePermission");
            RenameTable(name: "Module02.TenancySecurityProfile__TenancySecurityProfileAccountRole", newName: "Account__AccountRole");
            RenameTable(name: "Module02.TenancySecurityProfile__AccountRoleGroup", newName: "Account__AccountRoleGroup");
            RenameTable(name: "Module02.AccountRoleGroup__TenancySecurityProfileAccountRole", newName: "AccountRoleGroup__AccountRole");
            RenameTable(name: "Module02.TenancySecurityProfileAccountRoles", newName: "AccountRoles");
            RenameTable(name: "Module02.TenancySecurityProfiles", newName: "Accounts");
        }
    }
}
