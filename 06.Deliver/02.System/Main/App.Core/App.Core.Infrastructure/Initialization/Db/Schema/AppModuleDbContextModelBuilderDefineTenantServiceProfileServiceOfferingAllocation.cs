﻿namespace App.Core.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using App.Core.Infrastructure.Contracts;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Entities.TenancySpecific;

    public class AppModuleDbContextModelBuilderDefineTenantServiceProfileServiceOfferingAllocation : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<PrincipalServiceProfileServiceOfferingAllocation>(modelBuilder);

            var order = 1;

            // NO! new TenantFKAuditedTimestampedRecordStatedGuidIdDataConvention().Define<CourseInstructorRole>(modelBuilder, ref order ...no...);

            //// --------------------------------------------------
            //// Create Table Name:
            //modelBuilder.Entity<TenantServiceProfileServiceOfferingAllocation>()
            //    .ToTable(
            //        $"{typeof(TenantServiceProfile)}__{typeof(ServiceOfferingDefinition)}"
            //    );
            // --------------------------------------------------

            // Create Composite Index:
            // See: https://stackoverflow.com/a/9960987
            modelBuilder.Entity<PrincipalServiceProfileServiceOfferingAllocation>()
                 .HasKey(x => new
                 {
                     // x.TenantFK
                     x.ServiceProfileFK,
                     x.ServiceOfferingFK
                 });
            // --------------------------------------------------
            // Standard Properties:

            // Re/Do the usual columns:
            new UntenantedAuditedRecordStatedTimestampedNoIdDataConvention().Define<PrincipalServiceProfileServiceOfferingAllocation>(modelBuilder, ref order);


            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<PrincipalServiceProfileServiceOfferingAllocation>()
                .Property(x => x.ServiceProfileFK)
                .HasColumnOrder(order++)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            modelBuilder.Entity<PrincipalServiceProfileServiceOfferingAllocation>()
                    .Property(x => x.ServiceOfferingFK)
                    .HasColumnOrder(order++)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                    .IsRequired();

            // --------------------------------------------------
            // Model Specific Properties:

            modelBuilder.Entity<PrincipalServiceProfileServiceOfferingAllocation>()
                    .Property(x => x.Type)
                    .HasColumnOrder(order++)
                    .IsRequired();

            modelBuilder.Entity<PrincipalServiceProfileServiceOfferingAllocation>()
                    .Property(x => x.CostPerMonth)
                    .HasColumnOrder(order++)
                    .IsRequired();

            modelBuilder.Entity<PrincipalServiceProfileServiceOfferingAllocation>()
                    .Property(x => x.CostPerYear)
                    .HasColumnOrder(order++)
                    .IsRequired();

            // --------------------------------------------------
            // Entity Navigtation Properties:


            // Navigation from parent to this 
            // IMPORTANT: (notice T = Parent object, not this object)
            modelBuilder.Entity<PrincipalServiceProfile>()
                .HasMany(x => x.ServicePlans)
                .WithRequired(/*no navigation from Join Object to Parent*/)
                .HasForeignKey(x => x.ParentFK);


            // Navigate from here to to the child Object, 
            // without offering a means to navigate back up to this 
            // Complex, Join Object or the parent:
            modelBuilder.Entity<PrincipalServiceProfileServiceOfferingAllocation>()
                 .HasRequired(x => x.ServiceOffering)
                 // Notice how on the other side we are not specifying any collection:
                 .WithMany()
                 .HasForeignKey(x => x.ServiceOfferingFK)
                 ;

            // --------------------------------------------------
            // Collection Navigation Properties:


            // --------------------------------------------------
        }
    }


}

