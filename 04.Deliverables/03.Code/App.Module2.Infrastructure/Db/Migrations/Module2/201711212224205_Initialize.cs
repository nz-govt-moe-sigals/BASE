namespace App.Module2.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Module2.Bodies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                        TenantFK = c.Guid(nullable: false),
                        Type = c.Int(nullable: false),
                        Key = c.String(maxLength: 256),
                        Description = c.String(maxLength: 256),
                        Notes = c.String(maxLength: 2048),
                        CategoryFK = c.Guid(nullable: false),
                        LocationFK = c.Guid(),
                        Name = c.String(),
                        Prefix = c.String(),
                        GivenName = c.String(),
                        MiddleNames = c.String(),
                        SurName = c.String(),
                        Suffix = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module2.BodyCategories", t => t.CategoryFK, cascadeDelete: true)
                .ForeignKey("Module2.BodyLocations", t => t.LocationFK)
                .Index(t => t.CategoryFK)
                .Index(t => t.LocationFK);
            
            CreateTable(
                "Module2.BodyAlias",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                        TenantFK = c.Guid(nullable: false),
                        RecordState = c.Int(nullable: false),
                        OwnerFK = c.Guid(nullable: false),
                        DisplayOrderHint = c.Int(nullable: false),
                        Name = c.String(maxLength: 256),
                        Prefix = c.String(maxLength: 50),
                        GivenName = c.String(maxLength: 100),
                        MiddleNames = c.String(maxLength: 100),
                        SurName = c.String(maxLength: 100),
                        Suffix = c.String(maxLength: 50),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module2.Bodies", t => t.OwnerFK, cascadeDelete: true)
                .Index(t => t.OwnerFK);
            
            CreateTable(
                "Module2.BodyCategories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                        TenantFK = c.Guid(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 50),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module2.BodyChannels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                        TenantFK = c.Guid(nullable: false),
                        OwnerFK = c.Guid(nullable: false),
                        DisplayOrderHint = c.Int(nullable: false),
                        Protocol = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50),
                        Address = c.String(maxLength: 256),
                        AddressStreetAndNumber = c.String(maxLength: 256),
                        AddressSuburb = c.String(maxLength: 100),
                        AddressCity = c.String(maxLength: 100),
                        AddressRegion = c.String(maxLength: 100),
                        AddressState = c.String(maxLength: 100),
                        AddressPostalCode = c.String(maxLength: 100),
                        AddressCountry = c.String(maxLength: 100),
                        AddressInstructions = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module2.Bodies", t => t.OwnerFK, cascadeDelete: true)
                .Index(t => t.OwnerFK);
            
            CreateTable(
                "Module2.BodyClaims",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                        TenantFK = c.Guid(nullable: false),
                        OwnerFK = c.Guid(nullable: false),
                        Authority = c.String(nullable: false, maxLength: 50),
                        Key = c.String(nullable: false, maxLength: 50),
                        Value = c.String(maxLength: 1024),
                        AuthoritySignature = c.String(nullable: false, maxLength: 1024),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module2.Bodies", t => t.OwnerFK, cascadeDelete: true)
                .Index(t => t.OwnerFK);
            
            CreateTable(
                "Module2.BodyLocations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TenantFK = c.Guid(nullable: false),
                        CreatedOnUtc = c.DateTime(),
                        CreatedByPrincipalId = c.String(),
                        LastModifiedOnUtc = c.DateTime(),
                        LastModifiedByPrincipalId = c.String(),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                        RecordState = c.Int(nullable: false),
                        Timestamp = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module2.BodyProperties",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                        TenantFK = c.Guid(nullable: false),
                        OwnerFK = c.Guid(nullable: false),
                        Key = c.String(nullable: false, maxLength: 50),
                        Value = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module2.Bodies", t => t.OwnerFK, cascadeDelete: true)
                .Index(t => t.OwnerFK);
            
            CreateTable(
                "Module2.EducationOrganisations",
                c => new
                    {
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        ParentFK = c.Guid(),
                        Type = c.Int(nullable: false),
                        Key = c.String(),
                        Description = c.String(),
                        OrganisationFK = c.Guid(nullable: false),
                        PrincipalFK = c.Guid(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module2.Bodies", t => t.OrganisationFK)
                .ForeignKey("Module2.Bodies", t => t.PrincipalFK)
                .Index(t => t.OrganisationFK)
                .Index(t => t.PrincipalFK);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Module2.EducationOrganisations", "PrincipalFK", "Module2.Bodies");
            DropForeignKey("Module2.EducationOrganisations", "OrganisationFK", "Module2.Bodies");
            DropForeignKey("Module2.BodyProperties", "OwnerFK", "Module2.Bodies");
            DropForeignKey("Module2.Bodies", "LocationFK", "Module2.BodyLocations");
            DropForeignKey("Module2.BodyClaims", "OwnerFK", "Module2.Bodies");
            DropForeignKey("Module2.BodyChannels", "OwnerFK", "Module2.Bodies");
            DropForeignKey("Module2.Bodies", "CategoryFK", "Module2.BodyCategories");
            DropForeignKey("Module2.BodyAlias", "OwnerFK", "Module2.Bodies");
            DropIndex("Module2.EducationOrganisations", new[] { "PrincipalFK" });
            DropIndex("Module2.EducationOrganisations", new[] { "OrganisationFK" });
            DropIndex("Module2.BodyProperties", new[] { "OwnerFK" });
            DropIndex("Module2.BodyClaims", new[] { "OwnerFK" });
            DropIndex("Module2.BodyChannels", new[] { "OwnerFK" });
            DropIndex("Module2.BodyAlias", new[] { "OwnerFK" });
            DropIndex("Module2.Bodies", new[] { "LocationFK" });
            DropIndex("Module2.Bodies", new[] { "CategoryFK" });
            DropTable("Module2.EducationOrganisations");
            DropTable("Module2.BodyProperties");
            DropTable("Module2.BodyLocations");
            DropTable("Module2.BodyClaims");
            DropTable("Module2.BodyChannels");
            DropTable("Module2.BodyCategories");
            DropTable("Module2.BodyAlias");
            DropTable("Module2.Bodies");
        }
    }
}
