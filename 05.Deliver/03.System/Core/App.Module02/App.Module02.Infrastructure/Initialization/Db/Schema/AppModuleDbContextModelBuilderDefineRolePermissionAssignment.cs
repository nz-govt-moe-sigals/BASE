namespace App.Module02.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using App.Core.Infrastructure.Contracts;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module02.Infrastructure.Initialization.Db;
    using App.Module02.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineRolePermissionAssignment : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            // NO! new TenantFKAuditedTimestampedRecordStatedGuidIdDataConvention().Define<CourseInstructorRole>(modelBuilder, ref order ...no...);

            // --------------------------------------------------
            // Create Composite Index:
            // See: https://stackoverflow.com/a/9960987
            modelBuilder.Entity<AccountRoleAccountPermissionAssignment>()
                 .HasKey(x => new
                 {
                     // x.TenantFK
                     x.RoleFK,
                     x.PermissionFK
                 });


            // --------------------------------------------------
            // Standard Properties:

            // Re/Do the usual columns:
            new UntenantedAuditedRecordStatedTimestampedNoIdDataConvention().Define<AccountRoleAccountPermissionAssignment>(modelBuilder, ref order);

            // Add the tenancy:
            modelBuilder.DefineTenantFK<AccountRoleAccountPermissionAssignment>(ref order);

            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<AccountRoleAccountPermissionAssignment>()
                .Property(x => x.RoleFK)
                .HasColumnOrder(order++)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            modelBuilder.Entity<AccountRoleAccountPermissionAssignment>()
                    .Property(x => x.PermissionFK)
                    .HasColumnOrder(order++)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                    .IsRequired();

            // --------------------------------------------------
            // Entity Navigtation Properties:
            modelBuilder.Entity<AccountRoleAccountPermissionAssignment>()
             .HasRequired(x => x.Role)
             .WithMany(x => x.PermissionsAssignments)
             .HasForeignKey(x => x.RoleFK)
             ;

            modelBuilder.Entity<AccountRoleAccountPermissionAssignment>()
             .HasRequired(x => x.Permission)
             .WithMany()
             .HasForeignKey(x => x.PermissionFK)
             ;

            // --------------------------------------------------
            // Collection Navigtation Properties:

            //// Do not define these Entity Navigation Properties here, 
            //// as the Collection Navigation Properties
            //// are defined in the other objects.




            // --------------------------------------------------
        }
    }


}

