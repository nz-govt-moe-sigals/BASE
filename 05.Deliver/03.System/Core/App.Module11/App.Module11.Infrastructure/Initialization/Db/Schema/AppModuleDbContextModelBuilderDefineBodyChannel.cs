namespace App.Module11.DbContextModelBuilder
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module11.Infrastructure.Initialization;
    using App.Module11.Infrastructure.Initialization.Db;
    using App.Module11.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineBodyChannel : IHasAppModuleDbContextModelBuilderInitializer
    {
        private readonly TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention _convention;

        public AppModuleDbContextModelBuilderDefineBodyChannel(TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention modelBuilderConvention)
        {
            this._convention = modelBuilderConvention;
        }


        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;


            _convention.Define<BodyChannel>(modelBuilder, ref order);


            modelBuilder.Entity<BodyChannel>()
                .Property(x => x.BodyFK)
                .HasColumnOrder(order++)
                .IsRequired();
            modelBuilder.Entity<BodyChannel>()
                .Property(x => x.DisplayOrderHint)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<BodyChannel>()
                .Property(x => x.Protocol)
                .HasColumnOrder(order++)
                //.HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X64)
                .IsRequired();

            modelBuilder.Entity<BodyChannel>()
                .Property(x => x.Title)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X64)
                .IsRequired();
            modelBuilder.Entity<BodyChannel>()
                .Property(x => x.Address)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X256)
                .IsOptional();
            modelBuilder.Entity<BodyChannel>()
                .Property(x => x.AddressStreetAndNumber)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X256)
                .IsOptional();
            modelBuilder.Entity<BodyChannel>()
                .Property(x => x.AddressSuburb)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X256)
                .IsOptional();
            modelBuilder.Entity<BodyChannel>()
                .Property(x => x.AddressCity)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X256)
                .IsOptional();
            modelBuilder.Entity<BodyChannel>()
                .Property(x => x.AddressRegion)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X256)
                .IsOptional();
            modelBuilder.Entity<BodyChannel>()
                .Property(x => x.AddressState)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X256)
                .IsOptional();
            modelBuilder.Entity<BodyChannel>()
                .Property(x => x.AddressPostalCode)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X256)
                .IsOptional();
            modelBuilder.Entity<BodyChannel>()
                .Property(x => x.AddressCountry)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X256)
                .IsOptional();
            modelBuilder.Entity<BodyChannel>()
                .Property(x => x.AddressInstructions)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X256)
                .IsOptional();
        }
    }
}





