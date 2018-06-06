namespace App.Module32.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesBaseInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Module32.EducationSchoolProfiles",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(maxLength: 32),
                        SchoolId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_EducationSchoolProfile_TenantFK")
                .Index(t => t.RecordState, name: "IX_EducationSchoolProfile_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_EducationSchoolProfile_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_EducationSchoolProfile_LastModifiedByPrincipalId")
                .Index(t => t.SchoolId, name: "IX_EducationSchoolProfile_SchoolId");
            
            CreateTable(
                "Module32.EducationStudentProfiles",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(maxLength: 32),
                        FullName = c.String(nullable: false, maxLength: 1024),
                        NSN = c.String(nullable: false, maxLength: 32),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false, maxLength: 1),
                        EducationSchoolProfileFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module32.EducationSchoolProfiles", t => t.EducationSchoolProfileFK)
                .Index(t => t.TenantFK, name: "IX_EducationStudentProfile_TenantFK")
                .Index(t => t.RecordState, name: "IX_EducationStudentProfile_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_EducationStudentProfile_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_EducationStudentProfile_LastModifiedByPrincipalId")
                .Index(t => t.NSN, name: "IX_EducationStudentProfile_NSN")
                .Index(t => t.EducationSchoolProfileFK);
            
            CreateTable(
                "Module32.ExtractWatermarks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(maxLength: 32),
                        SourceTableName = c.String(nullable: false, maxLength: 255),
                        Watermark = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.RecordState, name: "IX_ExtractWatermark_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_ExtractWatermark_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_ExtractWatermark_LastModifiedByPrincipalId")
                .Index(t => t.SourceTableName, unique: true, name: "UX_ExtractWatermark_SourceTableName");
            
        }
        
        public override void Down()
        {
            DropForeignKey("Module32.EducationStudentProfiles", "EducationSchoolProfileFK", "Module32.EducationSchoolProfiles");
            DropIndex("Module32.ExtractWatermarks", "UX_ExtractWatermark_SourceTableName");
            DropIndex("Module32.ExtractWatermarks", "IX_ExtractWatermark_LastModifiedByPrincipalId");
            DropIndex("Module32.ExtractWatermarks", "IX_ExtractWatermark_LastModifiedOnUtc");
            DropIndex("Module32.ExtractWatermarks", "IX_ExtractWatermark_RecordState");
            DropIndex("Module32.EducationStudentProfiles", new[] { "EducationSchoolProfileFK" });
            DropIndex("Module32.EducationStudentProfiles", "IX_EducationStudentProfile_NSN");
            DropIndex("Module32.EducationStudentProfiles", "IX_EducationStudentProfile_LastModifiedByPrincipalId");
            DropIndex("Module32.EducationStudentProfiles", "IX_EducationStudentProfile_LastModifiedOnUtc");
            DropIndex("Module32.EducationStudentProfiles", "IX_EducationStudentProfile_RecordState");
            DropIndex("Module32.EducationStudentProfiles", "IX_EducationStudentProfile_TenantFK");
            DropIndex("Module32.EducationSchoolProfiles", "IX_EducationSchoolProfile_SchoolId");
            DropIndex("Module32.EducationSchoolProfiles", "IX_EducationSchoolProfile_LastModifiedByPrincipalId");
            DropIndex("Module32.EducationSchoolProfiles", "IX_EducationSchoolProfile_LastModifiedOnUtc");
            DropIndex("Module32.EducationSchoolProfiles", "IX_EducationSchoolProfile_RecordState");
            DropIndex("Module32.EducationSchoolProfiles", "IX_EducationSchoolProfile_TenantFK");
            DropTable("Module32.ExtractWatermarks");
            DropTable("Module32.EducationStudentProfiles");
            DropTable("Module32.EducationSchoolProfiles");
        }
    }
}
