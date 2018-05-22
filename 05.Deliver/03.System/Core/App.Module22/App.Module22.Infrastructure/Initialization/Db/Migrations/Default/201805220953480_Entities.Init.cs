namespace App.Module22.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Module22.Courses",
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
                .ForeignKey("Module22.CourseDepartments", t => t.DepartmentFK, cascadeDelete: true)
                .ForeignKey("Module22.CourseStatus", t => t.StatusFK)
                .Index(t => t.TenantFK, name: "IX_Course_TenantFK")
                .Index(t => t.RecordState, name: "IX_Course_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_Course_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_Course_LastModifiedByPrincipalId")
                .Index(t => t.StatusFK)
                .Index(t => t.DepartmentFK);
            
            CreateTable(
                "Module22.CourseDepartments",
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
                .ForeignKey("Module22.CourseStatus", t => t.StatusFK)
                .Index(t => t.TenantFK, name: "IX_CourseDepartment_TenantFK")
                .Index(t => t.RecordState, name: "IX_CourseDepartment_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseDepartment_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseDepartment_LastModifiedByPrincipalId")
                .Index(t => t.StatusFK);
            
            CreateTable(
                "Module22.CourseStatus",
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
                "Module22.CourseEnrollments",
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
                .ForeignKey("Module22.CourseEnrollees", t => t.EnrolleeFK)
                .ForeignKey("Module22.CourseGrades", t => t.GradeFK, cascadeDelete: true)
                .ForeignKey("Module22.CourseStatus", t => t.StatusFK)
                .ForeignKey("Module22.Courses", t => t.CourseFK)
                .Index(t => t.RecordState, name: "IX_CourseEnrollment_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseEnrollment_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseEnrollment_LastModifiedByPrincipalId")
                .Index(t => t.TenantFK, name: "IX_CourseEnrollment_TenantFK")
                .Index(t => t.StatusFK)
                .Index(t => t.CourseFK)
                .Index(t => t.EnrolleeFK)
                .Index(t => t.GradeFK);
            
            CreateTable(
                "Module22.CourseEnrollees",
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
                "Module22.CourseGrades",
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
                "Module22.CourseInstructorAssignments",
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
                .ForeignKey("Module22.CourseInstructors", t => t.CourseInstructorFK)
                .ForeignKey("Module22.CourseRoles", t => t.RoleFK, cascadeDelete: true)
                .ForeignKey("Module22.Courses", t => t.CourseFK, cascadeDelete: true)
                .Index(t => t.RecordState, name: "IX_CourseInstructorAssignment_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseInstructorAssignment_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseInstructorAssignment_LastModifiedByPrincipalId")
                .Index(t => t.TenantFK, name: "IX_CourseInstructorAssignment_TenantFK")
                .Index(t => t.CourseFK)
                .Index(t => t.CourseInstructorFK)
                .Index(t => t.RoleFK);
            
            CreateTable(
                "Module22.CourseInstructors",
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
                .ForeignKey("Module22.CourseStatus", t => t.StatusFK)
                .Index(t => t.TenantFK, name: "IX_CourseInstructor_TenantFK")
                .Index(t => t.RecordState, name: "IX_CourseInstructor_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseInstructor_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseInstructor_LastModifiedByPrincipalId")
                .Index(t => t.StatusFK);
            
            CreateTable(
                "Module22.CourseInstructorOfficeAssignments",
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
                .ForeignKey("Module22.CourseInstructorOffices", t => t.CourseInstructorOfficeFK)
                .ForeignKey("Module22.CourseInstructors", t => t.CourseInstructorFK)
                .Index(t => t.RecordState, name: "IX_CourseInstructorOfficeAssignment_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseInstructorOfficeAssignment_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseInstructorOfficeAssignment_LastModifiedByPrincipalId")
                .Index(t => t.TenantFK, name: "IX_CourseInstructorOfficeAssignment_TenantFK")
                .Index(t => t.CourseInstructorFK)
                .Index(t => t.CourseInstructorOfficeFK);
            
            CreateTable(
                "Module22.CourseInstructorOffices",
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
                "Module22.CourseRoles",
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
                "Module22.CourseOccurances",
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
                .ForeignKey("Module22.Courses", t => t.OwnerFK, cascadeDelete: true)
                .Index(t => t.TenantFK, name: "IX_CourseOccurance_TenantFK")
                .Index(t => t.RecordState, name: "IX_CourseOccurance_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseOccurance_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseOccurance_LastModifiedByPrincipalId")
                .Index(t => t.OwnerFK);
            
            CreateTable(
                "Module22.CourseResourceAssignments",
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
                .ForeignKey("Module22.CourseResources", t => t.ResourceFK)
                .ForeignKey("Module22.Courses", t => t.CourseFK)
                .Index(t => t.RecordState, name: "IX_CourseResourceAssignment_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseResourceAssignment_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseResourceAssignment_LastModifiedByPrincipalId")
                .Index(t => t.TenantFK, name: "IX_CourseResourceAssignment_TenantFK")
                .Index(t => t.CourseFK)
                .Index(t => t.ResourceFK);
            
            CreateTable(
                "Module22.CourseResources",
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
                .ForeignKey("Module22.CourseStatus", t => t.StatusFK)
                .ForeignKey("Module22.CourseResourceTypes", t => t.TypeFK, cascadeDelete: true)
                .Index(t => t.TenantFK, name: "IX_CourseResource_TenantFK")
                .Index(t => t.RecordState, name: "IX_CourseResource_RecordState")
                .Index(t => t.LastModifiedOnUtc, name: "IX_CourseResource_LastModifiedOnUtc")
                .Index(t => t.LastModifiedByPrincipalId, name: "IX_CourseResource_LastModifiedByPrincipalId")
                .Index(t => t.StatusFK)
                .Index(t => t.TypeFK);
            
            CreateTable(
                "Module22.CourseResourceTypes",
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
            DropForeignKey("Module22.Courses", "StatusFK", "Module22.CourseStatus");
            DropForeignKey("Module22.CourseResourceAssignments", "CourseFK", "Module22.Courses");
            DropForeignKey("Module22.CourseResources", "TypeFK", "Module22.CourseResourceTypes");
            DropForeignKey("Module22.CourseResources", "StatusFK", "Module22.CourseStatus");
            DropForeignKey("Module22.CourseResourceAssignments", "ResourceFK", "Module22.CourseResources");
            DropForeignKey("Module22.CourseOccurances", "OwnerFK", "Module22.Courses");
            DropForeignKey("Module22.CourseInstructorAssignments", "CourseFK", "Module22.Courses");
            DropForeignKey("Module22.CourseInstructorAssignments", "RoleFK", "Module22.CourseRoles");
            DropForeignKey("Module22.CourseInstructors", "StatusFK", "Module22.CourseStatus");
            DropForeignKey("Module22.CourseInstructorOfficeAssignments", "CourseInstructorFK", "Module22.CourseInstructors");
            DropForeignKey("Module22.CourseInstructorOfficeAssignments", "CourseInstructorOfficeFK", "Module22.CourseInstructorOffices");
            DropForeignKey("Module22.CourseInstructorAssignments", "CourseInstructorFK", "Module22.CourseInstructors");
            DropForeignKey("Module22.CourseEnrollments", "CourseFK", "Module22.Courses");
            DropForeignKey("Module22.CourseEnrollments", "StatusFK", "Module22.CourseStatus");
            DropForeignKey("Module22.CourseEnrollments", "GradeFK", "Module22.CourseGrades");
            DropForeignKey("Module22.CourseEnrollments", "EnrolleeFK", "Module22.CourseEnrollees");
            DropForeignKey("Module22.Courses", "DepartmentFK", "Module22.CourseDepartments");
            DropForeignKey("Module22.CourseDepartments", "StatusFK", "Module22.CourseStatus");
            DropIndex("Module22.CourseResourceTypes", "IX_CourseResourceType_LastModifiedByPrincipalId");
            DropIndex("Module22.CourseResourceTypes", "IX_CourseResourceType_LastModifiedOnUtc");
            DropIndex("Module22.CourseResourceTypes", "IX_CourseResourceType_RecordState");
            DropIndex("Module22.CourseResourceTypes", "IX_CourseResourceType_TenantFK");
            DropIndex("Module22.CourseResources", new[] { "TypeFK" });
            DropIndex("Module22.CourseResources", new[] { "StatusFK" });
            DropIndex("Module22.CourseResources", "IX_CourseResource_LastModifiedByPrincipalId");
            DropIndex("Module22.CourseResources", "IX_CourseResource_LastModifiedOnUtc");
            DropIndex("Module22.CourseResources", "IX_CourseResource_RecordState");
            DropIndex("Module22.CourseResources", "IX_CourseResource_TenantFK");
            DropIndex("Module22.CourseResourceAssignments", new[] { "ResourceFK" });
            DropIndex("Module22.CourseResourceAssignments", new[] { "CourseFK" });
            DropIndex("Module22.CourseResourceAssignments", "IX_CourseResourceAssignment_TenantFK");
            DropIndex("Module22.CourseResourceAssignments", "IX_CourseResourceAssignment_LastModifiedByPrincipalId");
            DropIndex("Module22.CourseResourceAssignments", "IX_CourseResourceAssignment_LastModifiedOnUtc");
            DropIndex("Module22.CourseResourceAssignments", "IX_CourseResourceAssignment_RecordState");
            DropIndex("Module22.CourseOccurances", new[] { "OwnerFK" });
            DropIndex("Module22.CourseOccurances", "IX_CourseOccurance_LastModifiedByPrincipalId");
            DropIndex("Module22.CourseOccurances", "IX_CourseOccurance_LastModifiedOnUtc");
            DropIndex("Module22.CourseOccurances", "IX_CourseOccurance_RecordState");
            DropIndex("Module22.CourseOccurances", "IX_CourseOccurance_TenantFK");
            DropIndex("Module22.CourseRoles", "IX_CourseRole_LastModifiedByPrincipalId");
            DropIndex("Module22.CourseRoles", "IX_CourseRole_LastModifiedOnUtc");
            DropIndex("Module22.CourseRoles", "IX_CourseRole_RecordState");
            DropIndex("Module22.CourseRoles", "IX_CourseRole_TenantFK");
            DropIndex("Module22.CourseInstructorOffices", "IX_CourseInstructorOffice_LastModifiedByPrincipalId");
            DropIndex("Module22.CourseInstructorOffices", "IX_CourseInstructorOffice_LastModifiedOnUtc");
            DropIndex("Module22.CourseInstructorOffices", "IX_CourseInstructorOffice_RecordState");
            DropIndex("Module22.CourseInstructorOffices", "IX_CourseInstructorOffice_TenantFK");
            DropIndex("Module22.CourseInstructorOfficeAssignments", new[] { "CourseInstructorOfficeFK" });
            DropIndex("Module22.CourseInstructorOfficeAssignments", new[] { "CourseInstructorFK" });
            DropIndex("Module22.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_TenantFK");
            DropIndex("Module22.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_LastModifiedByPrincipalId");
            DropIndex("Module22.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_LastModifiedOnUtc");
            DropIndex("Module22.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_RecordState");
            DropIndex("Module22.CourseInstructors", new[] { "StatusFK" });
            DropIndex("Module22.CourseInstructors", "IX_CourseInstructor_LastModifiedByPrincipalId");
            DropIndex("Module22.CourseInstructors", "IX_CourseInstructor_LastModifiedOnUtc");
            DropIndex("Module22.CourseInstructors", "IX_CourseInstructor_RecordState");
            DropIndex("Module22.CourseInstructors", "IX_CourseInstructor_TenantFK");
            DropIndex("Module22.CourseInstructorAssignments", new[] { "RoleFK" });
            DropIndex("Module22.CourseInstructorAssignments", new[] { "CourseInstructorFK" });
            DropIndex("Module22.CourseInstructorAssignments", new[] { "CourseFK" });
            DropIndex("Module22.CourseInstructorAssignments", "IX_CourseInstructorAssignment_TenantFK");
            DropIndex("Module22.CourseInstructorAssignments", "IX_CourseInstructorAssignment_LastModifiedByPrincipalId");
            DropIndex("Module22.CourseInstructorAssignments", "IX_CourseInstructorAssignment_LastModifiedOnUtc");
            DropIndex("Module22.CourseInstructorAssignments", "IX_CourseInstructorAssignment_RecordState");
            DropIndex("Module22.CourseGrades", "IX_CourseGrade_LastModifiedByPrincipalId");
            DropIndex("Module22.CourseGrades", "IX_CourseGrade_LastModifiedOnUtc");
            DropIndex("Module22.CourseGrades", "IX_CourseGrade_RecordState");
            DropIndex("Module22.CourseGrades", "IX_CourseGrade_TenantFK");
            DropIndex("Module22.CourseEnrollees", "IX_CourseEnrollee_LastModifiedByPrincipalId");
            DropIndex("Module22.CourseEnrollees", "IX_CourseEnrollee_LastModifiedOnUtc");
            DropIndex("Module22.CourseEnrollees", "IX_CourseEnrollee_RecordState");
            DropIndex("Module22.CourseEnrollees", "IX_CourseEnrollee_TenantFK");
            DropIndex("Module22.CourseEnrollments", new[] { "GradeFK" });
            DropIndex("Module22.CourseEnrollments", new[] { "EnrolleeFK" });
            DropIndex("Module22.CourseEnrollments", new[] { "CourseFK" });
            DropIndex("Module22.CourseEnrollments", new[] { "StatusFK" });
            DropIndex("Module22.CourseEnrollments", "IX_CourseEnrollment_TenantFK");
            DropIndex("Module22.CourseEnrollments", "IX_CourseEnrollment_LastModifiedByPrincipalId");
            DropIndex("Module22.CourseEnrollments", "IX_CourseEnrollment_LastModifiedOnUtc");
            DropIndex("Module22.CourseEnrollments", "IX_CourseEnrollment_RecordState");
            DropIndex("Module22.CourseStatus", "IX_CourseStatus_LastModifiedByPrincipalId");
            DropIndex("Module22.CourseStatus", "IX_CourseStatus_LastModifiedOnUtc");
            DropIndex("Module22.CourseStatus", "IX_CourseStatus_RecordState");
            DropIndex("Module22.CourseStatus", "IX_CourseStatus_TenantFK");
            DropIndex("Module22.CourseDepartments", new[] { "StatusFK" });
            DropIndex("Module22.CourseDepartments", "IX_CourseDepartment_LastModifiedByPrincipalId");
            DropIndex("Module22.CourseDepartments", "IX_CourseDepartment_LastModifiedOnUtc");
            DropIndex("Module22.CourseDepartments", "IX_CourseDepartment_RecordState");
            DropIndex("Module22.CourseDepartments", "IX_CourseDepartment_TenantFK");
            DropIndex("Module22.Courses", new[] { "DepartmentFK" });
            DropIndex("Module22.Courses", new[] { "StatusFK" });
            DropIndex("Module22.Courses", "IX_Course_LastModifiedByPrincipalId");
            DropIndex("Module22.Courses", "IX_Course_LastModifiedOnUtc");
            DropIndex("Module22.Courses", "IX_Course_RecordState");
            DropIndex("Module22.Courses", "IX_Course_TenantFK");
            DropTable("Module22.CourseResourceTypes");
            DropTable("Module22.CourseResources");
            DropTable("Module22.CourseResourceAssignments");
            DropTable("Module22.CourseOccurances");
            DropTable("Module22.CourseRoles");
            DropTable("Module22.CourseInstructorOffices");
            DropTable("Module22.CourseInstructorOfficeAssignments");
            DropTable("Module22.CourseInstructors");
            DropTable("Module22.CourseInstructorAssignments");
            DropTable("Module22.CourseGrades");
            DropTable("Module22.CourseEnrollees");
            DropTable("Module22.CourseEnrollments");
            DropTable("Module22.CourseStatus");
            DropTable("Module22.CourseDepartments");
            DropTable("Module22.Courses");
        }
    }
}
