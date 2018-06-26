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
    public class AppModuleDbContextModelBuilderDefineRegion : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<Region>(
                modelBuilder, ref order);


            modelBuilder.Entity<Region>()
                .Property(x => x.RegionId)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<Region>()
                .Property(x => x.Name)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired();

            modelBuilder.Entity<Region>()
                .HasMany(x => x.Beaches)
                .WithOptional()
                .HasForeignKey(x => x.RegionFK)
                .WillCascadeOnDelete(true);

        }

    }
}
