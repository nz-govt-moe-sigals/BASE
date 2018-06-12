namespace App.Module32.Infrastructure.Db.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesAddSourceModifiedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("Module32.EducationSchoolProfiles", "SourceModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("Module32.EducationStudentProfiles", "SourceModifiedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Module32.EducationStudentProfiles", "SourceModifiedDate");
            DropColumn("Module32.EducationSchoolProfiles", "SourceModifiedDate");
        }
    }
}
