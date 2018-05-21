namespace App.Module11.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesIndexOnRecordState : DbMigration
    {
        public override void Up()
        {
            CreateIndex("Module3.EducationProviderProfiles", "RecordState", name: "IX_EducationProviderProfile_RecordState");
        }
        
        public override void Down()
        {
            DropIndex("Module3.EducationProviderProfiles", "IX_EducationProviderProfile_RecordState");
        }
    }
}
