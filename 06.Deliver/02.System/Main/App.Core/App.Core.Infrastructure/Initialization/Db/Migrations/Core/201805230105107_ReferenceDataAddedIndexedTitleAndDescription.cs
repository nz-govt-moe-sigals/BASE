namespace App.Core.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReferenceDataAddedIndexedTitleAndDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("Core.DataClassifications", "Title", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Core.DataClassifications", "Description", c => c.String());
            AlterColumn("Core.DataClassifications", "DisplayOrderHint", c => c.Int(nullable: false));
            AlterColumn("Core.PrincipalCategories", "Text", c => c.String());
            AlterColumn("Core.PrincipalCategories", "DisplayStyleHint", c => c.String());
            CreateIndex("Core.DataClassifications", "Title", name: "IX_DataClassification_Title");
            DropColumn("Core.DataClassifications", "Text");
        }
        
        public override void Down()
        {
            AddColumn("Core.DataClassifications", "Text", c => c.String(nullable: false, maxLength: 64));
            DropIndex("Core.DataClassifications", "IX_DataClassification_Title");
            AlterColumn("Core.PrincipalCategories", "DisplayStyleHint", c => c.String(maxLength: 64));
            AlterColumn("Core.PrincipalCategories", "Text", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("Core.DataClassifications", "DisplayOrderHint", c => c.Int());
            DropColumn("Core.DataClassifications", "Description");
            DropColumn("Core.DataClassifications", "Title");
        }
    }
}
