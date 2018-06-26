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
    public class AppModuleDbContextModelBuilderDefineBeach : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<SurveyLocation>(
                modelBuilder, ref order);


            modelBuilder.Entity<SurveyLocation>()
                .Property(x => x.SurveyLocationId)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X32)
                .IsRequired();

            modelBuilder.Entity<SurveyLocation>()
                .Property(x => x.Name)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired();

            modelBuilder.Entity<SurveyLocation>()
                .Property(x => x.BackOfBeach)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsOptional();

            modelBuilder.Entity<SurveyLocation>()
                .Property(x => x.Length)
                .HasColumnOrder(order++)
                .HasPrecision(7,2)
                .IsRequired();

            modelBuilder.Entity<SurveyLocation>()
                .Property(x => x.Width)
                .HasColumnOrder(order++)
                .HasPrecision(7,2)
                .IsOptional();


            modelBuilder.Entity<SurveyLocation>()
                .Property(x => x.SubstratumType)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsOptional();

            modelBuilder.Entity<SurveyLocation>()
                .Property(x => x.SubstrateUniformity)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsOptional();


            modelBuilder.Entity<SurveyLocation>()
                .Property(x => x.TidalDistance)
                .HasColumnOrder(order++)
                .HasPrecision(7,2)
                .IsOptional();

            modelBuilder.Entity<SurveyLocation>()
                .Property(x => x.TidalRange)
                .HasColumnOrder(order++)
                .HasPrecision(7,2)
                .IsOptional();


            modelBuilder.Entity<SurveyLocation>()
                .Property(x => x.NearestTown)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsOptional();

            modelBuilder.Entity<SurveyLocation>()
                .Property(x => x.NearestTownDirection)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsOptional();

            modelBuilder.Entity<SurveyLocation>()
                .Property(x => x.NearestTownDistance)
                .HasColumnOrder(order++)
                .HasPrecision(7,2)
                .IsOptional();


            modelBuilder.Entity<SurveyLocation>()
                .Property(x => x.NearestRiverName)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsOptional();

            modelBuilder.Entity<SurveyLocation>()
                .Property(x => x.NearestRiverDirection)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsOptional();

            modelBuilder.Entity<SurveyLocation>()
                .Property(x => x.NearestRiverDistance)
                .HasColumnOrder(order++)
                .HasPrecision(7,2)
                .IsOptional();


            modelBuilder.Entity<SurveyLocation>()
                .Property(x => x.RiverInputName)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsOptional();

            modelBuilder.Entity<SurveyLocation>()
                .Property(x => x.PipesOrDrainsInput)
                .HasColumnOrder(order++)
                .IsOptional();

            modelBuilder.Entity<SurveyLocation>()
                .Property(x => x.Access)
                .HasColumnOrder(order++)
                .IsRequired();

            // 
            modelBuilder.Entity<SurveyLocation>()
                .HasRequired(x => x.Region)
                .WithMany()
                .HasForeignKey(x => x.RegionFK)
                .WillCascadeOnDelete(false);


            //Collections
            modelBuilder.Entity<SurveyLocation>()
                .HasMany(x => x.Surveys)
                .WithOptional()
                .HasForeignKey(x => x.BeachFK)
                .WillCascadeOnDelete(true);
        }

    }
}
