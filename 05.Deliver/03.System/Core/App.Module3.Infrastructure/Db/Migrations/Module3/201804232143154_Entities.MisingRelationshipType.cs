namespace App.Module3.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesMisingRelationshipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Module3.RelationshipTypes",
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
                        TenantFK = c.Guid(nullable: false),
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SIFKey = c.String(nullable: false, maxLength: 10),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                        SourceSystemName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_RelationshipType_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_RelationshipType_SIFKey");
            
        }
        
        public override void Down()
        {
            DropIndex("Module3.RelationshipTypes", "IX_RelationshipType_SIFKey");
            DropIndex("Module3.RelationshipTypes", "IX_RelationshipType_FIRSTKey");
            DropTable("Module3.RelationshipTypes");
        }
    }
}
