namespace App.Core.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesUniqueNullableIndex : DbMigration
    {
        public override void Up()
        {
            DropIndex("Core.Tenants", "IX_Tenant_IsDefault");
            string indexName = "UX_Tenant_IsDefault";
            string tableName = "Core.Tenants";
            string columnName = "IsDefault";

            Sql(string.Format(@"
                CREATE UNIQUE NONCLUSTERED INDEX {0}
                ON {1}({2}) 
                WHERE {2} IS NOT NULL;",
                            indexName, tableName, columnName));
        }
        
        public override void Down()
        {
            RenameIndex(table: "Core.Tenants", name: "UX_Tenant_IsDefault", newName: "IX_Tenant_IsDefault");
        }
    }
}
