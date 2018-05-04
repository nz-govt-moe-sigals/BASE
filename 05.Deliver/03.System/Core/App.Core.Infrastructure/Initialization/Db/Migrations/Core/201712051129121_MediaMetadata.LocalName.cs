namespace App.Core.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MediaMetadataLocalName : DbMigration
    {
        public override void Up()
        {
            DropIndex("Core.MediaMetadatas", "IX_MediaMetadata_LocalFileName");
            AlterColumn("Core.MediaMetadatas", "LocalName", c => c.String(maxLength: 256));
            CreateIndex("Core.MediaMetadatas", "LocalName", unique: true, name: "IX_MediaMetadata_LocalFileName");
        }
        
        public override void Down()
        {
            DropIndex("Core.MediaMetadatas", "IX_MediaMetadata_LocalFileName");
            AlterColumn("Core.MediaMetadatas", "LocalName", c => c.String(nullable: false, maxLength: 256));
            CreateIndex("Core.MediaMetadatas", "LocalName", unique: true, name: "IX_MediaMetadata_LocalFileName");
        }
    }
}
