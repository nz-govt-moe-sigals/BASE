namespace App.Module22.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module22.Infrastructure.Initialization.Db;
    using App.Module22.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineCourse : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<Course>(modelBuilder, ref order);


            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<Course>()
               .Property(x => x.StatusFK)
               .HasColumnOrder(order++)
               .IsRequired();

            modelBuilder.Entity<Course>()
               .Property(x => x.DepartmentFK)
               .HasColumnOrder(order++)
               .IsRequired();


            // --------------------------------------------------
            // Model Specific Properties:

            modelBuilder.Entity<Course>()
            .Property(x => x.Key)
            .HasColumnOrder(order++)
            .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X64)
            .IsRequired();

            modelBuilder.Entity<Course>()
                .Property(x => x.Title)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X64)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<Course>()
            .Property(x => x.Description)
            .HasColumnOrder(order++)
            //.HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X2048)
            .IsMaxLength()
            .IsOptional();


            modelBuilder.Entity<Course>()
            .Property(x => x.Credits)
            .HasColumnOrder(order++)
            .IsRequired();



            // --------------------------------------------------
            // Entity Navigation Properties:
            modelBuilder.Entity<Course>()
                .HasRequired(x => x.Status)
                .WithMany()
                .HasForeignKey(x => x.StatusFK)
                .WillCascadeOnDelete(false)
                ;

            //A course has a Department
            modelBuilder.Entity<Course>()
            .HasRequired(c => c.Department)
            .WithMany(d => d.Courses)
            .HasForeignKey(c => c.DepartmentFK);

            // --------------------------------------------------
            // Collection Navigation Properties:
            // One to Many:
            modelBuilder.Entity<Course>()
            .HasMany(x => x.Occurances)
            .WithRequired(x=> x.Course)
            .HasForeignKey(x => x.OwnerFK)
            .WillCascadeOnDelete(true);

            //We're moving past doing a Transparent Many2Many Map between Course and Instructor,
            // moving instead towads:


            modelBuilder.Entity<Course>()
                .HasMany(x => x.InstructorRoles)
                .WithRequired(x => x.Course)
                .HasForeignKey(x => x.CourseFK);


            //// Many 2 Many
            //// Seee: https://stackoverflow.com/questions/29062094/entity-framework-code-first-cycles-or-multiple-cascade-paths
            //modelBuilder.Entity<Course>()
            //    .HasMany(t => t.InstructorRoles)
            //    .WithMany(t => t.)
            //    .Map(m =>
            //    {
            //        m.ToTable(typeof(Course).Name + "_To_" + typeof(CourseInstructor).Name);
            //        m.MapLeftKey(typeof(Course).Name + "FK");
            //        m.MapRightKey(typeof(CourseInstructor).Name + "FK");
            //    })
            //    ;

            //                    public virtual ICollection<CourseCredit> Credits { get; set; }


            // Map to CourseEnrollment join table.
            // The other half of this is in the Enrollments table:
            // See: https://stackoverflow.com/a/9960987
            modelBuilder.Entity<Course>()
                .HasMany(x => x.Enrollments)
                .WithRequired(x => x.Course)
                .HasForeignKey(x => x.CourseFK)
                .WillCascadeOnDelete(false);



            // Map to CourseEnrollment join table.
            // The other half of this is in the Resource table:
            // See: https://stackoverflow.com/a/9960987
            modelBuilder.Entity<Course>()
                .HasMany(x => x.ResourceAssignments)
                .WithRequired(x => x.Course)
                .HasForeignKey(x => x.CourseFK)
                .WillCascadeOnDelete(false);



        }
    }
}

