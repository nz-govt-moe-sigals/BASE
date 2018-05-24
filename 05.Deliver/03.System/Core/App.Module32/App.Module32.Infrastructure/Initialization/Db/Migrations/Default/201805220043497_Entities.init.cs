namespace App.Module32.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Entitiesinit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Module32.Examples",
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
                        Owner = c.String(nullable: false),
                        PublicText = c.String(nullable: false),
                        SensitiveText = c.String(),
                        AppPrivateText = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_Example_TenantFK")
                .Index(t => t.RecordState, name: "IX_Example_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_Example_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_Example_LastModifiedByPrincipalId");
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module32.CourseDepartments", t => t.DepartmentFK, cascadeDelete: true)
                .ForeignKey("Module32.CourseStatus", t => t.StatusFK)
                .Index(t => t.TenantFK, name: "IX_Course_TenantFK")
                .Index(t => t.RecordState, name: "IX_Course_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_Course_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_Course_LastModifiedByPrincipalId")
                .Index(t => t.StatusFK)
                .Index(t => t.DepartmentFK);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module32.CourseStatus", t => t.StatusFK)
                .Index(t => t.TenantFK, name: "IX_CourseDepartment_TenantFK")
                .Index(t => t.RecordState, name: "IX_CourseDepartment_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseDepartment_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseDepartment_LastModifiedByPrincipalId")
                .Index(t => t.StatusFK);
            
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
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_CourseStatus_TenantFK")
                .Index(t => t.RecordState, name: "IX_CourseStatus_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseStatus_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseStatus_LastModifiedByPrincipalId");
            
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
                .PrimaryKey(t => new { t.CourseFK, t.EnrolleeFK })
                .ForeignKey("Module32.CourseEnrollees", t => t.EnrolleeFK)
                .ForeignKey("Module32.CourseGrades", t => t.GradeFK, cascadeDelete: true)
                .ForeignKey("Module32.CourseStatus", t => t.StatusFK)
                .ForeignKey("Module32.Courses", t => t.CourseFK)
                .Index(t => t.RecordState, name: "IX_CourseEnrollment_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseEnrollment_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseEnrollment_LastModifiedByPrincipalId")
                .Index(t => t.TenantFK, name: "IX_CourseEnrollment_TenantFK")
                .Index(t => t.StatusFK)
                .Index(t => t.CourseFK)
                .Index(t => t.EnrolleeFK)
                .Index(t => t.GradeFK);
            
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
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_CourseEnrollee_TenantFK")
                .Index(t => t.RecordState, name: "IX_CourseEnrollee_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseEnrollee_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseEnrollee_LastModifiedByPrincipalId");
            
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
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_CourseGrade_TenantFK")
                .Index(t => t.RecordState, name: "IX_CourseGrade_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseGrade_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseGrade_LastModifiedByPrincipalId");
            
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
                .PrimaryKey(t => new { t.CourseFK, t.CourseInstructorFK })
                .ForeignKey("Module32.CourseInstructors", t => t.CourseInstructorFK)
                .ForeignKey("Module32.CourseRoles", t => t.RoleFK, cascadeDelete: true)
                .ForeignKey("Module32.Courses", t => t.CourseFK, cascadeDelete: true)
                .Index(t => t.RecordState, name: "IX_CourseInstructorAssignment_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseInstructorAssignment_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseInstructorAssignment_LastModifiedByPrincipalId")
                .Index(t => t.TenantFK, name: "IX_CourseInstructorAssignment_TenantFK")
                .Index(t => t.CourseFK)
                .Index(t => t.CourseInstructorFK)
                .Index(t => t.RoleFK);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module32.CourseStatus", t => t.StatusFK)
                .Index(t => t.TenantFK, name: "IX_CourseInstructor_TenantFK")
                .Index(t => t.RecordState, name: "IX_CourseInstructor_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseInstructor_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseInstructor_LastModifiedByPrincipalId")
                .Index(t => t.StatusFK);
            
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
                .PrimaryKey(t => new { t.CourseInstructorFK, t.CourseInstructorOfficeFK })
                .ForeignKey("Module32.CourseInstructorOffices", t => t.CourseInstructorOfficeFK)
                .ForeignKey("Module32.CourseInstructors", t => t.CourseInstructorFK)
                .Index(t => t.RecordState, name: "IX_CourseInstructorOfficeAssignment_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseInstructorOfficeAssignment_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseInstructorOfficeAssignment_LastModifiedByPrincipalId")
                .Index(t => t.TenantFK, name: "IX_CourseInstructorOfficeAssignment_TenantFK")
                .Index(t => t.CourseInstructorFK)
                .Index(t => t.CourseInstructorOfficeFK);
            
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
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_CourseInstructorOffice_TenantFK")
                .Index(t => t.RecordState, name: "IX_CourseInstructorOffice_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseInstructorOffice_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseInstructorOffice_LastModifiedByPrincipalId");
            
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
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_CourseRole_TenantFK")
                .Index(t => t.RecordState, name: "IX_CourseRole_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseRole_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseRole_LastModifiedByPrincipalId");
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module32.Courses", t => t.OwnerFK, cascadeDelete: true)
                .Index(t => t.TenantFK, name: "IX_CourseOccurance_TenantFK")
                .Index(t => t.RecordState, name: "IX_CourseOccurance_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseOccurance_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseOccurance_LastModifiedByPrincipalId")
                .Index(t => t.OwnerFK);
            
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
                .PrimaryKey(t => new { t.CourseFK, t.ResourceFK })
                .ForeignKey("Module32.CourseResources", t => t.ResourceFK)
                .ForeignKey("Module32.Courses", t => t.CourseFK)
                .Index(t => t.RecordState, name: "IX_CourseResourceAssignment_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseResourceAssignment_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseResourceAssignment_LastModifiedByPrincipalId")
                .Index(t => t.TenantFK, name: "IX_CourseResourceAssignment_TenantFK")
                .Index(t => t.CourseFK)
                .Index(t => t.ResourceFK);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module32.CourseStatus", t => t.StatusFK)
                .ForeignKey("Module32.CourseResourceTypes", t => t.TypeFK, cascadeDelete: true)
                .Index(t => t.TenantFK, name: "IX_CourseResource_TenantFK")
                .Index(t => t.RecordState, name: "IX_CourseResource_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseResource_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseResource_LastModifiedByPrincipalId")
                .Index(t => t.StatusFK)
                .Index(t => t.TypeFK);
            
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
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_CourseResourceType_TenantFK")
                .Index(t => t.RecordState, name: "IX_CourseResourceType_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseResourceType_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseResourceType_LastModifiedByPrincipalId");
            
        }
        
        public override void Down()
        {
            DropForeignKey("Module32.Courses", "StatusFK", "Module32.CourseStatus");
            DropForeignKey("Module32.CourseResourceAssignments", "CourseFK", "Module32.Courses");
            DropForeignKey("Module32.CourseResources", "TypeFK", "Module32.CourseResourceTypes");
            DropForeignKey("Module32.CourseResources", "StatusFK", "Module32.CourseStatus");
            DropForeignKey("Module32.CourseResourceAssignments", "ResourceFK", "Module32.CourseResources");
            DropForeignKey("Module32.CourseOccurances", "OwnerFK", "Module32.Courses");
            DropForeignKey("Module32.CourseInstructorAssignments", "CourseFK", "Module32.Courses");
            DropForeignKey("Module32.CourseInstructorAssignments", "RoleFK", "Module32.CourseRoles");
            DropForeignKey("Module32.CourseInstructors", "StatusFK", "Module32.CourseStatus");
            DropForeignKey("Module32.CourseInstructorOfficeAssignments", "CourseInstructorFK", "Module32.CourseInstructors");
            DropForeignKey("Module32.CourseInstructorOfficeAssignments", "CourseInstructorOfficeFK", "Module32.CourseInstructorOffices");
            DropForeignKey("Module32.CourseInstructorAssignments", "CourseInstructorFK", "Module32.CourseInstructors");
            DropForeignKey("Module32.CourseEnrollments", "CourseFK", "Module32.Courses");
            DropForeignKey("Module32.CourseEnrollments", "StatusFK", "Module32.CourseStatus");
            DropForeignKey("Module32.CourseEnrollments", "GradeFK", "Module32.CourseGrades");
            DropForeignKey("Module32.CourseEnrollments", "EnrolleeFK", "Module32.CourseEnrollees");
            DropForeignKey("Module32.Courses", "DepartmentFK", "Module32.CourseDepartments");
            DropForeignKey("Module32.CourseDepartments", "StatusFK", "Module32.CourseStatus");
            DropIndex("Module32.CourseResourceTypes", "IX_CourseResourceType_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseResourceTypes", "IX_CourseResourceType_LastModifiedOnUtc");
            DropIndex("Module32.CourseResourceTypes", "IX_CourseResourceType_RecordState");
            DropIndex("Module32.CourseResourceTypes", "IX_CourseResourceType_TenantFK");
            DropIndex("Module32.CourseResources", new[] { "TypeFK" });
            DropIndex("Module32.CourseResources", new[] { "StatusFK" });
            DropIndex("Module32.CourseResources", "IX_CourseResource_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseResources", "IX_CourseResource_LastModifiedOnUtc");
            DropIndex("Module32.CourseResources", "IX_CourseResource_RecordState");
            DropIndex("Module32.CourseResources", "IX_CourseResource_TenantFK");
            DropIndex("Module32.CourseResourceAssignments", new[] { "ResourceFK" });
            DropIndex("Module32.CourseResourceAssignments", new[] { "CourseFK" });
            DropIndex("Module32.CourseResourceAssignments", "IX_CourseResourceAssignment_TenantFK");
            DropIndex("Module32.CourseResourceAssignments", "IX_CourseResourceAssignment_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseResourceAssignments", "IX_CourseResourceAssignment_LastModifiedOnUtc");
            DropIndex("Module32.CourseResourceAssignments", "IX_CourseResourceAssignment_RecordState");
            DropIndex("Module32.CourseOccurances", new[] { "OwnerFK" });
            DropIndex("Module32.CourseOccurances", "IX_CourseOccurance_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseOccurances", "IX_CourseOccurance_LastModifiedOnUtc");
            DropIndex("Module32.CourseOccurances", "IX_CourseOccurance_RecordState");
            DropIndex("Module32.CourseOccurances", "IX_CourseOccurance_TenantFK");
            DropIndex("Module32.CourseRoles", "IX_CourseRole_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseRoles", "IX_CourseRole_LastModifiedOnUtc");
            DropIndex("Module32.CourseRoles", "IX_CourseRole_RecordState");
            DropIndex("Module32.CourseRoles", "IX_CourseRole_TenantFK");
            DropIndex("Module32.CourseInstructorOffices", "IX_CourseInstructorOffice_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseInstructorOffices", "IX_CourseInstructorOffice_LastModifiedOnUtc");
            DropIndex("Module32.CourseInstructorOffices", "IX_CourseInstructorOffice_RecordState");
            DropIndex("Module32.CourseInstructorOffices", "IX_CourseInstructorOffice_TenantFK");
            DropIndex("Module32.CourseInstructorOfficeAssignments", new[] { "CourseInstructorOfficeFK" });
            DropIndex("Module32.CourseInstructorOfficeAssignments", new[] { "CourseInstructorFK" });
            DropIndex("Module32.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_TenantFK");
            DropIndex("Module32.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_LastModifiedOnUtc");
            DropIndex("Module32.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_RecordState");
            DropIndex("Module32.CourseInstructors", new[] { "StatusFK" });
            DropIndex("Module32.CourseInstructors", "IX_CourseInstructor_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseInstructors", "IX_CourseInstructor_LastModifiedOnUtc");
            DropIndex("Module32.CourseInstructors", "IX_CourseInstructor_RecordState");
            DropIndex("Module32.CourseInstructors", "IX_CourseInstructor_TenantFK");
            DropIndex("Module32.CourseInstructorAssignments", new[] { "RoleFK" });
            DropIndex("Module32.CourseInstructorAssignments", new[] { "CourseInstructorFK" });
            DropIndex("Module32.CourseInstructorAssignments", new[] { "CourseFK" });
            DropIndex("Module32.CourseInstructorAssignments", "IX_CourseInstructorAssignment_TenantFK");
            DropIndex("Module32.CourseInstructorAssignments", "IX_CourseInstructorAssignment_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseInstructorAssignments", "IX_CourseInstructorAssignment_LastModifiedOnUtc");
            DropIndex("Module32.CourseInstructorAssignments", "IX_CourseInstructorAssignment_RecordState");
            DropIndex("Module32.CourseGrades", "IX_CourseGrade_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseGrades", "IX_CourseGrade_LastModifiedOnUtc");
            DropIndex("Module32.CourseGrades", "IX_CourseGrade_RecordState");
            DropIndex("Module32.CourseGrades", "IX_CourseGrade_TenantFK");
            DropIndex("Module32.CourseEnrollees", "IX_CourseEnrollee_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseEnrollees", "IX_CourseEnrollee_LastModifiedOnUtc");
            DropIndex("Module32.CourseEnrollees", "IX_CourseEnrollee_RecordState");
            DropIndex("Module32.CourseEnrollees", "IX_CourseEnrollee_TenantFK");
            DropIndex("Module32.CourseEnrollments", new[] { "GradeFK" });
            DropIndex("Module32.CourseEnrollments", new[] { "EnrolleeFK" });
            DropIndex("Module32.CourseEnrollments", new[] { "CourseFK" });
            DropIndex("Module32.CourseEnrollments", new[] { "StatusFK" });
            DropIndex("Module32.CourseEnrollments", "IX_CourseEnrollment_TenantFK");
            DropIndex("Module32.CourseEnrollments", "IX_CourseEnrollment_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseEnrollments", "IX_CourseEnrollment_LastModifiedOnUtc");
            DropIndex("Module32.CourseEnrollments", "IX_CourseEnrollment_RecordState");
            DropIndex("Module32.CourseStatus", "IX_CourseStatus_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseStatus", "IX_CourseStatus_LastModifiedOnUtc");
            DropIndex("Module32.CourseStatus", "IX_CourseStatus_RecordState");
            DropIndex("Module32.CourseStatus", "IX_CourseStatus_TenantFK");
            DropIndex("Module32.CourseDepartments", new[] { "StatusFK" });
            DropIndex("Module32.CourseDepartments", "IX_CourseDepartment_LastModifiedByPrincipalId");
            DropIndex("Module32.CourseDepartments", "IX_CourseDepartment_LastModifiedOnUtc");
            DropIndex("Module32.CourseDepartments", "IX_CourseDepartment_RecordState");
            DropIndex("Module32.CourseDepartments", "IX_CourseDepartment_TenantFK");
            DropIndex("Module32.Courses", new[] { "DepartmentFK" });
            DropIndex("Module32.Courses", new[] { "StatusFK" });
            DropIndex("Module32.Courses", "IX_Course_LastModifiedByPrincipalId");
            DropIndex("Module32.Courses", "IX_Course_LastModifiedOnUtc");
            DropIndex("Module32.Courses", "IX_Course_RecordState");
            DropIndex("Module32.Courses", "IX_Course_TenantFK");
            DropIndex("Module32.Examples", "IX_Example_LastModifiedByPrincipalId");
            DropIndex("Module32.Examples", "IX_Example_LastModifiedOnUtc");
            DropIndex("Module32.Examples", "IX_Example_RecordState");
            DropIndex("Module32.Examples", "IX_Example_TenantFK");
            DropTable("Module32.CourseResourceTypes");
            DropTable("Module32.CourseResources");
            DropTable("Module32.CourseResourceAssignments");
            DropTable("Module32.CourseOccurances");
            DropTable("Module32.CourseRoles");
            DropTable("Module32.CourseInstructorOffices");
            DropTable("Module32.CourseInstructorOfficeAssignments");
            DropTable("Module32.CourseInstructors");
            DropTable("Module32.CourseInstructorAssignments");
            DropTable("Module32.CourseGrades");
            DropTable("Module32.CourseEnrollees");
            DropTable("Module32.CourseEnrollments");
            DropTable("Module32.CourseStatus");
            DropTable("Module32.CourseDepartments");
            DropTable("Module32.Courses");
            DropTable("Module32.Examples");
        }
    }
}


