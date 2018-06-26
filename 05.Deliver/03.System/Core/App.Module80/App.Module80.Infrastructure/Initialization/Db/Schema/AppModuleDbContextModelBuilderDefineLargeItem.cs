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
    public class AppModuleDbContextModelBuilderDefineLargeItem : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<LargeItem>(
                modelBuilder, ref order);


            modelBuilder.Entity<LargeItem>()
                .Property(x => x.Code)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X10)
                .IsRequired();

            modelBuilder.Entity<LargeItem>()
                .Property(x => x.Category)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X32)
                .IsOptional();

            modelBuilder.Entity<LargeItem>()
                .Property(x => x.Description)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X256)
                .IsRequired();

        }

    }
}
