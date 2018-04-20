namespace App.Module3.DbContextModelBuilder
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module3.Infrastructure.Initialization.Db;
    using App.Module3.Shared.Models.Entities;

    public class AppModule3DbContextModelBuilderDefineEducationProviderLevelGender : IHasAppModule3DbContextModelBuilderInitializer
    {
        private readonly TenantFKEtcConvention _schemaDefinitionConvention;

        public AppModule3DbContextModelBuilderDefineEducationProviderLevelGender(TenantFKEtcConvention schemaDefinitionConvention)
        {
            this._schemaDefinitionConvention = schemaDefinitionConvention;
        }

        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;
            this._schemaDefinitionConvention.Define<EducationProviderLevelGender>(modelBuilder, ref order);

            // A school profile can have n SchoolLevelGender records.
            modelBuilder.Entity<EducationProviderLevelGender>()
                .Property(x => x.EducationProviderFK)
                .HasColumnOrder(order++)
                .IsRequired();

            // A SchoolLevelGender record  points to one of each of the following:
            modelBuilder.Entity<EducationProviderLevelGender>()
                .HasRequired(x => x.Year)
                .WithMany()
                .HasForeignKey(x => x.YearFK);

            modelBuilder.Entity<EducationProviderLevelGender>()
                .HasRequired(x => x.Gender)
                .WithMany()
                .HasForeignKey(x => x.GenderFK);

            modelBuilder.Entity<EducationProviderLevelGender>()
                .Property(x => x.SourceReferenceId)
                .HasColumnOrder(order)
                .IsRequired();
        }
    }
}