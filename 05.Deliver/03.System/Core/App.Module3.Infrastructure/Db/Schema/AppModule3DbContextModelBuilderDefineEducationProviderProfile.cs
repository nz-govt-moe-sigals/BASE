using System.ComponentModel.DataAnnotations.Schema;

namespace App.Module3.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Annotations;
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module3.Infrastructure.Initialization.Db;
    using App.Module3.Shared.Models.Entities;

    public class AppModule3DbContextModelBuilderDefineEducationProviderProfile : IHasAppModule3DbContextModelBuilderInitializer
    {
        private readonly TenantFKEtcConvention _schemaDefinitionConvention;

        public AppModule3DbContextModelBuilderDefineEducationProviderProfile(TenantFKEtcConvention schemaDefinitionConvention)
        {
            this._schemaDefinitionConvention = schemaDefinitionConvention;
        }
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;
            this._schemaDefinitionConvention.Define<EducationProviderProfile>(modelBuilder, ref order);


            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.SchoolId)
                .HasColumnOrder(order++)
                .IsRequired()
                ;

            // ----------------------------------------------
            // Many to one:

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.EducationProviderType)
                .WithMany()
                .HasForeignKey(x => x.EducationProviderTypeFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.Status)
                .WithMany()
                .HasForeignKey(x => x.StatusFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.AuthorityType)
                .WithMany()
                .HasForeignKey(x => x.AuthorityTypeFK)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.SchoolingGender)
                .WithMany()
                .HasForeignKey(x => x.GeneralElectorateFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasOptional(x => x.CoL)
                .WithMany()
                .HasForeignKey(x => x.CoLFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.Region)
                .WithMany()
                .HasForeignKey(x => x.RegionFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.LocalOffice)
                .WithMany()
                .HasForeignKey(x => x.LocalOfficeFK)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.EducationProviderType)
                .WithMany()
                .HasForeignKey(x => x.EducationProviderTypeFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.SpecialSchooling)
                .WithMany()
                .HasForeignKey(x => x.SpecialSchoolingFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.TeacherEducation)
                .WithMany()
                .HasForeignKey(x => x.TeacherEducationFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.AreaUnit)
                .WithMany()
                .HasForeignKey(x => x.AreaUnitFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.CommunityBoard)
                .WithMany()
                .HasForeignKey(x => x.CommunityBoardFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.GeneralElectorate)
                .WithMany()
                .HasForeignKey(x => x.GeneralElectorateFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.MaoriElectorate)
                .WithMany()
                .HasForeignKey(x => x.MaoriElectorateFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.RegionalCouncil)
                .WithMany()
                .HasForeignKey(x => x.RegionalCouncilFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.TerritorialAuthority)
                .WithMany()
                .HasForeignKey(x => x.TerritorialAuthorityFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.UrbanArea)
                .WithMany()
                .HasForeignKey(x => x.UrbanAreaFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.Ward)
                .WithMany()
                .HasForeignKey(x => x.WardFK)
                .WillCascadeOnDelete(false);

            // ----------------------------------------------
            // Collection Navigations:


            modelBuilder.Entity<EducationProviderProfile>()
                .HasMany(x => x.LevelGender)
                .WithOptional()
                .HasForeignKey(x => x.EducationProviderFK);


            modelBuilder.Entity<EducationProviderProfile>()
                .HasMany(x => x.RollCounts)
                .WithOptional()
                .HasForeignKey(x => x.SchoolFK);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasMany(x => x.Locations)
                .WithOptional()
                .HasForeignKey(x => x.EducationProviderFK);



            // ----------------------------------------------
            // Value Attributes:


            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.Name)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X256)
                .IsRequired();

            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.Decile)
                .HasColumnOrder(order++)
                .IsOptional();

            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.OpeningDate)
                .HasColumnOrder(order++)
                .IsOptional();

            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.ClosedDate)
                .HasColumnOrder(order++)
                .IsOptional();

            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.Email)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X256)
                .IsOptional();

            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.Url)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X256)
                .IsOptional();

            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.Telephone)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsOptional();

            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.Fax)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsOptional();


            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.CohortEntryCurrent)
                .HasColumnOrder(order++)
                .IsOptional();

            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.CohortEntryFuture)
                .HasColumnOrder(order++)
                .IsOptional();

            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.CohortEntryFutureFrom)
                .HasColumnOrder(order++)
                .IsOptional();

            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.Contact1Name)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X256)
                .IsOptional();

            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.Contact1Role)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsOptional();

            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.Contact2Name)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X256)
                .IsOptional();

            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.Contact2Role)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsOptional();

            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.Address1Line1)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X256)
                .IsOptional();
            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.Address1Line2)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X256)
                .IsOptional();

            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.Address1Line3)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X256)
                .IsOptional();

            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.Address1Suburb)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsOptional();
            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.Address1City)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsOptional();
            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.Address1PostalCode)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsOptional();

            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.Address2Line1)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X256)
                .IsOptional();

            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.Address2Line2)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X256)
                .IsOptional();
            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.Address2Line3)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X256)
                .IsOptional();

            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.Address2Suburb)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsOptional();

            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.Address2City)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsOptional();

            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.Address2PostalCode)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsOptional();


            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.SourceSystemKey)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X10)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_EducationProviderProfile_SourceSystemKey")
                    {
                        IsUnique = true
                    }))
                .IsRequired();

            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.SourceSystemName)
                .HasColumnOrder(order)
                .HasMaxLength(TextFieldSizes.X256)
                .IsOptional();



        }
    }
}