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
    public class AppModuleDbContextModelBuilderDefineSessionOperationLog : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<SessionOperation>(modelBuilder);

            var order = 1;

            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<SessionOperation>(modelBuilder, ref order);

            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<SessionOperation>()
                .Property(x => x.SessionFK)
                .HasColumnOrder(order++)
                .IsOptional();

            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<SessionOperation>()
                .Property(x => x.BeginDateTimeUtc)
                .HasColumnOrder(order++)
                .IsRequired();
            modelBuilder.Entity<SessionOperation>()
                .Property(x => x.EndDateTimeUtc)
                .HasColumnOrder(order++)
                .IsRequired();
            modelBuilder.Entity<SessionOperation>()
                .Property(x => x.Duration)
                .HasColumnOrder(order++)
                .IsRequired();
            modelBuilder.Entity<SessionOperation>()
                .Property(x => x.ClientIp)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired();
            modelBuilder.Entity<SessionOperation>()
                .Property(x => x.Url)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X2048)
                .IsRequired();
            modelBuilder.Entity<SessionOperation>()
                .Property(x => x.ControllerName)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(SessionOperation).Name}_ControllerName") {IsUnique = false}))
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired();
            modelBuilder.Entity<SessionOperation>()
                .Property(x => x.ActionName)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(SessionOperation).Name}_ActionName") {IsUnique = false}))
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired();
            modelBuilder.Entity<SessionOperation>()
                .Property(x => x.ActionArguments)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<SessionOperation>()
                .Property(x => x.ResponseCode)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired();
            // --------------------------------------------------
            // Entity Navigtation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------
        }
    }
}