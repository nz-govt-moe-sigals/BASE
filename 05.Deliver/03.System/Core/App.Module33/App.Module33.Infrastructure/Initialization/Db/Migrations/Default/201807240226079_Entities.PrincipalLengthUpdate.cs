namespace App.Module33.Infrastructure.Initialization.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesPrincipalLengthUpdate : DbMigration
    {
        public override void Up()
        {
            DropIndex("Module33.CoherentPathwayLearningAreaSteps", "IX_CoherentPathwayLearningAreaStep_LastModifiedByPrincipalId");
            DropIndex("Module33.CoherentPathwaySteps", "IX_CoherentPathwayStep_LastModifiedByPrincipalId");
            DropIndex("Module33.CoherentPathways", "IX_CoherentPathway_LastModifiedByPrincipalId");
            DropIndex("Module33.Communities", "IX_Community_LastModifiedByPrincipalId");
            AlterColumn("Module33.CoherentPathwayLearningAreaSteps", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module33.CoherentPathwayLearningAreaSteps", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module33.CoherentPathwayLearningAreaSteps", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module33.CoherentPathwaySteps", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module33.CoherentPathwaySteps", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module33.CoherentPathwaySteps", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module33.CoherentPathways", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module33.CoherentPathways", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module33.CoherentPathways", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            AlterColumn("Module33.Communities", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module33.Communities", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("Module33.Communities", "DeletedByPrincipalId", c => c.String(maxLength: 36));
            CreateIndex("Module33.CoherentPathwayLearningAreaSteps", "LastModifiedByPrincipalId", name: "IX_CoherentPathwayLearningAreaStep_LastModifiedByPrincipalId");
            CreateIndex("Module33.CoherentPathwaySteps", "LastModifiedByPrincipalId", name: "IX_CoherentPathwayStep_LastModifiedByPrincipalId");
            CreateIndex("Module33.CoherentPathways", "LastModifiedByPrincipalId", name: "IX_CoherentPathway_LastModifiedByPrincipalId");
            CreateIndex("Module33.Communities", "LastModifiedByPrincipalId", name: "IX_Community_LastModifiedByPrincipalId");
        }
        
        public override void Down()
        {
            DropIndex("Module33.Communities", "IX_Community_LastModifiedByPrincipalId");
            DropIndex("Module33.CoherentPathways", "IX_CoherentPathway_LastModifiedByPrincipalId");
            DropIndex("Module33.CoherentPathwaySteps", "IX_CoherentPathwayStep_LastModifiedByPrincipalId");
            DropIndex("Module33.CoherentPathwayLearningAreaSteps", "IX_CoherentPathwayLearningAreaStep_LastModifiedByPrincipalId");
            AlterColumn("Module33.Communities", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module33.Communities", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module33.Communities", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module33.CoherentPathways", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module33.CoherentPathways", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module33.CoherentPathways", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module33.CoherentPathwaySteps", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module33.CoherentPathwaySteps", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module33.CoherentPathwaySteps", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module33.CoherentPathwayLearningAreaSteps", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module33.CoherentPathwayLearningAreaSteps", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module33.CoherentPathwayLearningAreaSteps", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            CreateIndex("Module33.Communities", "LastModifiedByPrincipalId", name: "IX_Community_LastModifiedByPrincipalId");
            CreateIndex("Module33.CoherentPathways", "LastModifiedByPrincipalId", name: "IX_CoherentPathway_LastModifiedByPrincipalId");
            CreateIndex("Module33.CoherentPathwaySteps", "LastModifiedByPrincipalId", name: "IX_CoherentPathwayStep_LastModifiedByPrincipalId");
            CreateIndex("Module33.CoherentPathwayLearningAreaSteps", "LastModifiedByPrincipalId", name: "IX_CoherentPathwayLearningAreaStep_LastModifiedByPrincipalId");
        }
    }
}
