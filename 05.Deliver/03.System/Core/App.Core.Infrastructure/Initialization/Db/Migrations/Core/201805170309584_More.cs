namespace App.Core.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class More : DbMigration
    {
        public override void Up()
        {
            CreateIndex("Core.DataTokens", "TenantFK", name: "IX_DataToken_TenantFK");
        }
        
        public override void Down()
        {
            DropIndex("Core.DataTokens", "IX_DataToken_TenantFK");
        }
    }
}
