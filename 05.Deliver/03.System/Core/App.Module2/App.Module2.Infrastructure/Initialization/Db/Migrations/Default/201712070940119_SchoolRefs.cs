namespace App.Module02.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchoolRefs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Module2.SchoolAuthorities",
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
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module2.SchoolDeciles",
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
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module2.SchoolDefinitions",
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
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module2.SchoolEducationRegions",
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
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module2.SchoolGenders",
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
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module2.SchoolGeneralElectorates",
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
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module2.SchoolMinistryOfEducationLocalOffices",
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
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module2.SchoolMaoriElectorates",
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
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module2.SchoolRegionalCouncils",
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
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module2.SchoolTerritorialAuthorityWithAucklandLocalBoards",
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
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module2.SchoolTypes",
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
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("Module2.Bodies", "Notes", c => c.String());
            AlterColumn("Module2.BodyAlias", "Prefix", c => c.String(maxLength: 64));
            AlterColumn("Module2.BodyAlias", "GivenName", c => c.String(maxLength: 256));
            AlterColumn("Module2.BodyAlias", "MiddleNames", c => c.String(maxLength: 256));
            AlterColumn("Module2.BodyAlias", "SurName", c => c.String(maxLength: 256));
            AlterColumn("Module2.BodyAlias", "Suffix", c => c.String(maxLength: 64));
            AlterColumn("Module2.BodyCategories", "Text", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("Module2.BodyCategories", "DisplayStyleHint", c => c.String(maxLength: 64));
            AlterColumn("Module2.BodyChannels", "Title", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("Module2.BodyChannels", "AddressSuburb", c => c.String(maxLength: 256));
            AlterColumn("Module2.BodyChannels", "AddressCity", c => c.String(maxLength: 256));
            AlterColumn("Module2.BodyChannels", "AddressRegion", c => c.String(maxLength: 256));
            AlterColumn("Module2.BodyChannels", "AddressState", c => c.String(maxLength: 256));
            AlterColumn("Module2.BodyChannels", "AddressPostalCode", c => c.String(maxLength: 256));
            AlterColumn("Module2.BodyChannels", "AddressCountry", c => c.String(maxLength: 256));
            AlterColumn("Module2.BodyChannels", "AddressInstructions", c => c.String(maxLength: 256));
            AlterColumn("Module2.BodyClaims", "Authority", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("Module2.BodyClaims", "Key", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("Module2.BodyProperties", "Key", c => c.String(nullable: false, maxLength: 64));
        }
        
        public override void Down()
        {
            AlterColumn("Module2.BodyProperties", "Key", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("Module2.BodyClaims", "Key", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("Module2.BodyClaims", "Authority", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("Module2.BodyChannels", "AddressInstructions", c => c.String(maxLength: 100));
            AlterColumn("Module2.BodyChannels", "AddressCountry", c => c.String(maxLength: 100));
            AlterColumn("Module2.BodyChannels", "AddressPostalCode", c => c.String(maxLength: 100));
            AlterColumn("Module2.BodyChannels", "AddressState", c => c.String(maxLength: 100));
            AlterColumn("Module2.BodyChannels", "AddressRegion", c => c.String(maxLength: 100));
            AlterColumn("Module2.BodyChannels", "AddressCity", c => c.String(maxLength: 100));
            AlterColumn("Module2.BodyChannels", "AddressSuburb", c => c.String(maxLength: 100));
            AlterColumn("Module2.BodyChannels", "Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("Module2.BodyCategories", "DisplayStyleHint", c => c.String(maxLength: 50));
            AlterColumn("Module2.BodyCategories", "Text", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("Module2.BodyAlias", "Suffix", c => c.String(maxLength: 50));
            AlterColumn("Module2.BodyAlias", "SurName", c => c.String(maxLength: 100));
            AlterColumn("Module2.BodyAlias", "MiddleNames", c => c.String(maxLength: 100));
            AlterColumn("Module2.BodyAlias", "GivenName", c => c.String(maxLength: 100));
            AlterColumn("Module2.BodyAlias", "Prefix", c => c.String(maxLength: 50));
            AlterColumn("Module2.Bodies", "Notes", c => c.String(maxLength: 2048));
            DropTable("Module2.SchoolTypes");
            DropTable("Module2.SchoolTerritorialAuthorityWithAucklandLocalBoards");
            DropTable("Module2.SchoolRegionalCouncils");
            DropTable("Module2.SchoolMaoriElectorates");
            DropTable("Module2.SchoolMinistryOfEducationLocalOffices");
            DropTable("Module2.SchoolGeneralElectorates");
            DropTable("Module2.SchoolGenders");
            DropTable("Module2.SchoolEducationRegions");
            DropTable("Module2.SchoolDefinitions");
            DropTable("Module2.SchoolDeciles");
            DropTable("Module2.SchoolAuthorities");
        }
    }
}
