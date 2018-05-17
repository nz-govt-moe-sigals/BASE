    modelBuilder.Entity<Student>()
                .HasMany<Course>(s => s.Courses)
                .WithMany(c => c.Students)
                .Map(j =>
                        {
                            j.ToTable(typeof(Student).Name + "_to_" typeof(Course).Name);
                            j.MapLeftKey("StudentRefId");
                            j.MapRightKey("CourseRefId");
                        });