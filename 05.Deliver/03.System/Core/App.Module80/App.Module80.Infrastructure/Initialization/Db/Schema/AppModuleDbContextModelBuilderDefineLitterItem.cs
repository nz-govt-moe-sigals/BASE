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
    public class AppModuleDbContextModelBuilderDefineLitterItem : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<LitterItem>(
                modelBuilder, ref order);

            modelBuilder.Entity<LitterItem>()
                .Property(x => x.Code)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X10)
                .IsRequired();

            modelBuilder.Entity<LitterItem>()
                .Property(x => x.Category)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X32)
                .IsOptional();

            modelBuilder.Entity<LitterItem>()
                .Property(x => x.Description)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X256)
                .IsRequired();
        }

    }
}
