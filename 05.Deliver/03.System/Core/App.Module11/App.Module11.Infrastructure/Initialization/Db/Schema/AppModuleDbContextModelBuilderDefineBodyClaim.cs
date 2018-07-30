namespace App.Module11.DbContextModelBuilder
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module11.Infrastructure.Initialization;
    using App.Module11.Infrastructure.Initialization.Db;
    using App.Module11.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineBodyClaim : IHasAppModuleDbContextModelBuilderInitializer
    {
        private readonly TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention _convention;

        public AppModuleDbContextModelBuilderDefineBodyClaim(TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention modelBuilderConvention)
        {
            this._convention = modelBuilderConvention;
        }

        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            _convention.Define<BodyClaim>(modelBuilder, ref order);

            modelBuilder.Entity<BodyClaim>()
                .Property(x => x.BodyFK)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<BodyClaim>()
                .Property(x => x.Authority)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X64)
                .IsRequired();
            modelBuilder.Entity<BodyClaim>()
                .Property(x => x.Key)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X64)
                .IsRequired();

            modelBuilder.Entity<BodyClaim>()
                .Property(x => x.Value)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X1024)
                .IsOptional();

            modelBuilder.Entity<BodyClaim>()
                .Property(x => x.AuthoritySignature)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X1024)
                .IsRequired();
        }
    }
}





