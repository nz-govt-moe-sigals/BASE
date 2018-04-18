namespace App.Module3.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtractWatermark : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Module3.ExtractWatermarks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                        SourceTableName = c.String(nullable: false, maxLength: 255),
                        Watermark = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SourceTableName, unique: true, name: "UX_ExtractWatermark_SourceTableName");
            
        }
        
        public override void Down()
        {
            DropIndex("Module3.ExtractWatermarks", "UX_ExtractWatermark_SourceTableName");
            DropTable("Module3.ExtractWatermarks");
        }
    }
}
