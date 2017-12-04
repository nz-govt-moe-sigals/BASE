namespace App.Core.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Annotations;
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppCoreDbContextModelBuilderDefineNotification : IHasAppCoreDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            new NonTenantFKEtcConvention().Define<Notification>(modelBuilder, ref order);


            modelBuilder.Entity<Notification>()
                .Property(x => x.Type)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<Notification>()
                .Property(x => x.Level)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<Notification>()
                .Ignore(x => x.IsRead);


            modelBuilder.Entity<Notification>()
                .Property(x => x.PrincipalFK)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("IX_Notification_PrincipalFK") { IsUnique = false }))
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<Notification>()
                .Property(x => x.DateTimeCreatedUtc)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<Notification>()
                .Property(x => x.DateTimeReadUtc)
                .HasColumnOrder(order++)
                .IsOptional();


            modelBuilder.Entity<Notification>()
                .Property(x => x.From)
                .HasColumnOrder(order++)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("IX_Notification_From") { IsUnique = false }))
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired();

            modelBuilder.Entity<Notification>()
                .Property(x => x.Class)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired();

            modelBuilder.Entity<Notification>()
                .Property(x => x.ImageUrl)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired();


            modelBuilder.Entity<Notification>()
                .Property(x => x.Value)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<Notification>()
                .Property(x => x.Text)
                .HasColumnOrder(order++)
                .IsMaxLength()
                .IsRequired();
        }
    }
}