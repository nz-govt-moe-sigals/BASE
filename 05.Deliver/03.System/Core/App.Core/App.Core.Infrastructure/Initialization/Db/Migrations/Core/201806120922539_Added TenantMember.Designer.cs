// <auto-generated />
namespace App.Core.Infrastructure.Db.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
    public sealed partial class AddedTenantMember : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddedTenantMember));
        
        string IMigrationMetadata.Id
        {
            get { return "201806120922539_Added TenantMember"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}