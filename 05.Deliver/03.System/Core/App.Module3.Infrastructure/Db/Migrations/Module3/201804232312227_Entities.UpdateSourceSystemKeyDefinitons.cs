namespace App.Module3.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesUpdateSourceSystemKeyDefinitons : DbMigration
    {
        public override void Up()
        {
            AddColumn("Module3.EducationProviderLocations", "SourceSystemKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.EducationProviderLocations", "SourceSystemName", c => c.String(maxLength: 256));
            AddColumn("Module3.EducationProviderEnrolmentCounts", "SourceSystemKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.EducationProviderEnrolmentCounts", "SourceSystemName", c => c.String(maxLength: 256));
            AddColumn("Module3.EducationProviderLevelGenders", "SourceSystemKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.EducationProviderLevelGenders", "SourceSystemName", c => c.String(maxLength: 256));
            AddColumn("Module3.EducationProviderProfiles", "SourceSystemKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.EducationProviderProfiles", "SourceSystemName", c => c.String(maxLength: 256));
            AlterColumn("Module3.AreaUnits", "SourceSystemName", c => c.String(maxLength: 256));
            AlterColumn("Module3.AuthorityTypes", "SourceSystemName", c => c.String(maxLength: 256));
            AlterColumn("Module3.CommunityBoards", "SourceSystemName", c => c.String(maxLength: 256));
            AlterColumn("Module3.GeneralElectorates", "SourceSystemName", c => c.String(maxLength: 256));
            AlterColumn("Module3.MaoriElectorates", "SourceSystemName", c => c.String(maxLength: 256));
            AlterColumn("Module3.EducationProviderStatus", "SourceSystemName", c => c.String(maxLength: 256));
            AlterColumn("Module3.EducationProviderTypes", "SourceSystemName", c => c.String(maxLength: 256));
            AlterColumn("Module3.Regions", "SourceSystemName", c => c.String(maxLength: 256));
            AlterColumn("Module3.RegionalCouncils", "SourceSystemName", c => c.String(maxLength: 256));
            AlterColumn("Module3.RelationshipTypes", "SourceSystemName", c => c.String(maxLength: 256));
            AlterColumn("Module3.EducationProviderClassifications", "SourceSystemName", c => c.String(maxLength: 256));
            AlterColumn("Module3.EducationProviderGenders", "SourceSystemName", c => c.String(maxLength: 256));
            AlterColumn("Module3.EducationProviderYearLevels", "SourceSystemName", c => c.String(maxLength: 256));
            AlterColumn("Module3.SpecialSchoolings", "SourceSystemName", c => c.String(maxLength: 256));
            AlterColumn("Module3.TeacherEducations", "SourceSystemName", c => c.String(maxLength: 256));
            AlterColumn("Module3.TerritorialAuthorities", "SourceSystemName", c => c.String(maxLength: 256));
            AlterColumn("Module3.UrbanAreas", "SourceSystemName", c => c.String(maxLength: 256));
            AlterColumn("Module3.Wards", "SourceSystemName", c => c.String(maxLength: 256));
            CreateIndex("Module3.EducationProviderLocations", "SourceSystemKey", unique: true, name: "IX_EducationProviderLocation_SourceSystemKey");
            CreateIndex("Module3.EducationProviderEnrolmentCounts", "SourceSystemKey", unique: true, name: "IX_EducationProviderEnrolmentCount_SourceSystemKey");
            CreateIndex("Module3.EducationProviderLevelGenders", "SourceSystemKey", unique: true, name: "IX_EducationProviderLevelGender_SourceSystemKey");
            CreateIndex("Module3.EducationProviderProfiles", "SourceSystemKey", unique: true, name: "IX_EducationProviderProfile_SourceSystemKey");
            DropColumn("Module3.EducationProviderLocations", "SourceReferenceId");
            DropColumn("Module3.EducationProviderEnrolmentCounts", "SourceReferenceId");
            DropColumn("Module3.EducationProviderLevelGenders", "SourceReferenceId");
            DropColumn("Module3.EducationProviderProfiles", "SourceReferenceId");
        }
        
        public override void Down()
        {
            AddColumn("Module3.EducationProviderProfiles", "SourceReferenceId", c => c.Int(nullable: false));
            AddColumn("Module3.EducationProviderLevelGenders", "SourceReferenceId", c => c.Int(nullable: false));
            AddColumn("Module3.EducationProviderEnrolmentCounts", "SourceReferenceId", c => c.Int(nullable: false));
            AddColumn("Module3.EducationProviderLocations", "SourceReferenceId", c => c.Int(nullable: false));
            DropIndex("Module3.EducationProviderProfiles", "IX_EducationProviderProfile_SourceSystemKey");
            DropIndex("Module3.EducationProviderLevelGenders", "IX_EducationProviderLevelGender_SourceSystemKey");
            DropIndex("Module3.EducationProviderEnrolmentCounts", "IX_EducationProviderEnrolmentCount_SourceSystemKey");
            DropIndex("Module3.EducationProviderLocations", "IX_EducationProviderLocation_SourceSystemKey");
            AlterColumn("Module3.Wards", "SourceSystemName", c => c.String());
            AlterColumn("Module3.UrbanAreas", "SourceSystemName", c => c.String());
            AlterColumn("Module3.TerritorialAuthorities", "SourceSystemName", c => c.String());
            AlterColumn("Module3.TeacherEducations", "SourceSystemName", c => c.String());
            AlterColumn("Module3.SpecialSchoolings", "SourceSystemName", c => c.String());
            AlterColumn("Module3.EducationProviderYearLevels", "SourceSystemName", c => c.String());
            AlterColumn("Module3.EducationProviderGenders", "SourceSystemName", c => c.String());
            AlterColumn("Module3.EducationProviderClassifications", "SourceSystemName", c => c.String());
            AlterColumn("Module3.RelationshipTypes", "SourceSystemName", c => c.String());
            AlterColumn("Module3.RegionalCouncils", "SourceSystemName", c => c.String());
            AlterColumn("Module3.Regions", "SourceSystemName", c => c.String());
            AlterColumn("Module3.EducationProviderTypes", "SourceSystemName", c => c.String());
            AlterColumn("Module3.EducationProviderStatus", "SourceSystemName", c => c.String());
            AlterColumn("Module3.MaoriElectorates", "SourceSystemName", c => c.String());
            AlterColumn("Module3.GeneralElectorates", "SourceSystemName", c => c.String());
            AlterColumn("Module3.CommunityBoards", "SourceSystemName", c => c.String());
            AlterColumn("Module3.AuthorityTypes", "SourceSystemName", c => c.String());
            AlterColumn("Module3.AreaUnits", "SourceSystemName", c => c.String());
            DropColumn("Module3.EducationProviderProfiles", "SourceSystemName");
            DropColumn("Module3.EducationProviderProfiles", "SourceSystemKey");
            DropColumn("Module3.EducationProviderLevelGenders", "SourceSystemName");
            DropColumn("Module3.EducationProviderLevelGenders", "SourceSystemKey");
            DropColumn("Module3.EducationProviderEnrolmentCounts", "SourceSystemName");
            DropColumn("Module3.EducationProviderEnrolmentCounts", "SourceSystemKey");
            DropColumn("Module3.EducationProviderLocations", "SourceSystemName");
            DropColumn("Module3.EducationProviderLocations", "SourceSystemKey");
        }
    }
}
