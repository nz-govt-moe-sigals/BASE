//namespace App.Core.Infrastructure.Db.Schema
//{
//    using System.Data.Entity;
//    using App.Core.Infrastructure.Initialization;
//    using App.Core.Infrastructure.Initialization.Db;
//    using App.Core.Shared.Models.Entities;

//    public class AppCoreDbContextModelBuilderDefineTenantMember2Role : IHasAppCoreDbContextModelBuilderInitializer
//    {
//        public void Define(DbModelBuilder modelBuilder)
//        {
//            //var order = 1;

//            modelBuilder.Entity<TenantMember>()
//                .HasMany(s => s.Roles)
//                .WithMany()
//                .Map(j =>
//                {
//                    j.ToTable(typeof(TenantMember).Name + "2" + /*(typeof(SystemRole)).Name)*/ "Role");
//                    j.MapLeftKey(typeof(TenantMember).Name + "FK");
//                    j.MapRightKey(typeof(SystemRole).Name + "FK");
//                });
//        }
//    }
//}