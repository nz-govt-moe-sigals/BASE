namespace App.Core.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedServiceProfilePartstoPrincipalServiceProfile : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Core.TenantServiceProfileServiceOfferingAllocations", newName: "PrincipalServiceProfileServiceOfferingAllocations");
            RenameTable(name: "Core.TenantServiceProfiles", newName: "PrincipalServiceProfiles");
            RenameTable(name: "Core.TenantServiceProfileServicePlanAllocations", newName: "PrincipalServiceProfileServicePlanAllocations");
            RenameColumn(table: "Core.PrincipalServiceProfileServicePlanAllocations", name: "TenantServiceProfileFK", newName: "ParentFK");
            RenameIndex(table: "Core.PrincipalServiceProfileServiceOfferingAllocations", name: "IX_TenantServiceProfileServiceOfferingAllocation_RecordState", newName: "IX_PrincipalServiceProfileServiceOfferingAllocation_RecordState");
            RenameIndex(table: "Core.PrincipalServiceProfileServiceOfferingAllocations", name: "IX_TenantServiceProfileServiceOfferingAllocation_LastModifiedOnUtc", newName: "IX_PrincipalServiceProfileServiceOfferingAllocation_LastModifiedOnUtc");
            RenameIndex(table: "Core.PrincipalServiceProfileServiceOfferingAllocations", name: "IX_TenantServiceProfileServiceOfferingAllocation_LastModifiedByPrincipalId", newName: "IX_PrincipalServiceProfileServiceOfferingAllocation_LastModifiedByPrincipalId");
            RenameIndex(table: "Core.PrincipalServiceProfiles", name: "IX_TenantServiceProfile_TenantFK", newName: "IX_PrincipalServiceProfile_TenantFK");
            RenameIndex(table: "Core.PrincipalServiceProfiles", name: "IX_TenantServiceProfile_RecordState", newName: "IX_PrincipalServiceProfile_RecordState");
            RenameIndex(table: "Core.PrincipalServiceProfiles", name: "IX_TenantServiceProfile_LastModifiedOnUtc", newName: "IX_PrincipalServiceProfile_LastModifiedOnUtc");
            RenameIndex(table: "Core.PrincipalServiceProfiles", name: "IX_TenantServiceProfile_LastModifiedByPrincipalId", newName: "IX_PrincipalServiceProfile_LastModifiedByPrincipalId");
            RenameIndex(table: "Core.PrincipalServiceProfileServicePlanAllocations", name: "IX_TenantServiceProfileServicePlanAllocation_RecordState", newName: "IX_PrincipalServiceProfileServicePlanAllocation_RecordState");
            RenameIndex(table: "Core.PrincipalServiceProfileServicePlanAllocations", name: "IX_TenantServiceProfileServicePlanAllocation_LastModifiedOnUtc", newName: "IX_PrincipalServiceProfileServicePlanAllocation_LastModifiedOnUtc");
            RenameIndex(table: "Core.PrincipalServiceProfileServicePlanAllocations", name: "IX_TenantServiceProfileServicePlanAllocation_LastModifiedByPrincipalId", newName: "IX_PrincipalServiceProfileServicePlanAllocation_LastModifiedByPrincipalId");
            RenameIndex(table: "Core.PrincipalServiceProfileServicePlanAllocations", name: "IX_TenantServiceProfileFK", newName: "IX_ParentFK");
        }
        
        public override void Down()
        {
            RenameIndex(table: "Core.PrincipalServiceProfileServicePlanAllocations", name: "IX_ParentFK", newName: "IX_TenantServiceProfileFK");
            RenameIndex(table: "Core.PrincipalServiceProfileServicePlanAllocations", name: "IX_PrincipalServiceProfileServicePlanAllocation_LastModifiedByPrincipalId", newName: "IX_TenantServiceProfileServicePlanAllocation_LastModifiedByPrincipalId");
            RenameIndex(table: "Core.PrincipalServiceProfileServicePlanAllocations", name: "IX_PrincipalServiceProfileServicePlanAllocation_LastModifiedOnUtc", newName: "IX_TenantServiceProfileServicePlanAllocation_LastModifiedOnUtc");
            RenameIndex(table: "Core.PrincipalServiceProfileServicePlanAllocations", name: "IX_PrincipalServiceProfileServicePlanAllocation_RecordState", newName: "IX_TenantServiceProfileServicePlanAllocation_RecordState");
            RenameIndex(table: "Core.PrincipalServiceProfiles", name: "IX_PrincipalServiceProfile_LastModifiedByPrincipalId", newName: "IX_TenantServiceProfile_LastModifiedByPrincipalId");
            RenameIndex(table: "Core.PrincipalServiceProfiles", name: "IX_PrincipalServiceProfile_LastModifiedOnUtc", newName: "IX_TenantServiceProfile_LastModifiedOnUtc");
            RenameIndex(table: "Core.PrincipalServiceProfiles", name: "IX_PrincipalServiceProfile_RecordState", newName: "IX_TenantServiceProfile_RecordState");
            RenameIndex(table: "Core.PrincipalServiceProfiles", name: "IX_PrincipalServiceProfile_TenantFK", newName: "IX_TenantServiceProfile_TenantFK");
            RenameIndex(table: "Core.PrincipalServiceProfileServiceOfferingAllocations", name: "IX_PrincipalServiceProfileServiceOfferingAllocation_LastModifiedByPrincipalId", newName: "IX_TenantServiceProfileServiceOfferingAllocation_LastModifiedByPrincipalId");
            RenameIndex(table: "Core.PrincipalServiceProfileServiceOfferingAllocations", name: "IX_PrincipalServiceProfileServiceOfferingAllocation_LastModifiedOnUtc", newName: "IX_TenantServiceProfileServiceOfferingAllocation_LastModifiedOnUtc");
            RenameIndex(table: "Core.PrincipalServiceProfileServiceOfferingAllocations", name: "IX_PrincipalServiceProfileServiceOfferingAllocation_RecordState", newName: "IX_TenantServiceProfileServiceOfferingAllocation_RecordState");
            RenameColumn(table: "Core.PrincipalServiceProfileServicePlanAllocations", name: "ParentFK", newName: "TenantServiceProfileFK");
            RenameTable(name: "Core.PrincipalServiceProfileServicePlanAllocations", newName: "TenantServiceProfileServicePlanAllocations");
            RenameTable(name: "Core.PrincipalServiceProfiles", newName: "TenantServiceProfiles");
            RenameTable(name: "Core.PrincipalServiceProfileServiceOfferingAllocations", newName: "TenantServiceProfileServiceOfferingAllocations");
        }
    }
}
