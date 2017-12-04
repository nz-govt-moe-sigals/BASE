namespace App.Module2.DbContextModelBuilder
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module2.Infrastructure.Initialization;
    using App.Module2.Infrastructure.Initialization.Db;
    using App.Module2.Shared.Models.Entities;

    public class
        AppModule2DbContextModelBuilderDefineEducationOrganisation : IHasAppModule2DbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            new TenantFKEtcConvention().Define<EducationOrganisation>(modelBuilder, ref order);

            modelBuilder.Entity<EducationOrganisation>()
                .Property(x => x.Id)
                .HasColumnOrder(order++)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();


            modelBuilder.Entity<EducationOrganisation>()
                .HasRequired(x => x.Organisation)
                .WithMany()
                .HasForeignKey(x => x.OrganisationFK)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<EducationOrganisation>()
                .HasRequired(x => x.Principal)
                .WithMany()
                .HasForeignKey(x => x.PrincipalFK)
                .WillCascadeOnDelete(false);
        }
    }
}