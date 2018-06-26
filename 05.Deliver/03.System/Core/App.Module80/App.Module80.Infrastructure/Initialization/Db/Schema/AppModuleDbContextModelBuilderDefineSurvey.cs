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
    public class AppModuleDbContextModelBuilderDefineSurvey : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<Survey>(
                modelBuilder, ref order);


            modelBuilder.Entity<Survey>()
                .Property(x => x.Name)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired();

  

            modelBuilder.Entity<Survey>()
                .Property(x => x.NumberOfPersonsInvolved)
                .HasColumnOrder(order++)
                .IsOptional();


            modelBuilder.Entity<Survey>()
                .Property(x => x.StartTime)
                .HasColumnOrder(order++)
                .IsOptional();

            modelBuilder.Entity<Survey>()
                .Property(x => x.StartLongitude)
                .HasColumnOrder(order++)
                .HasPrecision(10, 7)
                .IsOptional();

            modelBuilder.Entity<Survey>()
                .Property(x => x.StartLatitude)
                .HasColumnOrder(order++)
                .HasPrecision(10, 7)
                .IsOptional();


            modelBuilder.Entity<Survey>()
                .Property(x => x.EndTime)
                .HasColumnOrder(order++)
                .IsOptional();

            modelBuilder.Entity<Survey>()
                .Property(x => x.EndLongitude)
                .HasColumnOrder(order++)
                .HasPrecision(10, 7)
                .IsOptional();

            modelBuilder.Entity<Survey>()
                .Property(x => x.EndLatitude)
                .HasColumnOrder(order++)
                .HasPrecision(10, 7)
                .IsOptional();


            //
            modelBuilder.Entity<Survey>()
                .HasRequired(x => x.SurveyLocation)
                .WithMany()
                .HasForeignKey(x => x.BeachFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Survey>()
                .HasRequired(x => x.Organisation)
                .WithMany()
                .HasForeignKey(x => x.OrganisationFK)
                .WillCascadeOnDelete(false);



            //
            modelBuilder.Entity<Survey>()
                .HasMany(x => x.LargeItems)
                .WithOptional()
                .HasForeignKey(x => x.SurveyFK)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Survey>()
                .HasMany(x => x.LitterItems)
                .WithOptional()
                .HasForeignKey(x => x.SurveyFK)
                .WillCascadeOnDelete(true);

        }

    }
}
