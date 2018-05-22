namespace App.Module22.Infrastructure.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSchema : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "Module1.Examples", newSchema: "Module01");
            MoveTable(name: "Module1.CourseOccurances", newSchema: "Module01");
            MoveTable(name: "Module1.Courses", newSchema: "Module01");
            MoveTable(name: "Module1.CourseDepartments", newSchema: "Module01");
            MoveTable(name: "Module1.CourseStatus", newSchema: "Module01");
            MoveTable(name: "Module1.CourseEnrollments", newSchema: "Module01");
            MoveTable(name: "Module1.CourseEnrollees", newSchema: "Module01");
            MoveTable(name: "Module1.CourseGrades", newSchema: "Module01");
            MoveTable(name: "Module1.CourseInstructorAssignments", newSchema: "Module01");
            MoveTable(name: "Module1.CourseInstructors", newSchema: "Module01");
            MoveTable(name: "Module1.CourseInstructorOfficeAssignments", newSchema: "Module01");
            MoveTable(name: "Module1.CourseInstructorOffices", newSchema: "Module01");
            MoveTable(name: "Module1.CourseRoles", newSchema: "Module01");
            MoveTable(name: "Module1.CourseResourceAssignments", newSchema: "Module01");
            MoveTable(name: "Module1.CourseResources", newSchema: "Module01");
            MoveTable(name: "Module1.CourseResourceTypes", newSchema: "Module01");
        }
        
        public override void Down()
        {
            MoveTable(name: "Module01.CourseResourceTypes", newSchema: "Module1");
            MoveTable(name: "Module01.CourseResources", newSchema: "Module1");
            MoveTable(name: "Module01.CourseResourceAssignments", newSchema: "Module1");
            MoveTable(name: "Module01.CourseRoles", newSchema: "Module1");
            MoveTable(name: "Module01.CourseInstructorOffices", newSchema: "Module1");
            MoveTable(name: "Module01.CourseInstructorOfficeAssignments", newSchema: "Module1");
            MoveTable(name: "Module01.CourseInstructors", newSchema: "Module1");
            MoveTable(name: "Module01.CourseInstructorAssignments", newSchema: "Module1");
            MoveTable(name: "Module01.CourseGrades", newSchema: "Module1");
            MoveTable(name: "Module01.CourseEnrollees", newSchema: "Module1");
            MoveTable(name: "Module01.CourseEnrollments", newSchema: "Module1");
            MoveTable(name: "Module01.CourseStatus", newSchema: "Module1");
            MoveTable(name: "Module01.CourseDepartments", newSchema: "Module1");
            MoveTable(name: "Module01.Courses", newSchema: "Module1");
            MoveTable(name: "Module01.CourseOccurances", newSchema: "Module1");
            MoveTable(name: "Module01.Examples", newSchema: "Module1");
        }
    }
}


