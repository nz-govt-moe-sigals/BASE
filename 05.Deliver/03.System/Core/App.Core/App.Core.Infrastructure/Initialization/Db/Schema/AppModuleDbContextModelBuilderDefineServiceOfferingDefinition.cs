namespace App.Core.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.ModelConfiguration;
    using App.Core.Infrastructure.Contracts;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineServiceOfferingDefinition : IHasAppModuleDbContextModelBuilderInitializer
    {


        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<ServiceOfferingDefinition>(modelBuilder, ref order);

            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<ServiceOfferingDefinition>()
                .Property(x => x.ServiceFK)
                .HasColumnOrder(order++)
                .IsRequired();

            // --------------------------------------------------
            // Model Specific Properties:

            modelBuilder.DefineUniqueKey<ServiceOfferingDefinition>(ref order);

            modelBuilder.Entity<ServiceOfferingDefinition>()
                .Property(x => x.PrincipalLimit)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<ServiceOfferingDefinition>()
                .Property(x => x.ResourceLimit)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<ServiceOfferingDefinition>()
                .Property(x => x.DefaultCostPerMonth)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<ServiceOfferingDefinition>()
                .Property(x => x.DefaultCostPerYear)
                .HasColumnOrder(order++)
                .IsRequired();

            // --------------------------------------------------
            // FK Properties:

            modelBuilder.Entity<ServiceOfferingDefinition>()
                .HasRequired(x => x.Service)
                .WithMany()
                .HasForeignKey(x => x.ServiceFK);

            // --------------------------------------------------
            // Entity Navigation Properties:

            modelBuilder.Entity<ServiceOfferingDefinition>()
                .HasRequired(x => x.Service)
                .WithMany()
                .HasForeignKey(x => x.ServiceFK);
            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------
        }
    }


}

