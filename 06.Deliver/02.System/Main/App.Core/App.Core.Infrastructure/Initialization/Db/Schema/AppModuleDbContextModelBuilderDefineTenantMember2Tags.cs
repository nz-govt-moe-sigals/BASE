namespace App.Core.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Entities.TenancySpecific;

    public class AppModuleDbContextModelBuilderDefinePrincipalProfile2Tags : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<PrincipalProfile>(modelBuilder);

            modelBuilder.Entity<PrincipalProfile>()
                .HasMany(p => p.Tags)
                .WithMany()
                .Map(j =>
                {
                    j.ToTable(typeof(PrincipalProfile).Name + "2" + /*typeof(PrincipalProfileTag).Name*/ "Tag");
                    j.MapLeftKey(typeof(PrincipalProfile).Name + "FK");
                    j.MapRightKey(typeof(PrincipalProfileTag).Name + "FK");
                });
        }
    }
}