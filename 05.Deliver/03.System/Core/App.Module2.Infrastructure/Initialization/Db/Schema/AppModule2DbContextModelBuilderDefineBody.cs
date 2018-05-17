namespace App.Module2.DbContextModelBuilder
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module2.Infrastructure.Initialization;
    using App.Module2.Infrastructure.Initialization.Db;
    using App.Module2.Shared.Models.Entities;

    public class AppModule2DbContextModelBuilderDefineBody : IHasAppModule2DbContextModelBuilderInitializer
    {
        private readonly TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention _modelBuilderConvention;
                         
        public AppModule2DbContextModelBuilderDefineBody(TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention modelBuilderConvention)
        {
            this._modelBuilderConvention = modelBuilderConvention;
        }

        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            this._modelBuilderConvention.Define<Body>(modelBuilder, ref order);


            modelBuilder.Entity<Body>()
                .Property(x => x.Type)
                .HasColumnOrder(order++)
                .IsRequired();
            modelBuilder.Entity<Body>()
                .HasRequired(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryFK);
            modelBuilder.Entity<Body>()
                .HasOptional(i => i.Location)
                .WithMany()
                .HasForeignKey(x => x.LocationFK)
                .WillCascadeOnDelete(false) //so that if you delete the Child, the user is not lost.
                ;

            modelBuilder.Entity<Body>()
                .Property(x => x.Key)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X256)
                .IsOptional();
            modelBuilder.Entity<Body>()
                .Property(x => x.Description)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X256)
                .IsOptional();
            modelBuilder.Entity<Body>()
                .HasMany(x => x.Properties)
                .WithOptional()
                .HasForeignKey(x => x.OwnerFK);
            modelBuilder.Entity<Body>()
                .HasMany(x => x.Claims)
                .WithOptional()
                .HasForeignKey(x => x.OwnerFK);
            modelBuilder.Entity<Body>()
                .HasMany(x => x.Aliases)
                .WithOptional()
                .HasForeignKey(x => x.OwnerFK);
            modelBuilder.Entity<Body>()
                .HasMany(x => x.Channels)
                .WithOptional()
                .HasForeignKey(x => x.OwnerFK);
            modelBuilder.Entity<Body>()
                .Property(x => x.Notes)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X2048)
                .IsOptional();
        }
    }
}