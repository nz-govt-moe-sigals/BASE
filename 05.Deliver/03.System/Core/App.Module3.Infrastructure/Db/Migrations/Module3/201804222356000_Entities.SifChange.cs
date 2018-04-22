namespace App.Module3.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesSifChange : DbMigration
    {
        public override void Up()
        {
            DropIndex("Module3.AreaUnits", "IX_AreaUnit_SIFKey");
            DropIndex("Module3.AuthorityTypes", "IX_AuthorityType_SIFKey");
            DropIndex("Module3.CommunityBoards", "IX_CommunityBoard_SIFKey");
            DropIndex("Module3.GeneralElectorates", "IX_GeneralElectorate_SIFKey");
            DropIndex("Module3.MaoriElectorates", "IX_MaoriElectorate_SIFKey");
            DropIndex("Module3.EducationProviderStatus", "IX_EducationProviderStatus_SIFKey");
            DropIndex("Module3.EducationProviderTypes", "IX_EducationProviderType_SIFKey");
            DropIndex("Module3.Regions", "IX_Region_SIFKey");
            DropIndex("Module3.RegionalCouncils", "IX_RegionalCouncil_SIFKey");
            DropIndex("Module3.EducationProviderGenders", "IX_EducationProviderGender_SIFKey");
            DropIndex("Module3.EducationProviderClassifications", "IX_EducationProviderClassification_SIFKey");
            DropIndex("Module3.EducationProviderYearLevels", "IX_EducationProviderYearLevel_SIFKey");
            DropIndex("Module3.SpecialSchoolings", "IX_SpecialSchooling_SIFKey");
            DropIndex("Module3.TeacherEducations", "IX_TeacherEducation_SIFKey");
            DropIndex("Module3.TerritorialAuthorities", "IX_TerritorialAuthority_SIFKey");
            DropIndex("Module3.UrbanAreas", "IX_UrbanArea_SIFKey");
            DropIndex("Module3.Wards", "IX_Ward_SIFKey");
            DropColumn("Module3.AreaUnits", "SIFKey");
            DropColumn("Module3.AuthorityTypes", "SIFKey");
            DropColumn("Module3.CommunityBoards", "SIFKey");
            DropColumn("Module3.GeneralElectorates", "SIFKey");
            DropColumn("Module3.MaoriElectorates", "SIFKey");
            DropColumn("Module3.RegionalCouncils", "SIFKey");
            DropColumn("Module3.SpecialSchoolings", "SIFKey");
            DropColumn("Module3.TeacherEducations", "SIFKey");
            DropColumn("Module3.TerritorialAuthorities", "SIFKey");
            DropColumn("Module3.UrbanAreas", "SIFKey");
            DropColumn("Module3.Wards", "SIFKey");
            DropColumn("Module3.CoLs", "SIFKey");
            DropColumn("Module3.LocalOffices", "SIFKey");
        }
        
        public override void Down()
        {
            AddColumn("Module3.LocalOffices", "SIFKey", c => c.Int(nullable: false));
            AddColumn("Module3.CoLs", "SIFKey", c => c.Int(nullable: false));
            AddColumn("Module3.Wards", "SIFKey", c => c.Int(nullable: false));
            AddColumn("Module3.UrbanAreas", "SIFKey", c => c.Int(nullable: false));
            AddColumn("Module3.TerritorialAuthorities", "SIFKey", c => c.Int(nullable: false));
            AddColumn("Module3.TeacherEducations", "SIFKey", c => c.Int(nullable: false));
            AddColumn("Module3.SpecialSchoolings", "SIFKey", c => c.Int(nullable: false));
            AddColumn("Module3.RegionalCouncils", "SIFKey", c => c.Int(nullable: false));
            AddColumn("Module3.MaoriElectorates", "SIFKey", c => c.Int(nullable: false));
            AddColumn("Module3.GeneralElectorates", "SIFKey", c => c.Int(nullable: false));
            AddColumn("Module3.CommunityBoards", "SIFKey", c => c.Int(nullable: false));
            AddColumn("Module3.AuthorityTypes", "SIFKey", c => c.Int(nullable: false));
            AddColumn("Module3.AreaUnits", "SIFKey", c => c.Int(nullable: false));
            CreateIndex("Module3.Wards", "SIFKey", unique: true, name: "IX_Ward_SIFKey");
            CreateIndex("Module3.UrbanAreas", "SIFKey", unique: true, name: "IX_UrbanArea_SIFKey");
            CreateIndex("Module3.TerritorialAuthorities", "SIFKey", unique: true, name: "IX_TerritorialAuthority_SIFKey");
            CreateIndex("Module3.TeacherEducations", "SIFKey", unique: true, name: "IX_TeacherEducation_SIFKey");
            CreateIndex("Module3.SpecialSchoolings", "SIFKey", unique: true, name: "IX_SpecialSchooling_SIFKey");
            CreateIndex("Module3.EducationProviderYearLevels", "SIFKey", unique: true, name: "IX_EducationProviderYearLevel_SIFKey");
            CreateIndex("Module3.EducationProviderClassifications", "SIFKey", unique: true, name: "IX_EducationProviderClassification_SIFKey");
            CreateIndex("Module3.EducationProviderGenders", "SIFKey", unique: true, name: "IX_EducationProviderGender_SIFKey");
            CreateIndex("Module3.RegionalCouncils", "SIFKey", unique: true, name: "IX_RegionalCouncil_SIFKey");
            CreateIndex("Module3.Regions", "SIFKey", unique: true, name: "IX_Region_SIFKey");
            CreateIndex("Module3.EducationProviderTypes", "SIFKey", unique: true, name: "IX_EducationProviderType_SIFKey");
            CreateIndex("Module3.EducationProviderStatus", "SIFKey", unique: true, name: "IX_EducationProviderStatus_SIFKey");
            CreateIndex("Module3.MaoriElectorates", "SIFKey", unique: true, name: "IX_MaoriElectorate_SIFKey");
            CreateIndex("Module3.GeneralElectorates", "SIFKey", unique: true, name: "IX_GeneralElectorate_SIFKey");
            CreateIndex("Module3.CommunityBoards", "SIFKey", unique: true, name: "IX_CommunityBoard_SIFKey");
            CreateIndex("Module3.AuthorityTypes", "SIFKey", unique: true, name: "IX_AuthorityType_SIFKey");
            CreateIndex("Module3.AreaUnits", "SIFKey", unique: true, name: "IX_AreaUnit_SIFKey");
        }
    }
}
