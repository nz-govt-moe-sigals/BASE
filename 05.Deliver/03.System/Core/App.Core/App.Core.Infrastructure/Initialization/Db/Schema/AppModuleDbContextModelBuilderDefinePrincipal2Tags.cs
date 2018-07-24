namespace App.Core.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefinePrincipal2Tags : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<Principal>(modelBuilder);

            modelBuilder.Entity<Principal>()
                .HasMany(p => p.Tags)
                .WithMany()
                .Map(j =>
                {
                    j.ToTable(typeof(Principal).Name + "2" + /*typeof(PrincipalTag).Name*/ "Tag");
                    j.MapLeftKey("PrincipalFK");
                    j.MapRightKey("TagFK");
                });
        }
    }
}