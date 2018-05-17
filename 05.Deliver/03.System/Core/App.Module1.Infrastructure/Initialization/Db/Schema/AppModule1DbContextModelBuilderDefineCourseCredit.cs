//namespace App.Module1.Infrastructure.Db.Schema
//{
//    using System.Data.Entity;
//    using App.Core.Infrastructure.Db.Schema.Conventions;
//    using App.Module1.Infrastructure.Initialization.Db;
//    using App.Module1.Shared.Models.Entities;

//    public class AppModule1DbContextModelBuilderDefineCourseCredit : IHasAppModule1DbContextModelBuilderInitializer
//    {
//        public void Define(DbModelBuilder modelBuilder)
//        {
//            var order = 1;

// --------------------------------------------------
// Standard Properties:
//            new TenantFKAuditedTimestampedRecordStatedGuidIdDataConvention().Define<CourseCredit>(modelBuilder, ref order);
// --------------------------------------------------
// FK Properties:

// --------------------------------------------------
// Model Specific Properties:

// --------------------------------------------------
// Entity Navigation Properties:
// --------------------------------------------------

// --------------------------------------------------
// Collection Navigation Properties:

// --------------------------------------------------
//        }
//    }


//}