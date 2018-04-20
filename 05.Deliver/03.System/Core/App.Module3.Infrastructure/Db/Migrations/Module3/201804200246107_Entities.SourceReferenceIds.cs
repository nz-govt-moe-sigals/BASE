namespace App.Module3.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesSourceReferenceIds : DbMigration
    {
        public override void Up()
        {
            AddColumn("Module3.EducationProviderLocations", "SourceReferenceId", c => c.Int(nullable: false));
            AddColumn("Module3.EducationProviderEnrolmentCounts", "SourceReferenceId", c => c.Int(nullable: false));
            AddColumn("Module3.EducationProviderLevelGenders", "SourceReferenceId", c => c.Int(nullable: false));
            AddColumn("Module3.EducationProviderProfiles", "SourceReferenceId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Module3.EducationProviderProfiles", "SourceReferenceId");
            DropColumn("Module3.EducationProviderLevelGenders", "SourceReferenceId");
            DropColumn("Module3.EducationProviderEnrolmentCounts", "SourceReferenceId");
            DropColumn("Module3.EducationProviderLocations", "SourceReferenceId");
        }
    }
}
