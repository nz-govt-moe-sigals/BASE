namespace App.Core.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;

    public class AppCoreDbContextModelBuilderDefinePrincipal2Role : IHasAppCoreDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            //var order = 1;

            modelBuilder.Entity<Principal>()
                .HasMany(s => s.Roles)
                .WithMany()
                .Map(cs =>
                {
                    cs.MapLeftKey("PrincipalFK");
                    cs.MapRightKey("RoleFK");
                    cs.ToTable("Principal2Role");
                });
        }
    }
}