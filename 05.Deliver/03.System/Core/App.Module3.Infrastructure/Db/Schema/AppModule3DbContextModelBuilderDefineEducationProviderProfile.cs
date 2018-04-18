namespace App.Module3.DbContextModelBuilder
{
    using System.Data.Entity;
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
                .IsRequired();

            // ----------------------------------------------

            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.Decile)
                .HasColumnOrder(order++)
                .IsOptional();

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.EducationProviderType)
                .WithMany()
                .HasForeignKey(x => x.EducationProviderTypeFK);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.Status)
                .WithMany()
                .HasForeignKey(x => x.StatusFK);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.AuthorityType)
                .WithMany()
                .HasForeignKey(x => x.AuthorityTypeFK);


            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.SchoolingGender)
                .WithMany()
                .HasForeignKey(x => x.GeneralElectorateFK);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasOptional(x => x.CoL)
                .WithMany()
                .HasForeignKey(x => x.CoLFK);


            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.Region)
                .WithMany()
                .HasForeignKey(x => x.RegionFK);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.LocalOffice)
                .WithMany()
                .HasForeignKey(x => x.LocalOfficeFK);


            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.EducationProviderType)
                .WithMany()
                .HasForeignKey(x => x.EducationProviderTypeFK);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.SpecialSchooling)
                .WithMany()
                .HasForeignKey(x => x.SpecialSchoolingFK);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.TeacherEducation)
                .WithMany()
                .HasForeignKey(x => x.TeacherEducationFK);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.AreaUnit)
                .WithMany()
                .HasForeignKey(x => x.AreaUnitFK);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.CommunityBoard)
                .WithMany()
                .HasForeignKey(x => x.CommunityBoardFK);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.GeneralElectorate)
                .WithMany()
                .HasForeignKey(x => x.GeneralElectorateFK);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.MaoriElectorate)
                .WithMany()
                .HasForeignKey(x => x.MaoriElectorateFK);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.RegionalCouncil)
                .WithMany()
                .HasForeignKey(x => x.RegionalCouncilFK);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.TerritorialAuthority)
                .WithMany()
                .HasForeignKey(x => x.TerritorialAuthorityFK);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.UrbanArea)
                .WithMany()
                .HasForeignKey(x => x.UrbanAreaFK);

            modelBuilder.Entity<EducationProviderProfile>()
                .HasRequired(x => x.Ward)
                .WithMany()
                .HasForeignKey(x => x.WardFK);

            // ----------------------------------------------

            modelBuilder.Entity<EducationProviderProfile>()
                .Property(x => x.Name)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X256)
                .IsRequired();

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




        }
    }
}