namespace App.Module02.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Module02.AccountGroups", newName: "AccountRoleGroups");
            RenameTable(name: "Module02.Account__AccountGroup", newName: "Account__AccountRoleGroup");
            RenameTable(name: "Module02.AccountGroup__AccountRole", newName: "AccountRoleGroup__AccountRole");
            RenameIndex(table: "Module02.AccountRoleGroups", name: "IX_AccountGroup_TenantFK", newName: "IX_AccountRoleGroup_TenantFK");
            RenameIndex(table: "Module02.AccountRoleGroups", name: "IX_AccountGroup_RecordState", newName: "IX_AccountRoleGroup_RecordState");
            RenameIndex(table: "Module02.AccountRoleGroups", name: "IX_AccountGroup_LastModifiedOnUtc", newName: "IX_AccountRoleGroup_LastModifiedOnUtc");
            RenameIndex(table: "Module02.AccountRoleGroups", name: "IX_AccountGroup_LastModifiedByPrincipalId", newName: "IX_AccountRoleGroup_LastModifiedByPrincipalId");
            RenameIndex(table: "Module02.AccountRoleGroups", name: "IX_AccountGroup_Title", newName: "IX_AccountRoleGroup_Title");
            AddColumn("Module02.Accounts", "Enabled", c => c.Boolean(nullable: false));
            AddColumn("Module02.Accounts", "Key", c => c.String());
            AddColumn("Module02.AccountRoleAccountPermissionAssignments", "AssignmentType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Module02.AccountRoleAccountPermissionAssignments", "AssignmentType");
            DropColumn("Module02.Accounts", "Key");
            DropColumn("Module02.Accounts", "Enabled");
            RenameIndex(table: "Module02.AccountRoleGroups", name: "IX_AccountRoleGroup_Title", newName: "IX_AccountGroup_Title");
            RenameIndex(table: "Module02.AccountRoleGroups", name: "IX_AccountRoleGroup_LastModifiedByPrincipalId", newName: "IX_AccountGroup_LastModifiedByPrincipalId");
            RenameIndex(table: "Module02.AccountRoleGroups", name: "IX_AccountRoleGroup_LastModifiedOnUtc", newName: "IX_AccountGroup_LastModifiedOnUtc");
            RenameIndex(table: "Module02.AccountRoleGroups", name: "IX_AccountRoleGroup_RecordState", newName: "IX_AccountGroup_RecordState");
            RenameIndex(table: "Module02.AccountRoleGroups", name: "IX_AccountRoleGroup_TenantFK", newName: "IX_AccountGroup_TenantFK");
            RenameTable(name: "Module02.AccountRoleGroup__AccountRole", newName: "AccountGroup__AccountRole");
            RenameTable(name: "Module02.Account__AccountRoleGroup", newName: "Account__AccountGroup");
            RenameTable(name: "Module02.AccountRoleGroups", newName: "AccountGroups");
        }
    }
}
