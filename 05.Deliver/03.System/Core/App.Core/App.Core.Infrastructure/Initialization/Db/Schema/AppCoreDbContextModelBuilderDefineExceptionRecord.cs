namespace App.Core.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppCoreDbContextModelBuilderDefineExceptionRecord : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<ExceptionRecord>(modelBuilder, ref order);

            modelBuilder.Entity<ExceptionRecord>()
                .Property(x => x.Level)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<ExceptionRecord>()
                .Property(x => x.Title)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X2048)
                .IsRequired();

            modelBuilder.Entity<ExceptionRecord>()
                .Property(x => x.Stack)
                .HasColumnOrder(order++)
                .IsMaxLength()
                .IsRequired();


    }
}
}