namespace App.Module80.Infrastructure.Initialization.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Entitiesinit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Module80.SurveyLocations",
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
                        SurveyLocationId = c.String(nullable: false, maxLength: 32),
                        RegionFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module80.Regions", t => t.RegionFK, cascadeDelete: true)
                .Index(t => t.TenantFK, name: "IX_SurveyLocation_TenantFK")
                .Index(t => t.RecordState, name: "IX_SurveyLocation_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_SurveyLocation_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_SurveyLocation_LastModifiedByPrincipalId")
                .Index(t => t.RegionFK);
            
            CreateTable(
                "Module80.Regions",
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
                        RegionId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_Region_TenantFK")
                .Index(t => t.RecordState, name: "IX_Region_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_Region_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_Region_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module80.LargeItems",
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
                        Code = c.String(nullable: false, maxLength: 10),
                        Category = c.String(maxLength: 32),
                        Description = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_LargeItem_TenantFK")
                .Index(t => t.RecordState, name: "IX_LargeItem_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_LargeItem_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_LargeItem_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module80.LitterItems",
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
                        Code = c.String(nullable: false, maxLength: 10),
                        Category = c.String(maxLength: 32),
                        Description = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_LitterItem_TenantFK")
                .Index(t => t.RecordState, name: "IX_LitterItem_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_LitterItem_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_LitterItem_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module80.Organisations",
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
                        Name = c.String(nullable: false, maxLength: 64),
                        ContactNumber = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_Organisation_TenantFK")
                .Index(t => t.RecordState, name: "IX_Organisation_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_Organisation_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_Organisation_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module80.Surveys",
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
                        Name = c.String(nullable: false, maxLength: 64),
                        OrganisationFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module80.Organisations", t => t.OrganisationFK)
                .Index(t => t.TenantFK, name: "IX_Survey_TenantFK")
                .Index(t => t.RecordState, name: "IX_Survey_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_Survey_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_Survey_LastModifiedByPrincipalId")
                .Index(t => t.OrganisationFK);
            
            CreateTable(
                "Module80.SurveyLargeItems",
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
                        Count = c.Int(nullable: false),
                        Latitude = c.Decimal(precision: 10, scale: 7),
                        Longitude = c.Decimal(precision: 10, scale: 7),
                        DetailedDescription = c.String(maxLength: 256),
                        Status = c.Int(),
                        SurveyFK = c.Guid(nullable: false),
                        LargeItemFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module80.LargeItems", t => t.LargeItemFK)
                .ForeignKey("Module80.Surveys", t => t.SurveyFK, cascadeDelete: true)
                .Index(t => t.TenantFK, name: "IX_SurveyLargeItem_TenantFK")
                .Index(t => t.RecordState, name: "IX_SurveyLargeItem_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_SurveyLargeItem_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_SurveyLargeItem_LastModifiedByPrincipalId")
                .Index(t => t.SurveyFK)
                .Index(t => t.LargeItemFK);
            
            CreateTable(
                "Module80.SurveyLitterItems",
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
                        Count = c.Int(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 7, scale: 2),
                        SurveyFK = c.Guid(nullable: false),
                        LitterItemFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module80.LitterItems", t => t.LitterItemFK)
                .ForeignKey("Module80.Surveys", t => t.SurveyFK, cascadeDelete: true)
                .Index(t => t.TenantFK, name: "IX_SurveyLitterItem_TenantFK")
                .Index(t => t.RecordState, name: "IX_SurveyLitterItem_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_SurveyLitterItem_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_SurveyLitterItem_LastModifiedByPrincipalId")
                .Index(t => t.SurveyFK)
                .Index(t => t.LitterItemFK);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Module80.Surveys", "OrganisationFK", "Module80.Organisations");
            DropForeignKey("Module80.SurveyLitterItems", "SurveyFK", "Module80.Surveys");
            DropForeignKey("Module80.SurveyLitterItems", "LitterItemFK", "Module80.LitterItems");
            DropForeignKey("Module80.SurveyLargeItems", "SurveyFK", "Module80.Surveys");
            DropForeignKey("Module80.SurveyLargeItems", "LargeItemFK", "Module80.LargeItems");
            DropForeignKey("Module80.SurveyLocations", "RegionFK", "Module80.Regions");
            DropIndex("Module80.SurveyLitterItems", new[] { "LitterItemFK" });
            DropIndex("Module80.SurveyLitterItems", new[] { "SurveyFK" });
            DropIndex("Module80.SurveyLitterItems", "IX_SurveyLitterItem_LastModifiedByPrincipalId");
            DropIndex("Module80.SurveyLitterItems", "IX_SurveyLitterItem_LastModifiedOnUtc");
            DropIndex("Module80.SurveyLitterItems", "IX_SurveyLitterItem_RecordState");
            DropIndex("Module80.SurveyLitterItems", "IX_SurveyLitterItem_TenantFK");
            DropIndex("Module80.SurveyLargeItems", new[] { "LargeItemFK" });
            DropIndex("Module80.SurveyLargeItems", new[] { "SurveyFK" });
            DropIndex("Module80.SurveyLargeItems", "IX_SurveyLargeItem_LastModifiedByPrincipalId");
            DropIndex("Module80.SurveyLargeItems", "IX_SurveyLargeItem_LastModifiedOnUtc");
            DropIndex("Module80.SurveyLargeItems", "IX_SurveyLargeItem_RecordState");
            DropIndex("Module80.SurveyLargeItems", "IX_SurveyLargeItem_TenantFK");
            DropIndex("Module80.Surveys", new[] { "OrganisationFK" });
            DropIndex("Module80.Surveys", "IX_Survey_LastModifiedByPrincipalId");
            DropIndex("Module80.Surveys", "IX_Survey_LastModifiedOnUtc");
            DropIndex("Module80.Surveys", "IX_Survey_RecordState");
            DropIndex("Module80.Surveys", "IX_Survey_TenantFK");
            DropIndex("Module80.Organisations", "IX_Organisation_LastModifiedByPrincipalId");
            DropIndex("Module80.Organisations", "IX_Organisation_LastModifiedOnUtc");
            DropIndex("Module80.Organisations", "IX_Organisation_RecordState");
            DropIndex("Module80.Organisations", "IX_Organisation_TenantFK");
            DropIndex("Module80.LitterItems", "IX_LitterItem_LastModifiedByPrincipalId");
            DropIndex("Module80.LitterItems", "IX_LitterItem_LastModifiedOnUtc");
            DropIndex("Module80.LitterItems", "IX_LitterItem_RecordState");
            DropIndex("Module80.LitterItems", "IX_LitterItem_TenantFK");
            DropIndex("Module80.LargeItems", "IX_LargeItem_LastModifiedByPrincipalId");
            DropIndex("Module80.LargeItems", "IX_LargeItem_LastModifiedOnUtc");
            DropIndex("Module80.LargeItems", "IX_LargeItem_RecordState");
            DropIndex("Module80.LargeItems", "IX_LargeItem_TenantFK");
            DropIndex("Module80.Regions", "IX_Region_LastModifiedByPrincipalId");
            DropIndex("Module80.Regions", "IX_Region_LastModifiedOnUtc");
            DropIndex("Module80.Regions", "IX_Region_RecordState");
            DropIndex("Module80.Regions", "IX_Region_TenantFK");
            DropIndex("Module80.SurveyLocations", new[] { "RegionFK" });
            DropIndex("Module80.SurveyLocations", "IX_SurveyLocation_LastModifiedByPrincipalId");
            DropIndex("Module80.SurveyLocations", "IX_SurveyLocation_LastModifiedOnUtc");
            DropIndex("Module80.SurveyLocations", "IX_SurveyLocation_RecordState");
            DropIndex("Module80.SurveyLocations", "IX_SurveyLocation_TenantFK");
            DropTable("Module80.SurveyLitterItems");
            DropTable("Module80.SurveyLargeItems");
            DropTable("Module80.Surveys");
            DropTable("Module80.Organisations");
            DropTable("Module80.LitterItems");
            DropTable("Module80.LargeItems");
            DropTable("Module80.Regions");
            DropTable("Module80.SurveyLocations");
        }
    }
}
