namespace App.Core.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSecurityProfiles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Core.TenancySecurityProfiles",
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
                        Enabled = c.Boolean(nullable: false),
                        Key = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_TenancySecurityProfile_TenantFK")
                .Index(t => t.RecordState, name: "IX_TenancySecurityProfile_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_TenancySecurityProfile_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_TenancySecurityProfile_LastModifiedByPrincipalId");
            
            CreateTable(
                "Core.TenancySecurityProfileRoleGroups",
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
                .ForeignKey("Core.TenancySecurityProfileRoleGroups", t => t.ParentFK)
                .Index(t => t.TenantFK, name: "IX_TenancySecurityProfileRoleGroup_TenantFK")
                .Index(t => t.RecordState, name: "IX_TenancySecurityProfileRoleGroup_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_TenancySecurityProfileRoleGroup_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_TenancySecurityProfileRoleGroup_LastModifiedByPrincipalId")
                .Index(t => t.ParentFK)
                .Index(t => t.Title, name: "IX_TenancySecurityProfileRoleGroup_Title");
            
            CreateTable(
                "Core.TenancySecurityProfileAccountRoles",
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
                .Index(t => t.TenantFK, name: "IX_TenancySecurityProfileAccountRole_TenantFK")
                .Index(t => t.RecordState, name: "IX_TenancySecurityProfileAccountRole_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_TenancySecurityProfileAccountRole_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_TenancySecurityProfileAccountRole_LastModifiedByPrincipalId")
                .Index(t => t.Title, name: "IX_TenancySecurityProfileAccountRole_Title");
            
            CreateTable(
                "Core.TenancySecurityProfilePermissions",
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
                .Index(t => t.TenantFK, name: "IX_TenancySecurityProfilePermission_TenantFK")
                .Index(t => t.RecordState, name: "IX_TenancySecurityProfilePermission_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_TenancySecurityProfilePermission_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_TenancySecurityProfilePermission_LastModifiedByPrincipalId")
                .Index(t => t.Title, name: "IX_TenancySecurityProfilePermission_Title");
            
            CreateTable(
                "Core.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments",
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
                        AssignmentType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleFK, t.PermissionFK })
                .ForeignKey("Core.TenancySecurityProfilePermissions", t => t.PermissionFK, cascadeDelete: true)
                .ForeignKey("Core.TenancySecurityProfileAccountRoles", t => t.RoleFK, cascadeDelete: true)
                .Index(t => t.RecordState, name: "IX_TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment_LastModifiedByPrincipalId")
                .Index(t => t.TenantFK, name: "IX_TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment_TenantFK")
                .Index(t => t.RoleFK)
                .Index(t => t.PermissionFK);
            
            CreateTable(
                "Core.TenancySecurityProfileTenancySecurityProfilePermissionAssignments",
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
                .ForeignKey("Core.TenancySecurityProfiles", t => t.AccountFK, cascadeDelete: true)
                .ForeignKey("Core.TenancySecurityProfilePermissions", t => t.PermissionFK, cascadeDelete: true)
                .Index(t => t.RecordState, name: "IX_TenancySecurityProfileTenancySecurityProfilePermissionAssignment_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_TenancySecurityProfileTenancySecurityProfilePermissionAssignment_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_TenancySecurityProfileTenancySecurityProfilePermissionAssignment_LastModifiedByPrincipalId")
                .Index(t => t.TenantFK, name: "IX_TenancySecurityProfileTenancySecurityProfilePermissionAssignment_TenantFK")
                .Index(t => t.AccountFK)
                .Index(t => t.PermissionFK);
            
            CreateTable(
                "Core.TenancySecurityProfileAccountRole__TenancySecurityProfilePermission",
                c => new
                    {
                        RoleFK = c.Guid(nullable: false),
                        PermissionFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleFK, t.PermissionFK })
                .ForeignKey("Core.TenancySecurityProfileAccountRoles", t => t.RoleFK, cascadeDelete: true)
                .ForeignKey("Core.TenancySecurityProfilePermissions", t => t.PermissionFK, cascadeDelete: true)
                .Index(t => t.RoleFK)
                .Index(t => t.PermissionFK);
            
            CreateTable(
                "Core.TenancySecurityProfileRoleGroup__TenancySecurityProfileAccountRole",
                c => new
                    {
                        AccountGroupFK = c.Guid(nullable: false),
                        RoleFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccountGroupFK, t.RoleFK })
                .ForeignKey("Core.TenancySecurityProfileRoleGroups", t => t.AccountGroupFK, cascadeDelete: true)
                .ForeignKey("Core.TenancySecurityProfileAccountRoles", t => t.RoleFK, cascadeDelete: true)
                .Index(t => t.AccountGroupFK)
                .Index(t => t.RoleFK);
            
            CreateTable(
                "Core.TenancySecurityProfile__TenancySecurityProfileRoleGroup",
                c => new
                    {
                        AccountFK = c.Guid(nullable: false),
                        AccountGroupFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccountFK, t.AccountGroupFK })
                .ForeignKey("Core.TenancySecurityProfiles", t => t.AccountFK, cascadeDelete: true)
                .ForeignKey("Core.TenancySecurityProfileRoleGroups", t => t.AccountGroupFK, cascadeDelete: true)
                .Index(t => t.AccountFK)
                .Index(t => t.AccountGroupFK);
            
            CreateTable(
                "Core.TenancySecurityProfile__TenancySecurityProfileAccountRole",
                c => new
                    {
                        AccountFK = c.Guid(nullable: false),
                        RoleFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccountFK, t.RoleFK })
                .ForeignKey("Core.TenancySecurityProfiles", t => t.AccountFK, cascadeDelete: true)
                .ForeignKey("Core.TenancySecurityProfileAccountRoles", t => t.RoleFK, cascadeDelete: true)
                .Index(t => t.AccountFK)
                .Index(t => t.RoleFK);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Core.TenancySecurityProfile__TenancySecurityProfileAccountRole", "RoleFK", "Core.TenancySecurityProfileAccountRoles");
            DropForeignKey("Core.TenancySecurityProfile__TenancySecurityProfileAccountRole", "AccountFK", "Core.TenancySecurityProfiles");
            DropForeignKey("Core.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", "PermissionFK", "Core.TenancySecurityProfilePermissions");
            DropForeignKey("Core.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", "AccountFK", "Core.TenancySecurityProfiles");
            DropForeignKey("Core.TenancySecurityProfile__TenancySecurityProfileRoleGroup", "AccountGroupFK", "Core.TenancySecurityProfileRoleGroups");
            DropForeignKey("Core.TenancySecurityProfile__TenancySecurityProfileRoleGroup", "AccountFK", "Core.TenancySecurityProfiles");
            DropForeignKey("Core.TenancySecurityProfileRoleGroup__TenancySecurityProfileAccountRole", "RoleFK", "Core.TenancySecurityProfileAccountRoles");
            DropForeignKey("Core.TenancySecurityProfileRoleGroup__TenancySecurityProfileAccountRole", "AccountGroupFK", "Core.TenancySecurityProfileRoleGroups");
            DropForeignKey("Core.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", "RoleFK", "Core.TenancySecurityProfileAccountRoles");
            DropForeignKey("Core.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", "PermissionFK", "Core.TenancySecurityProfilePermissions");
            DropForeignKey("Core.TenancySecurityProfileAccountRole__TenancySecurityProfilePermission", "PermissionFK", "Core.TenancySecurityProfilePermissions");
            DropForeignKey("Core.TenancySecurityProfileAccountRole__TenancySecurityProfilePermission", "RoleFK", "Core.TenancySecurityProfileAccountRoles");
            DropForeignKey("Core.TenancySecurityProfileRoleGroups", "ParentFK", "Core.TenancySecurityProfileRoleGroups");
            DropIndex("Core.TenancySecurityProfile__TenancySecurityProfileAccountRole", new[] { "RoleFK" });
            DropIndex("Core.TenancySecurityProfile__TenancySecurityProfileAccountRole", new[] { "AccountFK" });
            DropIndex("Core.TenancySecurityProfile__TenancySecurityProfileRoleGroup", new[] { "AccountGroupFK" });
            DropIndex("Core.TenancySecurityProfile__TenancySecurityProfileRoleGroup", new[] { "AccountFK" });
            DropIndex("Core.TenancySecurityProfileRoleGroup__TenancySecurityProfileAccountRole", new[] { "RoleFK" });
            DropIndex("Core.TenancySecurityProfileRoleGroup__TenancySecurityProfileAccountRole", new[] { "AccountGroupFK" });
            DropIndex("Core.TenancySecurityProfileAccountRole__TenancySecurityProfilePermission", new[] { "PermissionFK" });
            DropIndex("Core.TenancySecurityProfileAccountRole__TenancySecurityProfilePermission", new[] { "RoleFK" });
            DropIndex("Core.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", new[] { "PermissionFK" });
            DropIndex("Core.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", new[] { "AccountFK" });
            DropIndex("Core.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", "IX_TenancySecurityProfileTenancySecurityProfilePermissionAssignment_TenantFK");
            DropIndex("Core.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", "IX_TenancySecurityProfileTenancySecurityProfilePermissionAssignment_LastModifiedByPrincipalId");
            DropIndex("Core.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", "IX_TenancySecurityProfileTenancySecurityProfilePermissionAssignment_LastModifiedOnUtc");
            DropIndex("Core.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", "IX_TenancySecurityProfileTenancySecurityProfilePermissionAssignment_RecordState");
            DropIndex("Core.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", new[] { "PermissionFK" });
            DropIndex("Core.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", new[] { "RoleFK" });
            DropIndex("Core.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", "IX_TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment_TenantFK");
            DropIndex("Core.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", "IX_TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment_LastModifiedByPrincipalId");
            DropIndex("Core.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", "IX_TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment_LastModifiedOnUtc");
            DropIndex("Core.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", "IX_TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment_RecordState");
            DropIndex("Core.TenancySecurityProfilePermissions", "IX_TenancySecurityProfilePermission_Title");
            DropIndex("Core.TenancySecurityProfilePermissions", "IX_TenancySecurityProfilePermission_LastModifiedByPrincipalId");
            DropIndex("Core.TenancySecurityProfilePermissions", "IX_TenancySecurityProfilePermission_LastModifiedOnUtc");
            DropIndex("Core.TenancySecurityProfilePermissions", "IX_TenancySecurityProfilePermission_RecordState");
            DropIndex("Core.TenancySecurityProfilePermissions", "IX_TenancySecurityProfilePermission_TenantFK");
            DropIndex("Core.TenancySecurityProfileAccountRoles", "IX_TenancySecurityProfileAccountRole_Title");
            DropIndex("Core.TenancySecurityProfileAccountRoles", "IX_TenancySecurityProfileAccountRole_LastModifiedByPrincipalId");
            DropIndex("Core.TenancySecurityProfileAccountRoles", "IX_TenancySecurityProfileAccountRole_LastModifiedOnUtc");
            DropIndex("Core.TenancySecurityProfileAccountRoles", "IX_TenancySecurityProfileAccountRole_RecordState");
            DropIndex("Core.TenancySecurityProfileAccountRoles", "IX_TenancySecurityProfileAccountRole_TenantFK");
            DropIndex("Core.TenancySecurityProfileRoleGroups", "IX_TenancySecurityProfileRoleGroup_Title");
            DropIndex("Core.TenancySecurityProfileRoleGroups", new[] { "ParentFK" });
            DropIndex("Core.TenancySecurityProfileRoleGroups", "IX_TenancySecurityProfileRoleGroup_LastModifiedByPrincipalId");
            DropIndex("Core.TenancySecurityProfileRoleGroups", "IX_TenancySecurityProfileRoleGroup_LastModifiedOnUtc");
            DropIndex("Core.TenancySecurityProfileRoleGroups", "IX_TenancySecurityProfileRoleGroup_RecordState");
            DropIndex("Core.TenancySecurityProfileRoleGroups", "IX_TenancySecurityProfileRoleGroup_TenantFK");
            DropIndex("Core.TenancySecurityProfiles", "IX_TenancySecurityProfile_LastModifiedByPrincipalId");
            DropIndex("Core.TenancySecurityProfiles", "IX_TenancySecurityProfile_LastModifiedOnUtc");
            DropIndex("Core.TenancySecurityProfiles", "IX_TenancySecurityProfile_RecordState");
            DropIndex("Core.TenancySecurityProfiles", "IX_TenancySecurityProfile_TenantFK");
            DropTable("Core.TenancySecurityProfile__TenancySecurityProfileAccountRole");
            DropTable("Core.TenancySecurityProfile__TenancySecurityProfileRoleGroup");
            DropTable("Core.TenancySecurityProfileRoleGroup__TenancySecurityProfileAccountRole");
            DropTable("Core.TenancySecurityProfileAccountRole__TenancySecurityProfilePermission");
            DropTable("Core.TenancySecurityProfileTenancySecurityProfilePermissionAssignments");
            DropTable("Core.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments");
            DropTable("Core.TenancySecurityProfilePermissions");
            DropTable("Core.TenancySecurityProfileAccountRoles");
            DropTable("Core.TenancySecurityProfileRoleGroups");
            DropTable("Core.TenancySecurityProfiles");
        }
    }
}
