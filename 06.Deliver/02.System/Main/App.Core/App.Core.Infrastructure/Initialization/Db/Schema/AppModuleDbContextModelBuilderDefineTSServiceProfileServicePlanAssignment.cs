namespace App.Core.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using App.Core.Infrastructure.Contracts;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Entities.TenancySpecific;

    public class AppModuleDbContextModelBuilderDefineTenantServiceProfileServicePlanAllocation : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<PrincipalServiceProfileServicePlanAllocation>(modelBuilder);

            var order = 1;

            // NO! new TenantFKAuditedTimestampedRecordStatedGuidIdDataConvention().Define<CourseInstructorRole>(modelBuilder, ref order ...no...);


            //// --------------------------------------------------
            //// Create Table Name:
            //modelBuilder.Entity<TenantServiceProfileServiceOfferingAllocation>()
            //    .ToTable(
            //        $"{typeof(TenantServiceProfile)}__{typeof(ServicePlanDefinition)}"
            //    );
            // --------------------------------------------------

            // Create Composite Index:
            // See: https://stackoverflow.com/a/9960987
            modelBuilder.Entity<PrincipalServiceProfileServicePlanAllocation>()
                 .HasKey(x => new
                 {
                     // x.TenantFK
                     x.TenantServiceProfileFK,
                     x.ServicePlanFK
                 });
            // --------------------------------------------------
            // Standard Properties:

            // Re/Do the usual columns:

            new UntenantedAuditedRecordStatedTimestampedNoIdDataConvention()
                .Define< PrincipalServiceProfileServicePlanAllocation>(modelBuilder, ref order);


            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<PrincipalServiceProfileServicePlanAllocation>()
                .Property(x => x.TenantServiceProfileFK)
                .HasColumnOrder(order++)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            modelBuilder.Entity<PrincipalServiceProfileServicePlanAllocation>()
                    .Property(x => x.ServicePlanFK)
                    .HasColumnOrder(order++)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                    .IsRequired();

            // --------------------------------------------------
            // Model Specific Properties:

            modelBuilder.Entity<PrincipalServiceProfileServicePlanAllocation>()
                    .Property(x => x.Enabled)
                    .HasColumnOrder(order++)
                    .IsRequired();

            modelBuilder.Entity<PrincipalServiceProfileServicePlanAllocation>()
                    .Property(x => x.ServicePlanQuantity)
                    .HasColumnOrder(order++)
                    .IsRequired();


            // --------------------------------------------------
            // Entity Navigtation Properties:

            // Navigation from parent to this 
            // IMPORTANT: (notice T = Parent object, not this object)
            modelBuilder.Entity<PrincipalServiceProfile>()
                .HasMany(x => x.ServicePlans)
                .WithRequired(/*no navigation from Join Object to Parent*/)
                .HasForeignKey(x => x.TenantServiceProfileFK);

            // Navigate from here to to the child Object, 
            // without offering a means to navigate back up to this 
            // Complex, Join Object or the parent:
            modelBuilder.Entity<PrincipalServiceProfileServicePlanAllocation>()
                 .HasRequired(x => x.ServicePlan)
                 // Notice how on the other side we are not specifying any collection:
                 .WithMany()
                 .HasForeignKey(x => x.ServicePlanFK)
                 ;
            // --------------------------------------------------
            // Collection Navigation Properties:


            // --------------------------------------------------
        }
    }


}

