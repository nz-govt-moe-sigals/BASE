namespace App.Module3.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesSourceAndSIFKeys : DbMigration
    {
        public override void Up()
        {
            DropIndex("Module3.AreaUnits", "IX_AreaUnit_SIFKey");
            DropIndex("Module3.AreaUnits", "IX_AreaUnit_FIRSTKey");
            DropIndex("Module3.AuthorityTypes", "IX_AuthorityType_SIFKey");
            DropIndex("Module3.AuthorityTypes", "IX_AuthorityType_FIRSTKey");
            DropIndex("Module3.CommunityBoards", "IX_CommunityBoard_SIFKey");
            DropIndex("Module3.CommunityBoards", "IX_CommunityBoard_FIRSTKey");
            DropIndex("Module3.GeneralElectorates", "IX_GeneralElectorate_SIFKey");
            DropIndex("Module3.GeneralElectorates", "IX_GeneralElectorate_FIRSTKey");
            DropIndex("Module3.MaoriElectorates", "IX_MaoriElectorate_SIFKey");
            DropIndex("Module3.MaoriElectorates", "IX_MaoriElectorate_FIRSTKey");
            DropIndex("Module3.EducationProviderStatus", "IX_EducationProviderStatus_SIFKey");
            DropIndex("Module3.EducationProviderStatus", "IX_EducationProviderStatus_FIRSTKey");
            DropIndex("Module3.EducationProviderTypes", "IX_EducationProviderType_SIFKey");
            DropIndex("Module3.EducationProviderTypes", "IX_EducationProviderType_FIRSTKey");
            DropIndex("Module3.Regions", "IX_Region_SIFKey");
            DropIndex("Module3.Regions", "IX_Region_FIRSTKey");
            DropIndex("Module3.RegionalCouncils", "IX_RegionalCouncil_SIFKey");
            DropIndex("Module3.RegionalCouncils", "IX_RegionalCouncil_FIRSTKey");
            DropIndex("Module3.EducationProviderGenders", "IX_EducationProviderGender_SIFKey");
            DropIndex("Module3.EducationProviderGenders", "IX_EducationProviderGender_FIRSTKey");
            DropIndex("Module3.EducationProviderClassifications", "IX_EducationProviderClassification_SIFKey");
            DropIndex("Module3.EducationProviderClassifications", "IX_EducationProviderClassification_FIRSTKey");
            DropIndex("Module3.EducationProviderYearLevels", "IX_EducationProviderYearLevel_SIFKey");
            DropIndex("Module3.EducationProviderYearLevels", "IX_EducationProviderYearLevel_FIRSTKey");
            DropIndex("Module3.SpecialSchoolings", "IX_SpecialSchooling_SIFKey");
            DropIndex("Module3.SpecialSchoolings", "IX_SpecialSchooling_FIRSTKey");
            DropIndex("Module3.TeacherEducations", "IX_TeacherEducation_SIFKey");
            DropIndex("Module3.TeacherEducations", "IX_TeacherEducation_FIRSTKey");
            DropIndex("Module3.TerritorialAuthorities", "IX_TerritorialAuthority_SIFKey");
            DropIndex("Module3.TerritorialAuthorities", "IX_TerritorialAuthority_FIRSTKey");
            DropIndex("Module3.UrbanAreas", "IX_UrbanArea_SIFKey");
            DropIndex("Module3.UrbanAreas", "IX_UrbanArea_FIRSTKey");
            DropIndex("Module3.Wards", "IX_Ward_SIFKey");
            DropIndex("Module3.Wards", "IX_Ward_FIRSTKey");
            AddColumn("Module3.AreaUnits", "SourceSystemKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.AreaUnits", "SourceSystemName", c => c.String());
            AddColumn("Module3.AuthorityTypes", "SourceSystemKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.AuthorityTypes", "SourceSystemName", c => c.String());
            AddColumn("Module3.CommunityBoards", "SourceSystemKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.CommunityBoards", "SourceSystemName", c => c.String());
            AddColumn("Module3.GeneralElectorates", "SourceSystemKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.GeneralElectorates", "SourceSystemName", c => c.String());
            AddColumn("Module3.MaoriElectorates", "SourceSystemKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.MaoriElectorates", "SourceSystemName", c => c.String());
            AddColumn("Module3.EducationProviderStatus", "SourceSystemKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.EducationProviderStatus", "SourceSystemName", c => c.String());
            AddColumn("Module3.EducationProviderTypes", "SourceSystemKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.EducationProviderTypes", "SourceSystemName", c => c.String());
            AddColumn("Module3.Regions", "SourceSystemKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.Regions", "SourceSystemName", c => c.String());
            AddColumn("Module3.RegionalCouncils", "SourceSystemKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.RegionalCouncils", "SourceSystemName", c => c.String());
            AddColumn("Module3.EducationProviderGenders", "SourceSystemKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.EducationProviderGenders", "SourceSystemName", c => c.String());
            AddColumn("Module3.EducationProviderClassifications", "SourceSystemKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.EducationProviderClassifications", "SourceSystemName", c => c.String());
            AddColumn("Module3.EducationProviderYearLevels", "SourceSystemKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.EducationProviderYearLevels", "SourceSystemName", c => c.String());
            AddColumn("Module3.SpecialSchoolings", "SourceSystemKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.SpecialSchoolings", "SourceSystemName", c => c.String());
            AddColumn("Module3.TeacherEducations", "SourceSystemKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.TeacherEducations", "SourceSystemName", c => c.String());
            AddColumn("Module3.TerritorialAuthorities", "SourceSystemKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.TerritorialAuthorities", "SourceSystemName", c => c.String());
            AddColumn("Module3.UrbanAreas", "SourceSystemKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.UrbanAreas", "SourceSystemName", c => c.String());
            AddColumn("Module3.Wards", "SourceSystemKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.Wards", "SourceSystemName", c => c.String());
            AddColumn("Module3.CoLs", "SourceSystemName", c => c.String());
            AddColumn("Module3.CoLs", "SourceSystemKey", c => c.String());
            AddColumn("Module3.LocalOffices", "SourceSystemName", c => c.String());
            AddColumn("Module3.LocalOffices", "SourceSystemKey", c => c.String());
            AlterColumn("Module3.AreaUnits", "SIFKey", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("Module3.AuthorityTypes", "SIFKey", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("Module3.CommunityBoards", "SIFKey", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("Module3.GeneralElectorates", "SIFKey", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("Module3.MaoriElectorates", "SIFKey", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("Module3.EducationProviderStatus", "SIFKey", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("Module3.EducationProviderTypes", "SIFKey", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("Module3.Regions", "SIFKey", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("Module3.RegionalCouncils", "SIFKey", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("Module3.EducationProviderGenders", "SIFKey", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("Module3.EducationProviderClassifications", "SIFKey", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("Module3.EducationProviderYearLevels", "SIFKey", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("Module3.SpecialSchoolings", "SIFKey", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("Module3.TeacherEducations", "SIFKey", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("Module3.TerritorialAuthorities", "SIFKey", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("Module3.UrbanAreas", "SIFKey", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("Module3.Wards", "SIFKey", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("Module3.CoLs", "SIFKey", c => c.String());
            AlterColumn("Module3.LocalOffices", "SIFKey", c => c.String());
            CreateIndex("Module3.AreaUnits", "SourceSystemKey", unique: true, name: "IX_AreaUnit_FIRSTKey");
            CreateIndex("Module3.AreaUnits", "SIFKey", unique: true, name: "IX_AreaUnit_SIFKey");
            CreateIndex("Module3.AuthorityTypes", "SourceSystemKey", unique: true, name: "IX_AuthorityType_FIRSTKey");
            CreateIndex("Module3.AuthorityTypes", "SIFKey", unique: true, name: "IX_AuthorityType_SIFKey");
            CreateIndex("Module3.CommunityBoards", "SourceSystemKey", unique: true, name: "IX_CommunityBoard_FIRSTKey");
            CreateIndex("Module3.CommunityBoards", "SIFKey", unique: true, name: "IX_CommunityBoard_SIFKey");
            CreateIndex("Module3.GeneralElectorates", "SourceSystemKey", unique: true, name: "IX_GeneralElectorate_FIRSTKey");
            CreateIndex("Module3.GeneralElectorates", "SIFKey", unique: true, name: "IX_GeneralElectorate_SIFKey");
            CreateIndex("Module3.MaoriElectorates", "SourceSystemKey", unique: true, name: "IX_MaoriElectorate_FIRSTKey");
            CreateIndex("Module3.MaoriElectorates", "SIFKey", unique: true, name: "IX_MaoriElectorate_SIFKey");
            CreateIndex("Module3.EducationProviderStatus", "SourceSystemKey", unique: true, name: "IX_EducationProviderStatus_FIRSTKey");
            CreateIndex("Module3.EducationProviderStatus", "SIFKey", unique: true, name: "IX_EducationProviderStatus_SIFKey");
            CreateIndex("Module3.EducationProviderTypes", "SourceSystemKey", unique: true, name: "IX_EducationProviderType_FIRSTKey");
            CreateIndex("Module3.EducationProviderTypes", "SIFKey", unique: true, name: "IX_EducationProviderType_SIFKey");
            CreateIndex("Module3.Regions", "SourceSystemKey", unique: true, name: "IX_Region_FIRSTKey");
            CreateIndex("Module3.Regions", "SIFKey", unique: true, name: "IX_Region_SIFKey");
            CreateIndex("Module3.RegionalCouncils", "SourceSystemKey", unique: true, name: "IX_RegionalCouncil_FIRSTKey");
            CreateIndex("Module3.RegionalCouncils", "SIFKey", unique: true, name: "IX_RegionalCouncil_SIFKey");
            CreateIndex("Module3.EducationProviderGenders", "SourceSystemKey", unique: true, name: "IX_EducationProviderGender_FIRSTKey");
            CreateIndex("Module3.EducationProviderGenders", "SIFKey", unique: true, name: "IX_EducationProviderGender_SIFKey");
            CreateIndex("Module3.EducationProviderClassifications", "SourceSystemKey", unique: true, name: "IX_EducationProviderClassification_FIRSTKey");
            CreateIndex("Module3.EducationProviderClassifications", "SIFKey", unique: true, name: "IX_EducationProviderClassification_SIFKey");
            CreateIndex("Module3.EducationProviderYearLevels", "SourceSystemKey", unique: true, name: "IX_EducationProviderYearLevel_FIRSTKey");
            CreateIndex("Module3.EducationProviderYearLevels", "SIFKey", unique: true, name: "IX_EducationProviderYearLevel_SIFKey");
            CreateIndex("Module3.SpecialSchoolings", "SourceSystemKey", unique: true, name: "IX_SpecialSchooling_FIRSTKey");
            CreateIndex("Module3.SpecialSchoolings", "SIFKey", unique: true, name: "IX_SpecialSchooling_SIFKey");
            CreateIndex("Module3.TeacherEducations", "SourceSystemKey", unique: true, name: "IX_TeacherEducation_FIRSTKey");
            CreateIndex("Module3.TeacherEducations", "SIFKey", unique: true, name: "IX_TeacherEducation_SIFKey");
            CreateIndex("Module3.TerritorialAuthorities", "SourceSystemKey", unique: true, name: "IX_TerritorialAuthority_FIRSTKey");
            CreateIndex("Module3.TerritorialAuthorities", "SIFKey", unique: true, name: "IX_TerritorialAuthority_SIFKey");
            CreateIndex("Module3.UrbanAreas", "SourceSystemKey", unique: true, name: "IX_UrbanArea_FIRSTKey");
            CreateIndex("Module3.UrbanAreas", "SIFKey", unique: true, name: "IX_UrbanArea_SIFKey");
            CreateIndex("Module3.Wards", "SourceSystemKey", unique: true, name: "IX_Ward_FIRSTKey");
            CreateIndex("Module3.Wards", "SIFKey", unique: true, name: "IX_Ward_SIFKey");
            DropColumn("Module3.AreaUnits", "FIRSTKey");
            DropColumn("Module3.AuthorityTypes", "FIRSTKey");
            DropColumn("Module3.CommunityBoards", "FIRSTKey");
            DropColumn("Module3.GeneralElectorates", "FIRSTKey");
            DropColumn("Module3.MaoriElectorates", "FIRSTKey");
            DropColumn("Module3.EducationProviderStatus", "FIRSTKey");
            DropColumn("Module3.EducationProviderTypes", "FIRSTKey");
            DropColumn("Module3.Regions", "FIRSTKey");
            DropColumn("Module3.RegionalCouncils", "FIRSTKey");
            DropColumn("Module3.EducationProviderGenders", "FIRSTKey");
            DropColumn("Module3.EducationProviderClassifications", "FIRSTKey");
            DropColumn("Module3.EducationProviderYearLevels", "FIRSTKey");
            DropColumn("Module3.SpecialSchoolings", "FIRSTKey");
            DropColumn("Module3.TeacherEducations", "FIRSTKey");
            DropColumn("Module3.TerritorialAuthorities", "FIRSTKey");
            DropColumn("Module3.UrbanAreas", "FIRSTKey");
            DropColumn("Module3.Wards", "FIRSTKey");
            DropColumn("Module3.CoLs", "FIRSTKey");
            DropColumn("Module3.LocalOffices", "FIRSTKey");
        }
        
        public override void Down()
        {
            AddColumn("Module3.LocalOffices", "FIRSTKey", c => c.String());
            AddColumn("Module3.CoLs", "FIRSTKey", c => c.String());
            AddColumn("Module3.Wards", "FIRSTKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.UrbanAreas", "FIRSTKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.TerritorialAuthorities", "FIRSTKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.TeacherEducations", "FIRSTKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.SpecialSchoolings", "FIRSTKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.EducationProviderYearLevels", "FIRSTKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.EducationProviderClassifications", "FIRSTKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.EducationProviderGenders", "FIRSTKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.RegionalCouncils", "FIRSTKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.Regions", "FIRSTKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.EducationProviderTypes", "FIRSTKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.EducationProviderStatus", "FIRSTKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.MaoriElectorates", "FIRSTKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.GeneralElectorates", "FIRSTKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.CommunityBoards", "FIRSTKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.AuthorityTypes", "FIRSTKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Module3.AreaUnits", "FIRSTKey", c => c.String(nullable: false, maxLength: 10));
            DropIndex("Module3.Wards", "IX_Ward_SIFKey");
            DropIndex("Module3.Wards", "IX_Ward_FIRSTKey");
            DropIndex("Module3.UrbanAreas", "IX_UrbanArea_SIFKey");
            DropIndex("Module3.UrbanAreas", "IX_UrbanArea_FIRSTKey");
            DropIndex("Module3.TerritorialAuthorities", "IX_TerritorialAuthority_SIFKey");
            DropIndex("Module3.TerritorialAuthorities", "IX_TerritorialAuthority_FIRSTKey");
            DropIndex("Module3.TeacherEducations", "IX_TeacherEducation_SIFKey");
            DropIndex("Module3.TeacherEducations", "IX_TeacherEducation_FIRSTKey");
            DropIndex("Module3.SpecialSchoolings", "IX_SpecialSchooling_SIFKey");
            DropIndex("Module3.SpecialSchoolings", "IX_SpecialSchooling_FIRSTKey");
            DropIndex("Module3.EducationProviderYearLevels", "IX_EducationProviderYearLevel_SIFKey");
            DropIndex("Module3.EducationProviderYearLevels", "IX_EducationProviderYearLevel_FIRSTKey");
            DropIndex("Module3.EducationProviderClassifications", "IX_EducationProviderClassification_SIFKey");
            DropIndex("Module3.EducationProviderClassifications", "IX_EducationProviderClassification_FIRSTKey");
            DropIndex("Module3.EducationProviderGenders", "IX_EducationProviderGender_SIFKey");
            DropIndex("Module3.EducationProviderGenders", "IX_EducationProviderGender_FIRSTKey");
            DropIndex("Module3.RegionalCouncils", "IX_RegionalCouncil_SIFKey");
            DropIndex("Module3.RegionalCouncils", "IX_RegionalCouncil_FIRSTKey");
            DropIndex("Module3.Regions", "IX_Region_SIFKey");
            DropIndex("Module3.Regions", "IX_Region_FIRSTKey");
            DropIndex("Module3.EducationProviderTypes", "IX_EducationProviderType_SIFKey");
            DropIndex("Module3.EducationProviderTypes", "IX_EducationProviderType_FIRSTKey");
            DropIndex("Module3.EducationProviderStatus", "IX_EducationProviderStatus_SIFKey");
            DropIndex("Module3.EducationProviderStatus", "IX_EducationProviderStatus_FIRSTKey");
            DropIndex("Module3.MaoriElectorates", "IX_MaoriElectorate_SIFKey");
            DropIndex("Module3.MaoriElectorates", "IX_MaoriElectorate_FIRSTKey");
            DropIndex("Module3.GeneralElectorates", "IX_GeneralElectorate_SIFKey");
            DropIndex("Module3.GeneralElectorates", "IX_GeneralElectorate_FIRSTKey");
            DropIndex("Module3.CommunityBoards", "IX_CommunityBoard_SIFKey");
            DropIndex("Module3.CommunityBoards", "IX_CommunityBoard_FIRSTKey");
            DropIndex("Module3.AuthorityTypes", "IX_AuthorityType_SIFKey");
            DropIndex("Module3.AuthorityTypes", "IX_AuthorityType_FIRSTKey");
            DropIndex("Module3.AreaUnits", "IX_AreaUnit_SIFKey");
            DropIndex("Module3.AreaUnits", "IX_AreaUnit_FIRSTKey");
            AlterColumn("Module3.LocalOffices", "SIFKey", c => c.Int(nullable: false));
            AlterColumn("Module3.CoLs", "SIFKey", c => c.Int(nullable: false));
            AlterColumn("Module3.Wards", "SIFKey", c => c.Int(nullable: false));
            AlterColumn("Module3.UrbanAreas", "SIFKey", c => c.Int(nullable: false));
            AlterColumn("Module3.TerritorialAuthorities", "SIFKey", c => c.Int(nullable: false));
            AlterColumn("Module3.TeacherEducations", "SIFKey", c => c.Int(nullable: false));
            AlterColumn("Module3.SpecialSchoolings", "SIFKey", c => c.Int(nullable: false));
            AlterColumn("Module3.EducationProviderYearLevels", "SIFKey", c => c.Int(nullable: false));
            AlterColumn("Module3.EducationProviderClassifications", "SIFKey", c => c.Int(nullable: false));
            AlterColumn("Module3.EducationProviderGenders", "SIFKey", c => c.Int(nullable: false));
            AlterColumn("Module3.RegionalCouncils", "SIFKey", c => c.Int(nullable: false));
            AlterColumn("Module3.Regions", "SIFKey", c => c.Int(nullable: false));
            AlterColumn("Module3.EducationProviderTypes", "SIFKey", c => c.Int(nullable: false));
            AlterColumn("Module3.EducationProviderStatus", "SIFKey", c => c.Int(nullable: false));
            AlterColumn("Module3.MaoriElectorates", "SIFKey", c => c.Int(nullable: false));
            AlterColumn("Module3.GeneralElectorates", "SIFKey", c => c.Int(nullable: false));
            AlterColumn("Module3.CommunityBoards", "SIFKey", c => c.Int(nullable: false));
            AlterColumn("Module3.AuthorityTypes", "SIFKey", c => c.Int(nullable: false));
            AlterColumn("Module3.AreaUnits", "SIFKey", c => c.Int(nullable: false));
            DropColumn("Module3.LocalOffices", "SourceSystemKey");
            DropColumn("Module3.LocalOffices", "SourceSystemName");
            DropColumn("Module3.CoLs", "SourceSystemKey");
            DropColumn("Module3.CoLs", "SourceSystemName");
            DropColumn("Module3.Wards", "SourceSystemName");
            DropColumn("Module3.Wards", "SourceSystemKey");
            DropColumn("Module3.UrbanAreas", "SourceSystemName");
            DropColumn("Module3.UrbanAreas", "SourceSystemKey");
            DropColumn("Module3.TerritorialAuthorities", "SourceSystemName");
            DropColumn("Module3.TerritorialAuthorities", "SourceSystemKey");
            DropColumn("Module3.TeacherEducations", "SourceSystemName");
            DropColumn("Module3.TeacherEducations", "SourceSystemKey");
            DropColumn("Module3.SpecialSchoolings", "SourceSystemName");
            DropColumn("Module3.SpecialSchoolings", "SourceSystemKey");
            DropColumn("Module3.EducationProviderYearLevels", "SourceSystemName");
            DropColumn("Module3.EducationProviderYearLevels", "SourceSystemKey");
            DropColumn("Module3.EducationProviderClassifications", "SourceSystemName");
            DropColumn("Module3.EducationProviderClassifications", "SourceSystemKey");
            DropColumn("Module3.EducationProviderGenders", "SourceSystemName");
            DropColumn("Module3.EducationProviderGenders", "SourceSystemKey");
            DropColumn("Module3.RegionalCouncils", "SourceSystemName");
            DropColumn("Module3.RegionalCouncils", "SourceSystemKey");
            DropColumn("Module3.Regions", "SourceSystemName");
            DropColumn("Module3.Regions", "SourceSystemKey");
            DropColumn("Module3.EducationProviderTypes", "SourceSystemName");
            DropColumn("Module3.EducationProviderTypes", "SourceSystemKey");
            DropColumn("Module3.EducationProviderStatus", "SourceSystemName");
            DropColumn("Module3.EducationProviderStatus", "SourceSystemKey");
            DropColumn("Module3.MaoriElectorates", "SourceSystemName");
            DropColumn("Module3.MaoriElectorates", "SourceSystemKey");
            DropColumn("Module3.GeneralElectorates", "SourceSystemName");
            DropColumn("Module3.GeneralElectorates", "SourceSystemKey");
            DropColumn("Module3.CommunityBoards", "SourceSystemName");
            DropColumn("Module3.CommunityBoards", "SourceSystemKey");
            DropColumn("Module3.AuthorityTypes", "SourceSystemName");
            DropColumn("Module3.AuthorityTypes", "SourceSystemKey");
            DropColumn("Module3.AreaUnits", "SourceSystemName");
            DropColumn("Module3.AreaUnits", "SourceSystemKey");
            CreateIndex("Module3.Wards", "FIRSTKey", unique: true, name: "IX_Ward_FIRSTKey");
            CreateIndex("Module3.Wards", "SIFKey", unique: true, name: "IX_Ward_SIFKey");
            CreateIndex("Module3.UrbanAreas", "FIRSTKey", unique: true, name: "IX_UrbanArea_FIRSTKey");
            CreateIndex("Module3.UrbanAreas", "SIFKey", unique: true, name: "IX_UrbanArea_SIFKey");
            CreateIndex("Module3.TerritorialAuthorities", "FIRSTKey", unique: true, name: "IX_TerritorialAuthority_FIRSTKey");
            CreateIndex("Module3.TerritorialAuthorities", "SIFKey", unique: true, name: "IX_TerritorialAuthority_SIFKey");
            CreateIndex("Module3.TeacherEducations", "FIRSTKey", unique: true, name: "IX_TeacherEducation_FIRSTKey");
            CreateIndex("Module3.TeacherEducations", "SIFKey", unique: true, name: "IX_TeacherEducation_SIFKey");
            CreateIndex("Module3.SpecialSchoolings", "FIRSTKey", unique: true, name: "IX_SpecialSchooling_FIRSTKey");
            CreateIndex("Module3.SpecialSchoolings", "SIFKey", unique: true, name: "IX_SpecialSchooling_SIFKey");
            CreateIndex("Module3.EducationProviderYearLevels", "FIRSTKey", unique: true, name: "IX_EducationProviderYearLevel_FIRSTKey");
            CreateIndex("Module3.EducationProviderYearLevels", "SIFKey", unique: true, name: "IX_EducationProviderYearLevel_SIFKey");
            CreateIndex("Module3.EducationProviderClassifications", "FIRSTKey", unique: true, name: "IX_EducationProviderClassification_FIRSTKey");
            CreateIndex("Module3.EducationProviderClassifications", "SIFKey", unique: true, name: "IX_EducationProviderClassification_SIFKey");
            CreateIndex("Module3.EducationProviderGenders", "FIRSTKey", unique: true, name: "IX_EducationProviderGender_FIRSTKey");
            CreateIndex("Module3.EducationProviderGenders", "SIFKey", unique: true, name: "IX_EducationProviderGender_SIFKey");
            CreateIndex("Module3.RegionalCouncils", "FIRSTKey", unique: true, name: "IX_RegionalCouncil_FIRSTKey");
            CreateIndex("Module3.RegionalCouncils", "SIFKey", unique: true, name: "IX_RegionalCouncil_SIFKey");
            CreateIndex("Module3.Regions", "FIRSTKey", unique: true, name: "IX_Region_FIRSTKey");
            CreateIndex("Module3.Regions", "SIFKey", unique: true, name: "IX_Region_SIFKey");
            CreateIndex("Module3.EducationProviderTypes", "FIRSTKey", unique: true, name: "IX_EducationProviderType_FIRSTKey");
            CreateIndex("Module3.EducationProviderTypes", "SIFKey", unique: true, name: "IX_EducationProviderType_SIFKey");
            CreateIndex("Module3.EducationProviderStatus", "FIRSTKey", unique: true, name: "IX_EducationProviderStatus_FIRSTKey");
            CreateIndex("Module3.EducationProviderStatus", "SIFKey", unique: true, name: "IX_EducationProviderStatus_SIFKey");
            CreateIndex("Module3.MaoriElectorates", "FIRSTKey", unique: true, name: "IX_MaoriElectorate_FIRSTKey");
            CreateIndex("Module3.MaoriElectorates", "SIFKey", unique: true, name: "IX_MaoriElectorate_SIFKey");
            CreateIndex("Module3.GeneralElectorates", "FIRSTKey", unique: true, name: "IX_GeneralElectorate_FIRSTKey");
            CreateIndex("Module3.GeneralElectorates", "SIFKey", unique: true, name: "IX_GeneralElectorate_SIFKey");
            CreateIndex("Module3.CommunityBoards", "FIRSTKey", unique: true, name: "IX_CommunityBoard_FIRSTKey");
            CreateIndex("Module3.CommunityBoards", "SIFKey", unique: true, name: "IX_CommunityBoard_SIFKey");
            CreateIndex("Module3.AuthorityTypes", "FIRSTKey", unique: true, name: "IX_AuthorityType_FIRSTKey");
            CreateIndex("Module3.AuthorityTypes", "SIFKey", unique: true, name: "IX_AuthorityType_SIFKey");
            CreateIndex("Module3.AreaUnits", "FIRSTKey", unique: true, name: "IX_AreaUnit_FIRSTKey");
            CreateIndex("Module3.AreaUnits", "SIFKey", unique: true, name: "IX_AreaUnit_SIFKey");
        }
    }
}
