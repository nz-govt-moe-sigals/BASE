namespace App.Module31.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Module31.ExtractWatermarks",
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
            
            CreateTable(
                "Module31.AreaUnits",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
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
                .Index(t => t.TenantFK, name: "IX_AreaUnit_TenantFK")
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_AreaUnit_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_AreaUnit_SIFKey")
                .Index(t => t.RecordState, name: "IX_AreaUnit_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_AreaUnit_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_AreaUnit_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module31.AuthorityTypes",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
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
                .Index(t => t.TenantFK, name: "IX_AuthorityType_TenantFK")
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_AuthorityType_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_AuthorityType_SIFKey")
                .Index(t => t.RecordState, name: "IX_AuthorityType_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_AuthorityType_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_AuthorityType_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module31.CommunityBoards",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
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
                .Index(t => t.TenantFK, name: "IX_CommunityBoard_TenantFK")
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_CommunityBoard_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_CommunityBoard_SIFKey")
                .Index(t => t.RecordState, name: "IX_CommunityBoard_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CommunityBoard_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CommunityBoard_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module31.EducationProviderLocations",
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
                        EducationProviderFK = c.Guid(nullable: false),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Altitude = c.Decimal(precision: 18, scale: 2),
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module31.EducationProviderProfiles", t => t.EducationProviderFK, cascadeDelete: true)
                .Index(t => t.TenantFK, name: "IX_EducationProviderLocation_TenantFK")
                .Index(t => t.RecordState, name: "IX_EducationProviderLocation_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_EducationProviderLocation_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_EducationProviderLocation_LastModifiedByPrincipalId")
                .Index(t => t.EducationProviderFK)
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_EducationProviderLocation_SourceSystemKey");
            
            CreateTable(
                "Module31.EducationProviderProfiles",
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
                .ForeignKey("Module31.AreaUnits", t => t.AreaUnitFK)
                .ForeignKey("Module31.AuthorityTypes", t => t.AuthorityTypeFK)
                .ForeignKey("Module31.EducationProviderClassifications", t => t.ClassificationFK)
                .ForeignKey("Module31.CoLs", t => t.CoLFK)
                .ForeignKey("Module31.CommunityBoards", t => t.CommunityBoardFK)
                .ForeignKey("Module31.EducationProviderTypes", t => t.EducationProviderTypeFK)
                .ForeignKey("Module31.GeneralElectorates", t => t.GeneralElectorateFK)
                .ForeignKey("Module31.LocalOffices", t => t.LocalOfficeFK)
                .ForeignKey("Module31.MaoriElectorates", t => t.MaoriElectorateFK)
                .ForeignKey("Module31.Regions", t => t.RegionFK)
                .ForeignKey("Module31.RegionalCouncils", t => t.RegionalCouncilFK)
                .ForeignKey("Module31.EducationProviderGenders", t => t.SchoolingGenderFK)
                .ForeignKey("Module31.SpecialSchoolings", t => t.SpecialSchoolingFK)
                .ForeignKey("Module31.EducationProviderStatus", t => t.StatusFK)
                .ForeignKey("Module31.TeacherEducations", t => t.TeacherEducationFK)
                .ForeignKey("Module31.TerritorialAuthorities", t => t.TerritorialAuthorityFK)
                .ForeignKey("Module31.UrbanAreas", t => t.UrbanAreaFK)
                .ForeignKey("Module31.Wards", t => t.WardFK)
                .Index(t => t.TenantFK, name: "IX_EducationProviderProfile_TenantFK")
                .Index(t => t.RecordState, name: "IX_EducationProviderProfile_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_EducationProviderProfile_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_EducationProviderProfile_LastModifiedByPrincipalId")
                .Index(t => t.SchoolId, unique: true, name: "IX_EducationProviderProfile_SchoolId")
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
                "Module31.EducationProviderClassifications",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
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
                .Index(t => t.TenantFK, name: "IX_EducationProviderClassification_TenantFK")
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_EducationProviderClassification_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_EducationProviderClassification_SIFKey")
                .Index(t => t.RecordState, name: "IX_EducationProviderClassification_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_EducationProviderClassification_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_EducationProviderClassification_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module31.CoLs",
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
                "Module31.EducationProviderTypes",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
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
                .Index(t => t.TenantFK, name: "IX_EducationProviderType_TenantFK")
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_EducationProviderType_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_EducationProviderType_SIFKey")
                .Index(t => t.RecordState, name: "IX_EducationProviderType_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_EducationProviderType_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_EducationProviderType_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module31.GeneralElectorates",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
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
                .Index(t => t.TenantFK, name: "IX_GeneralElectorate_TenantFK")
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_GeneralElectorate_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_GeneralElectorate_SIFKey")
                .Index(t => t.RecordState, name: "IX_GeneralElectorate_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_GeneralElectorate_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_GeneralElectorate_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module31.EducationProviderLevelGenders",
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
                        EducationProviderFK = c.Guid(nullable: false),
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        GenderFK = c.Guid(nullable: false),
                        YearFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module31.EducationProviderGenders", t => t.GenderFK, cascadeDelete: true)
                .ForeignKey("Module31.EducationProviderYearLevels", t => t.YearFK, cascadeDelete: true)
                .ForeignKey("Module31.EducationProviderProfiles", t => t.EducationProviderFK, cascadeDelete: true)
                .Index(t => t.TenantFK, name: "IX_EducationProviderLevelGender_TenantFK")
                .Index(t => t.RecordState, name: "IX_EducationProviderLevelGender_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_EducationProviderLevelGender_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_EducationProviderLevelGender_LastModifiedByPrincipalId")
                .Index(t => t.EducationProviderFK)
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_EducationProviderLevelGender_SourceSystemKey")
                .Index(t => t.GenderFK)
                .Index(t => t.YearFK);
            
            CreateTable(
                "Module31.EducationProviderGenders",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
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
                .Index(t => t.TenantFK, name: "IX_EducationProviderGender_TenantFK")
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_EducationProviderGender_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_EducationProviderGender_SIFKey")
                .Index(t => t.RecordState, name: "IX_EducationProviderGender_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_EducationProviderGender_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_EducationProviderGender_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module31.EducationProviderYearLevels",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
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
                .Index(t => t.TenantFK, name: "IX_EducationProviderYearLevel_TenantFK")
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_EducationProviderYearLevel_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_EducationProviderYearLevel_SIFKey")
                .Index(t => t.RecordState, name: "IX_EducationProviderYearLevel_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_EducationProviderYearLevel_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_EducationProviderYearLevel_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module31.LocalOffices",
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
                "Module31.MaoriElectorates",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
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
                .Index(t => t.TenantFK, name: "IX_MaoriElectorate_TenantFK")
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_MaoriElectorate_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_MaoriElectorate_SIFKey")
                .Index(t => t.RecordState, name: "IX_MaoriElectorate_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_MaoriElectorate_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_MaoriElectorate_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module31.Regions",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
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
                .Index(t => t.TenantFK, name: "IX_Region_TenantFK")
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_Region_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_Region_SIFKey")
                .Index(t => t.RecordState, name: "IX_Region_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_Region_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_Region_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module31.RegionalCouncils",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
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
                .Index(t => t.TenantFK, name: "IX_RegionalCouncil_TenantFK")
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_RegionalCouncil_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_RegionalCouncil_SIFKey")
                .Index(t => t.RecordState, name: "IX_RegionalCouncil_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_RegionalCouncil_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_RegionalCouncil_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module31.EducationProviderEnrolmentCounts",
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
                .ForeignKey("Module31.EducationProviderProfiles", t => t.EducationProviderFK, cascadeDelete: true)
                .Index(t => t.TenantFK, name: "IX_EducationProviderEnrolmentCount_TenantFK")
                .Index(t => t.RecordState, name: "IX_EducationProviderEnrolmentCount_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_EducationProviderEnrolmentCount_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_EducationProviderEnrolmentCount_LastModifiedByPrincipalId")
                .Index(t => t.EducationProviderFK)
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_EducationProviderEnrolmentCount_SourceSystemKey");
            
            CreateTable(
                "Module31.SpecialSchoolings",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
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
                .Index(t => t.TenantFK, name: "IX_SpecialSchooling_TenantFK")
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_SpecialSchooling_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_SpecialSchooling_SIFKey")
                .Index(t => t.RecordState, name: "IX_SpecialSchooling_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_SpecialSchooling_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_SpecialSchooling_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module31.EducationProviderStatus",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
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
                .Index(t => t.TenantFK, name: "IX_EducationProviderStatus_TenantFK")
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_EducationProviderStatus_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_EducationProviderStatus_SIFKey")
                .Index(t => t.RecordState, name: "IX_EducationProviderStatus_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_EducationProviderStatus_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_EducationProviderStatus_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module31.TeacherEducations",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
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
                .Index(t => t.TenantFK, name: "IX_TeacherEducation_TenantFK")
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_TeacherEducation_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_TeacherEducation_SIFKey")
                .Index(t => t.RecordState, name: "IX_TeacherEducation_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_TeacherEducation_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_TeacherEducation_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module31.TerritorialAuthorities",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
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
                .Index(t => t.TenantFK, name: "IX_TerritorialAuthority_TenantFK")
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_TerritorialAuthority_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_TerritorialAuthority_SIFKey")
                .Index(t => t.RecordState, name: "IX_TerritorialAuthority_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_TerritorialAuthority_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_TerritorialAuthority_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module31.UrbanAreas",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
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
                .Index(t => t.TenantFK, name: "IX_UrbanArea_TenantFK")
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_UrbanArea_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_UrbanArea_SIFKey")
                .Index(t => t.RecordState, name: "IX_UrbanArea_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_UrbanArea_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_UrbanArea_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module31.Wards",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
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
                .Index(t => t.TenantFK, name: "IX_Ward_TenantFK")
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_Ward_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_Ward_SIFKey")
                .Index(t => t.RecordState, name: "IX_Ward_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_Ward_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_Ward_LastModifiedByPrincipalId");
            
            CreateTable(
                "Module31.RelationshipTypes",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        SourceSystemKey = c.String(nullable: false, maxLength: 10),
                        SourceSystemName = c.String(maxLength: 256),
                        SIFKey = c.String(nullable: false, maxLength: 10),
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
                .Index(t => t.TenantFK, name: "IX_RelationshipType_TenantFK")
                .Index(t => t.SourceSystemKey, unique: true, name: "IX_RelationshipType_FIRSTKey")
                .Index(t => t.SIFKey, unique: true, name: "IX_RelationshipType_SIFKey")
                .Index(t => t.RecordState, name: "IX_RelationshipType_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_RelationshipType_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_RelationshipType_LastModifiedByPrincipalId");
            
        }
        
        public override void Down()
        {
            DropForeignKey("Module31.EducationProviderProfiles", "WardFK", "Module31.Wards");
            DropForeignKey("Module31.EducationProviderProfiles", "UrbanAreaFK", "Module31.UrbanAreas");
            DropForeignKey("Module31.EducationProviderProfiles", "TerritorialAuthorityFK", "Module31.TerritorialAuthorities");
            DropForeignKey("Module31.EducationProviderProfiles", "TeacherEducationFK", "Module31.TeacherEducations");
            DropForeignKey("Module31.EducationProviderProfiles", "StatusFK", "Module31.EducationProviderStatus");
            DropForeignKey("Module31.EducationProviderProfiles", "SpecialSchoolingFK", "Module31.SpecialSchoolings");
            DropForeignKey("Module31.EducationProviderProfiles", "SchoolingGenderFK", "Module31.EducationProviderGenders");
            DropForeignKey("Module31.EducationProviderEnrolmentCounts", "EducationProviderFK", "Module31.EducationProviderProfiles");
            DropForeignKey("Module31.EducationProviderProfiles", "RegionalCouncilFK", "Module31.RegionalCouncils");
            DropForeignKey("Module31.EducationProviderProfiles", "RegionFK", "Module31.Regions");
            DropForeignKey("Module31.EducationProviderProfiles", "MaoriElectorateFK", "Module31.MaoriElectorates");
            DropForeignKey("Module31.EducationProviderLocations", "EducationProviderFK", "Module31.EducationProviderProfiles");
            DropForeignKey("Module31.EducationProviderProfiles", "LocalOfficeFK", "Module31.LocalOffices");
            DropForeignKey("Module31.EducationProviderLevelGenders", "EducationProviderFK", "Module31.EducationProviderProfiles");
            DropForeignKey("Module31.EducationProviderLevelGenders", "YearFK", "Module31.EducationProviderYearLevels");
            DropForeignKey("Module31.EducationProviderLevelGenders", "GenderFK", "Module31.EducationProviderGenders");
            DropForeignKey("Module31.EducationProviderProfiles", "GeneralElectorateFK", "Module31.GeneralElectorates");
            DropForeignKey("Module31.EducationProviderProfiles", "EducationProviderTypeFK", "Module31.EducationProviderTypes");
            DropForeignKey("Module31.EducationProviderProfiles", "CommunityBoardFK", "Module31.CommunityBoards");
            DropForeignKey("Module31.EducationProviderProfiles", "CoLFK", "Module31.CoLs");
            DropForeignKey("Module31.EducationProviderProfiles", "ClassificationFK", "Module31.EducationProviderClassifications");
            DropForeignKey("Module31.EducationProviderProfiles", "AuthorityTypeFK", "Module31.AuthorityTypes");
            DropForeignKey("Module31.EducationProviderProfiles", "AreaUnitFK", "Module31.AreaUnits");
            DropIndex("Module31.RelationshipTypes", "IX_RelationshipType_LastModifiedByPrincipalId");
            DropIndex("Module31.RelationshipTypes", "IX_RelationshipType_LastModifiedOnUtc");
            DropIndex("Module31.RelationshipTypes", "IX_RelationshipType_RecordState");
            DropIndex("Module31.RelationshipTypes", "IX_RelationshipType_SIFKey");
            DropIndex("Module31.RelationshipTypes", "IX_RelationshipType_FIRSTKey");
            DropIndex("Module31.RelationshipTypes", "IX_RelationshipType_TenantFK");
            DropIndex("Module31.Wards", "IX_Ward_LastModifiedByPrincipalId");
            DropIndex("Module31.Wards", "IX_Ward_LastModifiedOnUtc");
            DropIndex("Module31.Wards", "IX_Ward_RecordState");
            DropIndex("Module31.Wards", "IX_Ward_SIFKey");
            DropIndex("Module31.Wards", "IX_Ward_FIRSTKey");
            DropIndex("Module31.Wards", "IX_Ward_TenantFK");
            DropIndex("Module31.UrbanAreas", "IX_UrbanArea_LastModifiedByPrincipalId");
            DropIndex("Module31.UrbanAreas", "IX_UrbanArea_LastModifiedOnUtc");
            DropIndex("Module31.UrbanAreas", "IX_UrbanArea_RecordState");
            DropIndex("Module31.UrbanAreas", "IX_UrbanArea_SIFKey");
            DropIndex("Module31.UrbanAreas", "IX_UrbanArea_FIRSTKey");
            DropIndex("Module31.UrbanAreas", "IX_UrbanArea_TenantFK");
            DropIndex("Module31.TerritorialAuthorities", "IX_TerritorialAuthority_LastModifiedByPrincipalId");
            DropIndex("Module31.TerritorialAuthorities", "IX_TerritorialAuthority_LastModifiedOnUtc");
            DropIndex("Module31.TerritorialAuthorities", "IX_TerritorialAuthority_RecordState");
            DropIndex("Module31.TerritorialAuthorities", "IX_TerritorialAuthority_SIFKey");
            DropIndex("Module31.TerritorialAuthorities", "IX_TerritorialAuthority_FIRSTKey");
            DropIndex("Module31.TerritorialAuthorities", "IX_TerritorialAuthority_TenantFK");
            DropIndex("Module31.TeacherEducations", "IX_TeacherEducation_LastModifiedByPrincipalId");
            DropIndex("Module31.TeacherEducations", "IX_TeacherEducation_LastModifiedOnUtc");
            DropIndex("Module31.TeacherEducations", "IX_TeacherEducation_RecordState");
            DropIndex("Module31.TeacherEducations", "IX_TeacherEducation_SIFKey");
            DropIndex("Module31.TeacherEducations", "IX_TeacherEducation_FIRSTKey");
            DropIndex("Module31.TeacherEducations", "IX_TeacherEducation_TenantFK");
            DropIndex("Module31.EducationProviderStatus", "IX_EducationProviderStatus_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderStatus", "IX_EducationProviderStatus_LastModifiedOnUtc");
            DropIndex("Module31.EducationProviderStatus", "IX_EducationProviderStatus_RecordState");
            DropIndex("Module31.EducationProviderStatus", "IX_EducationProviderStatus_SIFKey");
            DropIndex("Module31.EducationProviderStatus", "IX_EducationProviderStatus_FIRSTKey");
            DropIndex("Module31.EducationProviderStatus", "IX_EducationProviderStatus_TenantFK");
            DropIndex("Module31.SpecialSchoolings", "IX_SpecialSchooling_LastModifiedByPrincipalId");
            DropIndex("Module31.SpecialSchoolings", "IX_SpecialSchooling_LastModifiedOnUtc");
            DropIndex("Module31.SpecialSchoolings", "IX_SpecialSchooling_RecordState");
            DropIndex("Module31.SpecialSchoolings", "IX_SpecialSchooling_SIFKey");
            DropIndex("Module31.SpecialSchoolings", "IX_SpecialSchooling_FIRSTKey");
            DropIndex("Module31.SpecialSchoolings", "IX_SpecialSchooling_TenantFK");
            DropIndex("Module31.EducationProviderEnrolmentCounts", "IX_EducationProviderEnrolmentCount_SourceSystemKey");
            DropIndex("Module31.EducationProviderEnrolmentCounts", new[] { "EducationProviderFK" });
            DropIndex("Module31.EducationProviderEnrolmentCounts", "IX_EducationProviderEnrolmentCount_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderEnrolmentCounts", "IX_EducationProviderEnrolmentCount_LastModifiedOnUtc");
            DropIndex("Module31.EducationProviderEnrolmentCounts", "IX_EducationProviderEnrolmentCount_RecordState");
            DropIndex("Module31.EducationProviderEnrolmentCounts", "IX_EducationProviderEnrolmentCount_TenantFK");
            DropIndex("Module31.RegionalCouncils", "IX_RegionalCouncil_LastModifiedByPrincipalId");
            DropIndex("Module31.RegionalCouncils", "IX_RegionalCouncil_LastModifiedOnUtc");
            DropIndex("Module31.RegionalCouncils", "IX_RegionalCouncil_RecordState");
            DropIndex("Module31.RegionalCouncils", "IX_RegionalCouncil_SIFKey");
            DropIndex("Module31.RegionalCouncils", "IX_RegionalCouncil_FIRSTKey");
            DropIndex("Module31.RegionalCouncils", "IX_RegionalCouncil_TenantFK");
            DropIndex("Module31.Regions", "IX_Region_LastModifiedByPrincipalId");
            DropIndex("Module31.Regions", "IX_Region_LastModifiedOnUtc");
            DropIndex("Module31.Regions", "IX_Region_RecordState");
            DropIndex("Module31.Regions", "IX_Region_SIFKey");
            DropIndex("Module31.Regions", "IX_Region_FIRSTKey");
            DropIndex("Module31.Regions", "IX_Region_TenantFK");
            DropIndex("Module31.MaoriElectorates", "IX_MaoriElectorate_LastModifiedByPrincipalId");
            DropIndex("Module31.MaoriElectorates", "IX_MaoriElectorate_LastModifiedOnUtc");
            DropIndex("Module31.MaoriElectorates", "IX_MaoriElectorate_RecordState");
            DropIndex("Module31.MaoriElectorates", "IX_MaoriElectorate_SIFKey");
            DropIndex("Module31.MaoriElectorates", "IX_MaoriElectorate_FIRSTKey");
            DropIndex("Module31.MaoriElectorates", "IX_MaoriElectorate_TenantFK");
            DropIndex("Module31.EducationProviderYearLevels", "IX_EducationProviderYearLevel_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderYearLevels", "IX_EducationProviderYearLevel_LastModifiedOnUtc");
            DropIndex("Module31.EducationProviderYearLevels", "IX_EducationProviderYearLevel_RecordState");
            DropIndex("Module31.EducationProviderYearLevels", "IX_EducationProviderYearLevel_SIFKey");
            DropIndex("Module31.EducationProviderYearLevels", "IX_EducationProviderYearLevel_FIRSTKey");
            DropIndex("Module31.EducationProviderYearLevels", "IX_EducationProviderYearLevel_TenantFK");
            DropIndex("Module31.EducationProviderGenders", "IX_EducationProviderGender_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderGenders", "IX_EducationProviderGender_LastModifiedOnUtc");
            DropIndex("Module31.EducationProviderGenders", "IX_EducationProviderGender_RecordState");
            DropIndex("Module31.EducationProviderGenders", "IX_EducationProviderGender_SIFKey");
            DropIndex("Module31.EducationProviderGenders", "IX_EducationProviderGender_FIRSTKey");
            DropIndex("Module31.EducationProviderGenders", "IX_EducationProviderGender_TenantFK");
            DropIndex("Module31.EducationProviderLevelGenders", new[] { "YearFK" });
            DropIndex("Module31.EducationProviderLevelGenders", new[] { "GenderFK" });
            DropIndex("Module31.EducationProviderLevelGenders", "IX_EducationProviderLevelGender_SourceSystemKey");
            DropIndex("Module31.EducationProviderLevelGenders", new[] { "EducationProviderFK" });
            DropIndex("Module31.EducationProviderLevelGenders", "IX_EducationProviderLevelGender_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderLevelGenders", "IX_EducationProviderLevelGender_LastModifiedOnUtc");
            DropIndex("Module31.EducationProviderLevelGenders", "IX_EducationProviderLevelGender_RecordState");
            DropIndex("Module31.EducationProviderLevelGenders", "IX_EducationProviderLevelGender_TenantFK");
            DropIndex("Module31.GeneralElectorates", "IX_GeneralElectorate_LastModifiedByPrincipalId");
            DropIndex("Module31.GeneralElectorates", "IX_GeneralElectorate_LastModifiedOnUtc");
            DropIndex("Module31.GeneralElectorates", "IX_GeneralElectorate_RecordState");
            DropIndex("Module31.GeneralElectorates", "IX_GeneralElectorate_SIFKey");
            DropIndex("Module31.GeneralElectorates", "IX_GeneralElectorate_FIRSTKey");
            DropIndex("Module31.GeneralElectorates", "IX_GeneralElectorate_TenantFK");
            DropIndex("Module31.EducationProviderTypes", "IX_EducationProviderType_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderTypes", "IX_EducationProviderType_LastModifiedOnUtc");
            DropIndex("Module31.EducationProviderTypes", "IX_EducationProviderType_RecordState");
            DropIndex("Module31.EducationProviderTypes", "IX_EducationProviderType_SIFKey");
            DropIndex("Module31.EducationProviderTypes", "IX_EducationProviderType_FIRSTKey");
            DropIndex("Module31.EducationProviderTypes", "IX_EducationProviderType_TenantFK");
            DropIndex("Module31.EducationProviderClassifications", "IX_EducationProviderClassification_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderClassifications", "IX_EducationProviderClassification_LastModifiedOnUtc");
            DropIndex("Module31.EducationProviderClassifications", "IX_EducationProviderClassification_RecordState");
            DropIndex("Module31.EducationProviderClassifications", "IX_EducationProviderClassification_SIFKey");
            DropIndex("Module31.EducationProviderClassifications", "IX_EducationProviderClassification_FIRSTKey");
            DropIndex("Module31.EducationProviderClassifications", "IX_EducationProviderClassification_TenantFK");
            DropIndex("Module31.EducationProviderProfiles", new[] { "WardFK" });
            DropIndex("Module31.EducationProviderProfiles", new[] { "UrbanAreaFK" });
            DropIndex("Module31.EducationProviderProfiles", new[] { "TerritorialAuthorityFK" });
            DropIndex("Module31.EducationProviderProfiles", new[] { "TeacherEducationFK" });
            DropIndex("Module31.EducationProviderProfiles", new[] { "SpecialSchoolingFK" });
            DropIndex("Module31.EducationProviderProfiles", new[] { "RegionFK" });
            DropIndex("Module31.EducationProviderProfiles", new[] { "EducationProviderTypeFK" });
            DropIndex("Module31.EducationProviderProfiles", new[] { "RegionalCouncilFK" });
            DropIndex("Module31.EducationProviderProfiles", new[] { "MaoriElectorateFK" });
            DropIndex("Module31.EducationProviderProfiles", new[] { "GeneralElectorateFK" });
            DropIndex("Module31.EducationProviderProfiles", new[] { "CommunityBoardFK" });
            DropIndex("Module31.EducationProviderProfiles", new[] { "AreaUnitFK" });
            DropIndex("Module31.EducationProviderProfiles", new[] { "AuthorityTypeFK" });
            DropIndex("Module31.EducationProviderProfiles", new[] { "CoLFK" });
            DropIndex("Module31.EducationProviderProfiles", new[] { "LocalOfficeFK" });
            DropIndex("Module31.EducationProviderProfiles", new[] { "SchoolingGenderFK" });
            DropIndex("Module31.EducationProviderProfiles", new[] { "StatusFK" });
            DropIndex("Module31.EducationProviderProfiles", new[] { "ClassificationFK" });
            DropIndex("Module31.EducationProviderProfiles", "IX_EducationProviderProfile_SourceSystemKey");
            DropIndex("Module31.EducationProviderProfiles", "IX_EducationProviderProfile_SchoolId");
            DropIndex("Module31.EducationProviderProfiles", "IX_EducationProviderProfile_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderProfiles", "IX_EducationProviderProfile_LastModifiedOnUtc");
            DropIndex("Module31.EducationProviderProfiles", "IX_EducationProviderProfile_RecordState");
            DropIndex("Module31.EducationProviderProfiles", "IX_EducationProviderProfile_TenantFK");
            DropIndex("Module31.EducationProviderLocations", "IX_EducationProviderLocation_SourceSystemKey");
            DropIndex("Module31.EducationProviderLocations", new[] { "EducationProviderFK" });
            DropIndex("Module31.EducationProviderLocations", "IX_EducationProviderLocation_LastModifiedByPrincipalId");
            DropIndex("Module31.EducationProviderLocations", "IX_EducationProviderLocation_LastModifiedOnUtc");
            DropIndex("Module31.EducationProviderLocations", "IX_EducationProviderLocation_RecordState");
            DropIndex("Module31.EducationProviderLocations", "IX_EducationProviderLocation_TenantFK");
            DropIndex("Module31.CommunityBoards", "IX_CommunityBoard_LastModifiedByPrincipalId");
            DropIndex("Module31.CommunityBoards", "IX_CommunityBoard_LastModifiedOnUtc");
            DropIndex("Module31.CommunityBoards", "IX_CommunityBoard_RecordState");
            DropIndex("Module31.CommunityBoards", "IX_CommunityBoard_SIFKey");
            DropIndex("Module31.CommunityBoards", "IX_CommunityBoard_FIRSTKey");
            DropIndex("Module31.CommunityBoards", "IX_CommunityBoard_TenantFK");
            DropIndex("Module31.AuthorityTypes", "IX_AuthorityType_LastModifiedByPrincipalId");
            DropIndex("Module31.AuthorityTypes", "IX_AuthorityType_LastModifiedOnUtc");
            DropIndex("Module31.AuthorityTypes", "IX_AuthorityType_RecordState");
            DropIndex("Module31.AuthorityTypes", "IX_AuthorityType_SIFKey");
            DropIndex("Module31.AuthorityTypes", "IX_AuthorityType_FIRSTKey");
            DropIndex("Module31.AuthorityTypes", "IX_AuthorityType_TenantFK");
            DropIndex("Module31.AreaUnits", "IX_AreaUnit_LastModifiedByPrincipalId");
            DropIndex("Module31.AreaUnits", "IX_AreaUnit_LastModifiedOnUtc");
            DropIndex("Module31.AreaUnits", "IX_AreaUnit_RecordState");
            DropIndex("Module31.AreaUnits", "IX_AreaUnit_SIFKey");
            DropIndex("Module31.AreaUnits", "IX_AreaUnit_FIRSTKey");
            DropIndex("Module31.AreaUnits", "IX_AreaUnit_TenantFK");
            DropIndex("Module31.ExtractWatermarks", "UX_ExtractWatermark_SourceTableName");
            DropIndex("Module31.ExtractWatermarks", "IX_ExtractWatermark_LastModifiedByPrincipalId");
            DropIndex("Module31.ExtractWatermarks", "IX_ExtractWatermark_LastModifiedOnUtc");
            DropIndex("Module31.ExtractWatermarks", "IX_ExtractWatermark_RecordState");
            DropTable("Module31.RelationshipTypes");
            DropTable("Module31.Wards");
            DropTable("Module31.UrbanAreas");
            DropTable("Module31.TerritorialAuthorities");
            DropTable("Module31.TeacherEducations");
            DropTable("Module31.EducationProviderStatus");
            DropTable("Module31.SpecialSchoolings");
            DropTable("Module31.EducationProviderEnrolmentCounts");
            DropTable("Module31.RegionalCouncils");
            DropTable("Module31.Regions");
            DropTable("Module31.MaoriElectorates");
            DropTable("Module31.LocalOffices");
            DropTable("Module31.EducationProviderYearLevels");
            DropTable("Module31.EducationProviderGenders");
            DropTable("Module31.EducationProviderLevelGenders");
            DropTable("Module31.GeneralElectorates");
            DropTable("Module31.EducationProviderTypes");
            DropTable("Module31.CoLs");
            DropTable("Module31.EducationProviderClassifications");
            DropTable("Module31.EducationProviderProfiles");
            DropTable("Module31.EducationProviderLocations");
            DropTable("Module31.CommunityBoards");
            DropTable("Module31.AuthorityTypes");
            DropTable("Module31.AreaUnits");
            DropTable("Module31.ExtractWatermarks");
        }
    }
}
