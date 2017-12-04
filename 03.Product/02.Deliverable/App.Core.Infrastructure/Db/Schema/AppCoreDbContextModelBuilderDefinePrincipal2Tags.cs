namespace App.Core.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;

    public class AppCoreDbContextModelBuilderDefinePrincipal2Tags : IHasAppCoreDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Principal>()
                .HasMany(p => p.Tags)
                .WithMany()
                .Map(x =>
                {
                    x.MapLeftKey("PrincipalFK");
                    x.MapRightKey("TagFK");
                    x.ToTable("Principal2Tag");
                });
        }
    }
}