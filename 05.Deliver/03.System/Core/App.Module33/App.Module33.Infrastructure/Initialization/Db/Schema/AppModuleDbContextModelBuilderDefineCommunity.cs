using System.Data.Entity;
using App.Core.Infrastructure.Db.Schema.Conventions;
using App.Module33.Shared.Models.Entities;

namespace App.Module33.Infrastructure.Initialization.Db.Schema
{
    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineCommunity : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;
                
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<Community>(modelBuilder, ref order);


            // --------------------------------------------------
            // FK Properties:

            // --------------------------------------------------
            // Model Specific Properties:


            modelBuilder.Entity<Community>()
                .Property(x => x.Owner)
                .HasColumnOrder(order++)
                .IsRequired();
            modelBuilder.Entity<Community>()
                .Property(x => x.PublicText)
                .HasColumnOrder(order++)
                .IsRequired();
            modelBuilder.Entity<Community>()
                .Property(x => x.SensitiveText)
                .HasColumnOrder(order++)
                .IsOptional();
            modelBuilder.Entity<Community>()
                .Property(x => x.AppPrivateText)
                .HasColumnOrder(order++)
                .IsOptional();

            modelBuilder.Entity<Community>()
                .Property(x => x.Name)
                .HasColumnOrder(order++)
                .IsRequired();
            modelBuilder.Entity<Community>()
                .Property(x => x.Description)
                .HasColumnOrder(order++)
                .IsOptional();
            modelBuilder.Entity<Community>()
                .Property(x => x.ColourSchemeFK)
                .HasColumnOrder(order++)
                .IsRequired();
            modelBuilder.Entity<Community>()
                .HasRequired(x => x.ColourScheme)
                .WithMany(x => x.Communities)
                .HasForeignKey(x => x.ColourSchemeFK);
            modelBuilder.Entity<Community>()
                .Property(x => x.Strategy)
                .HasColumnOrder(order++)
                .IsOptional();

            modelBuilder.Entity<Community>()
                .HasMany(x => x.CoherentPathways)
                .WithRequired(x => x.Community)
                .HasForeignKey(x => x.CommunityFK);

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------
        }
    }
}
