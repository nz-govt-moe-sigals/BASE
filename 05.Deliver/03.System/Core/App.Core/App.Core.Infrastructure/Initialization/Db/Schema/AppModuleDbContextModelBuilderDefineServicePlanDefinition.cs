namespace App.Core.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineServicePlanDefinition : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<ServicePlanDefinition>(modelBuilder);


            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new UntenantedAuditedRecordStatedTimestampedGuidIdReferenceDataConvention().Define<ServicePlanDefinition>(modelBuilder, ref order);

            // Note that this Schema uses an Enum as the Id:

            // --------------------------------------------------
            // Model Specific Properties:

            // --------------------------------------------------
            // FK Properties:

            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.DefineUniqueKey<ServicePlanDefinition>(ref order);

            modelBuilder.DefineDisplayableReferenceData<ServicePlanDefinition>(ref order);

            modelBuilder.Entity<ServicePlanDefinition>()
                .Property(x => x.PrincipalLimit)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<ServicePlanDefinition>()
                .Property(x => x.CostPerMonth)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<ServicePlanDefinition>()
                .Property(x => x.CostPerYear)
                .HasColumnOrder(order++)
                .IsRequired();


            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            modelBuilder.Entity<ServicePlanDefinition>()
                .HasMany(p => p.ServiceAllocations)
                .WithMany()
                .Map(j =>
                {
                    j.ToTable(typeof(ServicePlanDefinition).Name + "__" + typeof(ServiceOfferingDefinition).Name);
                    j.MapLeftKey(typeof(ServicePlanDefinition).Name + "FK");
                    j.MapRightKey(typeof(ServiceOfferingDefinition).Name + "FK");
                });
            // --------------------------------------------------


        }
    }
}