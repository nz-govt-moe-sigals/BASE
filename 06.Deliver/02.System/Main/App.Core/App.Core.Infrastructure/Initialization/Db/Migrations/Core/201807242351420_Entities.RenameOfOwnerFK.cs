namespace App.Core.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesRenameOfOwnerFK : DbMigration
    {
        public override void Up()
        {
            DropIndex("Core.PrincipalLogins", "IX_PrincipalLogin_IdpLogin");
            RenameColumn(table: "Core.SessionOperations", name: "OwnerFK", newName: "SessionFK");
            RenameColumn(table: "Core.PrincipalClaims", name: "OwnerFK", newName: "PrincipalFK");
            RenameColumn(table: "Core.PrincipalLogins", name: "OwnerFK", newName: "PrincipalFK");
            RenameColumn(table: "Core.PrincipalProperties", name: "OwnerFK", newName: "PrincipalFK");
            RenameColumn(table: "Core.TenantClaims", name: "OwnerFK", newName: "TenantFK");
            RenameColumn(table: "Core.TenantProperties", name: "OwnerFK", newName: "TenantFK");
            RenameColumn(table: "Core.PrincipalProfileClaims", name: "OwnerFK", newName: "PrincipalProfileFK");
            RenameColumn(table: "Core.PrincipalProfileProperties", name: "OwnerFK", newName: "PrincipalProfileFK");
            RenameIndex(table: "Core.SessionOperations", name: "IX_OwnerFK", newName: "IX_SessionFK");
            RenameIndex(table: "Core.PrincipalClaims", name: "IX_OwnerFK", newName: "IX_PrincipalFK");
            RenameIndex(table: "Core.PrincipalLogins", name: "IX_OwnerFK", newName: "IX_PrincipalFK");
            RenameIndex(table: "Core.PrincipalProperties", name: "IX_OwnerFK", newName: "IX_PrincipalFK");
            RenameIndex(table: "Core.TenantClaims", name: "IX_OwnerFK", newName: "IX_TenantFK");
            RenameIndex(table: "Core.TenantProperties", name: "IX_OwnerFK", newName: "IX_TenantFK");
            RenameIndex(table: "Core.PrincipalProfileClaims", name: "IX_OwnerFK", newName: "IX_PrincipalProfileFK");
            RenameIndex(table: "Core.PrincipalProfileProperties", name: "IX_OwnerFK", newName: "IX_PrincipalProfileFK");
            AddColumn("Core.PrincipalLogins", "SubLogin", c => c.String(nullable: false, maxLength: 256));
            CreateIndex("Core.PrincipalLogins", new[] { "IdPLogin", "SubLogin" }, unique: true, name: "IX_PrincipalLogin_IdpSubLogin");
        }
        
        public override void Down()
        {
            DropIndex("Core.PrincipalLogins", "IX_PrincipalLogin_IdpSubLogin");
            DropColumn("Core.PrincipalLogins", "SubLogin");
            RenameIndex(table: "Core.PrincipalProfileProperties", name: "IX_PrincipalProfileFK", newName: "IX_OwnerFK");
            RenameIndex(table: "Core.PrincipalProfileClaims", name: "IX_PrincipalProfileFK", newName: "IX_OwnerFK");
            RenameIndex(table: "Core.TenantProperties", name: "IX_TenantFK", newName: "IX_OwnerFK");
            RenameIndex(table: "Core.TenantClaims", name: "IX_TenantFK", newName: "IX_OwnerFK");
            RenameIndex(table: "Core.PrincipalProperties", name: "IX_PrincipalFK", newName: "IX_OwnerFK");
            RenameIndex(table: "Core.PrincipalLogins", name: "IX_PrincipalFK", newName: "IX_OwnerFK");
            RenameIndex(table: "Core.PrincipalClaims", name: "IX_PrincipalFK", newName: "IX_OwnerFK");
            RenameIndex(table: "Core.SessionOperations", name: "IX_SessionFK", newName: "IX_OwnerFK");
            RenameColumn(table: "Core.PrincipalProfileProperties", name: "PrincipalProfileFK", newName: "OwnerFK");
            RenameColumn(table: "Core.PrincipalProfileClaims", name: "PrincipalProfileFK", newName: "OwnerFK");
            RenameColumn(table: "Core.TenantProperties", name: "TenantFK", newName: "OwnerFK");
            RenameColumn(table: "Core.TenantClaims", name: "TenantFK", newName: "OwnerFK");
            RenameColumn(table: "Core.PrincipalProperties", name: "PrincipalFK", newName: "OwnerFK");
            RenameColumn(table: "Core.PrincipalLogins", name: "PrincipalFK", newName: "OwnerFK");
            RenameColumn(table: "Core.PrincipalClaims", name: "PrincipalFK", newName: "OwnerFK");
            RenameColumn(table: "Core.SessionOperations", name: "SessionFK", newName: "OwnerFK");
            CreateIndex("Core.PrincipalLogins", "IdPLogin", name: "IX_PrincipalLogin_IdpLogin");
        }
    }
}
