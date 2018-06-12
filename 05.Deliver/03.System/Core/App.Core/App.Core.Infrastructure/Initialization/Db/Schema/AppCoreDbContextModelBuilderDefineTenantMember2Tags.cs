namespace App.Core.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;

    public class AppCoreDbContextModelBuilderDefineTenantMember2Tags : IHasAppCoreDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TenantMember>()
                .HasMany(p => p.Tags)
                .WithMany()
                .Map(j =>
                {
                    j.ToTable(typeof(TenantMember).Name + "2" + /*typeof(TenantMemberTag).Name*/ "Tag");
                    j.MapLeftKey(typeof(TenantMember).Name + "FK");
                    j.MapRightKey(typeof(TenantMemberTag).Name + "FK");
                });
        }
    }
}