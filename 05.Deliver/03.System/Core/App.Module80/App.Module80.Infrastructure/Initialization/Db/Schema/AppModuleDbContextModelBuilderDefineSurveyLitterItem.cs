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
    public class AppModuleDbContextModelBuilderDefineSurveyLitterItem : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<SurveyLitterItem>(
                modelBuilder, ref order);


            modelBuilder.Entity<SurveyLitterItem>()
                .Property(x => x.Count)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<SurveyLitterItem>()
                .Property(x => x.Weight)
                .HasColumnOrder(order++)
                .HasPrecision(7, 2)
                .IsRequired();


            modelBuilder.Entity<SurveyLitterItem>()
                .HasRequired(x => x.LitterItem)
                .WithMany()
                .HasForeignKey(x => x.LitterItemFK)
                .WillCascadeOnDelete(false);


        }

    }
}
