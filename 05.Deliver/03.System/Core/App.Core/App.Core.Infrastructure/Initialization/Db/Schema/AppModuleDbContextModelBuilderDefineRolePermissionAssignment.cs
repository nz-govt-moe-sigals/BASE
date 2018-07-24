namespace App.Core.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using App.Core.Infrastructure.Contracts;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineRolePermissionAssignment : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment>(modelBuilder);

            var order = 1;

            // NO! new TenantFKAuditedTimestampedRecordStatedGuidIdDataConvention().Define<CourseInstructorRole>(modelBuilder, ref order ...no...);

            // --------------------------------------------------
            // Create Composite Index:
            // See: https://stackoverflow.com/a/9960987
            modelBuilder.Entity<TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment>()
                 .HasKey(x => new
                 {
                     // x.TenantFK
                     x.RoleFK,
                     x.PermissionFK
                 });


            // --------------------------------------------------
            // Standard Properties:

            // Re/Do the usual columns:
            new UntenantedAuditedRecordStatedTimestampedNoIdDataConvention().Define<TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment>(modelBuilder, ref order);

            // Add the tenancy:
            modelBuilder.DefineTenantFK<TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment>(ref order);

            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment>()
                .Property(x => x.RoleFK)
                .HasColumnOrder(order++)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            modelBuilder.Entity<TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment>()
                    .Property(x => x.PermissionFK)
                    .HasColumnOrder(order++)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                    .IsRequired();

            // --------------------------------------------------
            // Entity Navigtation Properties:
            modelBuilder.Entity<TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment>()
             .HasRequired(x => x.Role)
             .WithMany(x => x.PermissionsAssignments)
             .HasForeignKey(x => x.RoleFK)
             ;

            modelBuilder.Entity<TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment>()
             .HasRequired(x => x.Permission)
             .WithMany()
             .HasForeignKey(x => x.PermissionFK)
             ;

            // --------------------------------------------------
            // Collection Navigation Properties:

            //// Do not define these Entity Navigation Properties here, 
            //// as the Collection Navigation Properties
            //// are defined in the other objects.




            // --------------------------------------------------
        }
    }


}

