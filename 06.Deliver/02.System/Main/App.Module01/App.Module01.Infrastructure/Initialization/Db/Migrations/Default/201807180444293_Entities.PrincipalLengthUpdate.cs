namespace App.Module01.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesPrincipalLengthUpdate : DbMigration
    {
        public override void Up()
        {
            DropIndex("Module01.Examples", "IX_Example_LastModifiedByPrincipalId");
            AlterColumn("Module01.Examples", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module01.Examples", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module01.Examples", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            CreateIndex("Module01.Examples", "LastModifiedByPrincipalId", name: "IX_Example_LastModifiedByPrincipalId");
        }
        
        public override void Down()
        {
            DropIndex("Module01.Examples", "IX_Example_LastModifiedByPrincipalId");
            AlterColumn("Module01.Examples", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module01.Examples", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module01.Examples", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            CreateIndex("Module01.Examples", "LastModifiedByPrincipalId", name: "IX_Example_LastModifiedByPrincipalId");
        }
    }
}
