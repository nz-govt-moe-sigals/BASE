using App.Core.Infrastructure.Db.Schema.Conventions;
using App.Module11.Infrastructure.Initialization.Db;
using App.Module11.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module11.Infrastructure.Db.Schema
{
    

    public class AppModuleDbContextModelBuilderDefineExtractWatermark : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            DefineTable(modelBuilder);
        }

        public void DefineTable(DbModelBuilder modelBuilder)
        {
            var order = 1;
            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<ExtractWatermark>(modelBuilder, ref order);


            modelBuilder.Entity<ExtractWatermark>()
                .Property(x => x.SourceTableName)
                .HasColumnOrder(order++)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<ExtractWatermark>()
                .Property(x => x.Watermark)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<ExtractWatermark>()
                .Property(t => t.SourceTableName)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute($"UX_{typeof(ExtractWatermark).Name}_SourceTableName") { IsUnique = true }));
        }
    }
}
