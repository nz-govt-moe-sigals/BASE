// <auto-generated />
namespace App.Module02.Infrastructure.Db.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
    public sealed partial class RenamedTenancySecurityProfileTenancySecurityProfilePermissionAssignment : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(RenamedTenancySecurityProfileTenancySecurityProfilePermissionAssignment));
        
        string IMigrationMetadata.Id
        {
            get { return "201806120524118_Renamed TenancySecurityProfileTenancySecurityProfilePermissionAssignment"; }
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