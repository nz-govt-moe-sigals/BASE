namespace App.Module22.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesCourses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Module1.CourseOccurances",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                        OwnerFK = c.Guid(nullable: false),
                        When = c.DateTimeOffset(nullable: false, precision: 7),
                        Duration = c.Time(nullable: false, precision: 7),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module1.Courses", t => t.OwnerFK, cascadeDelete: true)
                .Index(t => t.OwnerFK);
            
            CreateTable(
                "Module1.Courses",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                        StatusFK = c.Int(nullable: false),
                        DepartmentFK = c.Guid(nullable: false),
                        Key = c.String(nullable: false, maxLength: 64),
                        Title = c.String(nullable: false, maxLength: 64),
                        Description = c.String(),
                        Credits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module1.CourseDepartments", t => t.DepartmentFK, cascadeDelete: true)
                .ForeignKey("Module1.CourseStatus", t => t.StatusFK)
                .Index(t => t.StatusFK)
                .Index(t => t.DepartmentFK);
            
            CreateTable(
                "Module1.CourseDepartments",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                        StatusFK = c.Int(nullable: false),
                        Key = c.String(nullable: false, maxLength: 64),
                        Title = c.String(nullable: false, maxLength: 64),
                        Description = c.String(),
                        Budget = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module1.CourseStatus", t => t.StatusFK)
                .Index(t => t.StatusFK);
            
            CreateTable(
                "Module1.CourseStatus",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Int(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module1.CourseEnrollments",
                c => new
                    {
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                        TenantFK = c.Guid(nullable: false),
                        StatusFK = c.Int(nullable: false),
                        CourseFK = c.Guid(nullable: false),
                        EnrolleeFK = c.Guid(nullable: false),
                        GradeFK = c.Guid(nullable: false),
                        GradeComment = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => new { t.CourseFK, t.EnrolleeFK })
                .ForeignKey("Module1.CourseEnrollees", t => t.EnrolleeFK)
                .ForeignKey("Module1.CourseGrades", t => t.GradeFK, cascadeDelete: true)
                .ForeignKey("Module1.CourseStatus", t => t.StatusFK)
                .ForeignKey("Module1.Courses", t => t.CourseFK)
                .Index(t => t.StatusFK)
                .Index(t => t.CourseFK)
                .Index(t => t.EnrolleeFK)
                .Index(t => t.GradeFK);
            
            CreateTable(
                "Module1.CourseEnrollees",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                        Key = c.String(nullable: false, maxLength: 64),
                        Name = c.String(nullable: false, maxLength: 256),
                        Begin = c.DateTimeOffset(precision: 7),
                        End = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module1.CourseGrades",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module1.CourseInstructorAssignments",
                c => new
                    {
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                        TenantFK = c.Guid(nullable: false),
                        CourseFK = c.Guid(nullable: false),
                        CourseInstructorFK = c.Guid(nullable: false),
                        RoleFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseFK, t.CourseInstructorFK })
                .ForeignKey("Module1.CourseInstructors", t => t.CourseInstructorFK)
                .ForeignKey("Module1.CourseRoles", t => t.RoleFK, cascadeDelete: true)
                .ForeignKey("Module1.Courses", t => t.CourseFK, cascadeDelete: true)
                .Index(t => t.CourseFK)
                .Index(t => t.CourseInstructorFK)
                .Index(t => t.RoleFK);
            
            CreateTable(
                "Module1.CourseInstructors",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                        StatusFK = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        Begin = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module1.CourseStatus", t => t.StatusFK)
                .Index(t => t.StatusFK);
            
            CreateTable(
                "Module1.CourseInstructorOfficeAssignments",
                c => new
                    {
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                        TenantFK = c.Guid(nullable: false),
                        CourseInstructorFK = c.Guid(nullable: false),
                        CourseInstructorOfficeFK = c.Guid(nullable: false),
                        Begin = c.DateTimeOffset(precision: 7),
                        End = c.DateTimeOffset(precision: 7),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => new { t.CourseInstructorFK, t.CourseInstructorOfficeFK })
                .ForeignKey("Module1.CourseInstructorOffices", t => t.CourseInstructorOfficeFK)
                .ForeignKey("Module1.CourseInstructors", t => t.CourseInstructorFK)
                .Index(t => t.CourseInstructorFK)
                .Index(t => t.CourseInstructorOfficeFK);
            
            CreateTable(
                "Module1.CourseInstructorOffices",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                        Key = c.String(nullable: false, maxLength: 64),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module1.CourseRoles",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Module1.CourseResourceAssignments",
                c => new
                    {
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                        TenantFK = c.Guid(nullable: false),
                        CourseFK = c.Guid(nullable: false),
                        ResourceFK = c.Guid(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => new { t.CourseFK, t.ResourceFK })
                .ForeignKey("Module1.CourseResources", t => t.ResourceFK)
                .ForeignKey("Module1.Courses", t => t.CourseFK)
                .Index(t => t.CourseFK)
                .Index(t => t.ResourceFK);
            
            CreateTable(
                "Module1.CourseResources",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                        Key = c.String(nullable: false, maxLength: 64),
                        Title = c.String(nullable: false, maxLength: 64),
                        Description = c.String(),
                        StatusFK = c.Int(nullable: false),
                        TypeFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Module1.CourseStatus", t => t.StatusFK)
                .ForeignKey("Module1.CourseResourceTypes", t => t.TypeFK, cascadeDelete: true)
                .Index(t => t.StatusFK)
                .Index(t => t.TypeFK);
            
            CreateTable(
                "Module1.CourseResourceTypes",
                c => new
                    {
                        TenantFK = c.Guid(nullable: false),
                        Id = c.Int(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RecordState = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        CreatedByPrincipalId = c.String(nullable: false),
                        LastModifiedOnUtc = c.DateTime(nullable: false),
                        LastModifiedByPrincipalId = c.String(nullable: false),
                        DeletedOnUtc = c.DateTime(),
                        DeletedByPrincipalId = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 64),
                        DisplayOrderHint = c.Int(nullable: false),
                        DisplayStyleHint = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Module1.Courses", "StatusFK", "Module1.CourseStatus");
            DropForeignKey("Module1.CourseResourceAssignments", "CourseFK", "Module1.Courses");
            DropForeignKey("Module1.CourseResources", "TypeFK", "Module1.CourseResourceTypes");
            DropForeignKey("Module1.CourseResources", "StatusFK", "Module1.CourseStatus");
            DropForeignKey("Module1.CourseResourceAssignments", "ResourceFK", "Module1.CourseResources");
            DropForeignKey("Module1.CourseOccurances", "OwnerFK", "Module1.Courses");
            DropForeignKey("Module1.CourseInstructorAssignments", "CourseFK", "Module1.Courses");
            DropForeignKey("Module1.CourseInstructorAssignments", "RoleFK", "Module1.CourseRoles");
            DropForeignKey("Module1.CourseInstructors", "StatusFK", "Module1.CourseStatus");
            DropForeignKey("Module1.CourseInstructorOfficeAssignments", "CourseInstructorFK", "Module1.CourseInstructors");
            DropForeignKey("Module1.CourseInstructorOfficeAssignments", "CourseInstructorOfficeFK", "Module1.CourseInstructorOffices");
            DropForeignKey("Module1.CourseInstructorAssignments", "CourseInstructorFK", "Module1.CourseInstructors");
            DropForeignKey("Module1.CourseEnrollments", "CourseFK", "Module1.Courses");
            DropForeignKey("Module1.CourseEnrollments", "StatusFK", "Module1.CourseStatus");
            DropForeignKey("Module1.CourseEnrollments", "GradeFK", "Module1.CourseGrades");
            DropForeignKey("Module1.CourseEnrollments", "EnrolleeFK", "Module1.CourseEnrollees");
            DropForeignKey("Module1.Courses", "DepartmentFK", "Module1.CourseDepartments");
            DropForeignKey("Module1.CourseDepartments", "StatusFK", "Module1.CourseStatus");
            DropIndex("Module1.CourseResources", new[] { "TypeFK" });
            DropIndex("Module1.CourseResources", new[] { "StatusFK" });
            DropIndex("Module1.CourseResourceAssignments", new[] { "ResourceFK" });
            DropIndex("Module1.CourseResourceAssignments", new[] { "CourseFK" });
            DropIndex("Module1.CourseInstructorOfficeAssignments", new[] { "CourseInstructorOfficeFK" });
            DropIndex("Module1.CourseInstructorOfficeAssignments", new[] { "CourseInstructorFK" });
            DropIndex("Module1.CourseInstructors", new[] { "StatusFK" });
            DropIndex("Module1.CourseInstructorAssignments", new[] { "RoleFK" });
            DropIndex("Module1.CourseInstructorAssignments", new[] { "CourseInstructorFK" });
            DropIndex("Module1.CourseInstructorAssignments", new[] { "CourseFK" });
            DropIndex("Module1.CourseEnrollments", new[] { "GradeFK" });
            DropIndex("Module1.CourseEnrollments", new[] { "EnrolleeFK" });
            DropIndex("Module1.CourseEnrollments", new[] { "CourseFK" });
            DropIndex("Module1.CourseEnrollments", new[] { "StatusFK" });
            DropIndex("Module1.CourseDepartments", new[] { "StatusFK" });
            DropIndex("Module1.Courses", new[] { "DepartmentFK" });
            DropIndex("Module1.Courses", new[] { "StatusFK" });
            DropIndex("Module1.CourseOccurances", new[] { "OwnerFK" });
            DropTable("Module1.CourseResourceTypes");
            DropTable("Module1.CourseResources");
            DropTable("Module1.CourseResourceAssignments");
            DropTable("Module1.CourseRoles");
            DropTable("Module1.CourseInstructorOffices");
            DropTable("Module1.CourseInstructorOfficeAssignments");
            DropTable("Module1.CourseInstructors");
            DropTable("Module1.CourseInstructorAssignments");
            DropTable("Module1.CourseGrades");
            DropTable("Module1.CourseEnrollees");
            DropTable("Module1.CourseEnrollments");
            DropTable("Module1.CourseStatus");
            DropTable("Module1.CourseDepartments");
            DropTable("Module1.Courses");
            DropTable("Module1.CourseOccurances");
        }
    }
}


