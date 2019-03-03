namespace App.Module01.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCourses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Module01.CourseDepartments", "StatusFK", "Module01.CourseStatus");
            DropForeignKey("Module01.Courses", "DepartmentFK", "Module01.CourseDepartments");
            DropForeignKey("Module01.CourseEnrollments", "EnrolleeFK", "Module01.CourseEnrollees");
            DropForeignKey("Module01.CourseEnrollments", "GradeFK", "Module01.CourseGrades");
            DropForeignKey("Module01.CourseEnrollments", "StatusFK", "Module01.CourseStatus");
            DropForeignKey("Module01.CourseEnrollments", "CourseFK", "Module01.Courses");
            DropForeignKey("Module01.CourseInstructorAssignments", "CourseInstructorFK", "Module01.CourseInstructors");
            DropForeignKey("Module01.CourseInstructorOfficeAssignments", "CourseInstructorOfficeFK", "Module01.CourseInstructorOffices");
            DropForeignKey("Module01.CourseInstructorOfficeAssignments", "CourseInstructorFK", "Module01.CourseInstructors");
            DropForeignKey("Module01.CourseInstructors", "StatusFK", "Module01.CourseStatus");
            DropForeignKey("Module01.CourseInstructorAssignments", "RoleFK", "Module01.CourseRoles");
            DropForeignKey("Module01.CourseInstructorAssignments", "CourseFK", "Module01.Courses");
            DropForeignKey("Module01.CourseOccurances", "OwnerFK", "Module01.Courses");
            DropForeignKey("Module01.CourseResourceAssignments", "ResourceFK", "Module01.CourseResources");
            DropForeignKey("Module01.CourseResources", "StatusFK", "Module01.CourseStatus");
            DropForeignKey("Module01.CourseResources", "TypeFK", "Module01.CourseResourceTypes");
            DropForeignKey("Module01.CourseResourceAssignments", "CourseFK", "Module01.Courses");
            DropForeignKey("Module01.Courses", "StatusFK", "Module01.CourseStatus");
            DropIndex("Module01.Courses", "IX_Course_TenantFK");
            DropIndex("Module01.Courses", "IX_Course_RecordState");
            DropIndex("Module01.Courses", "IX_Course_LastModifiedOnUtc");
            DropIndex("Module01.Courses", "IX_Course_LastModifiedByPrincipalId");
            DropIndex("Module01.Courses", new[] { "StatusFK" });
            DropIndex("Module01.Courses", new[] { "DepartmentFK" });
            DropIndex("Module01.CourseDepartments", "IX_CourseDepartment_TenantFK");
            DropIndex("Module01.CourseDepartments", "IX_CourseDepartment_RecordState");
            DropIndex("Module01.CourseDepartments", "IX_CourseDepartment_LastModifiedOnUtc");
            DropIndex("Module01.CourseDepartments", "IX_CourseDepartment_LastModifiedByPrincipalId");
            DropIndex("Module01.CourseDepartments", new[] { "StatusFK" });
            DropIndex("Module01.CourseStatus", "IX_CourseStatus_TenantFK");
            DropIndex("Module01.CourseStatus", "IX_CourseStatus_RecordState");
            DropIndex("Module01.CourseStatus", "IX_CourseStatus_LastModifiedOnUtc");
            DropIndex("Module01.CourseStatus", "IX_CourseStatus_LastModifiedByPrincipalId");
            DropIndex("Module01.CourseEnrollments", "IX_CourseEnrollment_RecordState");
            DropIndex("Module01.CourseEnrollments", "IX_CourseEnrollment_LastModifiedOnUtc");
            DropIndex("Module01.CourseEnrollments", "IX_CourseEnrollment_LastModifiedByPrincipalId");
            DropIndex("Module01.CourseEnrollments", "IX_CourseEnrollment_TenantFK");
            DropIndex("Module01.CourseEnrollments", new[] { "StatusFK" });
            DropIndex("Module01.CourseEnrollments", new[] { "CourseFK" });
            DropIndex("Module01.CourseEnrollments", new[] { "EnrolleeFK" });
            DropIndex("Module01.CourseEnrollments", new[] { "GradeFK" });
            DropIndex("Module01.CourseEnrollees", "IX_CourseEnrollee_TenantFK");
            DropIndex("Module01.CourseEnrollees", "IX_CourseEnrollee_RecordState");
            DropIndex("Module01.CourseEnrollees", "IX_CourseEnrollee_LastModifiedOnUtc");
            DropIndex("Module01.CourseEnrollees", "IX_CourseEnrollee_LastModifiedByPrincipalId");
            DropIndex("Module01.CourseGrades", "IX_CourseGrade_TenantFK");
            DropIndex("Module01.CourseGrades", "IX_CourseGrade_RecordState");
            DropIndex("Module01.CourseGrades", "IX_CourseGrade_LastModifiedOnUtc");
            DropIndex("Module01.CourseGrades", "IX_CourseGrade_LastModifiedByPrincipalId");
            DropIndex("Module01.CourseInstructorAssignments", "IX_CourseInstructorAssignment_RecordState");
            DropIndex("Module01.CourseInstructorAssignments", "IX_CourseInstructorAssignment_LastModifiedOnUtc");
            DropIndex("Module01.CourseInstructorAssignments", "IX_CourseInstructorAssignment_LastModifiedByPrincipalId");
            DropIndex("Module01.CourseInstructorAssignments", "IX_CourseInstructorAssignment_TenantFK");
            DropIndex("Module01.CourseInstructorAssignments", new[] { "CourseFK" });
            DropIndex("Module01.CourseInstructorAssignments", new[] { "CourseInstructorFK" });
            DropIndex("Module01.CourseInstructorAssignments", new[] { "RoleFK" });
            DropIndex("Module01.CourseInstructors", "IX_CourseInstructor_TenantFK");
            DropIndex("Module01.CourseInstructors", "IX_CourseInstructor_RecordState");
            DropIndex("Module01.CourseInstructors", "IX_CourseInstructor_LastModifiedOnUtc");
            DropIndex("Module01.CourseInstructors", "IX_CourseInstructor_LastModifiedByPrincipalId");
            DropIndex("Module01.CourseInstructors", new[] { "StatusFK" });
            DropIndex("Module01.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_RecordState");
            DropIndex("Module01.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_LastModifiedOnUtc");
            DropIndex("Module01.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_LastModifiedByPrincipalId");
            DropIndex("Module01.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_TenantFK");
            DropIndex("Module01.CourseInstructorOfficeAssignments", new[] { "CourseInstructorFK" });
            DropIndex("Module01.CourseInstructorOfficeAssignments", new[] { "CourseInstructorOfficeFK" });
            DropIndex("Module01.CourseInstructorOffices", "IX_CourseInstructorOffice_TenantFK");
            DropIndex("Module01.CourseInstructorOffices", "IX_CourseInstructorOffice_RecordState");
            DropIndex("Module01.CourseInstructorOffices", "IX_CourseInstructorOffice_LastModifiedOnUtc");
            DropIndex("Module01.CourseInstructorOffices", "IX_CourseInstructorOffice_LastModifiedByPrincipalId");
            DropIndex("Module01.CourseRoles", "IX_CourseRole_TenantFK");
            DropIndex("Module01.CourseRoles", "IX_CourseRole_RecordState");
            DropIndex("Module01.CourseRoles", "IX_CourseRole_LastModifiedOnUtc");
            DropIndex("Module01.CourseRoles", "IX_CourseRole_LastModifiedByPrincipalId");
            DropIndex("Module01.CourseOccurances", "IX_CourseOccurance_TenantFK");
            DropIndex("Module01.CourseOccurances", "IX_CourseOccurance_RecordState");
            DropIndex("Module01.CourseOccurances", "IX_CourseOccurance_LastModifiedOnUtc");
            DropIndex("Module01.CourseOccurances", "IX_CourseOccurance_LastModifiedByPrincipalId");
            DropIndex("Module01.CourseOccurances", new[] { "OwnerFK" });
            DropIndex("Module01.CourseResourceAssignments", "IX_CourseResourceAssignment_RecordState");
            DropIndex("Module01.CourseResourceAssignments", "IX_CourseResourceAssignment_LastModifiedOnUtc");
            DropIndex("Module01.CourseResourceAssignments", "IX_CourseResourceAssignment_LastModifiedByPrincipalId");
            DropIndex("Module01.CourseResourceAssignments", "IX_CourseResourceAssignment_TenantFK");
            DropIndex("Module01.CourseResourceAssignments", new[] { "CourseFK" });
            DropIndex("Module01.CourseResourceAssignments", new[] { "ResourceFK" });
            DropIndex("Module01.CourseResources", "IX_CourseResource_TenantFK");
            DropIndex("Module01.CourseResources", "IX_CourseResource_RecordState");
            DropIndex("Module01.CourseResources", "IX_CourseResource_LastModifiedOnUtc");
            DropIndex("Module01.CourseResources", "IX_CourseResource_LastModifiedByPrincipalId");
            DropIndex("Module01.CourseResources", new[] { "StatusFK" });
            DropIndex("Module01.CourseResources", new[] { "TypeFK" });
            DropIndex("Module01.CourseResourceTypes", "IX_CourseResourceType_TenantFK");
            DropIndex("Module01.CourseResourceTypes", "IX_CourseResourceType_RecordState");
            DropIndex("Module01.CourseResourceTypes", "IX_CourseResourceType_LastModifiedOnUtc");
            DropIndex("Module01.CourseResourceTypes", "IX_CourseResourceType_LastModifiedByPrincipalId");
            DropTable("Module01.Courses");
            DropTable("Module01.CourseDepartments");
            DropTable("Module01.CourseStatus");
            DropTable("Module01.CourseEnrollments");
            DropTable("Module01.CourseEnrollees");
            DropTable("Module01.CourseGrades");
            DropTable("Module01.CourseInstructorAssignments");
            DropTable("Module01.CourseInstructors");
            DropTable("Module01.CourseInstructorOfficeAssignments");
            DropTable("Module01.CourseInstructorOffices");
            DropTable("Module01.CourseRoles");
            DropTable("Module01.CourseOccurances");
            DropTable("Module01.CourseResourceAssignments");
            DropTable("Module01.CourseResources");
            DropTable("Module01.CourseResourceTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "Module01.CourseResourceTypes",
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
                "Module01.CourseResources",
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
                "Module01.CourseResourceAssignments",
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
                "Module01.CourseOccurances",
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
                "Module01.CourseRoles",
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
                "Module01.CourseInstructorOffices",
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
                "Module01.CourseInstructorOfficeAssignments",
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
                "Module01.CourseInstructors",
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
                "Module01.CourseInstructorAssignments",
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
                "Module01.CourseGrades",
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
                "Module01.CourseEnrollees",
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
                "Module01.CourseEnrollments",
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
                "Module01.CourseStatus",
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
                "Module01.CourseDepartments",
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
                "Module01.Courses",
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
            
            CreateIndex("Module01.CourseResourceTypes", "LastModifiedByPrincipalId", name: "IX_CourseResourceType_LastModifiedByPrincipalId");
            CreateIndex("Module01.CourseResourceTypes", "LastModifiedOnUtc", name: "IX_CourseResourceType_LastModifiedOnUtc");
            CreateIndex("Module01.CourseResourceTypes", "RecordState", name: "IX_CourseResourceType_RecordState");
            CreateIndex("Module01.CourseResourceTypes", "TenantFK", name: "IX_CourseResourceType_TenantFK");
            CreateIndex("Module01.CourseResources", "TypeFK");
            CreateIndex("Module01.CourseResources", "StatusFK");
            CreateIndex("Module01.CourseResources", "LastModifiedByPrincipalId", name: "IX_CourseResource_LastModifiedByPrincipalId");
            CreateIndex("Module01.CourseResources", "LastModifiedOnUtc", name: "IX_CourseResource_LastModifiedOnUtc");
            CreateIndex("Module01.CourseResources", "RecordState", name: "IX_CourseResource_RecordState");
            CreateIndex("Module01.CourseResources", "TenantFK", name: "IX_CourseResource_TenantFK");
            CreateIndex("Module01.CourseResourceAssignments", "ResourceFK");
            CreateIndex("Module01.CourseResourceAssignments", "CourseFK");
            CreateIndex("Module01.CourseResourceAssignments", "TenantFK", name: "IX_CourseResourceAssignment_TenantFK");
            CreateIndex("Module01.CourseResourceAssignments", "LastModifiedByPrincipalId", name: "IX_CourseResourceAssignment_LastModifiedByPrincipalId");
            CreateIndex("Module01.CourseResourceAssignments", "LastModifiedOnUtc", name: "IX_CourseResourceAssignment_LastModifiedOnUtc");
            CreateIndex("Module01.CourseResourceAssignments", "RecordState", name: "IX_CourseResourceAssignment_RecordState");
            CreateIndex("Module01.CourseOccurances", "OwnerFK");
            CreateIndex("Module01.CourseOccurances", "LastModifiedByPrincipalId", name: "IX_CourseOccurance_LastModifiedByPrincipalId");
            CreateIndex("Module01.CourseOccurances", "LastModifiedOnUtc", name: "IX_CourseOccurance_LastModifiedOnUtc");
            CreateIndex("Module01.CourseOccurances", "RecordState", name: "IX_CourseOccurance_RecordState");
            CreateIndex("Module01.CourseOccurances", "TenantFK", name: "IX_CourseOccurance_TenantFK");
            CreateIndex("Module01.CourseRoles", "LastModifiedByPrincipalId", name: "IX_CourseRole_LastModifiedByPrincipalId");
            CreateIndex("Module01.CourseRoles", "LastModifiedOnUtc", name: "IX_CourseRole_LastModifiedOnUtc");
            CreateIndex("Module01.CourseRoles", "RecordState", name: "IX_CourseRole_RecordState");
            CreateIndex("Module01.CourseRoles", "TenantFK", name: "IX_CourseRole_TenantFK");
            CreateIndex("Module01.CourseInstructorOffices", "LastModifiedByPrincipalId", name: "IX_CourseInstructorOffice_LastModifiedByPrincipalId");
            CreateIndex("Module01.CourseInstructorOffices", "LastModifiedOnUtc", name: "IX_CourseInstructorOffice_LastModifiedOnUtc");
            CreateIndex("Module01.CourseInstructorOffices", "RecordState", name: "IX_CourseInstructorOffice_RecordState");
            CreateIndex("Module01.CourseInstructorOffices", "TenantFK", name: "IX_CourseInstructorOffice_TenantFK");
            CreateIndex("Module01.CourseInstructorOfficeAssignments", "CourseInstructorOfficeFK");
            CreateIndex("Module01.CourseInstructorOfficeAssignments", "CourseInstructorFK");
            CreateIndex("Module01.CourseInstructorOfficeAssignments", "TenantFK", name: "IX_CourseInstructorOfficeAssignment_TenantFK");
            CreateIndex("Module01.CourseInstructorOfficeAssignments", "LastModifiedByPrincipalId", name: "IX_CourseInstructorOfficeAssignment_LastModifiedByPrincipalId");
            CreateIndex("Module01.CourseInstructorOfficeAssignments", "LastModifiedOnUtc", name: "IX_CourseInstructorOfficeAssignment_LastModifiedOnUtc");
            CreateIndex("Module01.CourseInstructorOfficeAssignments", "RecordState", name: "IX_CourseInstructorOfficeAssignment_RecordState");
            CreateIndex("Module01.CourseInstructors", "StatusFK");
            CreateIndex("Module01.CourseInstructors", "LastModifiedByPrincipalId", name: "IX_CourseInstructor_LastModifiedByPrincipalId");
            CreateIndex("Module01.CourseInstructors", "LastModifiedOnUtc", name: "IX_CourseInstructor_LastModifiedOnUtc");
            CreateIndex("Module01.CourseInstructors", "RecordState", name: "IX_CourseInstructor_RecordState");
            CreateIndex("Module01.CourseInstructors", "TenantFK", name: "IX_CourseInstructor_TenantFK");
            CreateIndex("Module01.CourseInstructorAssignments", "RoleFK");
            CreateIndex("Module01.CourseInstructorAssignments", "CourseInstructorFK");
            CreateIndex("Module01.CourseInstructorAssignments", "CourseFK");
            CreateIndex("Module01.CourseInstructorAssignments", "TenantFK", name: "IX_CourseInstructorAssignment_TenantFK");
            CreateIndex("Module01.CourseInstructorAssignments", "LastModifiedByPrincipalId", name: "IX_CourseInstructorAssignment_LastModifiedByPrincipalId");
            CreateIndex("Module01.CourseInstructorAssignments", "LastModifiedOnUtc", name: "IX_CourseInstructorAssignment_LastModifiedOnUtc");
            CreateIndex("Module01.CourseInstructorAssignments", "RecordState", name: "IX_CourseInstructorAssignment_RecordState");
            CreateIndex("Module01.CourseGrades", "LastModifiedByPrincipalId", name: "IX_CourseGrade_LastModifiedByPrincipalId");
            CreateIndex("Module01.CourseGrades", "LastModifiedOnUtc", name: "IX_CourseGrade_LastModifiedOnUtc");
            CreateIndex("Module01.CourseGrades", "RecordState", name: "IX_CourseGrade_RecordState");
            CreateIndex("Module01.CourseGrades", "TenantFK", name: "IX_CourseGrade_TenantFK");
            CreateIndex("Module01.CourseEnrollees", "LastModifiedByPrincipalId", name: "IX_CourseEnrollee_LastModifiedByPrincipalId");
            CreateIndex("Module01.CourseEnrollees", "LastModifiedOnUtc", name: "IX_CourseEnrollee_LastModifiedOnUtc");
            CreateIndex("Module01.CourseEnrollees", "RecordState", name: "IX_CourseEnrollee_RecordState");
            CreateIndex("Module01.CourseEnrollees", "TenantFK", name: "IX_CourseEnrollee_TenantFK");
            CreateIndex("Module01.CourseEnrollments", "GradeFK");
            CreateIndex("Module01.CourseEnrollments", "EnrolleeFK");
            CreateIndex("Module01.CourseEnrollments", "CourseFK");
            CreateIndex("Module01.CourseEnrollments", "StatusFK");
            CreateIndex("Module01.CourseEnrollments", "TenantFK", name: "IX_CourseEnrollment_TenantFK");
            CreateIndex("Module01.CourseEnrollments", "LastModifiedByPrincipalId", name: "IX_CourseEnrollment_LastModifiedByPrincipalId");
            CreateIndex("Module01.CourseEnrollments", "LastModifiedOnUtc", name: "IX_CourseEnrollment_LastModifiedOnUtc");
            CreateIndex("Module01.CourseEnrollments", "RecordState", name: "IX_CourseEnrollment_RecordState");
            CreateIndex("Module01.CourseStatus", "LastModifiedByPrincipalId", name: "IX_CourseStatus_LastModifiedByPrincipalId");
            CreateIndex("Module01.CourseStatus", "LastModifiedOnUtc", name: "IX_CourseStatus_LastModifiedOnUtc");
            CreateIndex("Module01.CourseStatus", "RecordState", name: "IX_CourseStatus_RecordState");
            CreateIndex("Module01.CourseStatus", "TenantFK", name: "IX_CourseStatus_TenantFK");
            CreateIndex("Module01.CourseDepartments", "StatusFK");
            CreateIndex("Module01.CourseDepartments", "LastModifiedByPrincipalId", name: "IX_CourseDepartment_LastModifiedByPrincipalId");
            CreateIndex("Module01.CourseDepartments", "LastModifiedOnUtc", name: "IX_CourseDepartment_LastModifiedOnUtc");
            CreateIndex("Module01.CourseDepartments", "RecordState", name: "IX_CourseDepartment_RecordState");
            CreateIndex("Module01.CourseDepartments", "TenantFK", name: "IX_CourseDepartment_TenantFK");
            CreateIndex("Module01.Courses", "DepartmentFK");
            CreateIndex("Module01.Courses", "StatusFK");
            CreateIndex("Module01.Courses", "LastModifiedByPrincipalId", name: "IX_Course_LastModifiedByPrincipalId");
            CreateIndex("Module01.Courses", "LastModifiedOnUtc", name: "IX_Course_LastModifiedOnUtc");
            CreateIndex("Module01.Courses", "RecordState", name: "IX_Course_RecordState");
            CreateIndex("Module01.Courses", "TenantFK", name: "IX_Course_TenantFK");
            AddForeignKey("Module01.Courses", "StatusFK", "Module01.CourseStatus", "Id");
            AddForeignKey("Module01.CourseResourceAssignments", "CourseFK", "Module01.Courses", "Id");
            AddForeignKey("Module01.CourseResources", "TypeFK", "Module01.CourseResourceTypes", "Id", cascadeDelete: true);
            AddForeignKey("Module01.CourseResources", "StatusFK", "Module01.CourseStatus", "Id");
            AddForeignKey("Module01.CourseResourceAssignments", "ResourceFK", "Module01.CourseResources", "Id");
            AddForeignKey("Module01.CourseOccurances", "OwnerFK", "Module01.Courses", "Id", cascadeDelete: true);
            AddForeignKey("Module01.CourseInstructorAssignments", "CourseFK", "Module01.Courses", "Id", cascadeDelete: true);
            AddForeignKey("Module01.CourseInstructorAssignments", "RoleFK", "Module01.CourseRoles", "Id", cascadeDelete: true);
            AddForeignKey("Module01.CourseInstructors", "StatusFK", "Module01.CourseStatus", "Id");
            AddForeignKey("Module01.CourseInstructorOfficeAssignments", "CourseInstructorFK", "Module01.CourseInstructors", "Id");
            AddForeignKey("Module01.CourseInstructorOfficeAssignments", "CourseInstructorOfficeFK", "Module01.CourseInstructorOffices", "Id");
            AddForeignKey("Module01.CourseInstructorAssignments", "CourseInstructorFK", "Module01.CourseInstructors", "Id");
            AddForeignKey("Module01.CourseEnrollments", "CourseFK", "Module01.Courses", "Id");
            AddForeignKey("Module01.CourseEnrollments", "StatusFK", "Module01.CourseStatus", "Id");
            AddForeignKey("Module01.CourseEnrollments", "GradeFK", "Module01.CourseGrades", "Id", cascadeDelete: true);
            AddForeignKey("Module01.CourseEnrollments", "EnrolleeFK", "Module01.CourseEnrollees", "Id");
            AddForeignKey("Module01.Courses", "DepartmentFK", "Module01.CourseDepartments", "Id", cascadeDelete: true);
            AddForeignKey("Module01.CourseDepartments", "StatusFK", "Module01.CourseStatus", "Id");
        }
    }
}
