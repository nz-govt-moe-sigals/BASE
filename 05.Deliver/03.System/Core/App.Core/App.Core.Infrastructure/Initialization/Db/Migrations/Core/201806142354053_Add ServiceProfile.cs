namespace App.Core.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddServiceProfile : DbMigration
    {
        public override void Up()
        {
            DropIndex("Core.PrincipalTags", "IX_PrincipalTag_Text");
            CreateTable(
                "Core.TenantServiceProfileServiceOfferingAllocations",
                c => new
                    {
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(maxLength: 32),
                        ServiceProfileFK = c.Guid(nullable: false),
                        ServiceOfferingFK = c.Guid(nullable: false),
                        Type = c.Int(nullable: false),
                        CostPerMonth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPerYear = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ServiceProfileFK, t.ServiceOfferingFK })
                .ForeignKey("Core.ServiceOfferingDefinitions", t => t.ServiceOfferingFK, cascadeDelete: true)
                .ForeignKey("Core.TenantServiceProfiles", t => t.Id, cascadeDelete: true)
                .Index(t => t.RecordState, name: "IX_TenantServiceProfileServiceOfferingAllocation_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_TenantServiceProfileServiceOfferingAllocation_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_TenantServiceProfileServiceOfferingAllocation_LastModifiedByPrincipalId")
                .Index(t => t.ServiceOfferingFK)
                .Index(t => t.Id);
            
            CreateTable(
                "Core.ServiceOfferingDefinitions",
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
                        ServiceFK = c.Guid(nullable: false),
                        Key = c.String(nullable: false, maxLength: 64),
                        PrincipalLimit = c.Int(nullable: false),
                        ResourceLimit = c.Int(nullable: false),
                        DefaultCostPerMonth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DefaultCostPerYear = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Enabled = c.Boolean(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Core.ServiceDefinitions", t => t.ServiceFK, cascadeDelete: true)
                .Index(t => t.RecordState, name: "IX_ServiceOfferingDefinition_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_ServiceOfferingDefinition_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_ServiceOfferingDefinition_LastModifiedByPrincipalId")
                .Index(t => t.ServiceFK)
                .Index(t => t.Key, unique: true, name: "IX_ServiceOfferingDefinition_Key");
            
            CreateTable(
                "Core.ServiceDefinitions",
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
                        Enabled = c.Boolean(nullable: false),
                        Title = c.String(nullable: false, maxLength: 64),
                        Description = c.String(),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                        Key = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.RecordState, name: "IX_ServiceDefinition_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_ServiceDefinition_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_ServiceDefinition_LastModifiedByPrincipalId")
                .Index(t => t.Title, name: "IX_ServiceDefinition_Title");
            
            CreateTable(
                "Core.TenantServiceProfiles",
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Core.Tenants", t => t.TenantFK, cascadeDelete: true)
                .Index(t => t.TenantFK, name: "IX_TenantServiceProfile_TenantFK")
                .Index(t => t.RecordState, name: "IX_TenantServiceProfile_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_TenantServiceProfile_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_TenantServiceProfile_LastModifiedByPrincipalId");
            
            CreateTable(
                "Core.TenantServiceProfileServicePlanAllocations",
                c => new
                    {
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(maxLength: 32),
                        TenantServiceProfileFK = c.Guid(nullable: false),
                        ServicePlanFK = c.Guid(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        ServicePlanQuantity = c.Int(nullable: false),
                        Start = c.DateTimeOffset(precision: 7),
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.TenantServiceProfileFK, t.ServicePlanFK })
                .ForeignKey("Core.ServicePlanDefinitions", t => t.ServicePlanFK, cascadeDelete: true)
                .ForeignKey("Core.TenantServiceProfiles", t => t.TenantServiceProfileFK, cascadeDelete: true)
                .Index(t => t.RecordState, name: "IX_TenantServiceProfileServicePlanAllocation_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_TenantServiceProfileServicePlanAllocation_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_TenantServiceProfileServicePlanAllocation_LastModifiedByPrincipalId")
                .Index(t => t.TenantServiceProfileFK)
                .Index(t => t.ServicePlanFK);
            
            CreateTable(
                "Core.ServicePlanDefinitions",
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
                        Key = c.String(nullable: false, maxLength: 64),
                        Enabled = c.Boolean(nullable: false),
                        Title = c.String(nullable: false, maxLength: 64),
                        Description = c.String(),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                        PrincipalLimit = c.Int(nullable: false),
                        CostPerMonth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPerYear = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.RecordState, name: "IX_ServicePlanDefinition_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_ServicePlanDefinition_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_ServicePlanDefinition_LastModifiedByPrincipalId")
                .Index(t => t.Key, unique: true, name: "IX_ServicePlanDefinition_Key")
                .Index(t => t.Title, name: "IX_ServicePlanDefinition_Title");
            
            CreateTable(
                "Core.ServicePlanDefinition__ServiceOfferingDefinition",
                c => new
                    {
                        ServicePlanDefinitionFK = c.Guid(nullable: false),
                        ServiceOfferingDefinitionFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ServicePlanDefinitionFK, t.ServiceOfferingDefinitionFK })
                .ForeignKey("Core.ServicePlanDefinitions", t => t.ServicePlanDefinitionFK, cascadeDelete: true)
                .ForeignKey("Core.ServiceOfferingDefinitions", t => t.ServiceOfferingDefinitionFK, cascadeDelete: true)
                .Index(t => t.ServicePlanDefinitionFK)
                .Index(t => t.ServiceOfferingDefinitionFK);
            
            AddColumn("Core.PrincipalCategories", "Title", c => c.String());
            AddColumn("Core.PrincipalCategories", "Description", c => c.String());
            AddColumn("Core.PrincipalTags", "Title", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Core.PrincipalTags", "Description", c => c.String());
            CreateIndex("Core.PrincipalTags", "Title", name: "IX_PrincipalTag_Title");
            DropColumn("Core.PrincipalCategories", "Text");
            DropColumn("Core.PrincipalTags", "Text");
        }
        
        public override void Down()
        {
            AddColumn("Core.PrincipalTags", "Text", c => c.String(nullable: false, maxLength: 64));
            AddColumn("Core.PrincipalCategories", "Text", c => c.String());
            DropForeignKey("Core.TenantServiceProfiles", "TenantFK", "Core.Tenants");
            DropForeignKey("Core.TenantServiceProfileServiceOfferingAllocations", "Id", "Core.TenantServiceProfiles");
            DropForeignKey("Core.TenantServiceProfileServicePlanAllocations", "TenantServiceProfileFK", "Core.TenantServiceProfiles");
            DropForeignKey("Core.TenantServiceProfileServicePlanAllocations", "ServicePlanFK", "Core.ServicePlanDefinitions");
            DropForeignKey("Core.ServicePlanDefinition__ServiceOfferingDefinition", "ServiceOfferingDefinitionFK", "Core.ServiceOfferingDefinitions");
            DropForeignKey("Core.ServicePlanDefinition__ServiceOfferingDefinition", "ServicePlanDefinitionFK", "Core.ServicePlanDefinitions");
            DropForeignKey("Core.TenantServiceProfileServiceOfferingAllocations", "ServiceOfferingFK", "Core.ServiceOfferingDefinitions");
            DropForeignKey("Core.ServiceOfferingDefinitions", "ServiceFK", "Core.ServiceDefinitions");
            DropIndex("Core.ServicePlanDefinition__ServiceOfferingDefinition", new[] { "ServiceOfferingDefinitionFK" });
            DropIndex("Core.ServicePlanDefinition__ServiceOfferingDefinition", new[] { "ServicePlanDefinitionFK" });
            DropIndex("Core.ServicePlanDefinitions", "IX_ServicePlanDefinition_Title");
            DropIndex("Core.ServicePlanDefinitions", "IX_ServicePlanDefinition_Key");
            DropIndex("Core.ServicePlanDefinitions", "IX_ServicePlanDefinition_LastModifiedByPrincipalId");
            DropIndex("Core.ServicePlanDefinitions", "IX_ServicePlanDefinition_LastModifiedOnUtc");
            DropIndex("Core.ServicePlanDefinitions", "IX_ServicePlanDefinition_RecordState");
            DropIndex("Core.TenantServiceProfileServicePlanAllocations", new[] { "ServicePlanFK" });
            DropIndex("Core.TenantServiceProfileServicePlanAllocations", new[] { "TenantServiceProfileFK" });
            DropIndex("Core.TenantServiceProfileServicePlanAllocations", "IX_TenantServiceProfileServicePlanAllocation_LastModifiedByPrincipalId");
            DropIndex("Core.TenantServiceProfileServicePlanAllocations", "IX_TenantServiceProfileServicePlanAllocation_LastModifiedOnUtc");
            DropIndex("Core.TenantServiceProfileServicePlanAllocations", "IX_TenantServiceProfileServicePlanAllocation_RecordState");
            DropIndex("Core.TenantServiceProfiles", "IX_TenantServiceProfile_LastModifiedByPrincipalId");
            DropIndex("Core.TenantServiceProfiles", "IX_TenantServiceProfile_LastModifiedOnUtc");
            DropIndex("Core.TenantServiceProfiles", "IX_TenantServiceProfile_RecordState");
            DropIndex("Core.TenantServiceProfiles", "IX_TenantServiceProfile_TenantFK");
            DropIndex("Core.ServiceDefinitions", "IX_ServiceDefinition_Title");
            DropIndex("Core.ServiceDefinitions", "IX_ServiceDefinition_LastModifiedByPrincipalId");
            DropIndex("Core.ServiceDefinitions", "IX_ServiceDefinition_LastModifiedOnUtc");
            DropIndex("Core.ServiceDefinitions", "IX_ServiceDefinition_RecordState");
            DropIndex("Core.ServiceOfferingDefinitions", "IX_ServiceOfferingDefinition_Key");
            DropIndex("Core.ServiceOfferingDefinitions", new[] { "ServiceFK" });
            DropIndex("Core.ServiceOfferingDefinitions", "IX_ServiceOfferingDefinition_LastModifiedByPrincipalId");
            DropIndex("Core.ServiceOfferingDefinitions", "IX_ServiceOfferingDefinition_LastModifiedOnUtc");
            DropIndex("Core.ServiceOfferingDefinitions", "IX_ServiceOfferingDefinition_RecordState");
            DropIndex("Core.TenantServiceProfileServiceOfferingAllocations", new[] { "Id" });
            DropIndex("Core.TenantServiceProfileServiceOfferingAllocations", new[] { "ServiceOfferingFK" });
            DropIndex("Core.TenantServiceProfileServiceOfferingAllocations", "IX_TenantServiceProfileServiceOfferingAllocation_LastModifiedByPrincipalId");
            DropIndex("Core.TenantServiceProfileServiceOfferingAllocations", "IX_TenantServiceProfileServiceOfferingAllocation_LastModifiedOnUtc");
            DropIndex("Core.TenantServiceProfileServiceOfferingAllocations", "IX_TenantServiceProfileServiceOfferingAllocation_RecordState");
            DropIndex("Core.PrincipalTags", "IX_PrincipalTag_Title");
            DropColumn("Core.PrincipalTags", "Description");
            DropColumn("Core.PrincipalTags", "Title");
            DropColumn("Core.PrincipalCategories", "Description");
            DropColumn("Core.PrincipalCategories", "Title");
            DropTable("Core.ServicePlanDefinition__ServiceOfferingDefinition");
            DropTable("Core.ServicePlanDefinitions");
            DropTable("Core.TenantServiceProfileServicePlanAllocations");
            DropTable("Core.TenantServiceProfiles");
            DropTable("Core.ServiceDefinitions");
            DropTable("Core.ServiceOfferingDefinitions");
            DropTable("Core.TenantServiceProfileServiceOfferingAllocations");
            CreateIndex("Core.PrincipalTags", "Text", name: "IX_PrincipalTag_Text");
        }
    }
}
