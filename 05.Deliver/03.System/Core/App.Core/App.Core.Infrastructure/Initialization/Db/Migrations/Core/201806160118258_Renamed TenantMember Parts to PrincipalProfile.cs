namespace App.Core.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedTenantMemberPartstoPrincipalProfile : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Core.TenantMembers", newName: "PrincipalProfiles");
            RenameTable(name: "Core.TenantMemberCategories", newName: "PrincipalProfileCategories");
            RenameTable(name: "Core.TenantMemberClaims", newName: "PrincipalProfileClaims");
            RenameTable(name: "Core.TenantMemberProperties", newName: "PrincipalProfileProperties");
            RenameTable(name: "Core.TenantMemberTags", newName: "PrincipalProfileTags");
            RenameTable(name: "Core.TenantMember2Tag", newName: "PrincipalProfile2Tag");
            RenameColumn(table: "Core.PrincipalProfile2Tag", name: "TenantMemberFK", newName: "PrincipalProfileFK");
            RenameColumn(table: "Core.PrincipalProfile2Tag", name: "TenantMemberTagFK", newName: "PrincipalProfileTagFK");
            RenameIndex(table: "Core.PrincipalProfiles", name: "IX_TenantMember_TenantFK", newName: "IX_PrincipalProfile_TenantFK");
            RenameIndex(table: "Core.PrincipalProfiles", name: "IX_TenantMember_RecordState", newName: "IX_PrincipalProfile_RecordState");
            RenameIndex(table: "Core.PrincipalProfiles", name: "IX_TenantMember_LastModifiedOnUtc", newName: "IX_PrincipalProfile_LastModifiedOnUtc");
            RenameIndex(table: "Core.PrincipalProfiles", name: "IX_TenantMember_LastModifiedByPrincipalId", newName: "IX_PrincipalProfile_LastModifiedByPrincipalId");
            RenameIndex(table: "Core.PrincipalProfileCategories", name: "IX_TenantMemberCategory_TenantFK", newName: "IX_PrincipalProfileCategory_TenantFK");
            RenameIndex(table: "Core.PrincipalProfileCategories", name: "IX_TenantMemberCategory_RecordState", newName: "IX_PrincipalProfileCategory_RecordState");
            RenameIndex(table: "Core.PrincipalProfileCategories", name: "IX_TenantMemberCategory_LastModifiedOnUtc", newName: "IX_PrincipalProfileCategory_LastModifiedOnUtc");
            RenameIndex(table: "Core.PrincipalProfileCategories", name: "IX_TenantMemberCategory_LastModifiedByPrincipalId", newName: "IX_PrincipalProfileCategory_LastModifiedByPrincipalId");
            RenameIndex(table: "Core.PrincipalProfileClaims", name: "IX_TenantMemberClaim_RecordState", newName: "IX_PrincipalProfileClaim_RecordState");
            RenameIndex(table: "Core.PrincipalProfileClaims", name: "IX_TenantMemberClaim_LastModifiedOnUtc", newName: "IX_PrincipalProfileClaim_LastModifiedOnUtc");
            RenameIndex(table: "Core.PrincipalProfileClaims", name: "IX_TenantMemberClaim_LastModifiedByPrincipalId", newName: "IX_PrincipalProfileClaim_LastModifiedByPrincipalId");
            RenameIndex(table: "Core.PrincipalProfileClaims", name: "IX_TenantMemberClaim_Authority", newName: "IX_PrincipalProfileClaim_Authority");
            RenameIndex(table: "Core.PrincipalProfileClaims", name: "IX_TenantMemberClaim_Key", newName: "IX_PrincipalProfileClaim_Key");
            RenameIndex(table: "Core.PrincipalProfileProperties", name: "IX_TenantMemberProperty_TenantFK", newName: "IX_PrincipalProfileProperty_TenantFK");
            RenameIndex(table: "Core.PrincipalProfileProperties", name: "IX_TenantMemberProperty_RecordState", newName: "IX_PrincipalProfileProperty_RecordState");
            RenameIndex(table: "Core.PrincipalProfileProperties", name: "IX_TenantMemberProperty_LastModifiedOnUtc", newName: "IX_PrincipalProfileProperty_LastModifiedOnUtc");
            RenameIndex(table: "Core.PrincipalProfileProperties", name: "IX_TenantMemberProperty_LastModifiedByPrincipalId", newName: "IX_PrincipalProfileProperty_LastModifiedByPrincipalId");
            RenameIndex(table: "Core.PrincipalProfileProperties", name: "IX_TenantMemberProperty_Key", newName: "IX_PrincipalProfileProperty_Key");
            RenameIndex(table: "Core.PrincipalProfileTags", name: "IX_TenantMemberTag_RecordState", newName: "IX_PrincipalProfileTag_RecordState");
            RenameIndex(table: "Core.PrincipalProfileTags", name: "IX_TenantMemberTag_LastModifiedOnUtc", newName: "IX_PrincipalProfileTag_LastModifiedOnUtc");
            RenameIndex(table: "Core.PrincipalProfileTags", name: "IX_TenantMemberTag_LastModifiedByPrincipalId", newName: "IX_PrincipalProfileTag_LastModifiedByPrincipalId");
            RenameIndex(table: "Core.PrincipalProfileTags", name: "IX_TenantMemberTag_Text", newName: "IX_PrincipalProfileTag_Text");
            RenameIndex(table: "Core.PrincipalProfile2Tag", name: "IX_TenantMemberFK", newName: "IX_PrincipalProfileFK");
            RenameIndex(table: "Core.PrincipalProfile2Tag", name: "IX_TenantMemberTagFK", newName: "IX_PrincipalProfileTagFK");
        }
        
        public override void Down()
        {
            RenameIndex(table: "Core.PrincipalProfile2Tag", name: "IX_PrincipalProfileTagFK", newName: "IX_TenantMemberTagFK");
            RenameIndex(table: "Core.PrincipalProfile2Tag", name: "IX_PrincipalProfileFK", newName: "IX_TenantMemberFK");
            RenameIndex(table: "Core.PrincipalProfileTags", name: "IX_PrincipalProfileTag_Text", newName: "IX_TenantMemberTag_Text");
            RenameIndex(table: "Core.PrincipalProfileTags", name: "IX_PrincipalProfileTag_LastModifiedByPrincipalId", newName: "IX_TenantMemberTag_LastModifiedByPrincipalId");
            RenameIndex(table: "Core.PrincipalProfileTags", name: "IX_PrincipalProfileTag_LastModifiedOnUtc", newName: "IX_TenantMemberTag_LastModifiedOnUtc");
            RenameIndex(table: "Core.PrincipalProfileTags", name: "IX_PrincipalProfileTag_RecordState", newName: "IX_TenantMemberTag_RecordState");
            RenameIndex(table: "Core.PrincipalProfileProperties", name: "IX_PrincipalProfileProperty_Key", newName: "IX_TenantMemberProperty_Key");
            RenameIndex(table: "Core.PrincipalProfileProperties", name: "IX_PrincipalProfileProperty_LastModifiedByPrincipalId", newName: "IX_TenantMemberProperty_LastModifiedByPrincipalId");
            RenameIndex(table: "Core.PrincipalProfileProperties", name: "IX_PrincipalProfileProperty_LastModifiedOnUtc", newName: "IX_TenantMemberProperty_LastModifiedOnUtc");
            RenameIndex(table: "Core.PrincipalProfileProperties", name: "IX_PrincipalProfileProperty_RecordState", newName: "IX_TenantMemberProperty_RecordState");
            RenameIndex(table: "Core.PrincipalProfileProperties", name: "IX_PrincipalProfileProperty_TenantFK", newName: "IX_TenantMemberProperty_TenantFK");
            RenameIndex(table: "Core.PrincipalProfileClaims", name: "IX_PrincipalProfileClaim_Key", newName: "IX_TenantMemberClaim_Key");
            RenameIndex(table: "Core.PrincipalProfileClaims", name: "IX_PrincipalProfileClaim_Authority", newName: "IX_TenantMemberClaim_Authority");
            RenameIndex(table: "Core.PrincipalProfileClaims", name: "IX_PrincipalProfileClaim_LastModifiedByPrincipalId", newName: "IX_TenantMemberClaim_LastModifiedByPrincipalId");
            RenameIndex(table: "Core.PrincipalProfileClaims", name: "IX_PrincipalProfileClaim_LastModifiedOnUtc", newName: "IX_TenantMemberClaim_LastModifiedOnUtc");
            RenameIndex(table: "Core.PrincipalProfileClaims", name: "IX_PrincipalProfileClaim_RecordState", newName: "IX_TenantMemberClaim_RecordState");
            RenameIndex(table: "Core.PrincipalProfileCategories", name: "IX_PrincipalProfileCategory_LastModifiedByPrincipalId", newName: "IX_TenantMemberCategory_LastModifiedByPrincipalId");
            RenameIndex(table: "Core.PrincipalProfileCategories", name: "IX_PrincipalProfileCategory_LastModifiedOnUtc", newName: "IX_TenantMemberCategory_LastModifiedOnUtc");
            RenameIndex(table: "Core.PrincipalProfileCategories", name: "IX_PrincipalProfileCategory_RecordState", newName: "IX_TenantMemberCategory_RecordState");
            RenameIndex(table: "Core.PrincipalProfileCategories", name: "IX_PrincipalProfileCategory_TenantFK", newName: "IX_TenantMemberCategory_TenantFK");
            RenameIndex(table: "Core.PrincipalProfiles", name: "IX_PrincipalProfile_LastModifiedByPrincipalId", newName: "IX_TenantMember_LastModifiedByPrincipalId");
            RenameIndex(table: "Core.PrincipalProfiles", name: "IX_PrincipalProfile_LastModifiedOnUtc", newName: "IX_TenantMember_LastModifiedOnUtc");
            RenameIndex(table: "Core.PrincipalProfiles", name: "IX_PrincipalProfile_RecordState", newName: "IX_TenantMember_RecordState");
            RenameIndex(table: "Core.PrincipalProfiles", name: "IX_PrincipalProfile_TenantFK", newName: "IX_TenantMember_TenantFK");
            RenameColumn(table: "Core.PrincipalProfile2Tag", name: "PrincipalProfileTagFK", newName: "TenantMemberTagFK");
            RenameColumn(table: "Core.PrincipalProfile2Tag", name: "PrincipalProfileFK", newName: "TenantMemberFK");
            RenameTable(name: "Core.PrincipalProfile2Tag", newName: "TenantMember2Tag");
            RenameTable(name: "Core.PrincipalProfileTags", newName: "TenantMemberTags");
            RenameTable(name: "Core.PrincipalProfileProperties", newName: "TenantMemberProperties");
            RenameTable(name: "Core.PrincipalProfileClaims", newName: "TenantMemberClaims");
            RenameTable(name: "Core.PrincipalProfileCategories", newName: "TenantMemberCategories");
            RenameTable(name: "Core.PrincipalProfiles", newName: "TenantMembers");
        }
    }
}
