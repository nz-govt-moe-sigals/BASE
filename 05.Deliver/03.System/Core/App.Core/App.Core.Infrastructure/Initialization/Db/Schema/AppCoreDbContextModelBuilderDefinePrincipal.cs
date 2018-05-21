namespace App.Core.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Annotations;
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppCoreDbContextModelBuilderDefinePrincipal : IHasAppCoreDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;


            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<Principal>(modelBuilder, ref order);


            modelBuilder.Entity<Principal>()
                .Property(x => x.Enabled)
                .IsRequired();

            modelBuilder.Entity<Principal>()
                .HasOptional(x => x.DataClassification)
                .WithMany()
                .HasForeignKey(x => x.DataClassificationFK);


            modelBuilder.Entity<Principal>()
                .Property(x => x.DisplayName)
                .HasColumnOrder(order++)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(Principal).Name}_DisplayName") { IsUnique = false }))
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired();

            modelBuilder.Entity<Principal>()
                .HasRequired(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryFK);



            modelBuilder.Entity<Principal>()
                .HasMany(x => x.Properties)
                .WithOptional()
                .HasForeignKey(x => x.OwnerFK);

            modelBuilder.Entity<Principal>()
                .HasMany(x => x.Claims)
                .WithOptional()
                .HasForeignKey(x => x.OwnerFK);

            modelBuilder.Entity<Principal>()
                .HasMany(x => x.Logins)
                .WithOptional()
                .HasForeignKey(x => x.OwnerFK);
        }
    }
}