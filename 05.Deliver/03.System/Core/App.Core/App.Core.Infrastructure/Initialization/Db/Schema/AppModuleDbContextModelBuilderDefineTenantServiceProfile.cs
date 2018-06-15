namespace App.Core.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineTenantServiceProfile : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<TenantServiceProfile>(modelBuilder, ref order);
            // --------------------------------------------------
            // FK Properties:

            // --------------------------------------------------
            // Model Specific Properties:

            //modelBuilder.Entity<TenantServiceProfile>()
            //    .Property(x => x.Enabled)
            //    .IsRequired();
            // -----
            modelBuilder.Entity<TenantServiceProfile>()
                .HasRequired(x => x.Tenant)
                .WithMany()
                .HasForeignKey(x => x.TenantFK);
            // -----
            //modelBuilder.Entity<TenantServiceProfile>()
            //    .HasMany(x => x.ServicePlans)
            //    .WithOptional()
            //    .HasForeignKey(x => x.OwnerFK);

            //modelBuilder.Entity<TenantServiceProfile>()
            //    .HasMany(x => x.Services)
            //    .WithOptional()
            //    .HasForeignKey(x => x.OwnerFK);



            // --------------------------------------------------
            // Entity Navigtation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            /* See Complex Join Object for Navigation to ServicePlanOfferings collection */

            // --------------------------------------------------


        }
    }
}