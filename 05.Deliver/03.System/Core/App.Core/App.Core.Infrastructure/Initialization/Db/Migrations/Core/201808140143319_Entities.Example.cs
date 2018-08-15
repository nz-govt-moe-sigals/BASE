namespace App.Core.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesExample : DbMigration
    {
        public override void Up()
        {
            DropIndex("Core.Principals", "IX_Principal_DisplayName");
            AddColumn("Core.Principals", "FullName", c => c.String(maxLength: 128));
            AlterColumn("Core.Principals", "DisplayName", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("Core.Principals", "DisplayName", c => c.String(nullable: false, maxLength: 64));
            DropColumn("Core.Principals", "FullName");
            CreateIndex("Core.Principals", "DisplayName", name: "IX_Principal_DisplayName");
        }
    }
}
