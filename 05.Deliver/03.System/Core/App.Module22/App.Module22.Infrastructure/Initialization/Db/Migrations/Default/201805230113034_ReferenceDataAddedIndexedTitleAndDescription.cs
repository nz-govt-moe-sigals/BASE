namespace App.Module22.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReferenceDataAddedIndexedTitleAndDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("Module22.CourseStatus", "Title", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module22.CourseGrades", "Title", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module22.CourseRoles", "Title", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module22.CourseRoles", "Description", c => c.String());
            AddColumn("Module22.CourseResourceTypes", "Title", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module22.CourseResourceTypes", "Description", c => c.String());
            CreateIndex("Module22.CourseStatus", "Title", name: "IX_CourseStatus_Title");
            CreateIndex("Module22.CourseGrades", "Title", name: "IX_CourseGrade_Title");
            CreateIndex("Module22.CourseRoles", "Title", name: "IX_CourseRole_Title");
            CreateIndex("Module22.CourseResourceTypes", "Title", name: "IX_CourseResourceType_Title");
            DropColumn("Module22.CourseStatus", "Text");
            DropColumn("Module22.CourseGrades", "Text");
            DropColumn("Module22.CourseRoles", "Text");
            DropColumn("Module22.CourseResourceTypes", "Text");
        }
        
        public override void Down()
        {
            AddColumn("Module22.CourseResourceTypes", "Text", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module22.CourseRoles", "Text", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module22.CourseGrades", "Text", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module22.CourseStatus", "Text", c => c.String(nullable: false, maxLength: 64));
            DropIndex("Module22.CourseResourceTypes", "IX_CourseResourceType_Title");
            DropIndex("Module22.CourseRoles", "IX_CourseRole_Title");
            DropIndex("Module22.CourseGrades", "IX_CourseGrade_Title");
            DropIndex("Module22.CourseStatus", "IX_CourseStatus_Title");
            DropColumn("Module22.CourseResourceTypes", "Description");
            DropColumn("Module22.CourseResourceTypes", "Title");
            DropColumn("Module22.CourseRoles", "Description");
            DropColumn("Module22.CourseRoles", "Title");
            DropColumn("Module22.CourseGrades", "Title");
            DropColumn("Module22.CourseStatus", "Title");
        }
    }
}
