namespace App.Module02.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedTenancySecurityPermission : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Module02.AccountPermissions", newName: "TenancySecurityProfilePermissions");
            RenameTable(name: "Module02.AccountRole__AccountPermission", newName: "AccountRole__TenancySecurityProfilePermission");
            RenameIndex(table: "Module02.TenancySecurityProfilePermissions", name: "IX_AccountPermission_TenantFK", newName: "IX_TenancySecurityProfilePermission_TenantFK");
            RenameIndex(table: "Module02.TenancySecurityProfilePermissions", name: "IX_AccountPermission_RecordState", newName: "IX_TenancySecurityProfilePermission_RecordState");
            RenameIndex(table: "Module02.TenancySecurityProfilePermissions", name: "IX_AccountPermission_LastModifiedOnUtc", newName: "IX_TenancySecurityProfilePermission_LastModifiedOnUtc");
            RenameIndex(table: "Module02.TenancySecurityProfilePermissions", name: "IX_AccountPermission_LastModifiedByPrincipalId", newName: "IX_TenancySecurityProfilePermission_LastModifiedByPrincipalId");
            RenameIndex(table: "Module02.TenancySecurityProfilePermissions", name: "IX_AccountPermission_Title", newName: "IX_TenancySecurityProfilePermission_Title");
        }
        
        public override void Down()
        {
            RenameIndex(table: "Module02.TenancySecurityProfilePermissions", name: "IX_TenancySecurityProfilePermission_Title", newName: "IX_AccountPermission_Title");
            RenameIndex(table: "Module02.TenancySecurityProfilePermissions", name: "IX_TenancySecurityProfilePermission_LastModifiedByPrincipalId", newName: "IX_AccountPermission_LastModifiedByPrincipalId");
            RenameIndex(table: "Module02.TenancySecurityProfilePermissions", name: "IX_TenancySecurityProfilePermission_LastModifiedOnUtc", newName: "IX_AccountPermission_LastModifiedOnUtc");
            RenameIndex(table: "Module02.TenancySecurityProfilePermissions", name: "IX_TenancySecurityProfilePermission_RecordState", newName: "IX_AccountPermission_RecordState");
            RenameIndex(table: "Module02.TenancySecurityProfilePermissions", name: "IX_TenancySecurityProfilePermission_TenantFK", newName: "IX_AccountPermission_TenantFK");
            RenameTable(name: "Module02.AccountRole__TenancySecurityProfilePermission", newName: "AccountRole__AccountPermission");
            RenameTable(name: "Module02.TenancySecurityProfilePermissions", newName: "AccountPermissions");
        }
    }
}
