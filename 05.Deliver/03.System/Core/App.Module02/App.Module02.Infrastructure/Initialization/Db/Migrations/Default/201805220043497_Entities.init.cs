namespace App.Module02.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Entitiesinit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Module02.Examples",
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module02.CourseDepartments", t => t.DepartmentFK, cascadeDelete: true)
                .ForeignKey("Module02.CourseStatus", t => t.StatusFK)
                .Index(t => t.TenantFK, name: "IX_Course_TenantFK")
                .Index(t => t.RecordState, name: "IX_Course_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_Course_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_Course_LastModifiedByPrincipalId")
                .Index(t => t.StatusFK)
                .Index(t => t.DepartmentFK);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module02.CourseStatus", t => t.StatusFK)
                .Index(t => t.TenantFK, name: "IX_CourseDepartment_TenantFK")
                .Index(t => t.RecordState, name: "IX_CourseDepartment_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseDepartment_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseDepartment_LastModifiedByPrincipalId")
                .Index(t => t.StatusFK);
            
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
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_CourseStatus_TenantFK")
                .Index(t => t.RecordState, name: "IX_CourseStatus_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseStatus_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseStatus_LastModifiedByPrincipalId");
            
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
                .PrimaryKey(t => new { t.CourseFK, t.EnrolleeFK })
                .ForeignKey("Module02.CourseEnrollees", t => t.EnrolleeFK)
                .ForeignKey("Module02.CourseGrades", t => t.GradeFK, cascadeDelete: true)
                .ForeignKey("Module02.CourseStatus", t => t.StatusFK)
                .ForeignKey("Module02.Courses", t => t.CourseFK)
                .Index(t => t.RecordState, name: "IX_CourseEnrollment_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseEnrollment_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseEnrollment_LastModifiedByPrincipalId")
                .Index(t => t.TenantFK, name: "IX_CourseEnrollment_TenantFK")
                .Index(t => t.StatusFK)
                .Index(t => t.CourseFK)
                .Index(t => t.EnrolleeFK)
                .Index(t => t.GradeFK);
            
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
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_CourseEnrollee_TenantFK")
                .Index(t => t.RecordState, name: "IX_CourseEnrollee_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseEnrollee_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseEnrollee_LastModifiedByPrincipalId");
            
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
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_CourseGrade_TenantFK")
                .Index(t => t.RecordState, name: "IX_CourseGrade_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseGrade_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseGrade_LastModifiedByPrincipalId");
            
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
                .PrimaryKey(t => new { t.CourseFK, t.CourseInstructorFK })
                .ForeignKey("Module02.CourseInstructors", t => t.CourseInstructorFK)
                .ForeignKey("Module02.CourseRoles", t => t.RoleFK, cascadeDelete: true)
                .ForeignKey("Module02.Courses", t => t.CourseFK, cascadeDelete: true)
                .Index(t => t.RecordState, name: "IX_CourseInstructorAssignment_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseInstructorAssignment_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseInstructorAssignment_LastModifiedByPrincipalId")
                .Index(t => t.TenantFK, name: "IX_CourseInstructorAssignment_TenantFK")
                .Index(t => t.CourseFK)
                .Index(t => t.CourseInstructorFK)
                .Index(t => t.RoleFK);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module02.CourseStatus", t => t.StatusFK)
                .Index(t => t.TenantFK, name: "IX_CourseInstructor_TenantFK")
                .Index(t => t.RecordState, name: "IX_CourseInstructor_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseInstructor_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseInstructor_LastModifiedByPrincipalId")
                .Index(t => t.StatusFK);
            
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
                .PrimaryKey(t => new { t.CourseInstructorFK, t.CourseInstructorOfficeFK })
                .ForeignKey("Module02.CourseInstructorOffices", t => t.CourseInstructorOfficeFK)
                .ForeignKey("Module02.CourseInstructors", t => t.CourseInstructorFK)
                .Index(t => t.RecordState, name: "IX_CourseInstructorOfficeAssignment_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseInstructorOfficeAssignment_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseInstructorOfficeAssignment_LastModifiedByPrincipalId")
                .Index(t => t.TenantFK, name: "IX_CourseInstructorOfficeAssignment_TenantFK")
                .Index(t => t.CourseInstructorFK)
                .Index(t => t.CourseInstructorOfficeFK);
            
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
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_CourseInstructorOffice_TenantFK")
                .Index(t => t.RecordState, name: "IX_CourseInstructorOffice_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseInstructorOffice_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseInstructorOffice_LastModifiedByPrincipalId");
            
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
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_CourseRole_TenantFK")
                .Index(t => t.RecordState, name: "IX_CourseRole_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseRole_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseRole_LastModifiedByPrincipalId");
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module02.Courses", t => t.OwnerFK, cascadeDelete: true)
                .Index(t => t.TenantFK, name: "IX_CourseOccurance_TenantFK")
                .Index(t => t.RecordState, name: "IX_CourseOccurance_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseOccurance_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseOccurance_LastModifiedByPrincipalId")
                .Index(t => t.OwnerFK);
            
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
                .PrimaryKey(t => new { t.CourseFK, t.ResourceFK })
                .ForeignKey("Module02.CourseResources", t => t.ResourceFK)
                .ForeignKey("Module02.Courses", t => t.CourseFK)
                .Index(t => t.RecordState, name: "IX_CourseResourceAssignment_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseResourceAssignment_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseResourceAssignment_LastModifiedByPrincipalId")
                .Index(t => t.TenantFK, name: "IX_CourseResourceAssignment_TenantFK")
                .Index(t => t.CourseFK)
                .Index(t => t.ResourceFK);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module02.CourseStatus", t => t.StatusFK)
                .ForeignKey("Module02.CourseResourceTypes", t => t.TypeFK, cascadeDelete: true)
                .Index(t => t.TenantFK, name: "IX_CourseResource_TenantFK")
                .Index(t => t.RecordState, name: "IX_CourseResource_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseResource_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseResource_LastModifiedByPrincipalId")
                .Index(t => t.StatusFK)
                .Index(t => t.TypeFK);
            
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
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantFK, name: "IX_CourseResourceType_TenantFK")
                .Index(t => t.RecordState, name: "IX_CourseResourceType_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseResourceType_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseResourceType_LastModifiedByPrincipalId");
            
        }
        
        public override void Down()
        {
            DropForeignKey("Module02.Courses", "StatusFK", "Module02.CourseStatus");
            DropForeignKey("Module02.CourseResourceAssignments", "CourseFK", "Module02.Courses");
            DropForeignKey("Module02.CourseResources", "TypeFK", "Module02.CourseResourceTypes");
            DropForeignKey("Module02.CourseResources", "StatusFK", "Module02.CourseStatus");
            DropForeignKey("Module02.CourseResourceAssignments", "ResourceFK", "Module02.CourseResources");
            DropForeignKey("Module02.CourseOccurances", "OwnerFK", "Module02.Courses");
            DropForeignKey("Module02.CourseInstructorAssignments", "CourseFK", "Module02.Courses");
            DropForeignKey("Module02.CourseInstructorAssignments", "RoleFK", "Module02.CourseRoles");
            DropForeignKey("Module02.CourseInstructors", "StatusFK", "Module02.CourseStatus");
            DropForeignKey("Module02.CourseInstructorOfficeAssignments", "CourseInstructorFK", "Module02.CourseInstructors");
            DropForeignKey("Module02.CourseInstructorOfficeAssignments", "CourseInstructorOfficeFK", "Module02.CourseInstructorOffices");
            DropForeignKey("Module02.CourseInstructorAssignments", "CourseInstructorFK", "Module02.CourseInstructors");
            DropForeignKey("Module02.CourseEnrollments", "CourseFK", "Module02.Courses");
            DropForeignKey("Module02.CourseEnrollments", "StatusFK", "Module02.CourseStatus");
            DropForeignKey("Module02.CourseEnrollments", "GradeFK", "Module02.CourseGrades");
            DropForeignKey("Module02.CourseEnrollments", "EnrolleeFK", "Module02.CourseEnrollees");
            DropForeignKey("Module02.Courses", "DepartmentFK", "Module02.CourseDepartments");
            DropForeignKey("Module02.CourseDepartments", "StatusFK", "Module02.CourseStatus");
            DropIndex("Module02.CourseResourceTypes", "IX_CourseResourceType_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseResourceTypes", "IX_CourseResourceType_LastModifiedOnUtc");
            DropIndex("Module02.CourseResourceTypes", "IX_CourseResourceType_RecordState");
            DropIndex("Module02.CourseResourceTypes", "IX_CourseResourceType_TenantFK");
            DropIndex("Module02.CourseResources", new[] { "TypeFK" });
            DropIndex("Module02.CourseResources", new[] { "StatusFK" });
            DropIndex("Module02.CourseResources", "IX_CourseResource_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseResources", "IX_CourseResource_LastModifiedOnUtc");
            DropIndex("Module02.CourseResources", "IX_CourseResource_RecordState");
            DropIndex("Module02.CourseResources", "IX_CourseResource_TenantFK");
            DropIndex("Module02.CourseResourceAssignments", new[] { "ResourceFK" });
            DropIndex("Module02.CourseResourceAssignments", new[] { "CourseFK" });
            DropIndex("Module02.CourseResourceAssignments", "IX_CourseResourceAssignment_TenantFK");
            DropIndex("Module02.CourseResourceAssignments", "IX_CourseResourceAssignment_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseResourceAssignments", "IX_CourseResourceAssignment_LastModifiedOnUtc");
            DropIndex("Module02.CourseResourceAssignments", "IX_CourseResourceAssignment_RecordState");
            DropIndex("Module02.CourseOccurances", new[] { "OwnerFK" });
            DropIndex("Module02.CourseOccurances", "IX_CourseOccurance_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseOccurances", "IX_CourseOccurance_LastModifiedOnUtc");
            DropIndex("Module02.CourseOccurances", "IX_CourseOccurance_RecordState");
            DropIndex("Module02.CourseOccurances", "IX_CourseOccurance_TenantFK");
            DropIndex("Module02.CourseRoles", "IX_CourseRole_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseRoles", "IX_CourseRole_LastModifiedOnUtc");
            DropIndex("Module02.CourseRoles", "IX_CourseRole_RecordState");
            DropIndex("Module02.CourseRoles", "IX_CourseRole_TenantFK");
            DropIndex("Module02.CourseInstructorOffices", "IX_CourseInstructorOffice_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseInstructorOffices", "IX_CourseInstructorOffice_LastModifiedOnUtc");
            DropIndex("Module02.CourseInstructorOffices", "IX_CourseInstructorOffice_RecordState");
            DropIndex("Module02.CourseInstructorOffices", "IX_CourseInstructorOffice_TenantFK");
            DropIndex("Module02.CourseInstructorOfficeAssignments", new[] { "CourseInstructorOfficeFK" });
            DropIndex("Module02.CourseInstructorOfficeAssignments", new[] { "CourseInstructorFK" });
            DropIndex("Module02.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_TenantFK");
            DropIndex("Module02.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_LastModifiedOnUtc");
            DropIndex("Module02.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_RecordState");
            DropIndex("Module02.CourseInstructors", new[] { "StatusFK" });
            DropIndex("Module02.CourseInstructors", "IX_CourseInstructor_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseInstructors", "IX_CourseInstructor_LastModifiedOnUtc");
            DropIndex("Module02.CourseInstructors", "IX_CourseInstructor_RecordState");
            DropIndex("Module02.CourseInstructors", "IX_CourseInstructor_TenantFK");
            DropIndex("Module02.CourseInstructorAssignments", new[] { "RoleFK" });
            DropIndex("Module02.CourseInstructorAssignments", new[] { "CourseInstructorFK" });
            DropIndex("Module02.CourseInstructorAssignments", new[] { "CourseFK" });
            DropIndex("Module02.CourseInstructorAssignments", "IX_CourseInstructorAssignment_TenantFK");
            DropIndex("Module02.CourseInstructorAssignments", "IX_CourseInstructorAssignment_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseInstructorAssignments", "IX_CourseInstructorAssignment_LastModifiedOnUtc");
            DropIndex("Module02.CourseInstructorAssignments", "IX_CourseInstructorAssignment_RecordState");
            DropIndex("Module02.CourseGrades", "IX_CourseGrade_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseGrades", "IX_CourseGrade_LastModifiedOnUtc");
            DropIndex("Module02.CourseGrades", "IX_CourseGrade_RecordState");
            DropIndex("Module02.CourseGrades", "IX_CourseGrade_TenantFK");
            DropIndex("Module02.CourseEnrollees", "IX_CourseEnrollee_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseEnrollees", "IX_CourseEnrollee_LastModifiedOnUtc");
            DropIndex("Module02.CourseEnrollees", "IX_CourseEnrollee_RecordState");
            DropIndex("Module02.CourseEnrollees", "IX_CourseEnrollee_TenantFK");
            DropIndex("Module02.CourseEnrollments", new[] { "GradeFK" });
            DropIndex("Module02.CourseEnrollments", new[] { "EnrolleeFK" });
            DropIndex("Module02.CourseEnrollments", new[] { "CourseFK" });
            DropIndex("Module02.CourseEnrollments", new[] { "StatusFK" });
            DropIndex("Module02.CourseEnrollments", "IX_CourseEnrollment_TenantFK");
            DropIndex("Module02.CourseEnrollments", "IX_CourseEnrollment_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseEnrollments", "IX_CourseEnrollment_LastModifiedOnUtc");
            DropIndex("Module02.CourseEnrollments", "IX_CourseEnrollment_RecordState");
            DropIndex("Module02.CourseStatus", "IX_CourseStatus_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseStatus", "IX_CourseStatus_LastModifiedOnUtc");
            DropIndex("Module02.CourseStatus", "IX_CourseStatus_RecordState");
            DropIndex("Module02.CourseStatus", "IX_CourseStatus_TenantFK");
            DropIndex("Module02.CourseDepartments", new[] { "StatusFK" });
            DropIndex("Module02.CourseDepartments", "IX_CourseDepartment_LastModifiedByPrincipalId");
            DropIndex("Module02.CourseDepartments", "IX_CourseDepartment_LastModifiedOnUtc");
            DropIndex("Module02.CourseDepartments", "IX_CourseDepartment_RecordState");
            DropIndex("Module02.CourseDepartments", "IX_CourseDepartment_TenantFK");
            DropIndex("Module02.Courses", new[] { "DepartmentFK" });
            DropIndex("Module02.Courses", new[] { "StatusFK" });
            DropIndex("Module02.Courses", "IX_Course_LastModifiedByPrincipalId");
            DropIndex("Module02.Courses", "IX_Course_LastModifiedOnUtc");
            DropIndex("Module02.Courses", "IX_Course_RecordState");
            DropIndex("Module02.Courses", "IX_Course_TenantFK");
            DropIndex("Module02.Examples", "IX_Example_LastModifiedByPrincipalId");
            DropIndex("Module02.Examples", "IX_Example_LastModifiedOnUtc");
            DropIndex("Module02.Examples", "IX_Example_RecordState");
            DropIndex("Module02.Examples", "IX_Example_TenantFK");
            DropTable("Module02.CourseResourceTypes");
            DropTable("Module02.CourseResources");
            DropTable("Module02.CourseResourceAssignments");
            DropTable("Module02.CourseOccurances");
            DropTable("Module02.CourseRoles");
            DropTable("Module02.CourseInstructorOffices");
            DropTable("Module02.CourseInstructorOfficeAssignments");
            DropTable("Module02.CourseInstructors");
            DropTable("Module02.CourseInstructorAssignments");
            DropTable("Module02.CourseGrades");
            DropTable("Module02.CourseEnrollees");
            DropTable("Module02.CourseEnrollments");
            DropTable("Module02.CourseStatus");
            DropTable("Module02.CourseDepartments");
            DropTable("Module02.Courses");
            DropTable("Module02.Examples");
        }
    }
}


