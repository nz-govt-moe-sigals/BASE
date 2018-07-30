namespace App.Module32.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesPrincipalLengthUpdate : DbMigration
    {
        public override void Up()
        {
            DropIndex("Module32.EducationSchoolProfiles", "IX_EducationSchoolProfile_LastModifiedByPrincipalId");
            DropIndex("Module32.EducationStudentProfiles", "IX_EducationStudentProfile_LastModifiedByPrincipalId");
            DropIndex("Module32.ExtractWatermarks", "IX_ExtractWatermark_LastModifiedByPrincipalId");
            AlterColumn("Module32.EducationSchoolProfiles", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module32.EducationSchoolProfiles", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module32.EducationSchoolProfiles", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module32.EducationStudentProfiles", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module32.EducationStudentProfiles", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module32.EducationStudentProfiles", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module32.ExtractWatermarks", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module32.ExtractWatermarks", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module32.ExtractWatermarks", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            CreateIndex("Module32.EducationSchoolProfiles", "LastModifiedByPrincipalId", name: "IX_EducationSchoolProfile_LastModifiedByPrincipalId");
            CreateIndex("Module32.EducationStudentProfiles", "LastModifiedByPrincipalId", name: "IX_EducationStudentProfile_LastModifiedByPrincipalId");
            CreateIndex("Module32.ExtractWatermarks", "LastModifiedByPrincipalId", name: "IX_ExtractWatermark_LastModifiedByPrincipalId");

        }
        
        public override void Down()
        {
            DropIndex("Module32.ExtractWatermarks", "IX_ExtractWatermark_LastModifiedByPrincipalId");
            DropIndex("Module32.EducationStudentProfiles", "IX_EducationStudentProfile_LastModifiedByPrincipalId");
            DropIndex("Module32.EducationSchoolProfiles", "IX_EducationSchoolProfile_LastModifiedByPrincipalId");
            AlterColumn("Module32.ExtractWatermarks", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module32.ExtractWatermarks", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module32.ExtractWatermarks", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module32.EducationStudentProfiles", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module32.EducationStudentProfiles", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module32.EducationStudentProfiles", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module32.EducationSchoolProfiles", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module32.EducationSchoolProfiles", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module32.EducationSchoolProfiles", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            CreateIndex("Module32.ExtractWatermarks", "LastModifiedByPrincipalId", name: "IX_ExtractWatermark_LastModifiedByPrincipalId");
            CreateIndex("Module32.EducationStudentProfiles", "LastModifiedByPrincipalId", name: "IX_EducationStudentProfile_LastModifiedByPrincipalId");
            CreateIndex("Module32.EducationSchoolProfiles", "LastModifiedByPrincipalId", name: "IX_EducationSchoolProfile_LastModifiedByPrincipalId");
        }
    }
}
