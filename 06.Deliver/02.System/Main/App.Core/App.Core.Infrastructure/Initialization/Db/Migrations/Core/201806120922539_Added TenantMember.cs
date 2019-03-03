namespace App.Core.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTenantMember : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Core.TenantMembers",
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
                        EnabledBeginningUtc = c.DateTime(),
                        EnabledEndingUtc = c.DateTime(),
                        Enabled = c.Boolean(nullable: false),
                        DisplayName = c.String(),
                        DataClassificationFK = c.Int(),
                        CategoryFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Core.TenantMemberCategories", t => t.CategoryFK, cascadeDelete: true)
                .ForeignKey("Core.DataClassifications", t => t.DataClassificationFK)
                .Index(t => t.TenantFK, name: "IX_TenantMember_TenantFK")
                .Index(t => t.RecordState, name: "IX_TenantMember_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_TenantMember_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_TenantMember_LastModifiedByPrincipalId")
                .Index(t => t.DataClassificationFK)
                .Index(t => t.CategoryFK);
            
            CreateTable(
                "Core.TenantMemberCategories",
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
                        Title = c.String(),
                        Description = c.String(),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_TenantMemberCategory_TenantFK")
                .Index(t => t.RecordState, name: "IX_TenantMemberCategory_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_TenantMemberCategory_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_TenantMemberCategory_LastModifiedByPrincipalId");
            
            CreateTable(
                "Core.TenantMemberClaims",
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
                        TenantFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Core.TenantMembers", t => t.OwnerFK, cascadeDelete: true)
                .Index(t => t.RecordState, name: "IX_TenantMemberClaim_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_TenantMemberClaim_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_TenantMemberClaim_LastModifiedByPrincipalId")
                .Index(t => t.OwnerFK)
                .Index(t => t.Authority, name: "IX_TenantMemberClaim_Authority")
                .Index(t => t.Key, name: "IX_TenantMemberClaim_Key");
            
            CreateTable(
                "Core.TenantMemberProperties",
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
                .ForeignKey("Core.TenantMembers", t => t.OwnerFK, cascadeDelete: true)
                .Index(t => t.TenantFK, name: "IX_TenantMemberProperty_TenantFK")
                .Index(t => t.RecordState, name: "IX_TenantMemberProperty_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_TenantMemberProperty_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_TenantMemberProperty_LastModifiedByPrincipalId")
                .Index(t => t.OwnerFK)
                .Index(t => t.Key, name: "IX_TenantMemberProperty_Key");
            
            CreateTable(
                "Core.TenantMemberTags",
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
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                        Description = c.String(),
                        TenantFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.RecordState, name: "IX_TenantMemberTag_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_TenantMemberTag_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_TenantMemberTag_LastModifiedByPrincipalId")
                .Index(t => t.Title, name: "IX_TenantMemberTag_Text");
            
            CreateTable(
                "Core.TenantMember2Tag",
                c => new
                    {
                        TenantMemberFK = c.Guid(nullable: false),
                        TenantMemberTagFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.TenantMemberFK, t.TenantMemberTagFK })
                .ForeignKey("Core.TenantMembers", t => t.TenantMemberFK, cascadeDelete: true)
                .ForeignKey("Core.TenantMemberTags", t => t.TenantMemberTagFK, cascadeDelete: true)
                .Index(t => t.TenantMemberFK)
                .Index(t => t.TenantMemberTagFK);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Core.TenantMember2Tag", "TenantMemberTagFK", "Core.TenantMemberTags");
            DropForeignKey("Core.TenantMember2Tag", "TenantMemberFK", "Core.TenantMembers");
            DropForeignKey("Core.TenantMemberProperties", "OwnerFK", "Core.TenantMembers");
            DropForeignKey("Core.TenantMembers", "DataClassificationFK", "Core.DataClassifications");
            DropForeignKey("Core.TenantMemberClaims", "OwnerFK", "Core.TenantMembers");
            DropForeignKey("Core.TenantMembers", "CategoryFK", "Core.TenantMemberCategories");
            DropIndex("Core.TenantMember2Tag", new[] { "TenantMemberTagFK" });
            DropIndex("Core.TenantMember2Tag", new[] { "TenantMemberFK" });
            DropIndex("Core.TenantMemberTags", "IX_TenantMemberTag_Text");
            DropIndex("Core.TenantMemberTags", "IX_TenantMemberTag_LastModifiedByPrincipalId");
            DropIndex("Core.TenantMemberTags", "IX_TenantMemberTag_LastModifiedOnUtc");
            DropIndex("Core.TenantMemberTags", "IX_TenantMemberTag_RecordState");
            DropIndex("Core.TenantMemberProperties", "IX_TenantMemberProperty_Key");
            DropIndex("Core.TenantMemberProperties", new[] { "OwnerFK" });
            DropIndex("Core.TenantMemberProperties", "IX_TenantMemberProperty_LastModifiedByPrincipalId");
            DropIndex("Core.TenantMemberProperties", "IX_TenantMemberProperty_LastModifiedOnUtc");
            DropIndex("Core.TenantMemberProperties", "IX_TenantMemberProperty_RecordState");
            DropIndex("Core.TenantMemberProperties", "IX_TenantMemberProperty_TenantFK");
            DropIndex("Core.TenantMemberClaims", "IX_TenantMemberClaim_Key");
            DropIndex("Core.TenantMemberClaims", "IX_TenantMemberClaim_Authority");
            DropIndex("Core.TenantMemberClaims", new[] { "OwnerFK" });
            DropIndex("Core.TenantMemberClaims", "IX_TenantMemberClaim_LastModifiedByPrincipalId");
            DropIndex("Core.TenantMemberClaims", "IX_TenantMemberClaim_LastModifiedOnUtc");
            DropIndex("Core.TenantMemberClaims", "IX_TenantMemberClaim_RecordState");
            DropIndex("Core.TenantMemberCategories", "IX_TenantMemberCategory_LastModifiedByPrincipalId");
            DropIndex("Core.TenantMemberCategories", "IX_TenantMemberCategory_LastModifiedOnUtc");
            DropIndex("Core.TenantMemberCategories", "IX_TenantMemberCategory_RecordState");
            DropIndex("Core.TenantMemberCategories", "IX_TenantMemberCategory_TenantFK");
            DropIndex("Core.TenantMembers", new[] { "CategoryFK" });
            DropIndex("Core.TenantMembers", new[] { "DataClassificationFK" });
            DropIndex("Core.TenantMembers", "IX_TenantMember_LastModifiedByPrincipalId");
            DropIndex("Core.TenantMembers", "IX_TenantMember_LastModifiedOnUtc");
            DropIndex("Core.TenantMembers", "IX_TenantMember_RecordState");
            DropIndex("Core.TenantMembers", "IX_TenantMember_TenantFK");
            DropTable("Core.TenantMember2Tag");
            DropTable("Core.TenantMemberTags");
            DropTable("Core.TenantMemberProperties");
            DropTable("Core.TenantMemberClaims");
            DropTable("Core.TenantMemberCategories");
            DropTable("Core.TenantMembers");
        }
    }
}
