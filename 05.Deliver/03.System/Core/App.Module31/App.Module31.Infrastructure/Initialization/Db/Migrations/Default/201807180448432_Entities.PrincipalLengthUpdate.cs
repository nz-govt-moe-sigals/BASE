namespace App.Module31.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesPrincipalLengthUpdate : DbMigration
    {
        public override void Up()
        {
            DropIndex("Module31.ExtractWatermarks", "IX_ExtractWatermark_LastModifiedByPrincipalId");
            DropIndex("Module31.AreaUnits", "IX_AreaUnit_LastModifiedByPrincipalId");
            DropIndex("Module31.AuthorityTypes", "IX_AuthorityType_LastModifiedByPrincipalId");
            DropIndex("Module31.CommunityBoards", "IX_CommunityBoard_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderLocations", "IX_EducationProviderLocation_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderProfiles", "IX_EducationProviderProfile_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderClassifications", "IX_EducationProviderClassification_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderTypes", "IX_EducationProviderType_LastModifiedByPrincipalId");
            DropIndex("Module31.GeneralElectorates", "IX_GeneralElectorate_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderLevelGenders", "IX_EducationProviderLevelGender_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderGenders", "IX_EducationProviderGender_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderYearLevels", "IX_EducationProviderYearLevel_LastModifiedByPrincipalId");
            DropIndex("Module31.MaoriElectorates", "IX_MaoriElectorate_LastModifiedByPrincipalId");
            DropIndex("Module31.Regions", "IX_Region_LastModifiedByPrincipalId");
            DropIndex("Module31.RegionalCouncils", "IX_RegionalCouncil_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderEnrolmentCounts", "IX_EducationProviderEnrolmentCount_LastModifiedByPrincipalId");
            DropIndex("Module31.SpecialSchoolings", "IX_SpecialSchooling_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderStatus", "IX_EducationProviderStatus_LastModifiedByPrincipalId");
            DropIndex("Module31.TeacherEducations", "IX_TeacherEducation_LastModifiedByPrincipalId");
            DropIndex("Module31.TerritorialAuthorities", "IX_TerritorialAuthority_LastModifiedByPrincipalId");
            DropIndex("Module31.UrbanAreas", "IX_UrbanArea_LastModifiedByPrincipalId");
            DropIndex("Module31.Wards", "IX_Ward_LastModifiedByPrincipalId");
            DropIndex("Module31.RelationshipTypes", "IX_RelationshipType_LastModifiedByPrincipalId");
            AlterColumn("Module31.ExtractWatermarks", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.ExtractWatermarks", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.ExtractWatermarks", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module31.AreaUnits", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.AreaUnits", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.AreaUnits", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module31.AuthorityTypes", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.AuthorityTypes", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.AuthorityTypes", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module31.CommunityBoards", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.CommunityBoards", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.CommunityBoards", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module31.EducationProviderLocations", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.EducationProviderLocations", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.EducationProviderLocations", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module31.EducationProviderProfiles", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.EducationProviderProfiles", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.EducationProviderProfiles", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module31.EducationProviderClassifications", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.EducationProviderClassifications", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.EducationProviderClassifications", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module31.EducationProviderTypes", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.EducationProviderTypes", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.EducationProviderTypes", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module31.GeneralElectorates", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.GeneralElectorates", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.GeneralElectorates", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module31.EducationProviderLevelGenders", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.EducationProviderLevelGenders", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.EducationProviderLevelGenders", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module31.EducationProviderGenders", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.EducationProviderGenders", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.EducationProviderGenders", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module31.EducationProviderYearLevels", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.EducationProviderYearLevels", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.EducationProviderYearLevels", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module31.MaoriElectorates", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.MaoriElectorates", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.MaoriElectorates", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module31.Regions", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.Regions", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.Regions", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module31.RegionalCouncils", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.RegionalCouncils", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.RegionalCouncils", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module31.EducationProviderEnrolmentCounts", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.EducationProviderEnrolmentCounts", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.EducationProviderEnrolmentCounts", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module31.SpecialSchoolings", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.SpecialSchoolings", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.SpecialSchoolings", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module31.EducationProviderStatus", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.EducationProviderStatus", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.EducationProviderStatus", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module31.TeacherEducations", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.TeacherEducations", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.TeacherEducations", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module31.TerritorialAuthorities", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.TerritorialAuthorities", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.TerritorialAuthorities", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module31.UrbanAreas", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.UrbanAreas", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.UrbanAreas", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module31.Wards", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.Wards", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.Wards", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module31.RelationshipTypes", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.RelationshipTypes", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module31.RelationshipTypes", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            CreateIndex("Module31.ExtractWatermarks", "LastModifiedByPrincipalId", name: "IX_ExtractWatermark_LastModifiedByPrincipalId");
            CreateIndex("Module31.AreaUnits", "LastModifiedByPrincipalId", name: "IX_AreaUnit_LastModifiedByPrincipalId");
            CreateIndex("Module31.AuthorityTypes", "LastModifiedByPrincipalId", name: "IX_AuthorityType_LastModifiedByPrincipalId");
            CreateIndex("Module31.CommunityBoards", "LastModifiedByPrincipalId", name: "IX_CommunityBoard_LastModifiedByPrincipalId");
            CreateIndex("Module31.EducationProviderLocations", "LastModifiedByPrincipalId", name: "IX_EducationProviderLocation_LastModifiedByPrincipalId");
            CreateIndex("Module31.EducationProviderProfiles", "LastModifiedByPrincipalId", name: "IX_EducationProviderProfile_LastModifiedByPrincipalId");
            CreateIndex("Module31.EducationProviderClassifications", "LastModifiedByPrincipalId", name: "IX_EducationProviderClassification_LastModifiedByPrincipalId");
            CreateIndex("Module31.EducationProviderTypes", "LastModifiedByPrincipalId", name: "IX_EducationProviderType_LastModifiedByPrincipalId");
            CreateIndex("Module31.GeneralElectorates", "LastModifiedByPrincipalId", name: "IX_GeneralElectorate_LastModifiedByPrincipalId");
            CreateIndex("Module31.EducationProviderLevelGenders", "LastModifiedByPrincipalId", name: "IX_EducationProviderLevelGender_LastModifiedByPrincipalId");
            CreateIndex("Module31.EducationProviderGenders", "LastModifiedByPrincipalId", name: "IX_EducationProviderGender_LastModifiedByPrincipalId");
            CreateIndex("Module31.EducationProviderYearLevels", "LastModifiedByPrincipalId", name: "IX_EducationProviderYearLevel_LastModifiedByPrincipalId");
            CreateIndex("Module31.MaoriElectorates", "LastModifiedByPrincipalId", name: "IX_MaoriElectorate_LastModifiedByPrincipalId");
            CreateIndex("Module31.Regions", "LastModifiedByPrincipalId", name: "IX_Region_LastModifiedByPrincipalId");
            CreateIndex("Module31.RegionalCouncils", "LastModifiedByPrincipalId", name: "IX_RegionalCouncil_LastModifiedByPrincipalId");
            CreateIndex("Module31.EducationProviderEnrolmentCounts", "LastModifiedByPrincipalId", name: "IX_EducationProviderEnrolmentCount_LastModifiedByPrincipalId");
            CreateIndex("Module31.SpecialSchoolings", "LastModifiedByPrincipalId", name: "IX_SpecialSchooling_LastModifiedByPrincipalId");
            CreateIndex("Module31.EducationProviderStatus", "LastModifiedByPrincipalId", name: "IX_EducationProviderStatus_LastModifiedByPrincipalId");
            CreateIndex("Module31.TeacherEducations", "LastModifiedByPrincipalId", name: "IX_TeacherEducation_LastModifiedByPrincipalId");
            CreateIndex("Module31.TerritorialAuthorities", "LastModifiedByPrincipalId", name: "IX_TerritorialAuthority_LastModifiedByPrincipalId");
            CreateIndex("Module31.UrbanAreas", "LastModifiedByPrincipalId", name: "IX_UrbanArea_LastModifiedByPrincipalId");
            CreateIndex("Module31.Wards", "LastModifiedByPrincipalId", name: "IX_Ward_LastModifiedByPrincipalId");
            CreateIndex("Module31.RelationshipTypes", "LastModifiedByPrincipalId", name: "IX_RelationshipType_LastModifiedByPrincipalId");
        }
        
        public override void Down()
        {
            DropIndex("Module31.RelationshipTypes", "IX_RelationshipType_LastModifiedByPrincipalId");
            DropIndex("Module31.Wards", "IX_Ward_LastModifiedByPrincipalId");
            DropIndex("Module31.UrbanAreas", "IX_UrbanArea_LastModifiedByPrincipalId");
            DropIndex("Module31.TerritorialAuthorities", "IX_TerritorialAuthority_LastModifiedByPrincipalId");
            DropIndex("Module31.TeacherEducations", "IX_TeacherEducation_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderStatus", "IX_EducationProviderStatus_LastModifiedByPrincipalId");
            DropIndex("Module31.SpecialSchoolings", "IX_SpecialSchooling_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderEnrolmentCounts", "IX_EducationProviderEnrolmentCount_LastModifiedByPrincipalId");
            DropIndex("Module31.RegionalCouncils", "IX_RegionalCouncil_LastModifiedByPrincipalId");
            DropIndex("Module31.Regions", "IX_Region_LastModifiedByPrincipalId");
            DropIndex("Module31.MaoriElectorates", "IX_MaoriElectorate_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderYearLevels", "IX_EducationProviderYearLevel_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderGenders", "IX_EducationProviderGender_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderLevelGenders", "IX_EducationProviderLevelGender_LastModifiedByPrincipalId");
            DropIndex("Module31.GeneralElectorates", "IX_GeneralElectorate_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderTypes", "IX_EducationProviderType_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderClassifications", "IX_EducationProviderClassification_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderProfiles", "IX_EducationProviderProfile_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderLocations", "IX_EducationProviderLocation_LastModifiedByPrincipalId");
            DropIndex("Module31.CommunityBoards", "IX_CommunityBoard_LastModifiedByPrincipalId");
            DropIndex("Module31.AuthorityTypes", "IX_AuthorityType_LastModifiedByPrincipalId");
            DropIndex("Module31.AreaUnits", "IX_AreaUnit_LastModifiedByPrincipalId");
            DropIndex("Module31.ExtractWatermarks", "IX_ExtractWatermark_LastModifiedByPrincipalId");
            AlterColumn("Module31.RelationshipTypes", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module31.RelationshipTypes", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.RelationshipTypes", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.Wards", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module31.Wards", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.Wards", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.UrbanAreas", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module31.UrbanAreas", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.UrbanAreas", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.TerritorialAuthorities", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module31.TerritorialAuthorities", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.TerritorialAuthorities", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.TeacherEducations", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module31.TeacherEducations", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.TeacherEducations", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.EducationProviderStatus", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module31.EducationProviderStatus", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.EducationProviderStatus", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.SpecialSchoolings", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module31.SpecialSchoolings", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.SpecialSchoolings", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.EducationProviderEnrolmentCounts", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module31.EducationProviderEnrolmentCounts", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.EducationProviderEnrolmentCounts", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.RegionalCouncils", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module31.RegionalCouncils", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.RegionalCouncils", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.Regions", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module31.Regions", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.Regions", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.MaoriElectorates", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module31.MaoriElectorates", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.MaoriElectorates", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.EducationProviderYearLevels", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module31.EducationProviderYearLevels", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.EducationProviderYearLevels", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.EducationProviderGenders", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module31.EducationProviderGenders", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.EducationProviderGenders", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.EducationProviderLevelGenders", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module31.EducationProviderLevelGenders", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.EducationProviderLevelGenders", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.GeneralElectorates", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module31.GeneralElectorates", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.GeneralElectorates", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.EducationProviderTypes", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module31.EducationProviderTypes", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.EducationProviderTypes", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.EducationProviderClassifications", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module31.EducationProviderClassifications", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.EducationProviderClassifications", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.EducationProviderProfiles", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module31.EducationProviderProfiles", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.EducationProviderProfiles", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.EducationProviderLocations", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module31.EducationProviderLocations", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.EducationProviderLocations", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.CommunityBoards", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module31.CommunityBoards", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.CommunityBoards", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.AuthorityTypes", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module31.AuthorityTypes", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.AuthorityTypes", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.AreaUnits", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module31.AreaUnits", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.AreaUnits", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.ExtractWatermarks", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module31.ExtractWatermarks", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module31.ExtractWatermarks", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            CreateIndex("Module31.RelationshipTypes", "LastModifiedByPrincipalId", name: "IX_RelationshipType_LastModifiedByPrincipalId");
            CreateIndex("Module31.Wards", "LastModifiedByPrincipalId", name: "IX_Ward_LastModifiedByPrincipalId");
            CreateIndex("Module31.UrbanAreas", "LastModifiedByPrincipalId", name: "IX_UrbanArea_LastModifiedByPrincipalId");
            CreateIndex("Module31.TerritorialAuthorities", "LastModifiedByPrincipalId", name: "IX_TerritorialAuthority_LastModifiedByPrincipalId");
            CreateIndex("Module31.TeacherEducations", "LastModifiedByPrincipalId", name: "IX_TeacherEducation_LastModifiedByPrincipalId");
            CreateIndex("Module31.EducationProviderStatus", "LastModifiedByPrincipalId", name: "IX_EducationProviderStatus_LastModifiedByPrincipalId");
            CreateIndex("Module31.SpecialSchoolings", "LastModifiedByPrincipalId", name: "IX_SpecialSchooling_LastModifiedByPrincipalId");
            CreateIndex("Module31.EducationProviderEnrolmentCounts", "LastModifiedByPrincipalId", name: "IX_EducationProviderEnrolmentCount_LastModifiedByPrincipalId");
            CreateIndex("Module31.RegionalCouncils", "LastModifiedByPrincipalId", name: "IX_RegionalCouncil_LastModifiedByPrincipalId");
            CreateIndex("Module31.Regions", "LastModifiedByPrincipalId", name: "IX_Region_LastModifiedByPrincipalId");
            CreateIndex("Module31.MaoriElectorates", "LastModifiedByPrincipalId", name: "IX_MaoriElectorate_LastModifiedByPrincipalId");
            CreateIndex("Module31.EducationProviderYearLevels", "LastModifiedByPrincipalId", name: "IX_EducationProviderYearLevel_LastModifiedByPrincipalId");
            CreateIndex("Module31.EducationProviderGenders", "LastModifiedByPrincipalId", name: "IX_EducationProviderGender_LastModifiedByPrincipalId");
            CreateIndex("Module31.EducationProviderLevelGenders", "LastModifiedByPrincipalId", name: "IX_EducationProviderLevelGender_LastModifiedByPrincipalId");
            CreateIndex("Module31.GeneralElectorates", "LastModifiedByPrincipalId", name: "IX_GeneralElectorate_LastModifiedByPrincipalId");
            CreateIndex("Module31.EducationProviderTypes", "LastModifiedByPrincipalId", name: "IX_EducationProviderType_LastModifiedByPrincipalId");
            CreateIndex("Module31.EducationProviderClassifications", "LastModifiedByPrincipalId", name: "IX_EducationProviderClassification_LastModifiedByPrincipalId");
            CreateIndex("Module31.EducationProviderProfiles", "LastModifiedByPrincipalId", name: "IX_EducationProviderProfile_LastModifiedByPrincipalId");
            CreateIndex("Module31.EducationProviderLocations", "LastModifiedByPrincipalId", name: "IX_EducationProviderLocation_LastModifiedByPrincipalId");
            CreateIndex("Module31.CommunityBoards", "LastModifiedByPrincipalId", name: "IX_CommunityBoard_LastModifiedByPrincipalId");
            CreateIndex("Module31.AuthorityTypes", "LastModifiedByPrincipalId", name: "IX_AuthorityType_LastModifiedByPrincipalId");
            CreateIndex("Module31.AreaUnits", "LastModifiedByPrincipalId", name: "IX_AreaUnit_LastModifiedByPrincipalId");
            CreateIndex("Module31.ExtractWatermarks", "LastModifiedByPrincipalId", name: "IX_ExtractWatermark_LastModifiedByPrincipalId");
        }
    }
}