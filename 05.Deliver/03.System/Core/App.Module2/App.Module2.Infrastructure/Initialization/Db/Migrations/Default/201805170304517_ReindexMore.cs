namespace App.Module02.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReindexMore : DbMigration
    {
        public override void Up()
        {
            CreateIndex("Module2.Bodies", "TenantFK", name: "IX_Body_TenantFK");
            CreateIndex("Module2.BodyAlias", "TenantFK", name: "IX_BodyAlias_TenantFK");
            CreateIndex("Module2.BodyCategories", "TenantFK", name: "IX_BodyCategory_TenantFK");
            CreateIndex("Module2.BodyChannels", "TenantFK", name: "IX_BodyChannel_TenantFK");
            CreateIndex("Module2.BodyClaims", "TenantFK", name: "IX_BodyClaim_TenantFK");
            CreateIndex("Module2.BodyProperties", "TenantFK", name: "IX_BodyProperty_TenantFK");
            CreateIndex("Module2.EducationOrganisations", "TenantFK", name: "IX_EducationOrganisation_TenantFK");
            CreateIndex("Module2.SchoolAuthorities", "TenantFK", name: "IX_SchoolAuthority_TenantFK");
            CreateIndex("Module2.SchoolDeciles", "TenantFK", name: "IX_SchoolDecile_TenantFK");
            CreateIndex("Module2.SchoolDefinitions", "TenantFK", name: "IX_SchoolDefinition_TenantFK");
            CreateIndex("Module2.SchoolEducationRegions", "TenantFK", name: "IX_SchoolEducationRegion_TenantFK");
            CreateIndex("Module2.SchoolGenders", "TenantFK", name: "IX_SchoolGender_TenantFK");
            CreateIndex("Module2.SchoolGeneralElectorates", "TenantFK", name: "IX_SchoolGeneralElectorate_TenantFK");
            CreateIndex("Module2.SchoolMinistryOfEducationLocalOffices", "TenantFK", name: "IX_SchoolMinistryOfEducationLocalOffice_TenantFK");
            CreateIndex("Module2.SchoolMaoriElectorates", "TenantFK", name: "IX_SchoolMaoriElectorate_TenantFK");
            CreateIndex("Module2.SchoolRegionalCouncils", "TenantFK", name: "IX_SchoolRegionalCouncil_TenantFK");
            CreateIndex("Module2.SchoolTerritorialAuthorityWithAucklandLocalBoards", "TenantFK", name: "IX_SchoolTerritorialAuthorityWithAucklandLocalBoard_TenantFK");
            CreateIndex("Module2.SchoolTypes", "TenantFK", name: "IX_SchoolType_TenantFK");
        }
        
        public override void Down()
        {
            DropIndex("Module2.SchoolTypes", "IX_SchoolType_TenantFK");
            DropIndex("Module2.SchoolTerritorialAuthorityWithAucklandLocalBoards", "IX_SchoolTerritorialAuthorityWithAucklandLocalBoard_TenantFK");
            DropIndex("Module2.SchoolRegionalCouncils", "IX_SchoolRegionalCouncil_TenantFK");
            DropIndex("Module2.SchoolMaoriElectorates", "IX_SchoolMaoriElectorate_TenantFK");
            DropIndex("Module2.SchoolMinistryOfEducationLocalOffices", "IX_SchoolMinistryOfEducationLocalOffice_TenantFK");
            DropIndex("Module2.SchoolGeneralElectorates", "IX_SchoolGeneralElectorate_TenantFK");
            DropIndex("Module2.SchoolGenders", "IX_SchoolGender_TenantFK");
            DropIndex("Module2.SchoolEducationRegions", "IX_SchoolEducationRegion_TenantFK");
            DropIndex("Module2.SchoolDefinitions", "IX_SchoolDefinition_TenantFK");
            DropIndex("Module2.SchoolDeciles", "IX_SchoolDecile_TenantFK");
            DropIndex("Module2.SchoolAuthorities", "IX_SchoolAuthority_TenantFK");
            DropIndex("Module2.EducationOrganisations", "IX_EducationOrganisation_TenantFK");
            DropIndex("Module2.BodyProperties", "IX_BodyProperty_TenantFK");
            DropIndex("Module2.BodyClaims", "IX_BodyClaim_TenantFK");
            DropIndex("Module2.BodyChannels", "IX_BodyChannel_TenantFK");
            DropIndex("Module2.BodyCategories", "IX_BodyCategory_TenantFK");
            DropIndex("Module2.BodyAlias", "IX_BodyAlias_TenantFK");
            DropIndex("Module2.Bodies", "IX_Body_TenantFK");
        }
    }
}
