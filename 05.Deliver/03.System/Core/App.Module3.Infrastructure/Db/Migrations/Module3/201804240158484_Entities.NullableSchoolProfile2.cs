namespace App.Module3.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesNullableSchoolProfile2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "Module3.EducationProviderEnrolmentCounts", name: "SchoolFK", newName: "EducationProviderFK");
            RenameIndex(table: "Module3.EducationProviderEnrolmentCounts", name: "IX_SchoolFK", newName: "IX_EducationProviderFK");
        }
        
        public override void Down()
        {
            RenameIndex(table: "Module3.EducationProviderEnrolmentCounts", name: "IX_EducationProviderFK", newName: "IX_SchoolFK");
            RenameColumn(table: "Module3.EducationProviderEnrolmentCounts", name: "EducationProviderFK", newName: "SchoolFK");
        }
    }
}
