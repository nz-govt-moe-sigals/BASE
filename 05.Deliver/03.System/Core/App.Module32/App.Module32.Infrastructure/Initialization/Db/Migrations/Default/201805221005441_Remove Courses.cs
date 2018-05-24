namespace App.Module32.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCourses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Module32.CourseDepartments", "StatusFK", "Module32.CourseStatus");
            DropForeignKey("Module32.Courses", "DepartmentFK", "Module32.CourseDepartments");
            DropForeignKey("Module32.CourseEnrollments", "EnrolleeFK", "Module32.CourseEnrollees");
            DropForeignKey("Module32.CourseEnrollments", "GradeFK", "Module32.CourseGrades");
            DropForeignKey("Module32.CourseEnrollments", "StatusFK", "Module32.CourseStatus");
            DropForeignKey("Module32.CourseEnrollments", "CourseFK", "Module32.Courses");
            DropForeignKey("Module32.CourseInstructorAssignments", "CourseInstructorFK", "Module32.CourseInstructors");
            DropForeignKey("Module32.CourseInstructorOfficeAssignments", "CourseInstructorOfficeFK", "Module32.CourseInstructorOffices");
            DropForeignKey("Module32.CourseInstructorOfficeAssignments", "CourseInstructorFK", "Module32.CourseInstructors");
            DropForeignKey("Module32.CourseInstructors", "StatusFK", "Module32.CourseStatus");
            DropForeignKey("Module32.CourseInstructorAssignments", "RoleFK", "Module32.CourseRoles");
            DropForeignKey("Module32.CourseInstructorAssignments", "CourseFK", "Module32.Courses");
            DropForeignKey("Module32.CourseOccurances", "OwnerFK", "Module32.Courses");
            DropForeignKey("Module32.CourseResourceAssignments", "ResourceFK", "Module32.CourseResources");
            DropForeignKey("Module32.CourseResources", "StatusFK", "Module32.CourseStatus");
            DropForeignKey("Module32.CourseResources", "TypeFK", "Module32.CourseResourceTypes");
            DropForeignKey("Module32.CourseResourceAssignments", "CourseFK", "Module32.Courses");
            DropForeignKey("Module32.Courses", "StatusFK", "Module32.CourseStatus");
            DropIndex("Module32.Courses", "IX_Course_TenantFK");
            DropIndex("Module32.Courses", "IX_Course_RecordState");
            DropIndex("Module32.Courses", "IX_Course_LastModifiedOnUtc");
            DropIndex("Module32.Courses", "IX_Course_LastModifiedByPrincipalId");
            DropIndex("Module32.Courses", new[] { "StatusFK" });
            DropIndex("Module32.Courses", new[] { "DepartmentFK" });
            DropIndex("Module32.CourseDepartments", "IX_CourseDepartment_TenantFK");
            DropIndex("Module32.CourseDepartments", "IX_CourseDepartment_RecordState");
            DropIndex("Module32.CourseDepartments", "IX_CourseDepartment_LastModifiedOnUtc");
            DropIndex("Module32.CourseDepartments", "IX_CourseDepartment_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseDepartments", new[] { "StatusFK" });
            DropIndex("Module32.CourseStatus", "IX_CourseStatus_TenantFK");
            DropIndex("Module32.CourseStatus", "IX_CourseStatus_RecordState");
            DropIndex("Module32.CourseStatus", "IX_CourseStatus_LastModifiedOnUtc");
            DropIndex("Module32.CourseStatus", "IX_CourseStatus_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseEnrollments", "IX_CourseEnrollment_RecordState");
            DropIndex("Module32.CourseEnrollments", "IX_CourseEnrollment_LastModifiedOnUtc");
            DropIndex("Module32.CourseEnrollments", "IX_CourseEnrollment_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseEnrollments", "IX_CourseEnrollment_TenantFK");
            DropIndex("Module32.CourseEnrollments", new[] { "StatusFK" });
            DropIndex("Module32.CourseEnrollments", new[] { "CourseFK" });
            DropIndex("Module32.CourseEnrollments", new[] { "EnrolleeFK" });
            DropIndex("Module32.CourseEnrollments", new[] { "GradeFK" });
            DropIndex("Module32.CourseEnrollees", "IX_CourseEnrollee_TenantFK");
            DropIndex("Module32.CourseEnrollees", "IX_CourseEnrollee_RecordState");
            DropIndex("Module32.CourseEnrollees", "IX_CourseEnrollee_LastModifiedOnUtc");
            DropIndex("Module32.CourseEnrollees", "IX_CourseEnrollee_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseGrades", "IX_CourseGrade_TenantFK");
            DropIndex("Module32.CourseGrades", "IX_CourseGrade_RecordState");
            DropIndex("Module32.CourseGrades", "IX_CourseGrade_LastModifiedOnUtc");
            DropIndex("Module32.CourseGrades", "IX_CourseGrade_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseInstructorAssignments", "IX_CourseInstructorAssignment_RecordState");
            DropIndex("Module32.CourseInstructorAssignments", "IX_CourseInstructorAssignment_LastModifiedOnUtc");
            DropIndex("Module32.CourseInstructorAssignments", "IX_CourseInstructorAssignment_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseInstructorAssignments", "IX_CourseInstructorAssignment_TenantFK");
            DropIndex("Module32.CourseInstructorAssignments", new[] { "CourseFK" });
            DropIndex("Module32.CourseInstructorAssignments", new[] { "CourseInstructorFK" });
            DropIndex("Module32.CourseInstructorAssignments", new[] { "RoleFK" });
            DropIndex("Module32.CourseInstructors", "IX_CourseInstructor_TenantFK");
            DropIndex("Module32.CourseInstructors", "IX_CourseInstructor_RecordState");
            DropIndex("Module32.CourseInstructors", "IX_CourseInstructor_LastModifiedOnUtc");
            DropIndex("Module32.CourseInstructors", "IX_CourseInstructor_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseInstructors", new[] { "StatusFK" });
            DropIndex("Module32.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_RecordState");
            DropIndex("Module32.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_LastModifiedOnUtc");
            DropIndex("Module32.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_TenantFK");
            DropIndex("Module32.CourseInstructorOfficeAssignments", new[] { "CourseInstructorFK" });
            DropIndex("Module32.CourseInstructorOfficeAssignments", new[] { "CourseInstructorOfficeFK" });
            DropIndex("Module32.CourseInstructorOffices", "IX_CourseInstructorOffice_TenantFK");
            DropIndex("Module32.CourseInstructorOffices", "IX_CourseInstructorOffice_RecordState");
            DropIndex("Module32.CourseInstructorOffices", "IX_CourseInstructorOffice_LastModifiedOnUtc");
            DropIndex("Module32.CourseInstructorOffices", "IX_CourseInstructorOffice_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseRoles", "IX_CourseRole_TenantFK");
            DropIndex("Module32.CourseRoles", "IX_CourseRole_RecordState");
            DropIndex("Module32.CourseRoles", "IX_CourseRole_LastModifiedOnUtc");
            DropIndex("Module32.CourseRoles", "IX_CourseRole_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseOccurances", "IX_CourseOccurance_TenantFK");
            DropIndex("Module32.CourseOccurances", "IX_CourseOccurance_RecordState");
            DropIndex("Module32.CourseOccurances", "IX_CourseOccurance_LastModifiedOnUtc");
            DropIndex("Module32.CourseOccurances", "IX_CourseOccurance_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseOccurances", new[] { "OwnerFK" });
            DropIndex("Module32.CourseResourceAssignments", "IX_CourseResourceAssignment_RecordState");
            DropIndex("Module32.CourseResourceAssignments", "IX_CourseResourceAssignment_LastModifiedOnUtc");
            DropIndex("Module32.CourseResourceAssignments", "IX_CourseResourceAssignment_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseResourceAssignments", "IX_CourseResourceAssignment_TenantFK");
            DropIndex("Module32.CourseResourceAssignments", new[] { "CourseFK" });
            DropIndex("Module32.CourseResourceAssignments", new[] { "ResourceFK" });
            DropIndex("Module32.CourseResources", "IX_CourseResource_TenantFK");
            DropIndex("Module32.CourseResources", "IX_CourseResource_RecordState");
            DropIndex("Module32.CourseResources", "IX_CourseResource_LastModifiedOnUtc");
            DropIndex("Module32.CourseResources", "IX_CourseResource_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseResources", new[] { "StatusFK" });
            DropIndex("Module32.CourseResources", new[] { "TypeFK" });
            DropIndex("Module32.CourseResourceTypes", "IX_CourseResourceType_TenantFK");
            DropIndex("Module32.CourseResourceTypes", "IX_CourseResourceType_RecordState");
            DropIndex("Module32.CourseResourceTypes", "IX_CourseResourceType_LastModifiedOnUtc");
            DropIndex("Module32.CourseResourceTypes", "IX_CourseResourceType_LastModifiedByPrincipalId");
            DropTable("Module32.Courses");
            DropTable("Module32.CourseDepartments");
            DropTable("Module32.CourseStatus");
            DropTable("Module32.CourseEnrollments");
            DropTable("Module32.CourseEnrollees");
            DropTable("Module32.CourseGrades");
            DropTable("Module32.CourseInstructorAssignments");
            DropTable("Module32.CourseInstructors");
            DropTable("Module32.CourseInstructorOfficeAssignments");
            DropTable("Module32.CourseInstructorOffices");
            DropTable("Module32.CourseRoles");
            DropTable("Module32.CourseOccurances");
            DropTable("Module32.CourseResourceAssignments");
            DropTable("Module32.CourseResources");
            DropTable("Module32.CourseResourceTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "Module32.CourseResourceTypes",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Int(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(maxLength: 32),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module32.CourseResources",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(maxLength: 32),
                        Key = c.String(nullable: false, maxLength: 64),
                        Title = c.String(nullable: false, maxLength: 64),
                        Description = c.String(),
                        StatusFK = c.Int(nullable: false),
                        TypeFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module32.CourseResourceAssignments",
                c => new
                    {
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(maxLength: 32),
                        TenantFK = c.Guid(nullable: false),
                        CourseFK = c.Guid(nullable: false),
                        ResourceFK = c.Guid(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => new { t.CourseFK, t.ResourceFK });
            
            CreateTable(
                "Module32.CourseOccurances",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(maxLength: 32),
                        OwnerFK = c.Guid(nullable: false),
                        When = c.DateTimeOffset(nullable: false, precision: 7),
                        Duration = c.Time(nullable: false, precision: 7),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module32.CourseRoles",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(maxLength: 32),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module32.CourseInstructorOffices",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(maxLength: 32),
                        Key = c.String(nullable: false, maxLength: 64),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module32.CourseInstructorOfficeAssignments",
                c => new
                    {
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(maxLength: 32),
                        TenantFK = c.Guid(nullable: false),
                        CourseInstructorFK = c.Guid(nullable: false),
                        CourseInstructorOfficeFK = c.Guid(nullable: false),
                        Begin = c.DateTimeOffset(precision: 7),
                        End = c.DateTimeOffset(precision: 7),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => new { t.CourseInstructorFK, t.CourseInstructorOfficeFK });
            
            CreateTable(
                "Module32.CourseInstructors",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(maxLength: 32),
                        StatusFK = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        Begin = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module32.CourseInstructorAssignments",
                c => new
                    {
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(maxLength: 32),
                        TenantFK = c.Guid(nullable: false),
                        CourseFK = c.Guid(nullable: false),
                        CourseInstructorFK = c.Guid(nullable: false),
                        RoleFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseFK, t.CourseInstructorFK });
            
            CreateTable(
                "Module32.CourseGrades",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(maxLength: 32),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module32.CourseEnrollees",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(maxLength: 32),
                        Key = c.String(nullable: false, maxLength: 64),
                        Name = c.String(nullable: false, maxLength: 256),
                        Begin = c.DateTimeOffset(precision: 7),
                        End = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module32.CourseEnrollments",
                c => new
                    {
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(maxLength: 32),
                        TenantFK = c.Guid(nullable: false),
                        StatusFK = c.Int(nullable: false),
                        CourseFK = c.Guid(nullable: false),
                        EnrolleeFK = c.Guid(nullable: false),
                        GradeFK = c.Guid(nullable: false),
                        GradeComment = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => new { t.CourseFK, t.EnrolleeFK });
            
            CreateTable(
                "Module32.CourseStatus",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Int(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(maxLength: 32),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module32.CourseDepartments",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(maxLength: 32),
                        StatusFK = c.Int(nullable: false),
                        Key = c.String(nullable: false, maxLength: 64),
                        Title = c.String(nullable: false, maxLength: 64),
                        Description = c.String(),
                        Budget = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module32.Courses",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false, maxLength: 32),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(maxLength: 32),
                        StatusFK = c.Int(nullable: false),
                        DepartmentFK = c.Guid(nullable: false),
                        Key = c.String(nullable: false, maxLength: 64),
                        Title = c.String(nullable: false, maxLength: 64),
                        Description = c.String(),
                        Credits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("Module32.CourseResourceTypes", "LastModifiedByPrincipalId", name: "IX_CourseResourceType_LastModifiedByPrincipalId");
            CreateIndex("Module32.CourseResourceTypes", "LastModifiedOnUtc", name: "IX_CourseResourceType_LastModifiedOnUtc");
            CreateIndex("Module32.CourseResourceTypes", "RecordState", name: "IX_CourseResourceType_RecordState");
            CreateIndex("Module32.CourseResourceTypes", "TenantFK", name: "IX_CourseResourceType_TenantFK");
            CreateIndex("Module32.CourseResources", "TypeFK");
            CreateIndex("Module32.CourseResources", "StatusFK");
            CreateIndex("Module32.CourseResources", "LastModifiedByPrincipalId", name: "IX_CourseResource_LastModifiedByPrincipalId");
            CreateIndex("Module32.CourseResources", "LastModifiedOnUtc", name: "IX_CourseResource_LastModifiedOnUtc");
            CreateIndex("Module32.CourseResources", "RecordState", name: "IX_CourseResource_RecordState");
            CreateIndex("Module32.CourseResources", "TenantFK", name: "IX_CourseResource_TenantFK");
            CreateIndex("Module32.CourseResourceAssignments", "ResourceFK");
            CreateIndex("Module32.CourseResourceAssignments", "CourseFK");
            CreateIndex("Module32.CourseResourceAssignments", "TenantFK", name: "IX_CourseResourceAssignment_TenantFK");
            CreateIndex("Module32.CourseResourceAssignments", "LastModifiedByPrincipalId", name: "IX_CourseResourceAssignment_LastModifiedByPrincipalId");
            CreateIndex("Module32.CourseResourceAssignments", "LastModifiedOnUtc", name: "IX_CourseResourceAssignment_LastModifiedOnUtc");
            CreateIndex("Module32.CourseResourceAssignments", "RecordState", name: "IX_CourseResourceAssignment_RecordState");
            CreateIndex("Module32.CourseOccurances", "OwnerFK");
            CreateIndex("Module32.CourseOccurances", "LastModifiedByPrincipalId", name: "IX_CourseOccurance_LastModifiedByPrincipalId");
            CreateIndex("Module32.CourseOccurances", "LastModifiedOnUtc", name: "IX_CourseOccurance_LastModifiedOnUtc");
            CreateIndex("Module32.CourseOccurances", "RecordState", name: "IX_CourseOccurance_RecordState");
            CreateIndex("Module32.CourseOccurances", "TenantFK", name: "IX_CourseOccurance_TenantFK");
            CreateIndex("Module32.CourseRoles", "LastModifiedByPrincipalId", name: "IX_CourseRole_LastModifiedByPrincipalId");
            CreateIndex("Module32.CourseRoles", "LastModifiedOnUtc", name: "IX_CourseRole_LastModifiedOnUtc");
            CreateIndex("Module32.CourseRoles", "RecordState", name: "IX_CourseRole_RecordState");
            CreateIndex("Module32.CourseRoles", "TenantFK", name: "IX_CourseRole_TenantFK");
            CreateIndex("Module32.CourseInstructorOffices", "LastModifiedByPrincipalId", name: "IX_CourseInstructorOffice_LastModifiedByPrincipalId");
            CreateIndex("Module32.CourseInstructorOffices", "LastModifiedOnUtc", name: "IX_CourseInstructorOffice_LastModifiedOnUtc");
            CreateIndex("Module32.CourseInstructorOffices", "RecordState", name: "IX_CourseInstructorOffice_RecordState");
            CreateIndex("Module32.CourseInstructorOffices", "TenantFK", name: "IX_CourseInstructorOffice_TenantFK");
            CreateIndex("Module32.CourseInstructorOfficeAssignments", "CourseInstructorOfficeFK");
            CreateIndex("Module32.CourseInstructorOfficeAssignments", "CourseInstructorFK");
            CreateIndex("Module32.CourseInstructorOfficeAssignments", "TenantFK", name: "IX_CourseInstructorOfficeAssignment_TenantFK");
            CreateIndex("Module32.CourseInstructorOfficeAssignments", "LastModifiedByPrincipalId", name: "IX_CourseInstructorOfficeAssignment_LastModifiedByPrincipalId");
            CreateIndex("Module32.CourseInstructorOfficeAssignments", "LastModifiedOnUtc", name: "IX_CourseInstructorOfficeAssignment_LastModifiedOnUtc");
            CreateIndex("Module32.CourseInstructorOfficeAssignments", "RecordState", name: "IX_CourseInstructorOfficeAssignment_RecordState");
            CreateIndex("Module32.CourseInstructors", "StatusFK");
            CreateIndex("Module32.CourseInstructors", "LastModifiedByPrincipalId", name: "IX_CourseInstructor_LastModifiedByPrincipalId");
            CreateIndex("Module32.CourseInstructors", "LastModifiedOnUtc", name: "IX_CourseInstructor_LastModifiedOnUtc");
            CreateIndex("Module32.CourseInstructors", "RecordState", name: "IX_CourseInstructor_RecordState");
            CreateIndex("Module32.CourseInstructors", "TenantFK", name: "IX_CourseInstructor_TenantFK");
            CreateIndex("Module32.CourseInstructorAssignments", "RoleFK");
            CreateIndex("Module32.CourseInstructorAssignments", "CourseInstructorFK");
            CreateIndex("Module32.CourseInstructorAssignments", "CourseFK");
            CreateIndex("Module32.CourseInstructorAssignments", "TenantFK", name: "IX_CourseInstructorAssignment_TenantFK");
            CreateIndex("Module32.CourseInstructorAssignments", "LastModifiedByPrincipalId", name: "IX_CourseInstructorAssignment_LastModifiedByPrincipalId");
            CreateIndex("Module32.CourseInstructorAssignments", "LastModifiedOnUtc", name: "IX_CourseInstructorAssignment_LastModifiedOnUtc");
            CreateIndex("Module32.CourseInstructorAssignments", "RecordState", name: "IX_CourseInstructorAssignment_RecordState");
            CreateIndex("Module32.CourseGrades", "LastModifiedByPrincipalId", name: "IX_CourseGrade_LastModifiedByPrincipalId");
            CreateIndex("Module32.CourseGrades", "LastModifiedOnUtc", name: "IX_CourseGrade_LastModifiedOnUtc");
            CreateIndex("Module32.CourseGrades", "RecordState", name: "IX_CourseGrade_RecordState");
            CreateIndex("Module32.CourseGrades", "TenantFK", name: "IX_CourseGrade_TenantFK");
            CreateIndex("Module32.CourseEnrollees", "LastModifiedByPrincipalId", name: "IX_CourseEnrollee_LastModifiedByPrincipalId");
            CreateIndex("Module32.CourseEnrollees", "LastModifiedOnUtc", name: "IX_CourseEnrollee_LastModifiedOnUtc");
            CreateIndex("Module32.CourseEnrollees", "RecordState", name: "IX_CourseEnrollee_RecordState");
            CreateIndex("Module32.CourseEnrollees", "TenantFK", name: "IX_CourseEnrollee_TenantFK");
            CreateIndex("Module32.CourseEnrollments", "GradeFK");
            CreateIndex("Module32.CourseEnrollments", "EnrolleeFK");
            CreateIndex("Module32.CourseEnrollments", "CourseFK");
            CreateIndex("Module32.CourseEnrollments", "StatusFK");
            CreateIndex("Module32.CourseEnrollments", "TenantFK", name: "IX_CourseEnrollment_TenantFK");
            CreateIndex("Module32.CourseEnrollments", "LastModifiedByPrincipalId", name: "IX_CourseEnrollment_LastModifiedByPrincipalId");
            CreateIndex("Module32.CourseEnrollments", "LastModifiedOnUtc", name: "IX_CourseEnrollment_LastModifiedOnUtc");
            CreateIndex("Module32.CourseEnrollments", "RecordState", name: "IX_CourseEnrollment_RecordState");
            CreateIndex("Module32.CourseStatus", "LastModifiedByPrincipalId", name: "IX_CourseStatus_LastModifiedByPrincipalId");
            CreateIndex("Module32.CourseStatus", "LastModifiedOnUtc", name: "IX_CourseStatus_LastModifiedOnUtc");
            CreateIndex("Module32.CourseStatus", "RecordState", name: "IX_CourseStatus_RecordState");
            CreateIndex("Module32.CourseStatus", "TenantFK", name: "IX_CourseStatus_TenantFK");
            CreateIndex("Module32.CourseDepartments", "StatusFK");
            CreateIndex("Module32.CourseDepartments", "LastModifiedByPrincipalId", name: "IX_CourseDepartment_LastModifiedByPrincipalId");
            CreateIndex("Module32.CourseDepartments", "LastModifiedOnUtc", name: "IX_CourseDepartment_LastModifiedOnUtc");
            CreateIndex("Module32.CourseDepartments", "RecordState", name: "IX_CourseDepartment_RecordState");
            CreateIndex("Module32.CourseDepartments", "TenantFK", name: "IX_CourseDepartment_TenantFK");
            CreateIndex("Module32.Courses", "DepartmentFK");
            CreateIndex("Module32.Courses", "StatusFK");
            CreateIndex("Module32.Courses", "LastModifiedByPrincipalId", name: "IX_Course_LastModifiedByPrincipalId");
            CreateIndex("Module32.Courses", "LastModifiedOnUtc", name: "IX_Course_LastModifiedOnUtc");
            CreateIndex("Module32.Courses", "RecordState", name: "IX_Course_RecordState");
            CreateIndex("Module32.Courses", "TenantFK", name: "IX_Course_TenantFK");
            AddForeignKey("Module32.Courses", "StatusFK", "Module32.CourseStatus", "Id");
            AddForeignKey("Module32.CourseResourceAssignments", "CourseFK", "Module32.Courses", "Id");
            AddForeignKey("Module32.CourseResources", "TypeFK", "Module32.CourseResourceTypes", "Id", cascadeDelete: true);
            AddForeignKey("Module32.CourseResources", "StatusFK", "Module32.CourseStatus", "Id");
            AddForeignKey("Module32.CourseResourceAssignments", "ResourceFK", "Module32.CourseResources", "Id");
            AddForeignKey("Module32.CourseOccurances", "OwnerFK", "Module32.Courses", "Id", cascadeDelete: true);
            AddForeignKey("Module32.CourseInstructorAssignments", "CourseFK", "Module32.Courses", "Id", cascadeDelete: true);
            AddForeignKey("Module32.CourseInstructorAssignments", "RoleFK", "Module32.CourseRoles", "Id", cascadeDelete: true);
            AddForeignKey("Module32.CourseInstructors", "StatusFK", "Module32.CourseStatus", "Id");
            AddForeignKey("Module32.CourseInstructorOfficeAssignments", "CourseInstructorFK", "Module32.CourseInstructors", "Id");
            AddForeignKey("Module32.CourseInstructorOfficeAssignments", "CourseInstructorOfficeFK", "Module32.CourseInstructorOffices", "Id");
            AddForeignKey("Module32.CourseInstructorAssignments", "CourseInstructorFK", "Module32.CourseInstructors", "Id");
            AddForeignKey("Module32.CourseEnrollments", "CourseFK", "Module32.Courses", "Id");
            AddForeignKey("Module32.CourseEnrollments", "StatusFK", "Module32.CourseStatus", "Id");
            AddForeignKey("Module32.CourseEnrollments", "GradeFK", "Module32.CourseGrades", "Id", cascadeDelete: true);
            AddForeignKey("Module32.CourseEnrollments", "EnrolleeFK", "Module32.CourseEnrollees", "Id");
            AddForeignKey("Module32.Courses", "DepartmentFK", "Module32.CourseDepartments", "Id", cascadeDelete: true);
            AddForeignKey("Module32.CourseDepartments", "StatusFK", "Module32.CourseStatus", "Id");
        }
    }
}


