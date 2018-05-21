namespace App.Module3.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesInitialise : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Module3.ExtractWatermarks",
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
                        SourceTableName = c.String(nullable: false, maxLength: 255),
                        Watermark = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SourceTableName, unique: true, name: "UX_ExtractWatermark_SourceTableName");
            
            CreateTable(
                "Module3.AreaUnits",
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
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_AreaUnit_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_AreaUnit_SIFKey");
            
            CreateTable(
                "Module3.AuthorityTypes",
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
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_AuthorityType_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_AuthorityType_SIFKey");
            
            CreateTable(
                "Module3.CommunityBoards",
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
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_CommunityBoard_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_CommunityBoard_SIFKey");
            
            CreateTable(
                "Module3.GeneralElectorates",
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
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_GeneralElectorate_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_GeneralElectorate_SIFKey");
            
            CreateTable(
                "Module3.MaoriElectorates",
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
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_MaoriElectorate_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_MaoriElectorate_SIFKey");
            
            CreateTable(
                "Module3.EducationProviderStatus",
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
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_EducationProviderStatus_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_EducationProviderStatus_SIFKey");
            
            CreateTable(
                "Module3.EducationProviderTypes",
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
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_EducationProviderType_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_EducationProviderType_SIFKey");
            
            CreateTable(
                "Module3.Regions",
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
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_Region_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_Region_SIFKey");
            
            CreateTable(
                "Module3.RegionalCouncils",
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
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_RegionalCouncil_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_RegionalCouncil_SIFKey");
            
            CreateTable(
                "Module3.RelationshipTypes",
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
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_RelationshipType_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_RelationshipType_SIFKey");
            
            CreateTable(
                "Module3.EducationProviderClassifications",
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
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_EducationProviderClassification_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_EducationProviderClassification_SIFKey");
            
            CreateTable(
                "Module3.EducationProviderGenders",
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
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_EducationProviderGender_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_EducationProviderGender_SIFKey");
            
            CreateTable(
                "Module3.EducationProviderYearLevels",
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
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_EducationProviderYearLevel_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_EducationProviderYearLevel_SIFKey");
            
            CreateTable(
                "Module3.SpecialSchoolings",
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
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_SpecialSchooling_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_SpecialSchooling_SIFKey");
            
            CreateTable(
                "Module3.TeacherEducations",
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
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_TeacherEducation_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_TeacherEducation_SIFKey");
            
            CreateTable(
                "Module3.TerritorialAuthorities",
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
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_TerritorialAuthority_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_TerritorialAuthority_SIFKey");
            
            CreateTable(
                "Module3.UrbanAreas",
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
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_UrbanArea_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_UrbanArea_SIFKey");
            
            CreateTable(
                "Module3.Wards",
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
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_Ward_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_Ward_SIFKey");
            
            CreateTable(
                "Module3.EducationProviderLocations",
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
                        EducationProviderFK = c.Guid(nullable: false),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Altitude = c.Decimal(precision: 18, scale: 2),
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module3.EducationProviderProfiles", t => t.EducationProviderFK, cascadeDelete: true)
                .Index(t => t.EducationProviderFK)
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_EducationProviderLocation_SourceSystemKey");
            
            CreateTable(
                "Module3.EducationProviderEnrolmentCounts",
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
                        EducationProviderFK = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        TotalRoll = c.Int(nullable: false),
                        International = c.Int(nullable: false),
                        European = c.Int(nullable: false),
                        Maori = c.Int(nullable: false),
                        Pasifika = c.Int(nullable: false),
                        Asian = c.Int(nullable: false),
                        MELAA = c.Int(nullable: false),
                        Other = c.Int(nullable: false),
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module3.EducationProviderProfiles", t => t.EducationProviderFK, cascadeDelete: true)
                .Index(t => t.EducationProviderFK)
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_EducationProviderEnrolmentCount_SourceSystemKey");
            
            CreateTable(
                "Module3.EducationProviderLevelGenders",
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
                        EducationProviderFK = c.Guid(nullable: false),
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        GenderFK = c.Guid(nullable: false),
                        YearFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module3.EducationProviderGenders", t => t.GenderFK, cascadeDelete: true)
                .ForeignKey("Module3.EducationProviderYearLevels", t => t.YearFK, cascadeDelete: true)
                .ForeignKey("Module3.EducationProviderProfiles", t => t.EducationProviderFK, cascadeDelete: true)
                .Index(t => t.EducationProviderFK)
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_EducationProviderLevelGender_SourceSystemKey")
                .Index(t => t.GenderFK)
                .Index(t => t.YearFK);
            
            CreateTable(
                "Module3.EducationProviderProfiles",
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
                        SchoolId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Decile = c.Int(),
                        OpeningDate = c.DateTimeOffset(precision: 7),
                        ClosedDate = c.DateTimeOffset(precision: 7),
                        Email = c.String(maxLength: 256),
                        Url = c.String(maxLength: 256),
                        Telephone = c.String(maxLength: 64),
                        Fax = c.String(maxLength: 64),
                        CohortEntryCurrent = c.Boolean(),
                        CohortEntryFuture = c.Boolean(),
                        CohortEntryFutureFrom = c.DateTime(),
                        Contact1Name = c.String(maxLength: 256),
                        Contact1Role = c.String(maxLength: 64),
                        Contact2Name = c.String(maxLength: 256),
                        Contact2Role = c.String(maxLength: 64),
                        Address1Line1 = c.String(maxLength: 256),
                        Address1Line2 = c.String(maxLength: 256),
                        Address1Line3 = c.String(maxLength: 256),
                        Address1Suburb = c.String(maxLength: 64),
                        Address1City = c.String(maxLength: 64),
                        Address1PostalCode = c.String(maxLength: 64),
                        Address2Line1 = c.String(maxLength: 256),
                        Address2Line2 = c.String(maxLength: 256),
                        Address2Line3 = c.String(maxLength: 256),
                        Address2Suburb = c.String(maxLength: 64),
                        Address2City = c.String(maxLength: 64),
                        Address2PostalCode = c.String(maxLength: 64),
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        ClassificationFK = c.Guid(),
                        StatusFK = c.Guid(nullable: false),
                        SchoolingGenderFK = c.Guid(),
                        LocalOfficeFK = c.Guid(),
                        CoLFK = c.Guid(),
                        AuthorityTypeFK = c.Guid(nullable: false),
                        AreaUnitFK = c.Guid(),
                        CommunityBoardFK = c.Guid(),
                        GeneralElectorateFK = c.Guid(),
                        MaoriElectorateFK = c.Guid(),
                        RegionalCouncilFK = c.Guid(),
                        EducationProviderTypeFK = c.Guid(nullable: false),
                        RegionFK = c.Guid(nullable: false),
                        SpecialSchoolingFK = c.Guid(),
                        TeacherEducationFK = c.Guid(),
                        TerritorialAuthorityFK = c.Guid(),
                        UrbanAreaFK = c.Guid(),
                        WardFK = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module3.AreaUnits", t => t.AreaUnitFK)
                .ForeignKey("Module3.AuthorityTypes", t => t.AuthorityTypeFK)
                .ForeignKey("Module3.EducationProviderClassifications", t => t.ClassificationFK)
                .ForeignKey("Module3.CoLs", t => t.CoLFK)
                .ForeignKey("Module3.CommunityBoards", t => t.CommunityBoardFK)
                .ForeignKey("Module3.EducationProviderTypes", t => t.EducationProviderTypeFK)
                .ForeignKey("Module3.GeneralElectorates", t => t.GeneralElectorateFK)
                .ForeignKey("Module3.LocalOffices", t => t.LocalOfficeFK)
                .ForeignKey("Module3.MaoriElectorates", t => t.MaoriElectorateFK)
                .ForeignKey("Module3.Regions", t => t.RegionFK)
                .ForeignKey("Module3.RegionalCouncils", t => t.RegionalCouncilFK)
                .ForeignKey("Module3.EducationProviderGenders", t => t.SchoolingGenderFK)
                .ForeignKey("Module3.SpecialSchoolings", t => t.SpecialSchoolingFK)
                .ForeignKey("Module3.EducationProviderStatus", t => t.StatusFK)
                .ForeignKey("Module3.TeacherEducations", t => t.TeacherEducationFK)
                .ForeignKey("Module3.TerritorialAuthorities", t => t.TerritorialAuthorityFK)
                .ForeignKey("Module3.UrbanAreas", t => t.UrbanAreaFK)
                .ForeignKey("Module3.Wards", t => t.WardFK)
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_EducationProviderProfile_SourceSystemKey")
                .Index(t => t.ClassificationFK)
                .Index(t => t.StatusFK)
                .Index(t => t.SchoolingGenderFK)
                .Index(t => t.LocalOfficeFK)
                .Index(t => t.CoLFK)
                .Index(t => t.AuthorityTypeFK)
                .Index(t => t.AreaUnitFK)
                .Index(t => t.CommunityBoardFK)
                .Index(t => t.GeneralElectorateFK)
                .Index(t => t.MaoriElectorateFK)
                .Index(t => t.RegionalCouncilFK)
                .Index(t => t.EducationProviderTypeFK)
                .Index(t => t.RegionFK)
                .Index(t => t.SpecialSchoolingFK)
                .Index(t => t.TeacherEducationFK)
                .Index(t => t.TerritorialAuthorityFK)
                .Index(t => t.UrbanAreaFK)
                .Index(t => t.WardFK);
            
            CreateTable(
                "Module3.CoLs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SIFKey = c.String(),
                        SourceSystemName = c.String(),
                        SourceSystemKey = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(),
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
                "Module3.LocalOffices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SIFKey = c.String(),
                        SourceSystemName = c.String(),
                        SourceSystemKey = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("Module3.EducationProviderProfiles", "WardFK", "Module3.Wards");
            DropForeignKey("Module3.EducationProviderProfiles", "UrbanAreaFK", "Module3.UrbanAreas");
            DropForeignKey("Module3.EducationProviderProfiles", "TerritorialAuthorityFK", "Module3.TerritorialAuthorities");
            DropForeignKey("Module3.EducationProviderProfiles", "TeacherEducationFK", "Module3.TeacherEducations");
            DropForeignKey("Module3.EducationProviderProfiles", "StatusFK", "Module3.EducationProviderStatus");
            DropForeignKey("Module3.EducationProviderProfiles", "SpecialSchoolingFK", "Module3.SpecialSchoolings");
            DropForeignKey("Module3.EducationProviderProfiles", "SchoolingGenderFK", "Module3.EducationProviderGenders");
            DropForeignKey("Module3.EducationProviderEnrolmentCounts", "EducationProviderFK", "Module3.EducationProviderProfiles");
            DropForeignKey("Module3.EducationProviderProfiles", "RegionalCouncilFK", "Module3.RegionalCouncils");
            DropForeignKey("Module3.EducationProviderProfiles", "RegionFK", "Module3.Regions");
            DropForeignKey("Module3.EducationProviderProfiles", "MaoriElectorateFK", "Module3.MaoriElectorates");
            DropForeignKey("Module3.EducationProviderLocations", "EducationProviderFK", "Module3.EducationProviderProfiles");
            DropForeignKey("Module3.EducationProviderProfiles", "LocalOfficeFK", "Module3.LocalOffices");
            DropForeignKey("Module3.EducationProviderLevelGenders", "EducationProviderFK", "Module3.EducationProviderProfiles");
            DropForeignKey("Module3.EducationProviderProfiles", "GeneralElectorateFK", "Module3.GeneralElectorates");
            DropForeignKey("Module3.EducationProviderProfiles", "EducationProviderTypeFK", "Module3.EducationProviderTypes");
            DropForeignKey("Module3.EducationProviderProfiles", "CommunityBoardFK", "Module3.CommunityBoards");
            DropForeignKey("Module3.EducationProviderProfiles", "CoLFK", "Module3.CoLs");
            DropForeignKey("Module3.EducationProviderProfiles", "ClassificationFK", "Module3.EducationProviderClassifications");
            DropForeignKey("Module3.EducationProviderProfiles", "AuthorityTypeFK", "Module3.AuthorityTypes");
            DropForeignKey("Module3.EducationProviderProfiles", "AreaUnitFK", "Module3.AreaUnits");
            DropForeignKey("Module3.EducationProviderLevelGenders", "YearFK", "Module3.EducationProviderYearLevels");
            DropForeignKey("Module3.EducationProviderLevelGenders", "GenderFK", "Module3.EducationProviderGenders");
            DropIndex("Module3.EducationProviderProfiles", new[] { "WardFK" });
            DropIndex("Module3.EducationProviderProfiles", new[] { "UrbanAreaFK" });
            DropIndex("Module3.EducationProviderProfiles", new[] { "TerritorialAuthorityFK" });
            DropIndex("Module3.EducationProviderProfiles", new[] { "TeacherEducationFK" });
            DropIndex("Module3.EducationProviderProfiles", new[] { "SpecialSchoolingFK" });
            DropIndex("Module3.EducationProviderProfiles", new[] { "RegionFK" });
            DropIndex("Module3.EducationProviderProfiles", new[] { "EducationProviderTypeFK" });
            DropIndex("Module3.EducationProviderProfiles", new[] { "RegionalCouncilFK" });
            DropIndex("Module3.EducationProviderProfiles", new[] { "MaoriElectorateFK" });
            DropIndex("Module3.EducationProviderProfiles", new[] { "GeneralElectorateFK" });
            DropIndex("Module3.EducationProviderProfiles", new[] { "CommunityBoardFK" });
            DropIndex("Module3.EducationProviderProfiles", new[] { "AreaUnitFK" });
            DropIndex("Module3.EducationProviderProfiles", new[] { "AuthorityTypeFK" });
            DropIndex("Module3.EducationProviderProfiles", new[] { "CoLFK" });
            DropIndex("Module3.EducationProviderProfiles", new[] { "LocalOfficeFK" });
            DropIndex("Module3.EducationProviderProfiles", new[] { "SchoolingGenderFK" });
            DropIndex("Module3.EducationProviderProfiles", new[] { "StatusFK" });
            DropIndex("Module3.EducationProviderProfiles", new[] { "ClassificationFK" });
            DropIndex("Module3.EducationProviderProfiles", "IX_EducationProviderProfile_SourceSystemKey");
            DropIndex("Module3.EducationProviderLevelGenders", new[] { "YearFK" });
            DropIndex("Module3.EducationProviderLevelGenders", new[] { "GenderFK" });
            DropIndex("Module3.EducationProviderLevelGenders", "IX_EducationProviderLevelGender_SourceSystemKey");
            DropIndex("Module3.EducationProviderLevelGenders", new[] { "EducationProviderFK" });
            DropIndex("Module3.EducationProviderEnrolmentCounts", "IX_EducationProviderEnrolmentCount_SourceSystemKey");
            DropIndex("Module3.EducationProviderEnrolmentCounts", new[] { "EducationProviderFK" });
            DropIndex("Module3.EducationProviderLocations", "IX_EducationProviderLocation_SourceSystemKey");
            DropIndex("Module3.EducationProviderLocations", new[] { "EducationProviderFK" });
            DropIndex("Module3.Wards", "IX_Ward_SIFKey");
            DropIndex("Module3.Wards", "IX_Ward_FIRSTKey");
            DropIndex("Module3.UrbanAreas", "IX_UrbanArea_SIFKey");
            DropIndex("Module3.UrbanAreas", "IX_UrbanArea_FIRSTKey");
            DropIndex("Module3.TerritorialAuthorities", "IX_TerritorialAuthority_SIFKey");
            DropIndex("Module3.TerritorialAuthorities", "IX_TerritorialAuthority_FIRSTKey");
            DropIndex("Module3.TeacherEducations", "IX_TeacherEducation_SIFKey");
            DropIndex("Module3.TeacherEducations", "IX_TeacherEducation_FIRSTKey");
            DropIndex("Module3.SpecialSchoolings", "IX_SpecialSchooling_SIFKey");
            DropIndex("Module3.SpecialSchoolings", "IX_SpecialSchooling_FIRSTKey");
            DropIndex("Module3.EducationProviderYearLevels", "IX_EducationProviderYearLevel_SIFKey");
            DropIndex("Module3.EducationProviderYearLevels", "IX_EducationProviderYearLevel_FIRSTKey");
            DropIndex("Module3.EducationProviderGenders", "IX_EducationProviderGender_SIFKey");
            DropIndex("Module3.EducationProviderGenders", "IX_EducationProviderGender_FIRSTKey");
            DropIndex("Module3.EducationProviderClassifications", "IX_EducationProviderClassification_SIFKey");
            DropIndex("Module3.EducationProviderClassifications", "IX_EducationProviderClassification_FIRSTKey");
            DropIndex("Module3.RelationshipTypes", "IX_RelationshipType_SIFKey");
            DropIndex("Module3.RelationshipTypes", "IX_RelationshipType_FIRSTKey");
            DropIndex("Module3.RegionalCouncils", "IX_RegionalCouncil_SIFKey");
            DropIndex("Module3.RegionalCouncils", "IX_RegionalCouncil_FIRSTKey");
            DropIndex("Module3.Regions", "IX_Region_SIFKey");
            DropIndex("Module3.Regions", "IX_Region_FIRSTKey");
            DropIndex("Module3.EducationProviderTypes", "IX_EducationProviderType_SIFKey");
            DropIndex("Module3.EducationProviderTypes", "IX_EducationProviderType_FIRSTKey");
            DropIndex("Module3.EducationProviderStatus", "IX_EducationProviderStatus_SIFKey");
            DropIndex("Module3.EducationProviderStatus", "IX_EducationProviderStatus_FIRSTKey");
            DropIndex("Module3.MaoriElectorates", "IX_MaoriElectorate_SIFKey");
            DropIndex("Module3.MaoriElectorates", "IX_MaoriElectorate_FIRSTKey");
            DropIndex("Module3.GeneralElectorates", "IX_GeneralElectorate_SIFKey");
            DropIndex("Module3.GeneralElectorates", "IX_GeneralElectorate_FIRSTKey");
            DropIndex("Module3.CommunityBoards", "IX_CommunityBoard_SIFKey");
            DropIndex("Module3.CommunityBoards", "IX_CommunityBoard_FIRSTKey");
            DropIndex("Module3.AuthorityTypes", "IX_AuthorityType_SIFKey");
            DropIndex("Module3.AuthorityTypes", "IX_AuthorityType_FIRSTKey");
            DropIndex("Module3.AreaUnits", "IX_AreaUnit_SIFKey");
            DropIndex("Module3.AreaUnits", "IX_AreaUnit_FIRSTKey");
            DropIndex("Module3.ExtractWatermarks", "UX_ExtractWatermark_SourceTableName");
            DropTable("Module3.LocalOffices");
            DropTable("Module3.CoLs");
            DropTable("Module3.EducationProviderProfiles");
            DropTable("Module3.EducationProviderLevelGenders");
            DropTable("Module3.EducationProviderEnrolmentCounts");
            DropTable("Module3.EducationProviderLocations");
            DropTable("Module3.Wards");
            DropTable("Module3.UrbanAreas");
            DropTable("Module3.TerritorialAuthorities");
            DropTable("Module3.TeacherEducations");
            DropTable("Module3.SpecialSchoolings");
            DropTable("Module3.EducationProviderYearLevels");
            DropTable("Module3.EducationProviderGenders");
            DropTable("Module3.EducationProviderClassifications");
            DropTable("Module3.RelationshipTypes");
            DropTable("Module3.RegionalCouncils");
            DropTable("Module3.Regions");
            DropTable("Module3.EducationProviderTypes");
            DropTable("Module3.EducationProviderStatus");
            DropTable("Module3.MaoriElectorates");
            DropTable("Module3.GeneralElectorates");
            DropTable("Module3.CommunityBoards");
            DropTable("Module3.AuthorityTypes");
            DropTable("Module3.AreaUnits");
            DropTable("Module3.ExtractWatermarks");
        }
    }
}
