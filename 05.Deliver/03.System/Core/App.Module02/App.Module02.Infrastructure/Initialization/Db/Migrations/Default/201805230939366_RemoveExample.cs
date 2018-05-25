namespace App.Module02.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveExample : DbMigration
    {
        public override void Up()
        {
            DropIndex("Module02.Examples", "IX_Example_TenantFK");
            DropIndex("Module02.Examples", "IX_Example_RecordState");
            DropIndex("Module02.Examples", "IX_Example_LastModifiedOnUtc");
            DropIndex("Module02.Examples", "IX_Example_LastModifiedByPrincipalId");
            DropTable("Module02.Examples");
        }
        
        public override void Down()
        {
            CreateTable(
                "Module02.Examples",
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
                        Owner = c.String(nullable: false),
                        PublicText = c.String(nullable: false),
                        SensitiveText = c.String(),
                        AppPrivateText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("Module02.Examples", "LastModifiedByPrincipalId", name: "IX_Example_LastModifiedByPrincipalId");
            CreateIndex("Module02.Examples", "LastModifiedOnUtc", name: "IX_Example_LastModifiedOnUtc");
            CreateIndex("Module02.Examples", "RecordState", name: "IX_Example_RecordState");
            CreateIndex("Module02.Examples", "TenantFK", name: "IX_Example_TenantFK");
        }
    }
}
