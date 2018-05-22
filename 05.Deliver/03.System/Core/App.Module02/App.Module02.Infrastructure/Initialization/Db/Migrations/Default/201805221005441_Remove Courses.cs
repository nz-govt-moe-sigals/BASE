namespace App.Module02.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCourses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Module02.CourseDepartments", "StatusFK", "Module02.CourseStatus");
            DropForeignKey("Module02.Courses", "DepartmentFK", "Module02.CourseDepartments");
            DropForeignKey("Module02.CourseEnrollments", "EnrolleeFK", "Module02.CourseEnrollees");
            DropForeignKey("Module02.CourseEnrollments", "GradeFK", "Module02.CourseGrades");
            DropForeignKey("Module02.CourseEnrollments", "StatusFK", "Module02.CourseStatus");
            DropForeignKey("Module02.CourseEnrollments", "CourseFK", "Module02.Courses");
            DropForeignKey("Module02.CourseInstructorAssignments", "CourseInstructorFK", "Module02.CourseInstructors");
            DropForeignKey("Module02.CourseInstructorOfficeAssignments", "CourseInstructorOfficeFK", "Module02.CourseInstructorOffices");
            DropForeignKey("Module02.CourseInstructorOfficeAssignments", "CourseInstructorFK", "Module02.CourseInstructors");
            DropForeignKey("Module02.CourseInstructors", "StatusFK", "Module02.CourseStatus");
            DropForeignKey("Module02.CourseInstructorAssignments", "RoleFK", "Module02.CourseRoles");
            DropForeignKey("Module02.CourseInstructorAssignments", "CourseFK", "Module02.Courses");
            DropForeignKey("Module02.CourseOccurances", "OwnerFK", "Module02.Courses");
            DropForeignKey("Module02.CourseResourceAssignments", "ResourceFK", "Module02.CourseResources");
            DropForeignKey("Module02.CourseResources", "StatusFK", "Module02.CourseStatus");
            DropForeignKey("Module02.CourseResources", "TypeFK", "Module02.CourseResourceTypes");
            DropForeignKey("Module02.CourseResourceAssignments", "CourseFK", "Module02.Courses");
            DropForeignKey("Module02.Courses", "StatusFK", "Module02.CourseStatus");
            DropIndex("Module02.Courses", "IX_Course_TenantFK");
            DropIndex("Module02.Courses", "IX_Course_RecordState");
            DropIndex("Module02.Courses", "IX_Course_LastModifiedOnUtc");
            DropIndex("Module02.Courses", "IX_Course_LastModifiedByPrincipalId");
            DropIndex("Module02.Courses", new[] { "StatusFK" });
            DropIndex("Module02.Courses", new[] { "DepartmentFK" });
            DropIndex("Module02.CourseDepartments", "IX_CourseDepartment_TenantFK");
            DropIndex("Module02.CourseDepartments", "IX_CourseDepartment_RecordState");
            DropIndex("Module02.CourseDepartments", "IX_CourseDepartment_LastModifiedOnUtc");
            DropIndex("Module02.CourseDepartments", "IX_CourseDepartment_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseDepartments", new[] { "StatusFK" });
            DropIndex("Module02.CourseStatus", "IX_CourseStatus_TenantFK");
            DropIndex("Module02.CourseStatus", "IX_CourseStatus_RecordState");
            DropIndex("Module02.CourseStatus", "IX_CourseStatus_LastModifiedOnUtc");
            DropIndex("Module02.CourseStatus", "IX_CourseStatus_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseEnrollments", "IX_CourseEnrollment_RecordState");
            DropIndex("Module02.CourseEnrollments", "IX_CourseEnrollment_LastModifiedOnUtc");
            DropIndex("Module02.CourseEnrollments", "IX_CourseEnrollment_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseEnrollments", "IX_CourseEnrollment_TenantFK");
            DropIndex("Module02.CourseEnrollments", new[] { "StatusFK" });
            DropIndex("Module02.CourseEnrollments", new[] { "CourseFK" });
            DropIndex("Module02.CourseEnrollments", new[] { "EnrolleeFK" });
            DropIndex("Module02.CourseEnrollments", new[] { "GradeFK" });
            DropIndex("Module02.CourseEnrollees", "IX_CourseEnrollee_TenantFK");
            DropIndex("Module02.CourseEnrollees", "IX_CourseEnrollee_RecordState");
            DropIndex("Module02.CourseEnrollees", "IX_CourseEnrollee_LastModifiedOnUtc");
            DropIndex("Module02.CourseEnrollees", "IX_CourseEnrollee_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseGrades", "IX_CourseGrade_TenantFK");
            DropIndex("Module02.CourseGrades", "IX_CourseGrade_RecordState");
            DropIndex("Module02.CourseGrades", "IX_CourseGrade_LastModifiedOnUtc");
            DropIndex("Module02.CourseGrades", "IX_CourseGrade_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseInstructorAssignments", "IX_CourseInstructorAssignment_RecordState");
            DropIndex("Module02.CourseInstructorAssignments", "IX_CourseInstructorAssignment_LastModifiedOnUtc");
            DropIndex("Module02.CourseInstructorAssignments", "IX_CourseInstructorAssignment_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseInstructorAssignments", "IX_CourseInstructorAssignment_TenantFK");
            DropIndex("Module02.CourseInstructorAssignments", new[] { "CourseFK" });
            DropIndex("Module02.CourseInstructorAssignments", new[] { "CourseInstructorFK" });
            DropIndex("Module02.CourseInstructorAssignments", new[] { "RoleFK" });
            DropIndex("Module02.CourseInstructors", "IX_CourseInstructor_TenantFK");
            DropIndex("Module02.CourseInstructors", "IX_CourseInstructor_RecordState");
            DropIndex("Module02.CourseInstructors", "IX_CourseInstructor_LastModifiedOnUtc");
            DropIndex("Module02.CourseInstructors", "IX_CourseInstructor_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseInstructors", new[] { "StatusFK" });
            DropIndex("Module02.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_RecordState");
            DropIndex("Module02.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_LastModifiedOnUtc");
            DropIndex("Module02.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_TenantFK");
            DropIndex("Module02.CourseInstructorOfficeAssignments", new[] { "CourseInstructorFK" });
            DropIndex("Module02.CourseInstructorOfficeAssignments", new[] { "CourseInstructorOfficeFK" });
            DropIndex("Module02.CourseInstructorOffices", "IX_CourseInstructorOffice_TenantFK");
            DropIndex("Module02.CourseInstructorOffices", "IX_CourseInstructorOffice_RecordState");
            DropIndex("Module02.CourseInstructorOffices", "IX_CourseInstructorOffice_LastModifiedOnUtc");
            DropIndex("Module02.CourseInstructorOffices", "IX_CourseInstructorOffice_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseRoles", "IX_CourseRole_TenantFK");
            DropIndex("Module02.CourseRoles", "IX_CourseRole_RecordState");
            DropIndex("Module02.CourseRoles", "IX_CourseRole_LastModifiedOnUtc");
            DropIndex("Module02.CourseRoles", "IX_CourseRole_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseOccurances", "IX_CourseOccurance_TenantFK");
            DropIndex("Module02.CourseOccurances", "IX_CourseOccurance_RecordState");
            DropIndex("Module02.CourseOccurances", "IX_CourseOccurance_LastModifiedOnUtc");
            DropIndex("Module02.CourseOccurances", "IX_CourseOccurance_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseOccurances", new[] { "OwnerFK" });
            DropIndex("Module02.CourseResourceAssignments", "IX_CourseResourceAssignment_RecordState");
            DropIndex("Module02.CourseResourceAssignments", "IX_CourseResourceAssignment_LastModifiedOnUtc");
            DropIndex("Module02.CourseResourceAssignments", "IX_CourseResourceAssignment_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseResourceAssignments", "IX_CourseResourceAssignment_TenantFK");
            DropIndex("Module02.CourseResourceAssignments", new[] { "CourseFK" });
            DropIndex("Module02.CourseResourceAssignments", new[] { "ResourceFK" });
            DropIndex("Module02.CourseResources", "IX_CourseResource_TenantFK");
            DropIndex("Module02.CourseResources", "IX_CourseResource_RecordState");
            DropIndex("Module02.CourseResources", "IX_CourseResource_LastModifiedOnUtc");
            DropIndex("Module02.CourseResources", "IX_CourseResource_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseResources", new[] { "StatusFK" });
            DropIndex("Module02.CourseResources", new[] { "TypeFK" });
            DropIndex("Module02.CourseResourceTypes", "IX_CourseResourceType_TenantFK");
            DropIndex("Module02.CourseResourceTypes", "IX_CourseResourceType_RecordState");
            DropIndex("Module02.CourseResourceTypes", "IX_CourseResourceType_LastModifiedOnUtc");
            DropIndex("Module02.CourseResourceTypes", "IX_CourseResourceType_LastModifiedByPrincipalId");
            DropTable("Module02.Courses");
            DropTable("Module02.CourseDepartments");
            DropTable("Module02.CourseStatus");
            DropTable("Module02.CourseEnrollments");
            DropTable("Module02.CourseEnrollees");
            DropTable("Module02.CourseGrades");
            DropTable("Module02.CourseInstructorAssignments");
            DropTable("Module02.CourseInstructors");
            DropTable("Module02.CourseInstructorOfficeAssignments");
            DropTable("Module02.CourseInstructorOffices");
            DropTable("Module02.CourseRoles");
            DropTable("Module02.CourseOccurances");
            DropTable("Module02.CourseResourceAssignments");
            DropTable("Module02.CourseResources");
            DropTable("Module02.CourseResourceTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "Module02.CourseResourceTypes",
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
                "Module02.CourseResources",
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
                "Module02.CourseResourceAssignments",
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
                "Module02.CourseOccurances",
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
                "Module02.CourseRoles",
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
                "Module02.CourseInstructorOffices",
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
                "Module02.CourseInstructorOfficeAssignments",
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
                "Module02.CourseInstructors",
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
                "Module02.CourseInstructorAssignments",
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
                "Module02.CourseGrades",
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
                "Module02.CourseEnrollees",
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
                "Module02.CourseEnrollments",
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
                "Module02.CourseStatus",
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
                "Module02.CourseDepartments",
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
                "Module02.Courses",
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
            
            CreateIndex("Module02.CourseResourceTypes", "LastModifiedByPrincipalId", name: "IX_CourseResourceType_LastModifiedByPrincipalId");
            CreateIndex("Module02.CourseResourceTypes", "LastModifiedOnUtc", name: "IX_CourseResourceType_LastModifiedOnUtc");
            CreateIndex("Module02.CourseResourceTypes", "RecordState", name: "IX_CourseResourceType_RecordState");
            CreateIndex("Module02.CourseResourceTypes", "TenantFK", name: "IX_CourseResourceType_TenantFK");
            CreateIndex("Module02.CourseResources", "TypeFK");
            CreateIndex("Module02.CourseResources", "StatusFK");
            CreateIndex("Module02.CourseResources", "LastModifiedByPrincipalId", name: "IX_CourseResource_LastModifiedByPrincipalId");
            CreateIndex("Module02.CourseResources", "LastModifiedOnUtc", name: "IX_CourseResource_LastModifiedOnUtc");
            CreateIndex("Module02.CourseResources", "RecordState", name: "IX_CourseResource_RecordState");
            CreateIndex("Module02.CourseResources", "TenantFK", name: "IX_CourseResource_TenantFK");
            CreateIndex("Module02.CourseResourceAssignments", "ResourceFK");
            CreateIndex("Module02.CourseResourceAssignments", "CourseFK");
            CreateIndex("Module02.CourseResourceAssignments", "TenantFK", name: "IX_CourseResourceAssignment_TenantFK");
            CreateIndex("Module02.CourseResourceAssignments", "LastModifiedByPrincipalId", name: "IX_CourseResourceAssignment_LastModifiedByPrincipalId");
            CreateIndex("Module02.CourseResourceAssignments", "LastModifiedOnUtc", name: "IX_CourseResourceAssignment_LastModifiedOnUtc");
            CreateIndex("Module02.CourseResourceAssignments", "RecordState", name: "IX_CourseResourceAssignment_RecordState");
            CreateIndex("Module02.CourseOccurances", "OwnerFK");
            CreateIndex("Module02.CourseOccurances", "LastModifiedByPrincipalId", name: "IX_CourseOccurance_LastModifiedByPrincipalId");
            CreateIndex("Module02.CourseOccurances", "LastModifiedOnUtc", name: "IX_CourseOccurance_LastModifiedOnUtc");
            CreateIndex("Module02.CourseOccurances", "RecordState", name: "IX_CourseOccurance_RecordState");
            CreateIndex("Module02.CourseOccurances", "TenantFK", name: "IX_CourseOccurance_TenantFK");
            CreateIndex("Module02.CourseRoles", "LastModifiedByPrincipalId", name: "IX_CourseRole_LastModifiedByPrincipalId");
            CreateIndex("Module02.CourseRoles", "LastModifiedOnUtc", name: "IX_CourseRole_LastModifiedOnUtc");
            CreateIndex("Module02.CourseRoles", "RecordState", name: "IX_CourseRole_RecordState");
            CreateIndex("Module02.CourseRoles", "TenantFK", name: "IX_CourseRole_TenantFK");
            CreateIndex("Module02.CourseInstructorOffices", "LastModifiedByPrincipalId", name: "IX_CourseInstructorOffice_LastModifiedByPrincipalId");
            CreateIndex("Module02.CourseInstructorOffices", "LastModifiedOnUtc", name: "IX_CourseInstructorOffice_LastModifiedOnUtc");
            CreateIndex("Module02.CourseInstructorOffices", "RecordState", name: "IX_CourseInstructorOffice_RecordState");
            CreateIndex("Module02.CourseInstructorOffices", "TenantFK", name: "IX_CourseInstructorOffice_TenantFK");
            CreateIndex("Module02.CourseInstructorOfficeAssignments", "CourseInstructorOfficeFK");
            CreateIndex("Module02.CourseInstructorOfficeAssignments", "CourseInstructorFK");
            CreateIndex("Module02.CourseInstructorOfficeAssignments", "TenantFK", name: "IX_CourseInstructorOfficeAssignment_TenantFK");
            CreateIndex("Module02.CourseInstructorOfficeAssignments", "LastModifiedByPrincipalId", name: "IX_CourseInstructorOfficeAssignment_LastModifiedByPrincipalId");
            CreateIndex("Module02.CourseInstructorOfficeAssignments", "LastModifiedOnUtc", name: "IX_CourseInstructorOfficeAssignment_LastModifiedOnUtc");
            CreateIndex("Module02.CourseInstructorOfficeAssignments", "RecordState", name: "IX_CourseInstructorOfficeAssignment_RecordState");
            CreateIndex("Module02.CourseInstructors", "StatusFK");
            CreateIndex("Module02.CourseInstructors", "LastModifiedByPrincipalId", name: "IX_CourseInstructor_LastModifiedByPrincipalId");
            CreateIndex("Module02.CourseInstructors", "LastModifiedOnUtc", name: "IX_CourseInstructor_LastModifiedOnUtc");
            CreateIndex("Module02.CourseInstructors", "RecordState", name: "IX_CourseInstructor_RecordState");
            CreateIndex("Module02.CourseInstructors", "TenantFK", name: "IX_CourseInstructor_TenantFK");
            CreateIndex("Module02.CourseInstructorAssignments", "RoleFK");
            CreateIndex("Module02.CourseInstructorAssignments", "CourseInstructorFK");
            CreateIndex("Module02.CourseInstructorAssignments", "CourseFK");
            CreateIndex("Module02.CourseInstructorAssignments", "TenantFK", name: "IX_CourseInstructorAssignment_TenantFK");
            CreateIndex("Module02.CourseInstructorAssignments", "LastModifiedByPrincipalId", name: "IX_CourseInstructorAssignment_LastModifiedByPrincipalId");
            CreateIndex("Module02.CourseInstructorAssignments", "LastModifiedOnUtc", name: "IX_CourseInstructorAssignment_LastModifiedOnUtc");
            CreateIndex("Module02.CourseInstructorAssignments", "RecordState", name: "IX_CourseInstructorAssignment_RecordState");
            CreateIndex("Module02.CourseGrades", "LastModifiedByPrincipalId", name: "IX_CourseGrade_LastModifiedByPrincipalId");
            CreateIndex("Module02.CourseGrades", "LastModifiedOnUtc", name: "IX_CourseGrade_LastModifiedOnUtc");
            CreateIndex("Module02.CourseGrades", "RecordState", name: "IX_CourseGrade_RecordState");
            CreateIndex("Module02.CourseGrades", "TenantFK", name: "IX_CourseGrade_TenantFK");
            CreateIndex("Module02.CourseEnrollees", "LastModifiedByPrincipalId", name: "IX_CourseEnrollee_LastModifiedByPrincipalId");
            CreateIndex("Module02.CourseEnrollees", "LastModifiedOnUtc", name: "IX_CourseEnrollee_LastModifiedOnUtc");
            CreateIndex("Module02.CourseEnrollees", "RecordState", name: "IX_CourseEnrollee_RecordState");
            CreateIndex("Module02.CourseEnrollees", "TenantFK", name: "IX_CourseEnrollee_TenantFK");
            CreateIndex("Module02.CourseEnrollments", "GradeFK");
            CreateIndex("Module02.CourseEnrollments", "EnrolleeFK");
            CreateIndex("Module02.CourseEnrollments", "CourseFK");
            CreateIndex("Module02.CourseEnrollments", "StatusFK");
            CreateIndex("Module02.CourseEnrollments", "TenantFK", name: "IX_CourseEnrollment_TenantFK");
            CreateIndex("Module02.CourseEnrollments", "LastModifiedByPrincipalId", name: "IX_CourseEnrollment_LastModifiedByPrincipalId");
            CreateIndex("Module02.CourseEnrollments", "LastModifiedOnUtc", name: "IX_CourseEnrollment_LastModifiedOnUtc");
            CreateIndex("Module02.CourseEnrollments", "RecordState", name: "IX_CourseEnrollment_RecordState");
            CreateIndex("Module02.CourseStatus", "LastModifiedByPrincipalId", name: "IX_CourseStatus_LastModifiedByPrincipalId");
            CreateIndex("Module02.CourseStatus", "LastModifiedOnUtc", name: "IX_CourseStatus_LastModifiedOnUtc");
            CreateIndex("Module02.CourseStatus", "RecordState", name: "IX_CourseStatus_RecordState");
            CreateIndex("Module02.CourseStatus", "TenantFK", name: "IX_CourseStatus_TenantFK");
            CreateIndex("Module02.CourseDepartments", "StatusFK");
            CreateIndex("Module02.CourseDepartments", "LastModifiedByPrincipalId", name: "IX_CourseDepartment_LastModifiedByPrincipalId");
            CreateIndex("Module02.CourseDepartments", "LastModifiedOnUtc", name: "IX_CourseDepartment_LastModifiedOnUtc");
            CreateIndex("Module02.CourseDepartments", "RecordState", name: "IX_CourseDepartment_RecordState");
            CreateIndex("Module02.CourseDepartments", "TenantFK", name: "IX_CourseDepartment_TenantFK");
            CreateIndex("Module02.Courses", "DepartmentFK");
            CreateIndex("Module02.Courses", "StatusFK");
            CreateIndex("Module02.Courses", "LastModifiedByPrincipalId", name: "IX_Course_LastModifiedByPrincipalId");
            CreateIndex("Module02.Courses", "LastModifiedOnUtc", name: "IX_Course_LastModifiedOnUtc");
            CreateIndex("Module02.Courses", "RecordState", name: "IX_Course_RecordState");
            CreateIndex("Module02.Courses", "TenantFK", name: "IX_Course_TenantFK");
            AddForeignKey("Module02.Courses", "StatusFK", "Module02.CourseStatus", "Id");
            AddForeignKey("Module02.CourseResourceAssignments", "CourseFK", "Module02.Courses", "Id");
            AddForeignKey("Module02.CourseResources", "TypeFK", "Module02.CourseResourceTypes", "Id", cascadeDelete: true);
            AddForeignKey("Module02.CourseResources", "StatusFK", "Module02.CourseStatus", "Id");
            AddForeignKey("Module02.CourseResourceAssignments", "ResourceFK", "Module02.CourseResources", "Id");
            AddForeignKey("Module02.CourseOccurances", "OwnerFK", "Module02.Courses", "Id", cascadeDelete: true);
            AddForeignKey("Module02.CourseInstructorAssignments", "CourseFK", "Module02.Courses", "Id", cascadeDelete: true);
            AddForeignKey("Module02.CourseInstructorAssignments", "RoleFK", "Module02.CourseRoles", "Id", cascadeDelete: true);
            AddForeignKey("Module02.CourseInstructors", "StatusFK", "Module02.CourseStatus", "Id");
            AddForeignKey("Module02.CourseInstructorOfficeAssignments", "CourseInstructorFK", "Module02.CourseInstructors", "Id");
            AddForeignKey("Module02.CourseInstructorOfficeAssignments", "CourseInstructorOfficeFK", "Module02.CourseInstructorOffices", "Id");
            AddForeignKey("Module02.CourseInstructorAssignments", "CourseInstructorFK", "Module02.CourseInstructors", "Id");
            AddForeignKey("Module02.CourseEnrollments", "CourseFK", "Module02.Courses", "Id");
            AddForeignKey("Module02.CourseEnrollments", "StatusFK", "Module02.CourseStatus", "Id");
            AddForeignKey("Module02.CourseEnrollments", "GradeFK", "Module02.CourseGrades", "Id", cascadeDelete: true);
            AddForeignKey("Module02.CourseEnrollments", "EnrolleeFK", "Module02.CourseEnrollees", "Id");
            AddForeignKey("Module02.Courses", "DepartmentFK", "Module02.CourseDepartments", "Id", cascadeDelete: true);
            AddForeignKey("Module02.CourseDepartments", "StatusFK", "Module02.CourseStatus", "Id");
        }
    }
}


