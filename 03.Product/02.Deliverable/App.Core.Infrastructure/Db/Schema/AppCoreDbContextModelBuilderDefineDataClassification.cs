namespace App.Core.Infrastructure.Db.Schema
{
    using System;
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppCoreDbContextModelBuilderDefineDataClasssification : IHasAppCoreDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            // Note that this Schema uses an Enum as the Id:
            new NonTenantFKEtcConvention().Define<DataClassification,NZDataClassification>(modelBuilder, ref order);

            modelBuilder.Entity<DataClassification>()
                .Property(x => x.Enabled)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<DataClassification>()
                .Property(x => x.Text)
                .HasColumnOrder(order++)
                .HasMaxLength(Constants.Db.TextFieldSizes.X64)
                .IsRequired();


            modelBuilder.Entity<DataClassification>()
                .Property(x => x.DisplayStyleHint)
                .HasColumnOrder(order++)
                .HasMaxLength(Constants.Db.TextFieldSizes.X64)
                .IsOptional();

            modelBuilder.Entity<DataClassification>()
                .Property(x => x.DisplayOrderHint)
                .HasColumnOrder(order++)
                .IsOptional();
        }
    }
}