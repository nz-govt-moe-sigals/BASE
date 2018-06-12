namespace App.Module02.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingTenancySecurityProfile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Module02.TenancySecurityProfileRoleGroups", "ParentFK", "Module02.TenancySecurityProfileRoleGroups");
            DropForeignKey("Module02.TenancySecurityProfileAccountRole__TenancySecurityProfilePermission", "RoleFK", "Module02.TenancySecurityProfileAccountRoles");
            DropForeignKey("Module02.TenancySecurityProfileAccountRole__TenancySecurityProfilePermission", "PermissionFK", "Module02.TenancySecurityProfilePermissions");
            DropForeignKey("Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", "PermissionFK", "Module02.TenancySecurityProfilePermissions");
            DropForeignKey("Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", "RoleFK", "Module02.TenancySecurityProfileAccountRoles");
            DropForeignKey("Module02.TenancySecurityProfileRoleGroup__TenancySecurityProfileAccountRole", "AccountGroupFK", "Module02.TenancySecurityProfileRoleGroups");
            DropForeignKey("Module02.TenancySecurityProfileRoleGroup__TenancySecurityProfileAccountRole", "RoleFK", "Module02.TenancySecurityProfileAccountRoles");
            DropForeignKey("Module02.TenancySecurityProfile__TenancySecurityProfileRoleGroup", "AccountFK", "Module02.TenancySecurityProfiles");
            DropForeignKey("Module02.TenancySecurityProfile__TenancySecurityProfileRoleGroup", "AccountGroupFK", "Module02.TenancySecurityProfileRoleGroups");
            DropForeignKey("Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", "AccountFK", "Module02.TenancySecurityProfiles");
            DropForeignKey("Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", "PermissionFK", "Module02.TenancySecurityProfilePermissions");
            DropForeignKey("Module02.TenancySecurityProfile__TenancySecurityProfileAccountRole", "AccountFK", "Module02.TenancySecurityProfiles");
            DropForeignKey("Module02.TenancySecurityProfile__TenancySecurityProfileAccountRole", "RoleFK", "Module02.TenancySecurityProfileAccountRoles");
            DropIndex("Module02.TenancySecurityProfiles", "IX_TenancySecurityProfile_TenantFK");
            DropIndex("Module02.TenancySecurityProfiles", "IX_TenancySecurityProfile_RecordState");
            DropIndex("Module02.TenancySecurityProfiles", "IX_TenancySecurityProfile_LastModifiedOnUtc");
            DropIndex("Module02.TenancySecurityProfiles", "IX_TenancySecurityProfile_LastModifiedByPrincipalId");
            DropIndex("Module02.TenancySecurityProfileRoleGroups", "IX_TenancySecurityProfileRoleGroup_TenantFK");
            DropIndex("Module02.TenancySecurityProfileRoleGroups", "IX_TenancySecurityProfileRoleGroup_RecordState");
            DropIndex("Module02.TenancySecurityProfileRoleGroups", "IX_TenancySecurityProfileRoleGroup_LastModifiedOnUtc");
            DropIndex("Module02.TenancySecurityProfileRoleGroups", "IX_TenancySecurityProfileRoleGroup_LastModifiedByPrincipalId");
            DropIndex("Module02.TenancySecurityProfileRoleGroups", new[] { "ParentFK" });
            DropIndex("Module02.TenancySecurityProfileRoleGroups", "IX_TenancySecurityProfileRoleGroup_Title");
            DropIndex("Module02.TenancySecurityProfileAccountRoles", "IX_TenancySecurityProfileAccountRole_TenantFK");
            DropIndex("Module02.TenancySecurityProfileAccountRoles", "IX_TenancySecurityProfileAccountRole_RecordState");
            DropIndex("Module02.TenancySecurityProfileAccountRoles", "IX_TenancySecurityProfileAccountRole_LastModifiedOnUtc");
            DropIndex("Module02.TenancySecurityProfileAccountRoles", "IX_TenancySecurityProfileAccountRole_LastModifiedByPrincipalId");
            DropIndex("Module02.TenancySecurityProfileAccountRoles", "IX_TenancySecurityProfileAccountRole_Title");
            DropIndex("Module02.TenancySecurityProfilePermissions", "IX_TenancySecurityProfilePermission_TenantFK");
            DropIndex("Module02.TenancySecurityProfilePermissions", "IX_TenancySecurityProfilePermission_RecordState");
            DropIndex("Module02.TenancySecurityProfilePermissions", "IX_TenancySecurityProfilePermission_LastModifiedOnUtc");
            DropIndex("Module02.TenancySecurityProfilePermissions", "IX_TenancySecurityProfilePermission_LastModifiedByPrincipalId");
            DropIndex("Module02.TenancySecurityProfilePermissions", "IX_TenancySecurityProfilePermission_Title");
            DropIndex("Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", "IX_TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment_RecordState");
            DropIndex("Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", "IX_TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment_LastModifiedOnUtc");
            DropIndex("Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", "IX_TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment_LastModifiedByPrincipalId");
            DropIndex("Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", "IX_TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment_TenantFK");
            DropIndex("Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", new[] { "RoleFK" });
            DropIndex("Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", new[] { "PermissionFK" });
            DropIndex("Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", "IX_TenancySecurityProfileTenancySecurityProfilePermissionAssignment_RecordState");
            DropIndex("Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", "IX_TenancySecurityProfileTenancySecurityProfilePermissionAssignment_LastModifiedOnUtc");
            DropIndex("Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", "IX_TenancySecurityProfileTenancySecurityProfilePermissionAssignment_LastModifiedByPrincipalId");
            DropIndex("Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", "IX_TenancySecurityProfileTenancySecurityProfilePermissionAssignment_TenantFK");
            DropIndex("Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", new[] { "AccountFK" });
            DropIndex("Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", new[] { "PermissionFK" });
            DropIndex("Module02.TenancySecurityProfileAccountRole__TenancySecurityProfilePermission", new[] { "RoleFK" });
            DropIndex("Module02.TenancySecurityProfileAccountRole__TenancySecurityProfilePermission", new[] { "PermissionFK" });
            DropIndex("Module02.TenancySecurityProfileRoleGroup__TenancySecurityProfileAccountRole", new[] { "AccountGroupFK" });
            DropIndex("Module02.TenancySecurityProfileRoleGroup__TenancySecurityProfileAccountRole", new[] { "RoleFK" });
            DropIndex("Module02.TenancySecurityProfile__TenancySecurityProfileRoleGroup", new[] { "AccountFK" });
            DropIndex("Module02.TenancySecurityProfile__TenancySecurityProfileRoleGroup", new[] { "AccountGroupFK" });
            DropIndex("Module02.TenancySecurityProfile__TenancySecurityProfileAccountRole", new[] { "AccountFK" });
            DropIndex("Module02.TenancySecurityProfile__TenancySecurityProfileAccountRole", new[] { "RoleFK" });
            DropTable("Module02.TenancySecurityProfiles");
            DropTable("Module02.TenancySecurityProfileRoleGroups");
            DropTable("Module02.TenancySecurityProfileAccountRoles");
            DropTable("Module02.TenancySecurityProfilePermissions");
            DropTable("Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments");
            DropTable("Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments");
            DropTable("Module02.TenancySecurityProfileAccountRole__TenancySecurityProfilePermission");
            DropTable("Module02.TenancySecurityProfileRoleGroup__TenancySecurityProfileAccountRole");
            DropTable("Module02.TenancySecurityProfile__TenancySecurityProfileRoleGroup");
            DropTable("Module02.TenancySecurityProfile__TenancySecurityProfileAccountRole");
        }
        
        public override void Down()
        {
            CreateTable(
                "Module02.TenancySecurityProfile__TenancySecurityProfileAccountRole",
                c => new
                    {
                        AccountFK = c.Guid(nullable: false),
                        RoleFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccountFK, t.RoleFK });
            
            CreateTable(
                "Module02.TenancySecurityProfile__TenancySecurityProfileRoleGroup",
                c => new
                    {
                        AccountFK = c.Guid(nullable: false),
                        AccountGroupFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccountFK, t.AccountGroupFK });
            
            CreateTable(
                "Module02.TenancySecurityProfileRoleGroup__TenancySecurityProfileAccountRole",
                c => new
                    {
                        AccountGroupFK = c.Guid(nullable: false),
                        RoleFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccountGroupFK, t.RoleFK });
            
            CreateTable(
                "Module02.TenancySecurityProfileAccountRole__TenancySecurityProfilePermission",
                c => new
                    {
                        RoleFK = c.Guid(nullable: false),
                        PermissionFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleFK, t.PermissionFK });
            
            CreateTable(
                "Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments",
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
                .PrimaryKey(t => new { t.AccountFK, t.PermissionFK });
            
            CreateTable(
                "Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments",
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
                .PrimaryKey(t => new { t.RoleFK, t.PermissionFK });
            
            CreateTable(
                "Module02.TenancySecurityProfilePermissions",
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module02.TenancySecurityProfileAccountRoles",
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module02.TenancySecurityProfileRoleGroups",
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module02.TenancySecurityProfiles",
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("Module02.TenancySecurityProfile__TenancySecurityProfileAccountRole", "RoleFK");
            CreateIndex("Module02.TenancySecurityProfile__TenancySecurityProfileAccountRole", "AccountFK");
            CreateIndex("Module02.TenancySecurityProfile__TenancySecurityProfileRoleGroup", "AccountGroupFK");
            CreateIndex("Module02.TenancySecurityProfile__TenancySecurityProfileRoleGroup", "AccountFK");
            CreateIndex("Module02.TenancySecurityProfileRoleGroup__TenancySecurityProfileAccountRole", "RoleFK");
            CreateIndex("Module02.TenancySecurityProfileRoleGroup__TenancySecurityProfileAccountRole", "AccountGroupFK");
            CreateIndex("Module02.TenancySecurityProfileAccountRole__TenancySecurityProfilePermission", "PermissionFK");
            CreateIndex("Module02.TenancySecurityProfileAccountRole__TenancySecurityProfilePermission", "RoleFK");
            CreateIndex("Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", "PermissionFK");
            CreateIndex("Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", "AccountFK");
            CreateIndex("Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", "TenantFK", name: "IX_TenancySecurityProfileTenancySecurityProfilePermissionAssignment_TenantFK");
            CreateIndex("Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", "LastModifiedByPrincipalId", name: "IX_TenancySecurityProfileTenancySecurityProfilePermissionAssignment_LastModifiedByPrincipalId");
            CreateIndex("Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", "LastModifiedOnUtc", name: "IX_TenancySecurityProfileTenancySecurityProfilePermissionAssignment_LastModifiedOnUtc");
            CreateIndex("Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", "RecordState", name: "IX_TenancySecurityProfileTenancySecurityProfilePermissionAssignment_RecordState");
            CreateIndex("Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", "PermissionFK");
            CreateIndex("Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", "RoleFK");
            CreateIndex("Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", "TenantFK", name: "IX_TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment_TenantFK");
            CreateIndex("Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", "LastModifiedByPrincipalId", name: "IX_TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment_LastModifiedByPrincipalId");
            CreateIndex("Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", "LastModifiedOnUtc", name: "IX_TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment_LastModifiedOnUtc");
            CreateIndex("Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", "RecordState", name: "IX_TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment_RecordState");
            CreateIndex("Module02.TenancySecurityProfilePermissions", "Title", name: "IX_TenancySecurityProfilePermission_Title");
            CreateIndex("Module02.TenancySecurityProfilePermissions", "LastModifiedByPrincipalId", name: "IX_TenancySecurityProfilePermission_LastModifiedByPrincipalId");
            CreateIndex("Module02.TenancySecurityProfilePermissions", "LastModifiedOnUtc", name: "IX_TenancySecurityProfilePermission_LastModifiedOnUtc");
            CreateIndex("Module02.TenancySecurityProfilePermissions", "RecordState", name: "IX_TenancySecurityProfilePermission_RecordState");
            CreateIndex("Module02.TenancySecurityProfilePermissions", "TenantFK", name: "IX_TenancySecurityProfilePermission_TenantFK");
            CreateIndex("Module02.TenancySecurityProfileAccountRoles", "Title", name: "IX_TenancySecurityProfileAccountRole_Title");
            CreateIndex("Module02.TenancySecurityProfileAccountRoles", "LastModifiedByPrincipalId", name: "IX_TenancySecurityProfileAccountRole_LastModifiedByPrincipalId");
            CreateIndex("Module02.TenancySecurityProfileAccountRoles", "LastModifiedOnUtc", name: "IX_TenancySecurityProfileAccountRole_LastModifiedOnUtc");
            CreateIndex("Module02.TenancySecurityProfileAccountRoles", "RecordState", name: "IX_TenancySecurityProfileAccountRole_RecordState");
            CreateIndex("Module02.TenancySecurityProfileAccountRoles", "TenantFK", name: "IX_TenancySecurityProfileAccountRole_TenantFK");
            CreateIndex("Module02.TenancySecurityProfileRoleGroups", "Title", name: "IX_TenancySecurityProfileRoleGroup_Title");
            CreateIndex("Module02.TenancySecurityProfileRoleGroups", "ParentFK");
            CreateIndex("Module02.TenancySecurityProfileRoleGroups", "LastModifiedByPrincipalId", name: "IX_TenancySecurityProfileRoleGroup_LastModifiedByPrincipalId");
            CreateIndex("Module02.TenancySecurityProfileRoleGroups", "LastModifiedOnUtc", name: "IX_TenancySecurityProfileRoleGroup_LastModifiedOnUtc");
            CreateIndex("Module02.TenancySecurityProfileRoleGroups", "RecordState", name: "IX_TenancySecurityProfileRoleGroup_RecordState");
            CreateIndex("Module02.TenancySecurityProfileRoleGroups", "TenantFK", name: "IX_TenancySecurityProfileRoleGroup_TenantFK");
            CreateIndex("Module02.TenancySecurityProfiles", "LastModifiedByPrincipalId", name: "IX_TenancySecurityProfile_LastModifiedByPrincipalId");
            CreateIndex("Module02.TenancySecurityProfiles", "LastModifiedOnUtc", name: "IX_TenancySecurityProfile_LastModifiedOnUtc");
            CreateIndex("Module02.TenancySecurityProfiles", "RecordState", name: "IX_TenancySecurityProfile_RecordState");
            CreateIndex("Module02.TenancySecurityProfiles", "TenantFK", name: "IX_TenancySecurityProfile_TenantFK");
            AddForeignKey("Module02.TenancySecurityProfile__TenancySecurityProfileAccountRole", "RoleFK", "Module02.TenancySecurityProfileAccountRoles", "Id", cascadeDelete: true);
            AddForeignKey("Module02.TenancySecurityProfile__TenancySecurityProfileAccountRole", "AccountFK", "Module02.TenancySecurityProfiles", "Id", cascadeDelete: true);
            AddForeignKey("Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", "PermissionFK", "Module02.TenancySecurityProfilePermissions", "Id", cascadeDelete: true);
            AddForeignKey("Module02.TenancySecurityProfileTenancySecurityProfilePermissionAssignments", "AccountFK", "Module02.TenancySecurityProfiles", "Id", cascadeDelete: true);
            AddForeignKey("Module02.TenancySecurityProfile__TenancySecurityProfileRoleGroup", "AccountGroupFK", "Module02.TenancySecurityProfileRoleGroups", "Id", cascadeDelete: true);
            AddForeignKey("Module02.TenancySecurityProfile__TenancySecurityProfileRoleGroup", "AccountFK", "Module02.TenancySecurityProfiles", "Id", cascadeDelete: true);
            AddForeignKey("Module02.TenancySecurityProfileRoleGroup__TenancySecurityProfileAccountRole", "RoleFK", "Module02.TenancySecurityProfileAccountRoles", "Id", cascadeDelete: true);
            AddForeignKey("Module02.TenancySecurityProfileRoleGroup__TenancySecurityProfileAccountRole", "AccountGroupFK", "Module02.TenancySecurityProfileRoleGroups", "Id", cascadeDelete: true);
            AddForeignKey("Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", "RoleFK", "Module02.TenancySecurityProfileAccountRoles", "Id", cascadeDelete: true);
            AddForeignKey("Module02.TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignments", "PermissionFK", "Module02.TenancySecurityProfilePermissions", "Id", cascadeDelete: true);
            AddForeignKey("Module02.TenancySecurityProfileAccountRole__TenancySecurityProfilePermission", "PermissionFK", "Module02.TenancySecurityProfilePermissions", "Id", cascadeDelete: true);
            AddForeignKey("Module02.TenancySecurityProfileAccountRole__TenancySecurityProfilePermission", "RoleFK", "Module02.TenancySecurityProfileAccountRoles", "Id", cascadeDelete: true);
            AddForeignKey("Module02.TenancySecurityProfileRoleGroups", "ParentFK", "Module02.TenancySecurityProfileRoleGroups", "Id");
        }
    }
}
