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
    public class AppModuleDbContextModelBuilderDefineOrganisation : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<Organisation>(
                modelBuilder, ref order);


            modelBuilder.Entity<Organisation>()
                .Property(x => x.Name)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired();

            modelBuilder.Entity<Organisation>()
                .Property(x => x.ContactNumber)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X32)
                .IsOptional();

            //collections
            modelBuilder.Entity<Organisation>()
                .HasMany(x => x.Surveys)
                .WithOptional()
                .HasForeignKey(x => x.OrganisationFK)
                .WillCascadeOnDelete(true);
        }

    }
}
