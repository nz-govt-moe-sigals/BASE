namespace App.Module2.DbContextModelBuilder
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Shared.Models.Entities.Base;
    using App.Module2.Infrastructure.Initialization;
    using App.Module2.Infrastructure.Initialization.Db;
    using App.Module2.Shared.Models.Entities;

    public class
        AppModule2DbContextModelBuilderDefineEducationOrganisation : IHasAppModule2DbContextModelBuilderInitializer
    {
        private readonly TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention _convention;

        
        public AppModule2DbContextModelBuilderDefineEducationOrganisation(TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention _convention)
        {
            this._convention = _convention;
        }

        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            this._convention.Define<EducationOrganisation>(modelBuilder, ref order);


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