namespace App.Module11.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReferenceDataAddedIndexedTitleAndDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("Module11.BodyCategories", "Title", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module11.BodyCategories", "Description", c => c.String());
            AddColumn("Module11.SchoolAuthorities", "Title", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module11.SchoolAuthorities", "Description", c => c.String());
            AddColumn("Module11.SchoolDeciles", "Title", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module11.SchoolDeciles", "Description", c => c.String());
            AddColumn("Module11.SchoolDefinitions", "Title", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module11.SchoolDefinitions", "Description", c => c.String());
            AddColumn("Module11.SchoolEducationRegions", "Title", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module11.SchoolEducationRegions", "Description", c => c.String());
            AddColumn("Module11.SchoolGenders", "Title", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module11.SchoolGenders", "Description", c => c.String());
            AddColumn("Module11.SchoolGeneralElectorates", "Title", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module11.SchoolGeneralElectorates", "Description", c => c.String());
            AddColumn("Module11.SchoolMinistryOfEducationLocalOffices", "Title", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module11.SchoolMinistryOfEducationLocalOffices", "Description", c => c.String());
            AddColumn("Module11.SchoolMaoriElectorates", "Title", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module11.SchoolMaoriElectorates", "Description", c => c.String());
            AddColumn("Module11.SchoolRegionalCouncils", "Title", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module11.SchoolRegionalCouncils", "Description", c => c.String());
            AddColumn("Module11.SchoolTerritorialAuthorityWithAucklandLocalBoards", "Title", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module11.SchoolTerritorialAuthorityWithAucklandLocalBoards", "Description", c => c.String());
            AddColumn("Module11.SchoolTypes", "Title", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module11.SchoolTypes", "Description", c => c.String());
            AlterColumn("Module11.Bodies", "Description", c => c.String());
            CreateIndex("Module11.BodyCategories", "Title", name: "IX_BodyCategory_Title");
            CreateIndex("Module11.SchoolAuthorities", "Title", name: "IX_SchoolAuthority_Title");
            CreateIndex("Module11.SchoolDeciles", "Title", name: "IX_SchoolDecile_Title");
            CreateIndex("Module11.SchoolDefinitions", "Title", name: "IX_SchoolDefinition_Title");
            CreateIndex("Module11.SchoolEducationRegions", "Title", name: "IX_SchoolEducationRegion_Title");
            CreateIndex("Module11.SchoolGenders", "Title", name: "IX_SchoolGender_Title");
            CreateIndex("Module11.SchoolGeneralElectorates", "Title", name: "IX_SchoolGeneralElectorate_Title");
            CreateIndex("Module11.SchoolMinistryOfEducationLocalOffices", "Title", name: "IX_SchoolMinistryOfEducationLocalOffice_Title");
            CreateIndex("Module11.SchoolMaoriElectorates", "Title", name: "IX_SchoolMaoriElectorate_Title");
            CreateIndex("Module11.SchoolRegionalCouncils", "Title", name: "IX_SchoolRegionalCouncil_Title");
            CreateIndex("Module11.SchoolTerritorialAuthorityWithAucklandLocalBoards", "Title", name: "IX_SchoolTerritorialAuthorityWithAucklandLocalBoard_Title");
            CreateIndex("Module11.SchoolTypes", "Title", name: "IX_SchoolType_Title");
            DropColumn("Module11.BodyCategories", "Text");
            DropColumn("Module11.SchoolAuthorities", "Text");
            DropColumn("Module11.SchoolDeciles", "Text");
            DropColumn("Module11.SchoolDefinitions", "Text");
            DropColumn("Module11.SchoolEducationRegions", "Text");
            DropColumn("Module11.SchoolGenders", "Text");
            DropColumn("Module11.SchoolGeneralElectorates", "Text");
            DropColumn("Module11.SchoolMinistryOfEducationLocalOffices", "Text");
            DropColumn("Module11.SchoolMaoriElectorates", "Text");
            DropColumn("Module11.SchoolRegionalCouncils", "Text");
            DropColumn("Module11.SchoolTerritorialAuthorityWithAucklandLocalBoards", "Text");
            DropColumn("Module11.SchoolTypes", "Text");
        }
        
        public override void Down()
        {
            AddColumn("Module11.SchoolTypes", "Text", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module11.SchoolTerritorialAuthorityWithAucklandLocalBoards", "Text", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module11.SchoolRegionalCouncils", "Text", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module11.SchoolMaoriElectorates", "Text", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module11.SchoolMinistryOfEducationLocalOffices", "Text", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module11.SchoolGeneralElectorates", "Text", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module11.SchoolGenders", "Text", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module11.SchoolEducationRegions", "Text", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module11.SchoolDefinitions", "Text", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module11.SchoolDeciles", "Text", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module11.SchoolAuthorities", "Text", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Module11.BodyCategories", "Text", c => c.String(nullable: false, maxLength: 64));
            DropIndex("Module11.SchoolTypes", "IX_SchoolType_Title");
            DropIndex("Module11.SchoolTerritorialAuthorityWithAucklandLocalBoards", "IX_SchoolTerritorialAuthorityWithAucklandLocalBoard_Title");
            DropIndex("Module11.SchoolRegionalCouncils", "IX_SchoolRegionalCouncil_Title");
            DropIndex("Module11.SchoolMaoriElectorates", "IX_SchoolMaoriElectorate_Title");
            DropIndex("Module11.SchoolMinistryOfEducationLocalOffices", "IX_SchoolMinistryOfEducationLocalOffice_Title");
            DropIndex("Module11.SchoolGeneralElectorates", "IX_SchoolGeneralElectorate_Title");
            DropIndex("Module11.SchoolGenders", "IX_SchoolGender_Title");
            DropIndex("Module11.SchoolEducationRegions", "IX_SchoolEducationRegion_Title");
            DropIndex("Module11.SchoolDefinitions", "IX_SchoolDefinition_Title");
            DropIndex("Module11.SchoolDeciles", "IX_SchoolDecile_Title");
            DropIndex("Module11.SchoolAuthorities", "IX_SchoolAuthority_Title");
            DropIndex("Module11.BodyCategories", "IX_BodyCategory_Title");
            AlterColumn("Module11.Bodies", "Description", c => c.String(maxLength: 256));
            DropColumn("Module11.SchoolTypes", "Description");
            DropColumn("Module11.SchoolTypes", "Title");
            DropColumn("Module11.SchoolTerritorialAuthorityWithAucklandLocalBoards", "Description");
            DropColumn("Module11.SchoolTerritorialAuthorityWithAucklandLocalBoards", "Title");
            DropColumn("Module11.SchoolRegionalCouncils", "Description");
            DropColumn("Module11.SchoolRegionalCouncils", "Title");
            DropColumn("Module11.SchoolMaoriElectorates", "Description");
            DropColumn("Module11.SchoolMaoriElectorates", "Title");
            DropColumn("Module11.SchoolMinistryOfEducationLocalOffices", "Description");
            DropColumn("Module11.SchoolMinistryOfEducationLocalOffices", "Title");
            DropColumn("Module11.SchoolGeneralElectorates", "Description");
            DropColumn("Module11.SchoolGeneralElectorates", "Title");
            DropColumn("Module11.SchoolGenders", "Description");
            DropColumn("Module11.SchoolGenders", "Title");
            DropColumn("Module11.SchoolEducationRegions", "Description");
            DropColumn("Module11.SchoolEducationRegions", "Title");
            DropColumn("Module11.SchoolDefinitions", "Description");
            DropColumn("Module11.SchoolDefinitions", "Title");
            DropColumn("Module11.SchoolDeciles", "Description");
            DropColumn("Module11.SchoolDeciles", "Title");
            DropColumn("Module11.SchoolAuthorities", "Description");
            DropColumn("Module11.SchoolAuthorities", "Title");
            DropColumn("Module11.BodyCategories", "Description");
            DropColumn("Module11.BodyCategories", "Title");
        }
    }
}
