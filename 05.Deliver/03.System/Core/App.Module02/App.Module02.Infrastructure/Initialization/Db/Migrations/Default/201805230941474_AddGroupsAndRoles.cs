namespace App.Module02.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGroupsAndRoles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Module02.Accounts",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_Account_TenantFK")
                .Index(t => t.RecordState, name: "IX_Account_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_Account_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_Account_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module02.AccountGroups",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(maxLength: 32),
                        ParentFK = c.Guid(),
                        Title = c.String(nullable: false, maxLength: 64),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module02.AccountGroups", t => t.ParentFK)
                .Index(t => t.TenantFK, name: "IX_AccountGroup_TenantFK")
                .Index(t => t.RecordState, name: "IX_AccountGroup_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_AccountGroup_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_AccountGroup_LastModifiedByPrincipalId")
                .Index(t => t.ParentFK)
                .Index(t => t.Title, name: "IX_AccountGroup_Title");
            
            CreateTable(
                "Module02.AccountRoles",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(maxLength: 32),
                        Title = c.String(nullable: false, maxLength: 64),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_AccountRole_TenantFK")
                .Index(t => t.RecordState, name: "IX_AccountRole_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_AccountRole_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_AccountRole_LastModifiedByPrincipalId")
                .Index(t => t.Title, name: "IX_AccountRole_Title");
            
            CreateTable(
                "Module02.AccountPermissions",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(maxLength: 32),
                        Title = c.String(nullable: false, maxLength: 64),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_AccountPermission_TenantFK")
                .Index(t => t.RecordState, name: "IX_AccountPermission_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_AccountPermission_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_AccountPermission_LastModifiedByPrincipalId")
                .Index(t => t.Title, name: "IX_AccountPermission_Title");
            
            CreateTable(
                "Module02.AccountRoleAccountPermissionAssignments",
                c => new
                    {
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(maxLength: 32),
                        TenantFK = c.Guid(nullable: false),
                        RoleFK = c.Guid(nullable: false),
                        PermissionFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleFK, t.PermissionFK })
                .ForeignKey("Module02.AccountPermissions", t => t.PermissionFK, cascadeDelete: true)
                .ForeignKey("Module02.AccountRoles", t => t.RoleFK, cascadeDelete: true)
                .Index(t => t.RecordState, name: "IX_AccountRoleAccountPermissionAssignment_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_AccountRoleAccountPermissionAssignment_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_AccountRoleAccountPermissionAssignment_LastModifiedByPrincipalId")
                .Index(t => t.TenantFK, name: "IX_AccountRoleAccountPermissionAssignment_TenantFK")
                .Index(t => t.RoleFK)
                .Index(t => t.PermissionFK);
            
            CreateTable(
                "Module02.AccountAccountPermissionAssignments",
                c => new
                    {
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(maxLength: 32),
                        TenantFK = c.Guid(nullable: false),
                        AccountFK = c.Guid(nullable: false),
                        PermissionFK = c.Guid(nullable: false),
                        AssignmentType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccountFK, t.PermissionFK })
                .ForeignKey("Module02.Accounts", t => t.AccountFK, cascadeDelete: true)
                .ForeignKey("Module02.AccountPermissions", t => t.PermissionFK, cascadeDelete: true)
                .Index(t => t.RecordState, name: "IX_AccountAccountPermissionAssignment_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_AccountAccountPermissionAssignment_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_AccountAccountPermissionAssignment_LastModifiedByPrincipalId")
                .Index(t => t.TenantFK, name: "IX_AccountAccountPermissionAssignment_TenantFK")
                .Index(t => t.AccountFK)
                .Index(t => t.PermissionFK);
            
            CreateTable(
                "Module02.AccountRole__AccountPermission",
                c => new
                    {
                        RoleFK = c.Guid(nullable: false),
                        PermissionFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleFK, t.PermissionFK })
                .ForeignKey("Module02.AccountRoles", t => t.RoleFK, cascadeDelete: true)
                .ForeignKey("Module02.AccountPermissions", t => t.PermissionFK, cascadeDelete: true)
                .Index(t => t.RoleFK)
                .Index(t => t.PermissionFK);
            
            CreateTable(
                "Module02.AccountGroup__AccountRole",
                c => new
                    {
                        AccountGroupFK = c.Guid(nullable: false),
                        RoleFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccountGroupFK, t.RoleFK })
                .ForeignKey("Module02.AccountGroups", t => t.AccountGroupFK, cascadeDelete: true)
                .ForeignKey("Module02.AccountRoles", t => t.RoleFK, cascadeDelete: true)
                .Index(t => t.AccountGroupFK)
                .Index(t => t.RoleFK);
            
            CreateTable(
                "Module02.Account__AccountGroup",
                c => new
                    {
                        AccountFK = c.Guid(nullable: false),
                        AccountGroupFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccountFK, t.AccountGroupFK })
                .ForeignKey("Module02.Accounts", t => t.AccountFK, cascadeDelete: true)
                .ForeignKey("Module02.AccountGroups", t => t.AccountGroupFK, cascadeDelete: true)
                .Index(t => t.AccountFK)
                .Index(t => t.AccountGroupFK);
            
            CreateTable(
                "Module02.Account__AccountRole",
                c => new
                    {
                        AccountFK = c.Guid(nullable: false),
                        RoleFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccountFK, t.RoleFK })
                .ForeignKey("Module02.Accounts", t => t.AccountFK, cascadeDelete: true)
                .ForeignKey("Module02.AccountRoles", t => t.RoleFK, cascadeDelete: true)
                .Index(t => t.AccountFK)
                .Index(t => t.RoleFK);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Module02.Account__AccountRole", "RoleFK", "Module02.AccountRoles");
            DropForeignKey("Module02.Account__AccountRole", "AccountFK", "Module02.Accounts");
            DropForeignKey("Module02.AccountAccountPermissionAssignments", "PermissionFK", "Module02.AccountPermissions");
            DropForeignKey("Module02.AccountAccountPermissionAssignments", "AccountFK", "Module02.Accounts");
            DropForeignKey("Module02.Account__AccountGroup", "AccountGroupFK", "Module02.AccountGroups");
            DropForeignKey("Module02.Account__AccountGroup", "AccountFK", "Module02.Accounts");
            DropForeignKey("Module02.AccountGroup__AccountRole", "RoleFK", "Module02.AccountRoles");
            DropForeignKey("Module02.AccountGroup__AccountRole", "AccountGroupFK", "Module02.AccountGroups");
            DropForeignKey("Module02.AccountRoleAccountPermissionAssignments", "RoleFK", "Module02.AccountRoles");
            DropForeignKey("Module02.AccountRoleAccountPermissionAssignments", "PermissionFK", "Module02.AccountPermissions");
            DropForeignKey("Module02.AccountRole__AccountPermission", "PermissionFK", "Module02.AccountPermissions");
            DropForeignKey("Module02.AccountRole__AccountPermission", "RoleFK", "Module02.AccountRoles");
            DropForeignKey("Module02.AccountGroups", "ParentFK", "Module02.AccountGroups");
            DropIndex("Module02.Account__AccountRole", new[] { "RoleFK" });
            DropIndex("Module02.Account__AccountRole", new[] { "AccountFK" });
            DropIndex("Module02.Account__AccountGroup", new[] { "AccountGroupFK" });
            DropIndex("Module02.Account__AccountGroup", new[] { "AccountFK" });
            DropIndex("Module02.AccountGroup__AccountRole", new[] { "RoleFK" });
            DropIndex("Module02.AccountGroup__AccountRole", new[] { "AccountGroupFK" });
            DropIndex("Module02.AccountRole__AccountPermission", new[] { "PermissionFK" });
            DropIndex("Module02.AccountRole__AccountPermission", new[] { "RoleFK" });
            DropIndex("Module02.AccountAccountPermissionAssignments", new[] { "PermissionFK" });
            DropIndex("Module02.AccountAccountPermissionAssignments", new[] { "AccountFK" });
            DropIndex("Module02.AccountAccountPermissionAssignments", "IX_AccountAccountPermissionAssignment_TenantFK");
            DropIndex("Module02.AccountAccountPermissionAssignments", "IX_AccountAccountPermissionAssignment_LastModifiedByPrincipalId");
            DropIndex("Module02.AccountAccountPermissionAssignments", "IX_AccountAccountPermissionAssignment_LastModifiedOnUtc");
            DropIndex("Module02.AccountAccountPermissionAssignments", "IX_AccountAccountPermissionAssignment_RecordState");
            DropIndex("Module02.AccountRoleAccountPermissionAssignments", new[] { "PermissionFK" });
            DropIndex("Module02.AccountRoleAccountPermissionAssignments", new[] { "RoleFK" });
            DropIndex("Module02.AccountRoleAccountPermissionAssignments", "IX_AccountRoleAccountPermissionAssignment_TenantFK");
            DropIndex("Module02.AccountRoleAccountPermissionAssignments", "IX_AccountRoleAccountPermissionAssignment_LastModifiedByPrincipalId");
            DropIndex("Module02.AccountRoleAccountPermissionAssignments", "IX_AccountRoleAccountPermissionAssignment_LastModifiedOnUtc");
            DropIndex("Module02.AccountRoleAccountPermissionAssignments", "IX_AccountRoleAccountPermissionAssignment_RecordState");
            DropIndex("Module02.AccountPermissions", "IX_AccountPermission_Title");
            DropIndex("Module02.AccountPermissions", "IX_AccountPermission_LastModifiedByPrincipalId");
            DropIndex("Module02.AccountPermissions", "IX_AccountPermission_LastModifiedOnUtc");
            DropIndex("Module02.AccountPermissions", "IX_AccountPermission_RecordState");
            DropIndex("Module02.AccountPermissions", "IX_AccountPermission_TenantFK");
            DropIndex("Module02.AccountRoles", "IX_AccountRole_Title");
            DropIndex("Module02.AccountRoles", "IX_AccountRole_LastModifiedByPrincipalId");
            DropIndex("Module02.AccountRoles", "IX_AccountRole_LastModifiedOnUtc");
            DropIndex("Module02.AccountRoles", "IX_AccountRole_RecordState");
            DropIndex("Module02.AccountRoles", "IX_AccountRole_TenantFK");
            DropIndex("Module02.AccountGroups", "IX_AccountGroup_Title");
            DropIndex("Module02.AccountGroups", new[] { "ParentFK" });
            DropIndex("Module02.AccountGroups", "IX_AccountGroup_LastModifiedByPrincipalId");
            DropIndex("Module02.AccountGroups", "IX_AccountGroup_LastModifiedOnUtc");
            DropIndex("Module02.AccountGroups", "IX_AccountGroup_RecordState");
            DropIndex("Module02.AccountGroups", "IX_AccountGroup_TenantFK");
            DropIndex("Module02.Accounts", "IX_Account_LastModifiedByPrincipalId");
            DropIndex("Module02.Accounts", "IX_Account_LastModifiedOnUtc");
            DropIndex("Module02.Accounts", "IX_Account_RecordState");
            DropIndex("Module02.Accounts", "IX_Account_TenantFK");
            DropTable("Module02.Account__AccountRole");
            DropTable("Module02.Account__AccountGroup");
            DropTable("Module02.AccountGroup__AccountRole");
            DropTable("Module02.AccountRole__AccountPermission");
            DropTable("Module02.AccountAccountPermissionAssignments");
            DropTable("Module02.AccountRoleAccountPermissionAssignments");
            DropTable("Module02.AccountPermissions");
            DropTable("Module02.AccountRoles");
            DropTable("Module02.AccountGroups");
            DropTable("Module02.Accounts");
        }
    }
}
