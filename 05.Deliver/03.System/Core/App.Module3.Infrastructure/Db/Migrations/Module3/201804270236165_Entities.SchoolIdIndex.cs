namespace App.Module3.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesSchoolIdIndex : DbMigration
    {
        public override void Up()
        {
            CreateIndex("Module3.EducationProviderProfiles", "SchoolId", unique: true, name: "IX_EducationProviderProfile_SchoolId");
        }
        
        public override void Down()
        {
            DropIndex("Module3.EducationProviderProfiles", "IX_EducationProviderProfile_SchoolId");
        }
    }
}
