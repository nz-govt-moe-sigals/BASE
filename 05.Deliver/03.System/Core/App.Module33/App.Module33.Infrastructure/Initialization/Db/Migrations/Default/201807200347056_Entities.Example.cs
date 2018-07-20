namespace App.Module33.Infrastructure.Initialization.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesExample : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Module33.CoherentPathwayLearningAreaCapabilities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CoherentPathwayLearningAreaStepFK = c.Guid(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(),
                        TenantFK = c.Guid(nullable: false),
                        Timestamp = c.Binary(),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(),
                        CreatedByPrincipalId = c.String(),
                        LastModifiedOnUtc = c.DateTime(),
                        LastModifiedByPrincipalId = c.String(),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module33.CoherentPathwayLearningAreaSteps", t => t.CoherentPathwayLearningAreaStepFK, cascadeDelete: true)
                .Index(t => t.CoherentPathwayLearningAreaStepFK);
            
            CreateTable(
                "Module33.CoherentPathwayLearningAreaSteps",
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
                        CurriculumArea = c.Boolean(nullable: false),
                        CoherentPathwayStepFK = c.Guid(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module33.CoherentPathwaySteps", t => t.CoherentPathwayStepFK, cascadeDelete: true)
                .Index(t => t.TenantFK, name: "IX_CoherentPathwayLearningAreaStep_TenantFK")
                .Index(t => t.RecordState, name: "IX_CoherentPathwayLearningAreaStep_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CoherentPathwayLearningAreaStep_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CoherentPathwayLearningAreaStep_LastModifiedByPrincipalId")
                .Index(t => t.CoherentPathwayStepFK);
            
            CreateTable(
                "Module33.CoherentPathwaySteps",
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
                        CoherentPathwayFK = c.Guid(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module33.CoherentPathways", t => t.CoherentPathwayFK, cascadeDelete: true)
                .Index(t => t.TenantFK, name: "IX_CoherentPathwayStep_TenantFK")
                .Index(t => t.RecordState, name: "IX_CoherentPathwayStep_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CoherentPathwayStep_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CoherentPathwayStep_LastModifiedByPrincipalId")
                .Index(t => t.CoherentPathwayFK);
            
            CreateTable(
                "Module33.CoherentPathways",
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
                        Strategy = c.String(),
                        CommunityFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module33.Communities", t => t.CommunityFK, cascadeDelete: true)
                .Index(t => t.TenantFK, name: "IX_CoherentPathway_TenantFK")
                .Index(t => t.RecordState, name: "IX_CoherentPathway_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CoherentPathway_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CoherentPathway_LastModifiedByPrincipalId")
                .Index(t => t.CommunityFK);
            
            CreateTable(
                "Module33.Communities",
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
                        Owner = c.String(nullable: false),
                        PublicText = c.String(nullable: false),
                        SensitiveText = c.String(),
                        AppPrivateText = c.String(),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        ColourSchemeFK = c.Guid(nullable: false),
                        Strategy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module33.CommunityColourSchemes", t => t.ColourSchemeFK, cascadeDelete: true)
                .Index(t => t.TenantFK, name: "IX_Community_TenantFK")
                .Index(t => t.RecordState, name: "IX_Community_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_Community_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_Community_LastModifiedByPrincipalId")
                .Index(t => t.ColourSchemeFK);
            
            CreateTable(
                "Module33.CommunityColourSchemes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(),
                        TenantFK = c.Guid(nullable: false),
                        Timestamp = c.Binary(),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(),
                        CreatedByPrincipalId = c.String(),
                        LastModifiedOnUtc = c.DateTime(),
                        LastModifiedByPrincipalId = c.String(),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module33.CoherentPathwayOverarchingCapabilities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CoherentPathwayStepFK = c.Guid(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(),
                        TenantFK = c.Guid(nullable: false),
                        Timestamp = c.Binary(),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(),
                        CreatedByPrincipalId = c.String(),
                        LastModifiedOnUtc = c.DateTime(),
                        LastModifiedByPrincipalId = c.String(),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module33.CoherentPathwaySteps", t => t.CoherentPathwayStepFK, cascadeDelete: true)
                .Index(t => t.CoherentPathwayStepFK);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Module33.CoherentPathwayOverarchingCapabilities", "CoherentPathwayStepFK", "Module33.CoherentPathwaySteps");
            DropForeignKey("Module33.CoherentPathwayLearningAreaSteps", "CoherentPathwayStepFK", "Module33.CoherentPathwaySteps");
            DropForeignKey("Module33.Communities", "ColourSchemeFK", "Module33.CommunityColourSchemes");
            DropForeignKey("Module33.CoherentPathways", "CommunityFK", "Module33.Communities");
            DropForeignKey("Module33.CoherentPathwaySteps", "CoherentPathwayFK", "Module33.CoherentPathways");
            DropForeignKey("Module33.CoherentPathwayLearningAreaCapabilities", "CoherentPathwayLearningAreaStepFK", "Module33.CoherentPathwayLearningAreaSteps");
            DropIndex("Module33.CoherentPathwayOverarchingCapabilities", new[] { "CoherentPathwayStepFK" });
            DropIndex("Module33.Communities", new[] { "ColourSchemeFK" });
            DropIndex("Module33.Communities", "IX_Community_LastModifiedByPrincipalId");
            DropIndex("Module33.Communities", "IX_Community_LastModifiedOnUtc");
            DropIndex("Module33.Communities", "IX_Community_RecordState");
            DropIndex("Module33.Communities", "IX_Community_TenantFK");
            DropIndex("Module33.CoherentPathways", new[] { "CommunityFK" });
            DropIndex("Module33.CoherentPathways", "IX_CoherentPathway_LastModifiedByPrincipalId");
            DropIndex("Module33.CoherentPathways", "IX_CoherentPathway_LastModifiedOnUtc");
            DropIndex("Module33.CoherentPathways", "IX_CoherentPathway_RecordState");
            DropIndex("Module33.CoherentPathways", "IX_CoherentPathway_TenantFK");
            DropIndex("Module33.CoherentPathwaySteps", new[] { "CoherentPathwayFK" });
            DropIndex("Module33.CoherentPathwaySteps", "IX_CoherentPathwayStep_LastModifiedByPrincipalId");
            DropIndex("Module33.CoherentPathwaySteps", "IX_CoherentPathwayStep_LastModifiedOnUtc");
            DropIndex("Module33.CoherentPathwaySteps", "IX_CoherentPathwayStep_RecordState");
            DropIndex("Module33.CoherentPathwaySteps", "IX_CoherentPathwayStep_TenantFK");
            DropIndex("Module33.CoherentPathwayLearningAreaSteps", new[] { "CoherentPathwayStepFK" });
            DropIndex("Module33.CoherentPathwayLearningAreaSteps", "IX_CoherentPathwayLearningAreaStep_LastModifiedByPrincipalId");
            DropIndex("Module33.CoherentPathwayLearningAreaSteps", "IX_CoherentPathwayLearningAreaStep_LastModifiedOnUtc");
            DropIndex("Module33.CoherentPathwayLearningAreaSteps", "IX_CoherentPathwayLearningAreaStep_RecordState");
            DropIndex("Module33.CoherentPathwayLearningAreaSteps", "IX_CoherentPathwayLearningAreaStep_TenantFK");
            DropIndex("Module33.CoherentPathwayLearningAreaCapabilities", new[] { "CoherentPathwayLearningAreaStepFK" });
            DropTable("Module33.CoherentPathwayOverarchingCapabilities");
            DropTable("Module33.CommunityColourSchemes");
            DropTable("Module33.Communities");
            DropTable("Module33.CoherentPathways");
            DropTable("Module33.CoherentPathwaySteps");
            DropTable("Module33.CoherentPathwayLearningAreaSteps");
            DropTable("Module33.CoherentPathwayLearningAreaCapabilities");
        }
    }
}
