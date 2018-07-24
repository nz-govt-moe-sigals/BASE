namespace App.Core.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefinePrincipal2Role : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<Principal>(modelBuilder);

            //var order = 1;

            modelBuilder.Entity<Principal>()
                .HasMany(s => s.Roles)
                .WithMany()
                .Map(j =>
                {
                    j.ToTable(typeof(Principal).Name + "2" + /*(typeof(SystemRole)).Name)*/ "Role");
                    j.MapLeftKey("PrincipalFK");
                    j.MapRightKey("RoleFK");
                });
        }
    }
}