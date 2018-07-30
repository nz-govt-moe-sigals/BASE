namespace App.Core.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Annotations;
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefinePrincipalLogin : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<PrincipalLogin>(modelBuilder);

            var order = 1;


            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<PrincipalLogin>(modelBuilder, ref order);

            modelBuilder.Entity<PrincipalLogin>()
                .Property(x => x.Enabled)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<PrincipalLogin>()
                .Property(x => x.IdPLogin)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X1024)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(PrincipalLogin).Name}_IdpSubLogin") { IsUnique = true, Order = 1}))
                .IsRequired();

            modelBuilder.Entity<PrincipalLogin>()
                .Property(x => x.SubLogin)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X256)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(PrincipalLogin).Name}_IdpSubLogin") { IsUnique = true, Order = 2}))
                .IsRequired();

            modelBuilder.Entity<PrincipalLogin>()
                .Property(x => x.LastLoggedInUtc)
                .HasColumnOrder(order++)
                .IsRequired();
        }
    }
}