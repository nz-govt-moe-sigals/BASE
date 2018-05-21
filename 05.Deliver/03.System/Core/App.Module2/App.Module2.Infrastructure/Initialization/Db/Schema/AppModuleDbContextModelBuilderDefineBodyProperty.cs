namespace App.Module02.DbContextModelBuilder
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module02.Infrastructure.Initialization;
    using App.Module02.Infrastructure.Initialization.Db;
    using App.Module02.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineBodyProperty : IHasAppModuleDbContextModelBuilderInitializer
    {
        private readonly TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention _convention;

        public AppModuleDbContextModelBuilderDefineBodyProperty(TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention modelBuilderConvention)
        {
            this._convention = modelBuilderConvention;
        }
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            _convention.Define<BodyProperty>(modelBuilder, ref order);


            modelBuilder.Entity<BodyProperty>()
                .Property(x => x.OwnerFK)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<BodyProperty>()
                .Property(x => x.Key)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X64)
                .IsRequired();

            modelBuilder.Entity<BodyProperty>()
                .Property(x => x.Value)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X1024)
                .IsOptional();
        }
    }
}