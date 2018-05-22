namespace App.Module11.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Module11.Bodies",
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
                        Type = c.Int(nullable: false),
                        Key = c.String(maxLength: 256),
                        Description = c.String(maxLength: 256),
                        Notes = c.String(),
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
                .ForeignKey("Module11.BodyCategories", t => t.CategoryFK, cascadeDelete: true)
                .ForeignKey("Module11.BodyLocations", t => t.LocationFK)
                .Index(t => t.TenantFK, name: "IX_Body_TenantFK")
                .Index(t => t.RecordState, name: "IX_Body_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_Body_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_Body_LastModifiedByPrincipalId")
                .Index(t => t.CategoryFK)
                .Index(t => t.LocationFK);
            
            CreateTable(
                "Module11.BodyAlias",
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
                        OwnerFK = c.Guid(nullable: false),
                        DisplayOrderHint = c.Int(nullable: false),
                        Name = c.String(maxLength: 256),
                        Prefix = c.String(maxLength: 64),
                        GivenName = c.String(maxLength: 256),
                        MiddleNames = c.String(maxLength: 256),
                        SurName = c.String(maxLength: 256),
                        Suffix = c.String(maxLength: 64),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module11.Bodies", t => t.OwnerFK, cascadeDelete: true)
                .Index(t => t.TenantFK, name: "IX_BodyAlias_TenantFK")
                .Index(t => t.RecordState, name: "IX_BodyAlias_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_BodyAlias_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_BodyAlias_LastModifiedByPrincipalId")
                .Index(t => t.OwnerFK);
            
            CreateTable(
                "Module11.BodyCategories",
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
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_BodyCategory_TenantFK")
                .Index(t => t.RecordState, name: "IX_BodyCategory_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_BodyCategory_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_BodyCategory_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module11.BodyChannels",
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
                        OwnerFK = c.Guid(nullable: false),
                        DisplayOrderHint = c.Int(nullable: false),
                        Protocol = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 64),
                        Address = c.String(maxLength: 256),
                        AddressStreetAndNumber = c.String(maxLength: 256),
                        AddressSuburb = c.String(maxLength: 256),
                        AddressCity = c.String(maxLength: 256),
                        AddressRegion = c.String(maxLength: 256),
                        AddressState = c.String(maxLength: 256),
                        AddressPostalCode = c.String(maxLength: 256),
                        AddressCountry = c.String(maxLength: 256),
                        AddressInstructions = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module11.Bodies", t => t.OwnerFK, cascadeDelete: true)
                .Index(t => t.TenantFK, name: "IX_BodyChannel_TenantFK")
                .Index(t => t.RecordState, name: "IX_BodyChannel_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_BodyChannel_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_BodyChannel_LastModifiedByPrincipalId")
                .Index(t => t.OwnerFK);
            
            CreateTable(
                "Module11.BodyClaims",
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
                        OwnerFK = c.Guid(nullable: false),
                        Authority = c.String(nullable: false, maxLength: 64),
                        Key = c.String(nullable: false, maxLength: 64),
                        Value = c.String(maxLength: 1024),
                        AuthoritySignature = c.String(nullable: false, maxLength: 1024),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module11.Bodies", t => t.OwnerFK, cascadeDelete: true)
                .Index(t => t.TenantFK, name: "IX_BodyClaim_TenantFK")
                .Index(t => t.RecordState, name: "IX_BodyClaim_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_BodyClaim_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_BodyClaim_LastModifiedByPrincipalId")
                .Index(t => t.OwnerFK);
            
            CreateTable(
                "Module11.BodyLocations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.Int(nullable: false),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Altitude = c.Decimal(precision: 18, scale: 2),
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
                "Module11.BodyProperties",
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
                        OwnerFK = c.Guid(nullable: false),
                        Key = c.String(nullable: false, maxLength: 64),
                        Value = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module11.Bodies", t => t.OwnerFK, cascadeDelete: true)
                .Index(t => t.TenantFK, name: "IX_BodyProperty_TenantFK")
                .Index(t => t.RecordState, name: "IX_BodyProperty_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_BodyProperty_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_BodyProperty_LastModifiedByPrincipalId")
                .Index(t => t.OwnerFK);
            
            CreateTable(
                "Module11.EducationOrganisations",
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
                        ParentFK = c.Guid(),
                        Type = c.Int(nullable: false),
                        Key = c.String(),
                        Description = c.String(),
                        OrganisationFK = c.Guid(nullable: false),
                        PrincipalFK = c.Guid(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module11.Bodies", t => t.OrganisationFK)
                .ForeignKey("Module11.Bodies", t => t.PrincipalFK)
                .Index(t => t.TenantFK, name: "IX_EducationOrganisation_TenantFK")
                .Index(t => t.RecordState, name: "IX_EducationOrganisation_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_EducationOrganisation_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_EducationOrganisation_LastModifiedByPrincipalId")
                .Index(t => t.OrganisationFK)
                .Index(t => t.PrincipalFK);
            
            CreateTable(
                "Module11.SchoolAuthorities",
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
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_SchoolAuthority_TenantFK")
                .Index(t => t.RecordState, name: "IX_SchoolAuthority_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_SchoolAuthority_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_SchoolAuthority_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module11.SchoolDeciles",
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
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_SchoolDecile_TenantFK")
                .Index(t => t.RecordState, name: "IX_SchoolDecile_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_SchoolDecile_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_SchoolDecile_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module11.SchoolDefinitions",
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
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_SchoolDefinition_TenantFK")
                .Index(t => t.RecordState, name: "IX_SchoolDefinition_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_SchoolDefinition_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_SchoolDefinition_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module11.SchoolEducationRegions",
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
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_SchoolEducationRegion_TenantFK")
                .Index(t => t.RecordState, name: "IX_SchoolEducationRegion_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_SchoolEducationRegion_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_SchoolEducationRegion_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module11.SchoolGenders",
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
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_SchoolGender_TenantFK")
                .Index(t => t.RecordState, name: "IX_SchoolGender_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_SchoolGender_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_SchoolGender_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module11.SchoolGeneralElectorates",
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
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_SchoolGeneralElectorate_TenantFK")
                .Index(t => t.RecordState, name: "IX_SchoolGeneralElectorate_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_SchoolGeneralElectorate_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_SchoolGeneralElectorate_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module11.SchoolMinistryOfEducationLocalOffices",
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
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_SchoolMinistryOfEducationLocalOffice_TenantFK")
                .Index(t => t.RecordState, name: "IX_SchoolMinistryOfEducationLocalOffice_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_SchoolMinistryOfEducationLocalOffice_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_SchoolMinistryOfEducationLocalOffice_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module11.SchoolMaoriElectorates",
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
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_SchoolMaoriElectorate_TenantFK")
                .Index(t => t.RecordState, name: "IX_SchoolMaoriElectorate_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_SchoolMaoriElectorate_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_SchoolMaoriElectorate_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module11.SchoolRegionalCouncils",
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
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_SchoolRegionalCouncil_TenantFK")
                .Index(t => t.RecordState, name: "IX_SchoolRegionalCouncil_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_SchoolRegionalCouncil_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_SchoolRegionalCouncil_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module11.SchoolTerritorialAuthorityWithAucklandLocalBoards",
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
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_SchoolTerritorialAuthorityWithAucklandLocalBoard_TenantFK")
                .Index(t => t.RecordState, name: "IX_SchoolTerritorialAuthorityWithAucklandLocalBoard_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_SchoolTerritorialAuthorityWithAucklandLocalBoard_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_SchoolTerritorialAuthorityWithAucklandLocalBoard_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module11.SchoolTypes",
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
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_SchoolType_TenantFK")
                .Index(t => t.RecordState, name: "IX_SchoolType_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_SchoolType_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_SchoolType_LastModifiedByPrincipalId");
            
        }
        
        public override void Down()
        {
            DropForeignKey("Module11.EducationOrganisations", "PrincipalFK", "Module11.Bodies");
            DropForeignKey("Module11.EducationOrganisations", "OrganisationFK", "Module11.Bodies");
            DropForeignKey("Module11.BodyProperties", "OwnerFK", "Module11.Bodies");
            DropForeignKey("Module11.Bodies", "LocationFK", "Module11.BodyLocations");
            DropForeignKey("Module11.BodyClaims", "OwnerFK", "Module11.Bodies");
            DropForeignKey("Module11.BodyChannels", "OwnerFK", "Module11.Bodies");
            DropForeignKey("Module11.Bodies", "CategoryFK", "Module11.BodyCategories");
            DropForeignKey("Module11.BodyAlias", "OwnerFK", "Module11.Bodies");
            DropIndex("Module11.SchoolTypes", "IX_SchoolType_LastModifiedByPrincipalId");
            DropIndex("Module11.SchoolTypes", "IX_SchoolType_LastModifiedOnUtc");
            DropIndex("Module11.SchoolTypes", "IX_SchoolType_RecordState");
            DropIndex("Module11.SchoolTypes", "IX_SchoolType_TenantFK");
            DropIndex("Module11.SchoolTerritorialAuthorityWithAucklandLocalBoards", "IX_SchoolTerritorialAuthorityWithAucklandLocalBoard_LastModifiedByPrincipalId");
            DropIndex("Module11.SchoolTerritorialAuthorityWithAucklandLocalBoards", "IX_SchoolTerritorialAuthorityWithAucklandLocalBoard_LastModifiedOnUtc");
            DropIndex("Module11.SchoolTerritorialAuthorityWithAucklandLocalBoards", "IX_SchoolTerritorialAuthorityWithAucklandLocalBoard_RecordState");
            DropIndex("Module11.SchoolTerritorialAuthorityWithAucklandLocalBoards", "IX_SchoolTerritorialAuthorityWithAucklandLocalBoard_TenantFK");
            DropIndex("Module11.SchoolRegionalCouncils", "IX_SchoolRegionalCouncil_LastModifiedByPrincipalId");
            DropIndex("Module11.SchoolRegionalCouncils", "IX_SchoolRegionalCouncil_LastModifiedOnUtc");
            DropIndex("Module11.SchoolRegionalCouncils", "IX_SchoolRegionalCouncil_RecordState");
            DropIndex("Module11.SchoolRegionalCouncils", "IX_SchoolRegionalCouncil_TenantFK");
            DropIndex("Module11.SchoolMaoriElectorates", "IX_SchoolMaoriElectorate_LastModifiedByPrincipalId");
            DropIndex("Module11.SchoolMaoriElectorates", "IX_SchoolMaoriElectorate_LastModifiedOnUtc");
            DropIndex("Module11.SchoolMaoriElectorates", "IX_SchoolMaoriElectorate_RecordState");
            DropIndex("Module11.SchoolMaoriElectorates", "IX_SchoolMaoriElectorate_TenantFK");
            DropIndex("Module11.SchoolMinistryOfEducationLocalOffices", "IX_SchoolMinistryOfEducationLocalOffice_LastModifiedByPrincipalId");
            DropIndex("Module11.SchoolMinistryOfEducationLocalOffices", "IX_SchoolMinistryOfEducationLocalOffice_LastModifiedOnUtc");
            DropIndex("Module11.SchoolMinistryOfEducationLocalOffices", "IX_SchoolMinistryOfEducationLocalOffice_RecordState");
            DropIndex("Module11.SchoolMinistryOfEducationLocalOffices", "IX_SchoolMinistryOfEducationLocalOffice_TenantFK");
            DropIndex("Module11.SchoolGeneralElectorates", "IX_SchoolGeneralElectorate_LastModifiedByPrincipalId");
            DropIndex("Module11.SchoolGeneralElectorates", "IX_SchoolGeneralElectorate_LastModifiedOnUtc");
            DropIndex("Module11.SchoolGeneralElectorates", "IX_SchoolGeneralElectorate_RecordState");
            DropIndex("Module11.SchoolGeneralElectorates", "IX_SchoolGeneralElectorate_TenantFK");
            DropIndex("Module11.SchoolGenders", "IX_SchoolGender_LastModifiedByPrincipalId");
            DropIndex("Module11.SchoolGenders", "IX_SchoolGender_LastModifiedOnUtc");
            DropIndex("Module11.SchoolGenders", "IX_SchoolGender_RecordState");
            DropIndex("Module11.SchoolGenders", "IX_SchoolGender_TenantFK");
            DropIndex("Module11.SchoolEducationRegions", "IX_SchoolEducationRegion_LastModifiedByPrincipalId");
            DropIndex("Module11.SchoolEducationRegions", "IX_SchoolEducationRegion_LastModifiedOnUtc");
            DropIndex("Module11.SchoolEducationRegions", "IX_SchoolEducationRegion_RecordState");
            DropIndex("Module11.SchoolEducationRegions", "IX_SchoolEducationRegion_TenantFK");
            DropIndex("Module11.SchoolDefinitions", "IX_SchoolDefinition_LastModifiedByPrincipalId");
            DropIndex("Module11.SchoolDefinitions", "IX_SchoolDefinition_LastModifiedOnUtc");
            DropIndex("Module11.SchoolDefinitions", "IX_SchoolDefinition_RecordState");
            DropIndex("Module11.SchoolDefinitions", "IX_SchoolDefinition_TenantFK");
            DropIndex("Module11.SchoolDeciles", "IX_SchoolDecile_LastModifiedByPrincipalId");
            DropIndex("Module11.SchoolDeciles", "IX_SchoolDecile_LastModifiedOnUtc");
            DropIndex("Module11.SchoolDeciles", "IX_SchoolDecile_RecordState");
            DropIndex("Module11.SchoolDeciles", "IX_SchoolDecile_TenantFK");
            DropIndex("Module11.SchoolAuthorities", "IX_SchoolAuthority_LastModifiedByPrincipalId");
            DropIndex("Module11.SchoolAuthorities", "IX_SchoolAuthority_LastModifiedOnUtc");
            DropIndex("Module11.SchoolAuthorities", "IX_SchoolAuthority_RecordState");
            DropIndex("Module11.SchoolAuthorities", "IX_SchoolAuthority_TenantFK");
            DropIndex("Module11.EducationOrganisations", new[] { "PrincipalFK" });
            DropIndex("Module11.EducationOrganisations", new[] { "OrganisationFK" });
            DropIndex("Module11.EducationOrganisations", "IX_EducationOrganisation_LastModifiedByPrincipalId");
            DropIndex("Module11.EducationOrganisations", "IX_EducationOrganisation_LastModifiedOnUtc");
            DropIndex("Module11.EducationOrganisations", "IX_EducationOrganisation_RecordState");
            DropIndex("Module11.EducationOrganisations", "IX_EducationOrganisation_TenantFK");
            DropIndex("Module11.BodyProperties", new[] { "OwnerFK" });
            DropIndex("Module11.BodyProperties", "IX_BodyProperty_LastModifiedByPrincipalId");
            DropIndex("Module11.BodyProperties", "IX_BodyProperty_LastModifiedOnUtc");
            DropIndex("Module11.BodyProperties", "IX_BodyProperty_RecordState");
            DropIndex("Module11.BodyProperties", "IX_BodyProperty_TenantFK");
            DropIndex("Module11.BodyClaims", new[] { "OwnerFK" });
            DropIndex("Module11.BodyClaims", "IX_BodyClaim_LastModifiedByPrincipalId");
            DropIndex("Module11.BodyClaims", "IX_BodyClaim_LastModifiedOnUtc");
            DropIndex("Module11.BodyClaims", "IX_BodyClaim_RecordState");
            DropIndex("Module11.BodyClaims", "IX_BodyClaim_TenantFK");
            DropIndex("Module11.BodyChannels", new[] { "OwnerFK" });
            DropIndex("Module11.BodyChannels", "IX_BodyChannel_LastModifiedByPrincipalId");
            DropIndex("Module11.BodyChannels", "IX_BodyChannel_LastModifiedOnUtc");
            DropIndex("Module11.BodyChannels", "IX_BodyChannel_RecordState");
            DropIndex("Module11.BodyChannels", "IX_BodyChannel_TenantFK");
            DropIndex("Module11.BodyCategories", "IX_BodyCategory_LastModifiedByPrincipalId");
            DropIndex("Module11.BodyCategories", "IX_BodyCategory_LastModifiedOnUtc");
            DropIndex("Module11.BodyCategories", "IX_BodyCategory_RecordState");
            DropIndex("Module11.BodyCategories", "IX_BodyCategory_TenantFK");
            DropIndex("Module11.BodyAlias", new[] { "OwnerFK" });
            DropIndex("Module11.BodyAlias", "IX_BodyAlias_LastModifiedByPrincipalId");
            DropIndex("Module11.BodyAlias", "IX_BodyAlias_LastModifiedOnUtc");
            DropIndex("Module11.BodyAlias", "IX_BodyAlias_RecordState");
            DropIndex("Module11.BodyAlias", "IX_BodyAlias_TenantFK");
            DropIndex("Module11.Bodies", new[] { "LocationFK" });
            DropIndex("Module11.Bodies", new[] { "CategoryFK" });
            DropIndex("Module11.Bodies", "IX_Body_LastModifiedByPrincipalId");
            DropIndex("Module11.Bodies", "IX_Body_LastModifiedOnUtc");
            DropIndex("Module11.Bodies", "IX_Body_RecordState");
            DropIndex("Module11.Bodies", "IX_Body_TenantFK");
            DropTable("Module11.SchoolTypes");
            DropTable("Module11.SchoolTerritorialAuthorityWithAucklandLocalBoards");
            DropTable("Module11.SchoolRegionalCouncils");
            DropTable("Module11.SchoolMaoriElectorates");
            DropTable("Module11.SchoolMinistryOfEducationLocalOffices");
            DropTable("Module11.SchoolGeneralElectorates");
            DropTable("Module11.SchoolGenders");
            DropTable("Module11.SchoolEducationRegions");
            DropTable("Module11.SchoolDefinitions");
            DropTable("Module11.SchoolDeciles");
            DropTable("Module11.SchoolAuthorities");
            DropTable("Module11.EducationOrganisations");
            DropTable("Module11.BodyProperties");
            DropTable("Module11.BodyLocations");
            DropTable("Module11.BodyClaims");
            DropTable("Module11.BodyChannels");
            DropTable("Module11.BodyCategories");
            DropTable("Module11.BodyAlias");
            DropTable("Module11.Bodies");
        }
    }
}
