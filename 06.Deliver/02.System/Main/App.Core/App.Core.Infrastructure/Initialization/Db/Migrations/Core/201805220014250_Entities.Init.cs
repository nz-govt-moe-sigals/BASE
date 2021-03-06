namespace App.Core.Infrastructure.Db.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Core.MediaMetadatas",
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
                        UploadedDateTimeUtc = c.DateTime(nullable: false),
                        ContentHash = c.String(nullable: false, maxLength: 256),
                        ContentSize = c.Long(nullable: false),
                        MimeType = c.String(nullable: false, maxLength: 256),
                        SourceFileName = c.String(nullable: false, maxLength: 256),
                        LatestScanDateTimeUtc = c.DateTime(),
                        LatestScanResults = c.String(),
                        LatestScanMalwareDetetected = c.Boolean(),
                        LocalName = c.String(maxLength: 256),
                        DataClassificationFK = c.Int(nullable: false),
                        TenantFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Core.DataClassifications", t => t.DataClassificationFK, cascadeDelete: true)
                .Index(t => t.RecordState, name: "IX_MediaMetadata_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_MediaMetadata_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_MediaMetadata_LastModifiedByPrincipalId")
                .Index(t => t.ContentHash, name: "IX_MediaMetadata_ContentHash")
                .Index(t => t.SourceFileName, name: "IX_MediaMetadata_SourceFileName")
                .Index(t => t.LocalName, unique: true, name: "IX_MediaMetadata_LocalFileName")
                .Index(t => t.DataClassificationFK);
            
            CreateTable(
                "Core.DataClassifications",
                c => new
                    {
                        Id = c.Int(nullable: false),
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
                        DisplayStyleHint = c.String(maxLength: 64),
                        DisplayOrderHint = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.RecordState, name: "IX_DataClassification_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_DataClassification_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_DataClassification_LastModifiedByPrincipalId");
            
            CreateTable(
                "Core.Notifications",
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
                        Type = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        PrincipalFK = c.Guid(nullable: false),
                        DateTimeCreatedUtc = c.DateTime(nullable: false),
                        DateTimeReadUtc = c.DateTime(),
                        From = c.String(nullable: false, maxLength: 64),
                        Class = c.String(nullable: false, maxLength: 64),
                        ImageUrl = c.String(nullable: false, maxLength: 64),
                        Value = c.Int(nullable: false),
                        Text = c.String(nullable: false),
                        TenantFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.RecordState, name: "IX_Notification_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_Notification_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_Notification_LastModifiedByPrincipalId")
                .Index(t => t.PrincipalFK, name: "IX_Notification_PrincipalFK")
                .Index(t => t.From, name: "IX_Notification_From");
            
            CreateTable(
                "Core.SessionOperations",
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
                        BeginDateTimeUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        EndDateTimeUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        Duration = c.Time(nullable: false, precision: 7),
                        ClientIp = c.String(nullable: false, maxLength: 64),
                        Url = c.String(nullable: false),
                        ControllerName = c.String(nullable: false, maxLength: 64),
                        ActionName = c.String(nullable: false, maxLength: 64),
                        ActionArguments = c.String(nullable: false),
                        ResponseCode = c.String(nullable: false, maxLength: 64),
                        OwnerFK = c.Guid(nullable: false),
                        ResourceTenantKey = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Core.Sessions", t => t.OwnerFK, cascadeDelete: true)
                .Index(t => t.RecordState, name: "IX_SessionOperation_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_SessionOperation_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_SessionOperation_LastModifiedByPrincipalId")
                .Index(t => t.ControllerName, name: "IX_SessionOperation_ControllerName")
                .Index(t => t.ActionName, name: "IX_SessionOperation_ActionName")
                .Index(t => t.OwnerFK);
            
            CreateTable(
                "Core.Sessions",
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
                        PrincipalFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Core.Principals", t => t.PrincipalFK, cascadeDelete: true)
                .Index(t => t.RecordState, name: "IX_Session_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_Session_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_Session_LastModifiedByPrincipalId")
                .Index(t => t.PrincipalFK);
            
            CreateTable(
                "Core.Principals",
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
                        DisplayName = c.String(nullable: false, maxLength: 64),
                        EnabledBeginningUtc = c.DateTime(),
                        EnabledEndingUtc = c.DateTime(),
                        Enabled = c.Boolean(nullable: false),
                        DataClassificationFK = c.Int(),
                        CategoryFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Core.PrincipalCategories", t => t.CategoryFK, cascadeDelete: true)
                .ForeignKey("Core.DataClassifications", t => t.DataClassificationFK)
                .Index(t => t.RecordState, name: "IX_Principal_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_Principal_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_Principal_LastModifiedByPrincipalId")
                .Index(t => t.DisplayName, name: "IX_Principal_DisplayName")
                .Index(t => t.DataClassificationFK)
                .Index(t => t.CategoryFK);
            
            CreateTable(
                "Core.PrincipalCategories",
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
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.RecordState, name: "IX_PrincipalCategory_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_PrincipalCategory_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_PrincipalCategory_LastModifiedByPrincipalId");
            
            CreateTable(
                "Core.PrincipalClaims",
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
                        OwnerFK = c.Guid(nullable: false),
                        Authority = c.String(nullable: false, maxLength: 64),
                        Key = c.String(nullable: false, maxLength: 64),
                        Value = c.String(maxLength: 1024),
                        AuthoritySignature = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Core.Principals", t => t.OwnerFK, cascadeDelete: true)
                .Index(t => t.RecordState, name: "IX_PrincipalClaim_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_PrincipalClaim_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_PrincipalClaim_LastModifiedByPrincipalId")
                .Index(t => t.OwnerFK)
                .Index(t => t.Authority, name: "IX_PrincipalClaim_Authority")
                .Index(t => t.Key, name: "IX_PrincipalClaim_Key");
            
            CreateTable(
                "Core.PrincipalLogins",
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
                        IdPLogin = c.String(nullable: false, maxLength: 1024),
                        LastLoggedInUtc = c.DateTime(nullable: false),
                        OwnerFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Core.Principals", t => t.OwnerFK, cascadeDelete: true)
                .Index(t => t.RecordState, name: "IX_PrincipalLogin_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_PrincipalLogin_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_PrincipalLogin_LastModifiedByPrincipalId")
                .Index(t => t.IdPLogin, name: "IX_PrincipalLogin_IdpLogin")
                .Index(t => t.OwnerFK);
            
            CreateTable(
                "Core.PrincipalProperties",
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
                        OwnerFK = c.Guid(nullable: false),
                        Key = c.String(nullable: false, maxLength: 64),
                        Value = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Core.Principals", t => t.OwnerFK, cascadeDelete: true)
                .Index(t => t.RecordState, name: "IX_PrincipalProperty_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_PrincipalProperty_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_PrincipalProperty_LastModifiedByPrincipalId")
                .Index(t => t.OwnerFK)
                .Index(t => t.Key, name: "IX_PrincipalProperty_Key");
            
            CreateTable(
                "Core.SystemRoles",
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
                        ModuleKey = c.String(),
                        DataClassificationFK = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Core.DataClassifications", t => t.DataClassificationFK)
                .Index(t => t.RecordState, name: "IX_SystemRole_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_SystemRole_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_SystemRole_LastModifiedByPrincipalId")
                .Index(t => t.Key, name: "IX_SystemRole_Key")
                .Index(t => t.DataClassificationFK);
            
            CreateTable(
                "Core.PrincipalTags",
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
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.RecordState, name: "IX_PrincipalTag_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_PrincipalTag_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_PrincipalTag_LastModifiedByPrincipalId")
                .Index(t => t.Text, name: "IX_PrincipalTag_Text");
            
            CreateTable(
                "Core.Tenants",
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
                        IsDefault = c.Boolean(),
                        Enabled = c.Boolean(nullable: false),
                        Key = c.String(nullable: false, maxLength: 64),
                        HostName = c.String(maxLength: 64),
                        DisplayName = c.String(nullable: false, maxLength: 64),
                        DataClassificationFK = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Core.DataClassifications", t => t.DataClassificationFK)
                .Index(t => t.RecordState, name: "IX_Tenant_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_Tenant_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_Tenant_LastModifiedByPrincipalId")
                .Index(t => t.IsDefault, unique: true, name: "IX_Tenant_IsDefault")
                .Index(t => t.Key, unique: true, name: "IX_Tenant_Key")
                .Index(t => t.HostName, unique: true, name: "IX_Tenant_HostName")
                .Index(t => t.DisplayName, name: "IX_Tenant_DisplayName")
                .Index(t => t.DataClassificationFK);
            
            CreateTable(
                "Core.TenantClaims",
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
                        OwnerFK = c.Guid(nullable: false),
                        Authority = c.String(nullable: false, maxLength: 64),
                        Key = c.String(nullable: false, maxLength: 64),
                        Value = c.String(maxLength: 1024),
                        AuthoritySignature = c.String(nullable: false, maxLength: 1024),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Core.Tenants", t => t.OwnerFK, cascadeDelete: true)
                .Index(t => t.RecordState, name: "IX_TenantClaim_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_TenantClaim_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_TenantClaim_LastModifiedByPrincipalId")
                .Index(t => t.OwnerFK)
                .Index(t => t.Authority, name: "IX_TenantClaim_Authority")
                .Index(t => t.Key, name: "IX_TenantClaim_Key");
            
            CreateTable(
                "Core.TenantProperties",
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
                        OwnerFK = c.Guid(nullable: false),
                        Key = c.String(nullable: false, maxLength: 64),
                        Value = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Core.Tenants", t => t.OwnerFK, cascadeDelete: true)
                .Index(t => t.RecordState, name: "IX_TenantProperty_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_TenantProperty_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_TenantProperty_LastModifiedByPrincipalId")
                .Index(t => t.OwnerFK)
                .Index(t => t.Key, name: "IX_TenantProperty_Key");
            
            CreateTable(
                "Core.ExceptionRecords",
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
                        Level = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Stack = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.RecordState, name: "IX_ExceptionRecord_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_ExceptionRecord_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_ExceptionRecord_LastModifiedByPrincipalId");
            
            CreateTable(
                "Core.DataTokens",
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
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_DataToken_TenantFK")
                .Index(t => t.RecordState, name: "IX_DataToken_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_DataToken_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_DataToken_LastModifiedByPrincipalId");
            
            CreateTable(
                "Core.Principal2Role",
                c => new
                    {
                        PrincipalFK = c.Guid(nullable: false),
                        RoleFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.PrincipalFK, t.RoleFK })
                .ForeignKey("Core.Principals", t => t.PrincipalFK, cascadeDelete: true)
                .ForeignKey("Core.SystemRoles", t => t.RoleFK, cascadeDelete: true)
                .Index(t => t.PrincipalFK)
                .Index(t => t.RoleFK);
            
            CreateTable(
                "Core.Principal2Tag",
                c => new
                    {
                        PrincipalFK = c.Guid(nullable: false),
                        TagFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.PrincipalFK, t.TagFK })
                .ForeignKey("Core.Principals", t => t.PrincipalFK, cascadeDelete: true)
                .ForeignKey("Core.PrincipalTags", t => t.TagFK, cascadeDelete: true)
                .Index(t => t.PrincipalFK)
                .Index(t => t.TagFK);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Core.TenantProperties", "OwnerFK", "Core.Tenants");
            DropForeignKey("Core.Tenants", "DataClassificationFK", "Core.DataClassifications");
            DropForeignKey("Core.TenantClaims", "OwnerFK", "Core.Tenants");
            DropForeignKey("Core.Sessions", "PrincipalFK", "Core.Principals");
            DropForeignKey("Core.Principal2Tag", "TagFK", "Core.PrincipalTags");
            DropForeignKey("Core.Principal2Tag", "PrincipalFK", "Core.Principals");
            DropForeignKey("Core.Principal2Role", "RoleFK", "Core.SystemRoles");
            DropForeignKey("Core.Principal2Role", "PrincipalFK", "Core.Principals");
            DropForeignKey("Core.SystemRoles", "DataClassificationFK", "Core.DataClassifications");
            DropForeignKey("Core.PrincipalProperties", "OwnerFK", "Core.Principals");
            DropForeignKey("Core.PrincipalLogins", "OwnerFK", "Core.Principals");
            DropForeignKey("Core.Principals", "DataClassificationFK", "Core.DataClassifications");
            DropForeignKey("Core.PrincipalClaims", "OwnerFK", "Core.Principals");
            DropForeignKey("Core.Principals", "CategoryFK", "Core.PrincipalCategories");
            DropForeignKey("Core.SessionOperations", "OwnerFK", "Core.Sessions");
            DropForeignKey("Core.MediaMetadatas", "DataClassificationFK", "Core.DataClassifications");
            DropIndex("Core.Principal2Tag", new[] { "TagFK" });
            DropIndex("Core.Principal2Tag", new[] { "PrincipalFK" });
            DropIndex("Core.Principal2Role", new[] { "RoleFK" });
            DropIndex("Core.Principal2Role", new[] { "PrincipalFK" });
            DropIndex("Core.DataTokens", "IX_DataToken_LastModifiedByPrincipalId");
            DropIndex("Core.DataTokens", "IX_DataToken_LastModifiedOnUtc");
            DropIndex("Core.DataTokens", "IX_DataToken_RecordState");
            DropIndex("Core.DataTokens", "IX_DataToken_TenantFK");
            DropIndex("Core.ExceptionRecords", "IX_ExceptionRecord_LastModifiedByPrincipalId");
            DropIndex("Core.ExceptionRecords", "IX_ExceptionRecord_LastModifiedOnUtc");
            DropIndex("Core.ExceptionRecords", "IX_ExceptionRecord_RecordState");
            DropIndex("Core.TenantProperties", "IX_TenantProperty_Key");
            DropIndex("Core.TenantProperties", new[] { "OwnerFK" });
            DropIndex("Core.TenantProperties", "IX_TenantProperty_LastModifiedByPrincipalId");
            DropIndex("Core.TenantProperties", "IX_TenantProperty_LastModifiedOnUtc");
            DropIndex("Core.TenantProperties", "IX_TenantProperty_RecordState");
            DropIndex("Core.TenantClaims", "IX_TenantClaim_Key");
            DropIndex("Core.TenantClaims", "IX_TenantClaim_Authority");
            DropIndex("Core.TenantClaims", new[] { "OwnerFK" });
            DropIndex("Core.TenantClaims", "IX_TenantClaim_LastModifiedByPrincipalId");
            DropIndex("Core.TenantClaims", "IX_TenantClaim_LastModifiedOnUtc");
            DropIndex("Core.TenantClaims", "IX_TenantClaim_RecordState");
            DropIndex("Core.Tenants", new[] { "DataClassificationFK" });
            DropIndex("Core.Tenants", "IX_Tenant_DisplayName");
            DropIndex("Core.Tenants", "IX_Tenant_HostName");
            DropIndex("Core.Tenants", "IX_Tenant_Key");
            DropIndex("Core.Tenants", "IX_Tenant_IsDefault");
            DropIndex("Core.Tenants", "IX_Tenant_LastModifiedByPrincipalId");
            DropIndex("Core.Tenants", "IX_Tenant_LastModifiedOnUtc");
            DropIndex("Core.Tenants", "IX_Tenant_RecordState");
            DropIndex("Core.PrincipalTags", "IX_PrincipalTag_Text");
            DropIndex("Core.PrincipalTags", "IX_PrincipalTag_LastModifiedByPrincipalId");
            DropIndex("Core.PrincipalTags", "IX_PrincipalTag_LastModifiedOnUtc");
            DropIndex("Core.PrincipalTags", "IX_PrincipalTag_RecordState");
            DropIndex("Core.SystemRoles", new[] { "DataClassificationFK" });
            DropIndex("Core.SystemRoles", "IX_SystemRole_Key");
            DropIndex("Core.SystemRoles", "IX_SystemRole_LastModifiedByPrincipalId");
            DropIndex("Core.SystemRoles", "IX_SystemRole_LastModifiedOnUtc");
            DropIndex("Core.SystemRoles", "IX_SystemRole_RecordState");
            DropIndex("Core.PrincipalProperties", "IX_PrincipalProperty_Key");
            DropIndex("Core.PrincipalProperties", new[] { "OwnerFK" });
            DropIndex("Core.PrincipalProperties", "IX_PrincipalProperty_LastModifiedByPrincipalId");
            DropIndex("Core.PrincipalProperties", "IX_PrincipalProperty_LastModifiedOnUtc");
            DropIndex("Core.PrincipalProperties", "IX_PrincipalProperty_RecordState");
            DropIndex("Core.PrincipalLogins", new[] { "OwnerFK" });
            DropIndex("Core.PrincipalLogins", "IX_PrincipalLogin_IdpLogin");
            DropIndex("Core.PrincipalLogins", "IX_PrincipalLogin_LastModifiedByPrincipalId");
            DropIndex("Core.PrincipalLogins", "IX_PrincipalLogin_LastModifiedOnUtc");
            DropIndex("Core.PrincipalLogins", "IX_PrincipalLogin_RecordState");
            DropIndex("Core.PrincipalClaims", "IX_PrincipalClaim_Key");
            DropIndex("Core.PrincipalClaims", "IX_PrincipalClaim_Authority");
            DropIndex("Core.PrincipalClaims", new[] { "OwnerFK" });
            DropIndex("Core.PrincipalClaims", "IX_PrincipalClaim_LastModifiedByPrincipalId");
            DropIndex("Core.PrincipalClaims", "IX_PrincipalClaim_LastModifiedOnUtc");
            DropIndex("Core.PrincipalClaims", "IX_PrincipalClaim_RecordState");
            DropIndex("Core.PrincipalCategories", "IX_PrincipalCategory_LastModifiedByPrincipalId");
            DropIndex("Core.PrincipalCategories", "IX_PrincipalCategory_LastModifiedOnUtc");
            DropIndex("Core.PrincipalCategories", "IX_PrincipalCategory_RecordState");
            DropIndex("Core.Principals", new[] { "CategoryFK" });
            DropIndex("Core.Principals", new[] { "DataClassificationFK" });
            DropIndex("Core.Principals", "IX_Principal_DisplayName");
            DropIndex("Core.Principals", "IX_Principal_LastModifiedByPrincipalId");
            DropIndex("Core.Principals", "IX_Principal_LastModifiedOnUtc");
            DropIndex("Core.Principals", "IX_Principal_RecordState");
            DropIndex("Core.Sessions", new[] { "PrincipalFK" });
            DropIndex("Core.Sessions", "IX_Session_LastModifiedByPrincipalId");
            DropIndex("Core.Sessions", "IX_Session_LastModifiedOnUtc");
            DropIndex("Core.Sessions", "IX_Session_RecordState");
            DropIndex("Core.SessionOperations", new[] { "OwnerFK" });
            DropIndex("Core.SessionOperations", "IX_SessionOperation_ActionName");
            DropIndex("Core.SessionOperations", "IX_SessionOperation_ControllerName");
            DropIndex("Core.SessionOperations", "IX_SessionOperation_LastModifiedByPrincipalId");
            DropIndex("Core.SessionOperations", "IX_SessionOperation_LastModifiedOnUtc");
            DropIndex("Core.SessionOperations", "IX_SessionOperation_RecordState");
            DropIndex("Core.Notifications", "IX_Notification_From");
            DropIndex("Core.Notifications", "IX_Notification_PrincipalFK");
            DropIndex("Core.Notifications", "IX_Notification_LastModifiedByPrincipalId");
            DropIndex("Core.Notifications", "IX_Notification_LastModifiedOnUtc");
            DropIndex("Core.Notifications", "IX_Notification_RecordState");
            DropIndex("Core.DataClassifications", "IX_DataClassification_LastModifiedByPrincipalId");
            DropIndex("Core.DataClassifications", "IX_DataClassification_LastModifiedOnUtc");
            DropIndex("Core.DataClassifications", "IX_DataClassification_RecordState");
            DropIndex("Core.MediaMetadatas", new[] { "DataClassificationFK" });
            DropIndex("Core.MediaMetadatas", "IX_MediaMetadata_LocalFileName");
            DropIndex("Core.MediaMetadatas", "IX_MediaMetadata_SourceFileName");
            DropIndex("Core.MediaMetadatas", "IX_MediaMetadata_ContentHash");
            DropIndex("Core.MediaMetadatas", "IX_MediaMetadata_LastModifiedByPrincipalId");
            DropIndex("Core.MediaMetadatas", "IX_MediaMetadata_LastModifiedOnUtc");
            DropIndex("Core.MediaMetadatas", "IX_MediaMetadata_RecordState");
            DropTable("Core.Principal2Tag");
            DropTable("Core.Principal2Role");
            DropTable("Core.DataTokens");
            DropTable("Core.ExceptionRecords");
            DropTable("Core.TenantProperties");
            DropTable("Core.TenantClaims");
            DropTable("Core.Tenants");
            DropTable("Core.PrincipalTags");
            DropTable("Core.SystemRoles");
            DropTable("Core.PrincipalProperties");
            DropTable("Core.PrincipalLogins");
            DropTable("Core.PrincipalClaims");
            DropTable("Core.PrincipalCategories");
            DropTable("Core.Principals");
            DropTable("Core.Sessions");
            DropTable("Core.SessionOperations");
            DropTable("Core.Notifications");
            DropTable("Core.DataClassifications");
            DropTable("Core.MediaMetadatas");
        }
    }
}
