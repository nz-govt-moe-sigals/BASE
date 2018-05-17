namespace App.Core.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Annotations;
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;

    public class AppCoreDbContextModelBuilderDefinePrincipalLogin : IHasAppCoreDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
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
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(PrincipalLogin).Name}_IdpLogin") { IsUnique = false }))
                .IsRequired();

            modelBuilder.Entity<PrincipalLogin>()
                .Property(x => x.LastLoggedInUtc)
                .HasColumnOrder(order++)
                .IsRequired();
        }
    }
}