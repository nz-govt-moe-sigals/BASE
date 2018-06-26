using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Constants.Db;
using App.Core.Infrastructure.Db.Schema.Conventions;
using App.Module80.Shared.Models.Entities;

namespace App.Module80.Infrastructure.Initialization.Db.Schema
{
    public class AppModuleDbContextModelBuilderDefineSurveyLargeItem : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<SurveyLargeItem>(
                modelBuilder, ref order);


            modelBuilder.Entity<SurveyLargeItem>()
                .Property(x => x.Count)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<SurveyLargeItem>()
                .Property(x => x.Latitude)
                .HasColumnOrder(order++)
                .HasPrecision(10, 7)
                .IsOptional();

            modelBuilder.Entity<SurveyLargeItem>()
                .Property(x => x.Longitude)
                .HasColumnOrder(order++)
                .HasPrecision(10, 7)
                .IsOptional();

            modelBuilder.Entity<SurveyLargeItem>()
                .Property(x => x.DetailedDescription)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X256)
                .IsOptional();

            modelBuilder.Entity<SurveyLargeItem>()
                .Property(x => x.Status)
                .HasColumnOrder(order++)
                .IsOptional();

            modelBuilder.Entity<SurveyLargeItem>()
                .HasRequired(x => x.LargeItem)
                .WithMany()
                .HasForeignKey(x => x.LargeItemFK)
                .WillCascadeOnDelete(false);
        }

    }
}
