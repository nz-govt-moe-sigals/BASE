namespace App.Module02.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesAddedAltitude : DbMigration
    {
        public override void Up()
        {
            AddColumn("Module2.BodyLocations", "Type", c => c.Int(nullable: false));
            AddColumn("Module2.BodyLocations", "Altitude", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("Module2.BodyLocations", "Altitude");
            DropColumn("Module2.BodyLocations", "Type");
        }
    }
}
