namespace App.Core.Infrastructure.Db.Schema
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Annotations;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineMediaMetadata : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<MediaMetadata>(modelBuilder, ref order);

            modelBuilder.Entity<MediaMetadata>()
                .HasRequired(x => x.DataClassification)
                .WithMany()
                .HasForeignKey(x => x.DataClassificationFK);

            modelBuilder.Entity<MediaMetadata>()
                .Property(x => x.UploadedDateTimeUtc)
                .HasColumnOrder(order++)
                .IsRequired();
            modelBuilder.Entity<MediaMetadata>()
                .Property(x => x.ContentHash)
                .HasMaxLength(Constants.Db.TextFieldSizes.X256)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(MediaMetadata).Name}_ContentHash") { IsUnique = false }))
                .HasColumnOrder(order++)
                .IsRequired();
            modelBuilder.Entity<MediaMetadata>()
                .Property(x => x.ContentSize)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<MediaMetadata>()
                .Property(x => x.MimeType)
                .HasMaxLength(Constants.Db.TextFieldSizes.X256)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<MediaMetadata>()
                .Property(x => x.SourceFileName)
                .HasColumnOrder(order++)
                .HasMaxLength(Constants.Db.TextFieldSizes.X256)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(MediaMetadata).Name}_SourceFileName") { IsUnique = false }))
                .IsRequired();

            modelBuilder.Entity<MediaMetadata>()
                .Property(x => x.LatestScanDateTimeUtc)
                .HasColumnOrder(order++)
                .IsOptional();

            modelBuilder.Entity<MediaMetadata>()
                .Property(x => x.LatestScanResults)
                .HasColumnOrder(order++)
                .IsMaxLength()
                .IsOptional();

            modelBuilder.Entity<MediaMetadata>()
                .Property(x => x.LatestScanMalwareDetetected)
                .HasColumnOrder(order++)
                .IsOptional();

            modelBuilder.Entity<MediaMetadata>()
                .Property(x => x.LocalName)
                .HasColumnOrder(order++)
                .HasMaxLength(Constants.Db.TextFieldSizes.X256)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(MediaMetadata).Name}_LocalFileName") { IsUnique = true }))
                .IsOptional();
        }
    }
}