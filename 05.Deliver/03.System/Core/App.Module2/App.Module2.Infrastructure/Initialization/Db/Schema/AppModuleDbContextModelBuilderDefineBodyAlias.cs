namespace App.Module02.DbContextModelBuilder
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module02.Infrastructure.Initialization;
    using App.Module02.Infrastructure.Initialization.Db;
    using App.Module02.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineBodyAlias : IHasAppModuleDbContextModelBuilderInitializer
    {
        private readonly TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention _convention;

        public AppModuleDbContextModelBuilderDefineBodyAlias(TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention modelBuilderConvention)
        {
            this._convention = modelBuilderConvention;
        }

        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            _convention.Define<BodyAlias>(modelBuilder, ref order);



            modelBuilder.Entity<BodyAlias>()
                .Property(x => x.OwnerFK)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<BodyAlias>()
                .Property(x => x.DisplayOrderHint)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<BodyAlias>()
                .Property(x => x.Name)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X256)
                .IsOptional();

            modelBuilder.Entity<BodyAlias>()
                .Property(x => x.Prefix)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X64)
                .IsOptional();

            modelBuilder.Entity<BodyAlias>()
                .Property(x => x.GivenName)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X256)
                .IsOptional();

            modelBuilder.Entity<BodyAlias>()
                .Property(x => x.MiddleNames)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X256)
                .IsOptional();

            modelBuilder.Entity<BodyAlias>()
                .Property(x => x.SurName)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X256)
                .IsOptional();

            modelBuilder.Entity<BodyAlias>()
                .Property(x => x.Suffix)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X64)
                .IsOptional();
        }
    }
}