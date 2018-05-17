namespace App.Module1.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reindex : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Module1.Examples", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.Examples", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.Examples", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module1.CourseOccurances", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseOccurances", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseOccurances", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module1.Courses", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.Courses", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.Courses", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module1.CourseDepartments", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseDepartments", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseDepartments", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module1.CourseStatus", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseStatus", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseStatus", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module1.CourseEnrollments", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseEnrollments", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseEnrollments", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module1.CourseEnrollees", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseEnrollees", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseEnrollees", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module1.CourseGrades", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseGrades", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseGrades", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module1.CourseInstructorAssignments", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseInstructorAssignments", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseInstructorAssignments", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module1.CourseInstructors", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseInstructors", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseInstructors", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module1.CourseInstructorOfficeAssignments", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseInstructorOfficeAssignments", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseInstructorOfficeAssignments", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module1.CourseInstructorOffices", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseInstructorOffices", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseInstructorOffices", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module1.CourseRoles", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseRoles", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseRoles", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module1.CourseResourceAssignments", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseResourceAssignments", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseResourceAssignments", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module1.CourseResources", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseResources", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseResources", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            AlterColumn("Module1.CourseResourceTypes", "CreatedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseResourceTypes", "LastModifiedByPrincipalId", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("Module1.CourseResourceTypes", "DeletedByPrincipalId", c => c.String(maxLength: 32));
            CreateIndex("Module1.Examples", "TenantFK", name: "IX_Example_TenantFK");
            CreateIndex("Module1.Examples", "RecordState", name: "IX_Example_RecordState");
            CreateIndex("Module1.Examples", "LastModifiedOnUtc", name: "IX_Example_LastModifiedOnUtc");
            CreateIndex("Module1.Examples", "LastModifiedByPrincipalId", name: "IX_Example_LastModifiedByPrincipalId");
            CreateIndex("Module1.CourseOccurances", "TenantFK", name: "IX_CourseOccurance_TenantFK");
            CreateIndex("Module1.CourseOccurances", "RecordState", name: "IX_CourseOccurance_RecordState");
            CreateIndex("Module1.CourseOccurances", "LastModifiedOnUtc", name: "IX_CourseOccurance_LastModifiedOnUtc");
            CreateIndex("Module1.CourseOccurances", "LastModifiedByPrincipalId", name: "IX_CourseOccurance_LastModifiedByPrincipalId");
            CreateIndex("Module1.Courses", "TenantFK", name: "IX_Course_TenantFK");
            CreateIndex("Module1.Courses", "RecordState", name: "IX_Course_RecordState");
            CreateIndex("Module1.Courses", "LastModifiedOnUtc", name: "IX_Course_LastModifiedOnUtc");
            CreateIndex("Module1.Courses", "LastModifiedByPrincipalId", name: "IX_Course_LastModifiedByPrincipalId");
            CreateIndex("Module1.CourseDepartments", "TenantFK", name: "IX_CourseDepartment_TenantFK");
            CreateIndex("Module1.CourseDepartments", "RecordState", name: "IX_CourseDepartment_RecordState");
            CreateIndex("Module1.CourseDepartments", "LastModifiedOnUtc", name: "IX_CourseDepartment_LastModifiedOnUtc");
            CreateIndex("Module1.CourseDepartments", "LastModifiedByPrincipalId", name: "IX_CourseDepartment_LastModifiedByPrincipalId");
            CreateIndex("Module1.CourseStatus", "TenantFK", name: "IX_CourseStatus_TenantFK");
            CreateIndex("Module1.CourseStatus", "RecordState", name: "IX_CourseStatus_RecordState");
            CreateIndex("Module1.CourseStatus", "LastModifiedOnUtc", name: "IX_CourseStatus_LastModifiedOnUtc");
            CreateIndex("Module1.CourseStatus", "LastModifiedByPrincipalId", name: "IX_CourseStatus_LastModifiedByPrincipalId");
            CreateIndex("Module1.CourseEnrollments", "RecordState", name: "IX_CourseEnrollment_RecordState");
            CreateIndex("Module1.CourseEnrollments", "LastModifiedOnUtc", name: "IX_CourseEnrollment_LastModifiedOnUtc");
            CreateIndex("Module1.CourseEnrollments", "LastModifiedByPrincipalId", name: "IX_CourseEnrollment_LastModifiedByPrincipalId");
            CreateIndex("Module1.CourseEnrollments", "TenantFK", name: "IX_CourseEnrollment_TenantFK");
            CreateIndex("Module1.CourseEnrollees", "TenantFK", name: "IX_CourseEnrollee_TenantFK");
            CreateIndex("Module1.CourseEnrollees", "RecordState", name: "IX_CourseEnrollee_RecordState");
            CreateIndex("Module1.CourseEnrollees", "LastModifiedOnUtc", name: "IX_CourseEnrollee_LastModifiedOnUtc");
            CreateIndex("Module1.CourseEnrollees", "LastModifiedByPrincipalId", name: "IX_CourseEnrollee_LastModifiedByPrincipalId");
            CreateIndex("Module1.CourseGrades", "TenantFK", name: "IX_CourseGrade_TenantFK");
            CreateIndex("Module1.CourseGrades", "RecordState", name: "IX_CourseGrade_RecordState");
            CreateIndex("Module1.CourseGrades", "LastModifiedOnUtc", name: "IX_CourseGrade_LastModifiedOnUtc");
            CreateIndex("Module1.CourseGrades", "LastModifiedByPrincipalId", name: "IX_CourseGrade_LastModifiedByPrincipalId");
            CreateIndex("Module1.CourseInstructorAssignments", "RecordState", name: "IX_CourseInstructorAssignment_RecordState");
            CreateIndex("Module1.CourseInstructorAssignments", "LastModifiedOnUtc", name: "IX_CourseInstructorAssignment_LastModifiedOnUtc");
            CreateIndex("Module1.CourseInstructorAssignments", "LastModifiedByPrincipalId", name: "IX_CourseInstructorAssignment_LastModifiedByPrincipalId");
            CreateIndex("Module1.CourseInstructorAssignments", "TenantFK", name: "IX_CourseInstructorAssignment_TenantFK");
            CreateIndex("Module1.CourseInstructors", "TenantFK", name: "IX_CourseInstructor_TenantFK");
            CreateIndex("Module1.CourseInstructors", "RecordState", name: "IX_CourseInstructor_RecordState");
            CreateIndex("Module1.CourseInstructors", "LastModifiedOnUtc", name: "IX_CourseInstructor_LastModifiedOnUtc");
            CreateIndex("Module1.CourseInstructors", "LastModifiedByPrincipalId", name: "IX_CourseInstructor_LastModifiedByPrincipalId");
            CreateIndex("Module1.CourseInstructorOfficeAssignments", "RecordState", name: "IX_CourseInstructorOfficeAssignment_RecordState");
            CreateIndex("Module1.CourseInstructorOfficeAssignments", "LastModifiedOnUtc", name: "IX_CourseInstructorOfficeAssignment_LastModifiedOnUtc");
            CreateIndex("Module1.CourseInstructorOfficeAssignments", "LastModifiedByPrincipalId", name: "IX_CourseInstructorOfficeAssignment_LastModifiedByPrincipalId");
            CreateIndex("Module1.CourseInstructorOfficeAssignments", "TenantFK", name: "IX_CourseInstructorOfficeAssignment_TenantFK");
            CreateIndex("Module1.CourseInstructorOffices", "TenantFK", name: "IX_CourseInstructorOffice_TenantFK");
            CreateIndex("Module1.CourseInstructorOffices", "RecordState", name: "IX_CourseInstructorOffice_RecordState");
            CreateIndex("Module1.CourseInstructorOffices", "LastModifiedOnUtc", name: "IX_CourseInstructorOffice_LastModifiedOnUtc");
            CreateIndex("Module1.CourseInstructorOffices", "LastModifiedByPrincipalId", name: "IX_CourseInstructorOffice_LastModifiedByPrincipalId");
            CreateIndex("Module1.CourseRoles", "TenantFK", name: "IX_CourseRole_TenantFK");
            CreateIndex("Module1.CourseRoles", "RecordState", name: "IX_CourseRole_RecordState");
            CreateIndex("Module1.CourseRoles", "LastModifiedOnUtc", name: "IX_CourseRole_LastModifiedOnUtc");
            CreateIndex("Module1.CourseRoles", "LastModifiedByPrincipalId", name: "IX_CourseRole_LastModifiedByPrincipalId");
            CreateIndex("Module1.CourseResourceAssignments", "RecordState", name: "IX_CourseResourceAssignment_RecordState");
            CreateIndex("Module1.CourseResourceAssignments", "LastModifiedOnUtc", name: "IX_CourseResourceAssignment_LastModifiedOnUtc");
            CreateIndex("Module1.CourseResourceAssignments", "LastModifiedByPrincipalId", name: "IX_CourseResourceAssignment_LastModifiedByPrincipalId");
            CreateIndex("Module1.CourseResourceAssignments", "TenantFK", name: "IX_CourseResourceAssignment_TenantFK");
            CreateIndex("Module1.CourseResources", "TenantFK", name: "IX_CourseResource_TenantFK");
            CreateIndex("Module1.CourseResources", "RecordState", name: "IX_CourseResource_RecordState");
            CreateIndex("Module1.CourseResources", "LastModifiedOnUtc", name: "IX_CourseResource_LastModifiedOnUtc");
            CreateIndex("Module1.CourseResources", "LastModifiedByPrincipalId", name: "IX_CourseResource_LastModifiedByPrincipalId");
            CreateIndex("Module1.CourseResourceTypes", "TenantFK", name: "IX_CourseResourceType_TenantFK");
            CreateIndex("Module1.CourseResourceTypes", "RecordState", name: "IX_CourseResourceType_RecordState");
            CreateIndex("Module1.CourseResourceTypes", "LastModifiedOnUtc", name: "IX_CourseResourceType_LastModifiedOnUtc");
            CreateIndex("Module1.CourseResourceTypes", "LastModifiedByPrincipalId", name: "IX_CourseResourceType_LastModifiedByPrincipalId");
        }
        
        public override void Down()
        {
            DropIndex("Module1.CourseResourceTypes", "IX_CourseResourceType_LastModifiedByPrincipalId");
            DropIndex("Module1.CourseResourceTypes", "IX_CourseResourceType_LastModifiedOnUtc");
            DropIndex("Module1.CourseResourceTypes", "IX_CourseResourceType_RecordState");
            DropIndex("Module1.CourseResourceTypes", "IX_CourseResourceType_TenantFK");
            DropIndex("Module1.CourseResources", "IX_CourseResource_LastModifiedByPrincipalId");
            DropIndex("Module1.CourseResources", "IX_CourseResource_LastModifiedOnUtc");
            DropIndex("Module1.CourseResources", "IX_CourseResource_RecordState");
            DropIndex("Module1.CourseResources", "IX_CourseResource_TenantFK");
            DropIndex("Module1.CourseResourceAssignments", "IX_CourseResourceAssignment_TenantFK");
            DropIndex("Module1.CourseResourceAssignments", "IX_CourseResourceAssignment_LastModifiedByPrincipalId");
            DropIndex("Module1.CourseResourceAssignments", "IX_CourseResourceAssignment_LastModifiedOnUtc");
            DropIndex("Module1.CourseResourceAssignments", "IX_CourseResourceAssignment_RecordState");
            DropIndex("Module1.CourseRoles", "IX_CourseRole_LastModifiedByPrincipalId");
            DropIndex("Module1.CourseRoles", "IX_CourseRole_LastModifiedOnUtc");
            DropIndex("Module1.CourseRoles", "IX_CourseRole_RecordState");
            DropIndex("Module1.CourseRoles", "IX_CourseRole_TenantFK");
            DropIndex("Module1.CourseInstructorOffices", "IX_CourseInstructorOffice_LastModifiedByPrincipalId");
            DropIndex("Module1.CourseInstructorOffices", "IX_CourseInstructorOffice_LastModifiedOnUtc");
            DropIndex("Module1.CourseInstructorOffices", "IX_CourseInstructorOffice_RecordState");
            DropIndex("Module1.CourseInstructorOffices", "IX_CourseInstructorOffice_TenantFK");
            DropIndex("Module1.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_TenantFK");
            DropIndex("Module1.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_LastModifiedByPrincipalId");
            DropIndex("Module1.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_LastModifiedOnUtc");
            DropIndex("Module1.CourseInstructorOfficeAssignments", "IX_CourseInstructorOfficeAssignment_RecordState");
            DropIndex("Module1.CourseInstructors", "IX_CourseInstructor_LastModifiedByPrincipalId");
            DropIndex("Module1.CourseInstructors", "IX_CourseInstructor_LastModifiedOnUtc");
            DropIndex("Module1.CourseInstructors", "IX_CourseInstructor_RecordState");
            DropIndex("Module1.CourseInstructors", "IX_CourseInstructor_TenantFK");
            DropIndex("Module1.CourseInstructorAssignments", "IX_CourseInstructorAssignment_TenantFK");
            DropIndex("Module1.CourseInstructorAssignments", "IX_CourseInstructorAssignment_LastModifiedByPrincipalId");
            DropIndex("Module1.CourseInstructorAssignments", "IX_CourseInstructorAssignment_LastModifiedOnUtc");
            DropIndex("Module1.CourseInstructorAssignments", "IX_CourseInstructorAssignment_RecordState");
            DropIndex("Module1.CourseGrades", "IX_CourseGrade_LastModifiedByPrincipalId");
            DropIndex("Module1.CourseGrades", "IX_CourseGrade_LastModifiedOnUtc");
            DropIndex("Module1.CourseGrades", "IX_CourseGrade_RecordState");
            DropIndex("Module1.CourseGrades", "IX_CourseGrade_TenantFK");
            DropIndex("Module1.CourseEnrollees", "IX_CourseEnrollee_LastModifiedByPrincipalId");
            DropIndex("Module1.CourseEnrollees", "IX_CourseEnrollee_LastModifiedOnUtc");
            DropIndex("Module1.CourseEnrollees", "IX_CourseEnrollee_RecordState");
            DropIndex("Module1.CourseEnrollees", "IX_CourseEnrollee_TenantFK");
            DropIndex("Module1.CourseEnrollments", "IX_CourseEnrollment_TenantFK");
            DropIndex("Module1.CourseEnrollments", "IX_CourseEnrollment_LastModifiedByPrincipalId");
            DropIndex("Module1.CourseEnrollments", "IX_CourseEnrollment_LastModifiedOnUtc");
            DropIndex("Module1.CourseEnrollments", "IX_CourseEnrollment_RecordState");
            DropIndex("Module1.CourseStatus", "IX_CourseStatus_LastModifiedByPrincipalId");
            DropIndex("Module1.CourseStatus", "IX_CourseStatus_LastModifiedOnUtc");
            DropIndex("Module1.CourseStatus", "IX_CourseStatus_RecordState");
            DropIndex("Module1.CourseStatus", "IX_CourseStatus_TenantFK");
            DropIndex("Module1.CourseDepartments", "IX_CourseDepartment_LastModifiedByPrincipalId");
            DropIndex("Module1.CourseDepartments", "IX_CourseDepartment_LastModifiedOnUtc");
            DropIndex("Module1.CourseDepartments", "IX_CourseDepartment_RecordState");
            DropIndex("Module1.CourseDepartments", "IX_CourseDepartment_TenantFK");
            DropIndex("Module1.Courses", "IX_Course_LastModifiedByPrincipalId");
            DropIndex("Module1.Courses", "IX_Course_LastModifiedOnUtc");
            DropIndex("Module1.Courses", "IX_Course_RecordState");
            DropIndex("Module1.Courses", "IX_Course_TenantFK");
            DropIndex("Module1.CourseOccurances", "IX_CourseOccurance_LastModifiedByPrincipalId");
            DropIndex("Module1.CourseOccurances", "IX_CourseOccurance_LastModifiedOnUtc");
            DropIndex("Module1.CourseOccurances", "IX_CourseOccurance_RecordState");
            DropIndex("Module1.CourseOccurances", "IX_CourseOccurance_TenantFK");
            DropIndex("Module1.Examples", "IX_Example_LastModifiedByPrincipalId");
            DropIndex("Module1.Examples", "IX_Example_LastModifiedOnUtc");
            DropIndex("Module1.Examples", "IX_Example_RecordState");
            DropIndex("Module1.Examples", "IX_Example_TenantFK");
            AlterColumn("Module1.CourseResourceTypes", "DeletedByPrincipalId", c => c.String());
            AlterColumn("Module1.CourseResourceTypes", "LastModifiedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseResourceTypes", "CreatedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseResources", "DeletedByPrincipalId", c => c.String());
            AlterColumn("Module1.CourseResources", "LastModifiedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseResources", "CreatedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseResourceAssignments", "DeletedByPrincipalId", c => c.String());
            AlterColumn("Module1.CourseResourceAssignments", "LastModifiedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseResourceAssignments", "CreatedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseRoles", "DeletedByPrincipalId", c => c.String());
            AlterColumn("Module1.CourseRoles", "LastModifiedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseRoles", "CreatedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseInstructorOffices", "DeletedByPrincipalId", c => c.String());
            AlterColumn("Module1.CourseInstructorOffices", "LastModifiedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseInstructorOffices", "CreatedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseInstructorOfficeAssignments", "DeletedByPrincipalId", c => c.String());
            AlterColumn("Module1.CourseInstructorOfficeAssignments", "LastModifiedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseInstructorOfficeAssignments", "CreatedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseInstructors", "DeletedByPrincipalId", c => c.String());
            AlterColumn("Module1.CourseInstructors", "LastModifiedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseInstructors", "CreatedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseInstructorAssignments", "DeletedByPrincipalId", c => c.String());
            AlterColumn("Module1.CourseInstructorAssignments", "LastModifiedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseInstructorAssignments", "CreatedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseGrades", "DeletedByPrincipalId", c => c.String());
            AlterColumn("Module1.CourseGrades", "LastModifiedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseGrades", "CreatedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseEnrollees", "DeletedByPrincipalId", c => c.String());
            AlterColumn("Module1.CourseEnrollees", "LastModifiedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseEnrollees", "CreatedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseEnrollments", "DeletedByPrincipalId", c => c.String());
            AlterColumn("Module1.CourseEnrollments", "LastModifiedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseEnrollments", "CreatedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseStatus", "DeletedByPrincipalId", c => c.String());
            AlterColumn("Module1.CourseStatus", "LastModifiedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseStatus", "CreatedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseDepartments", "DeletedByPrincipalId", c => c.String());
            AlterColumn("Module1.CourseDepartments", "LastModifiedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseDepartments", "CreatedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.Courses", "DeletedByPrincipalId", c => c.String());
            AlterColumn("Module1.Courses", "LastModifiedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.Courses", "CreatedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseOccurances", "DeletedByPrincipalId", c => c.String());
            AlterColumn("Module1.CourseOccurances", "LastModifiedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.CourseOccurances", "CreatedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.Examples", "DeletedByPrincipalId", c => c.String());
            AlterColumn("Module1.Examples", "LastModifiedByPrincipalId", c => c.String(nullable: false));
            AlterColumn("Module1.Examples", "CreatedByPrincipalId", c => c.String(nullable: false));
        }
    }
}
