namespace App.Core.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesSessionAlteration : DbMigration
    {
        public override void Up()
        {
            Sql("Delete from Core.SessionOperations");
            Sql("Delete from Core.Sessions");
            DropForeignKey("Core.SessionOperations", "SessionFK", "Core.Sessions");
            DropIndex("Core.SessionOperations", new[] { "SessionFK" });
            AddColumn("Core.Sessions", "UniqueIdentifier", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("Core.SessionOperations", "SessionFK", c => c.Guid());
            CreateIndex("Core.SessionOperations", "SessionFK");
            CreateIndex("Core.Sessions", "UniqueIdentifier", unique: true, name: "IX_Session_UniqueIdentifier");
            AddForeignKey("Core.SessionOperations", "SessionFK", "Core.Sessions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("Core.SessionOperations", "SessionFK", "Core.Sessions");
            DropIndex("Core.Sessions", "IX_Session_UniqueIdentifier");
            DropIndex("Core.SessionOperations", new[] { "SessionFK" });
            AlterColumn("Core.SessionOperations", "SessionFK", c => c.Guid(nullable: false));
            DropColumn("Core.Sessions", "UniqueIdentifier");
            CreateIndex("Core.SessionOperations", "SessionFK");
            AddForeignKey("Core.SessionOperations", "SessionFK", "Core.Sessions", "Id", cascadeDelete: true);
        }
    }
}
