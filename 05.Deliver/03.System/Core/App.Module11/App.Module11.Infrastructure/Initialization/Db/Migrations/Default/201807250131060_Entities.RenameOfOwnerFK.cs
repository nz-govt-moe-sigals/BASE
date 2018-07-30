namespace App.Module11.Infrastructure.Db.Migrations
{

    using System.Data.Entity.Migrations;
    
    public partial class EntitiesRenameOfOwnerFK : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "Module11.BodyAlias", name: "OwnerFK", newName: "BodyFK");
            RenameColumn(table: "Module11.BodyChannels", name: "OwnerFK", newName: "BodyFK");
            RenameColumn(table: "Module11.BodyClaims", name: "OwnerFK", newName: "BodyFK");
            RenameColumn(table: "Module11.BodyProperties", name: "OwnerFK", newName: "BodyFK");
            RenameIndex(table: "Module11.BodyAlias", name: "IX_OwnerFK", newName: "IX_BodyFK");
            RenameIndex(table: "Module11.BodyChannels", name: "IX_OwnerFK", newName: "IX_BodyFK");
            RenameIndex(table: "Module11.BodyClaims", name: "IX_OwnerFK", newName: "IX_BodyFK");
            RenameIndex(table: "Module11.BodyProperties", name: "IX_OwnerFK", newName: "IX_BodyFK");
        }
        
        public override void Down()
        {
            RenameIndex(table: "Module11.BodyProperties", name: "IX_BodyFK", newName: "IX_OwnerFK");
            RenameIndex(table: "Module11.BodyClaims", name: "IX_BodyFK", newName: "IX_OwnerFK");
            RenameIndex(table: "Module11.BodyChannels", name: "IX_BodyFK", newName: "IX_OwnerFK");
            RenameIndex(table: "Module11.BodyAlias", name: "IX_BodyFK", newName: "IX_OwnerFK");
            RenameColumn(table: "Module11.BodyProperties", name: "BodyFK", newName: "OwnerFK");
            RenameColumn(table: "Module11.BodyClaims", name: "BodyFK", newName: "OwnerFK");
            RenameColumn(table: "Module11.BodyChannels", name: "BodyFK", newName: "OwnerFK");
            RenameColumn(table: "Module11.BodyAlias", name: "BodyFK", newName: "OwnerFK");
        }
    }
}
