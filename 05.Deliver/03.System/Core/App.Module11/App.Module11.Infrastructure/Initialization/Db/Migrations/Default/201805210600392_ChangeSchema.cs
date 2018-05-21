namespace App.Module11.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSchema : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "Module3.ExtractWatermarks", newSchema: "Module11");
            MoveTable(name: "Module3.AreaUnits", newSchema: "Module11");
            MoveTable(name: "Module3.AuthorityTypes", newSchema: "Module11");
            MoveTable(name: "Module3.CommunityBoards", newSchema: "Module11");
            MoveTable(name: "Module3.GeneralElectorates", newSchema: "Module11");
            MoveTable(name: "Module3.MaoriElectorates", newSchema: "Module11");
            MoveTable(name: "Module3.EducationProviderStatus", newSchema: "Module11");
            MoveTable(name: "Module3.EducationProviderTypes", newSchema: "Module11");
            MoveTable(name: "Module3.Regions", newSchema: "Module11");
            MoveTable(name: "Module3.RegionalCouncils", newSchema: "Module11");
            MoveTable(name: "Module3.RelationshipTypes", newSchema: "Module11");
            MoveTable(name: "Module3.EducationProviderClassifications", newSchema: "Module11");
            MoveTable(name: "Module3.EducationProviderGenders", newSchema: "Module11");
            MoveTable(name: "Module3.EducationProviderYearLevels", newSchema: "Module11");
            MoveTable(name: "Module3.SpecialSchoolings", newSchema: "Module11");
            MoveTable(name: "Module3.TeacherEducations", newSchema: "Module11");
            MoveTable(name: "Module3.TerritorialAuthorities", newSchema: "Module11");
            MoveTable(name: "Module3.UrbanAreas", newSchema: "Module11");
            MoveTable(name: "Module3.Wards", newSchema: "Module11");
            MoveTable(name: "Module3.EducationProviderLocations", newSchema: "Module11");
            MoveTable(name: "Module3.EducationProviderEnrolmentCounts", newSchema: "Module11");
            MoveTable(name: "Module3.EducationProviderLevelGenders", newSchema: "Module11");
            MoveTable(name: "Module3.EducationProviderProfiles", newSchema: "Module11");
            MoveTable(name: "Module3.CoLs", newSchema: "Module11");
            MoveTable(name: "Module3.LocalOffices", newSchema: "Module11");
        }
        
        public override void Down()
        {
            MoveTable(name: "Module11.LocalOffices", newSchema: "Module3");
            MoveTable(name: "Module11.CoLs", newSchema: "Module3");
            MoveTable(name: "Module11.EducationProviderProfiles", newSchema: "Module3");
            MoveTable(name: "Module11.EducationProviderLevelGenders", newSchema: "Module3");
            MoveTable(name: "Module11.EducationProviderEnrolmentCounts", newSchema: "Module3");
            MoveTable(name: "Module11.EducationProviderLocations", newSchema: "Module3");
            MoveTable(name: "Module11.Wards", newSchema: "Module3");
            MoveTable(name: "Module11.UrbanAreas", newSchema: "Module3");
            MoveTable(name: "Module11.TerritorialAuthorities", newSchema: "Module3");
            MoveTable(name: "Module11.TeacherEducations", newSchema: "Module3");
            MoveTable(name: "Module11.SpecialSchoolings", newSchema: "Module3");
            MoveTable(name: "Module11.EducationProviderYearLevels", newSchema: "Module3");
            MoveTable(name: "Module11.EducationProviderGenders", newSchema: "Module3");
            MoveTable(name: "Module11.EducationProviderClassifications", newSchema: "Module3");
            MoveTable(name: "Module11.RelationshipTypes", newSchema: "Module3");
            MoveTable(name: "Module11.RegionalCouncils", newSchema: "Module3");
            MoveTable(name: "Module11.Regions", newSchema: "Module3");
            MoveTable(name: "Module11.EducationProviderTypes", newSchema: "Module3");
            MoveTable(name: "Module11.EducationProviderStatus", newSchema: "Module3");
            MoveTable(name: "Module11.MaoriElectorates", newSchema: "Module3");
            MoveTable(name: "Module11.GeneralElectorates", newSchema: "Module3");
            MoveTable(name: "Module11.CommunityBoards", newSchema: "Module3");
            MoveTable(name: "Module11.AuthorityTypes", newSchema: "Module3");
            MoveTable(name: "Module11.AreaUnits", newSchema: "Module3");
            MoveTable(name: "Module11.ExtractWatermarks", newSchema: "Module3");
        }
    }
}
