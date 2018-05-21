namespace App.Module02.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSchema : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "Module2.Bodies", newSchema: "Module02");
            MoveTable(name: "Module2.BodyAlias", newSchema: "Module02");
            MoveTable(name: "Module2.BodyCategories", newSchema: "Module02");
            MoveTable(name: "Module2.BodyChannels", newSchema: "Module02");
            MoveTable(name: "Module2.BodyClaims", newSchema: "Module02");
            MoveTable(name: "Module2.BodyLocations", newSchema: "Module02");
            MoveTable(name: "Module2.BodyProperties", newSchema: "Module02");
            MoveTable(name: "Module2.EducationOrganisations", newSchema: "Module02");
            MoveTable(name: "Module2.SchoolAuthorities", newSchema: "Module02");
            MoveTable(name: "Module2.SchoolDeciles", newSchema: "Module02");
            MoveTable(name: "Module2.SchoolDefinitions", newSchema: "Module02");
            MoveTable(name: "Module2.SchoolEducationRegions", newSchema: "Module02");
            MoveTable(name: "Module2.SchoolGenders", newSchema: "Module02");
            MoveTable(name: "Module2.SchoolGeneralElectorates", newSchema: "Module02");
            MoveTable(name: "Module2.SchoolMinistryOfEducationLocalOffices", newSchema: "Module02");
            MoveTable(name: "Module2.SchoolMaoriElectorates", newSchema: "Module02");
            MoveTable(name: "Module2.SchoolRegionalCouncils", newSchema: "Module02");
            MoveTable(name: "Module2.SchoolTerritorialAuthorityWithAucklandLocalBoards", newSchema: "Module02");
            MoveTable(name: "Module2.SchoolTypes", newSchema: "Module02");
        }
        
        public override void Down()
        {
            MoveTable(name: "Module02.SchoolTypes", newSchema: "Module2");
            MoveTable(name: "Module02.SchoolTerritorialAuthorityWithAucklandLocalBoards", newSchema: "Module2");
            MoveTable(name: "Module02.SchoolRegionalCouncils", newSchema: "Module2");
            MoveTable(name: "Module02.SchoolMaoriElectorates", newSchema: "Module2");
            MoveTable(name: "Module02.SchoolMinistryOfEducationLocalOffices", newSchema: "Module2");
            MoveTable(name: "Module02.SchoolGeneralElectorates", newSchema: "Module2");
            MoveTable(name: "Module02.SchoolGenders", newSchema: "Module2");
            MoveTable(name: "Module02.SchoolEducationRegions", newSchema: "Module2");
            MoveTable(name: "Module02.SchoolDefinitions", newSchema: "Module2");
            MoveTable(name: "Module02.SchoolDeciles", newSchema: "Module2");
            MoveTable(name: "Module02.SchoolAuthorities", newSchema: "Module2");
            MoveTable(name: "Module02.EducationOrganisations", newSchema: "Module2");
            MoveTable(name: "Module02.BodyProperties", newSchema: "Module2");
            MoveTable(name: "Module02.BodyLocations", newSchema: "Module2");
            MoveTable(name: "Module02.BodyClaims", newSchema: "Module2");
            MoveTable(name: "Module02.BodyChannels", newSchema: "Module2");
            MoveTable(name: "Module02.BodyCategories", newSchema: "Module2");
            MoveTable(name: "Module02.BodyAlias", newSchema: "Module2");
            MoveTable(name: "Module02.Bodies", newSchema: "Module2");
        }
    }
}
