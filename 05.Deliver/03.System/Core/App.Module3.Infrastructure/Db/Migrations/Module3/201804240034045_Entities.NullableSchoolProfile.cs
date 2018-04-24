namespace App.Module3.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesNullableSchoolProfile : DbMigration
    {
        public override void Up()
        {
            DropIndex("Module3.EducationProviderProfiles", new[] { "LocalOfficeFK" });
            DropIndex("Module3.EducationProviderProfiles", new[] { "EducationProviderTypeFK" });
            DropIndex("Module3.EducationProviderProfiles", new[] { "SpecialSchoolingFK" });
            DropIndex("Module3.EducationProviderProfiles", new[] { "TeacherEducationFK" });
            AlterColumn("Module3.EducationProviderProfiles", "LocalOfficeFK", c => c.Guid());
            AlterColumn("Module3.EducationProviderProfiles", "EducationProviderTypeFK", c => c.Guid());
            AlterColumn("Module3.EducationProviderProfiles", "SpecialSchoolingFK", c => c.Guid());
            AlterColumn("Module3.EducationProviderProfiles", "TeacherEducationFK", c => c.Guid());
            CreateIndex("Module3.EducationProviderProfiles", "LocalOfficeFK");
            CreateIndex("Module3.EducationProviderProfiles", "EducationProviderTypeFK");
            CreateIndex("Module3.EducationProviderProfiles", "SpecialSchoolingFK");
            CreateIndex("Module3.EducationProviderProfiles", "TeacherEducationFK");
        }
        
        public override void Down()
        {
            DropIndex("Module3.EducationProviderProfiles", new[] { "TeacherEducationFK" });
            DropIndex("Module3.EducationProviderProfiles", new[] { "SpecialSchoolingFK" });
            DropIndex("Module3.EducationProviderProfiles", new[] { "EducationProviderTypeFK" });
            DropIndex("Module3.EducationProviderProfiles", new[] { "LocalOfficeFK" });
            AlterColumn("Module3.EducationProviderProfiles", "TeacherEducationFK", c => c.Guid(nullable: false));
            AlterColumn("Module3.EducationProviderProfiles", "SpecialSchoolingFK", c => c.Guid(nullable: false));
            AlterColumn("Module3.EducationProviderProfiles", "EducationProviderTypeFK", c => c.Guid(nullable: false));
            AlterColumn("Module3.EducationProviderProfiles", "LocalOfficeFK", c => c.Guid(nullable: false));
            CreateIndex("Module3.EducationProviderProfiles", "TeacherEducationFK");
            CreateIndex("Module3.EducationProviderProfiles", "SpecialSchoolingFK");
            CreateIndex("Module3.EducationProviderProfiles", "EducationProviderTypeFK");
            CreateIndex("Module3.EducationProviderProfiles", "LocalOfficeFK");
        }
    }
}
