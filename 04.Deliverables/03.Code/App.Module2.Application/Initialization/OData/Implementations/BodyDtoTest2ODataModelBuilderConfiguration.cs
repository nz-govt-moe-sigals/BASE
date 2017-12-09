//namespace App.Module2.Application.Initialization.OData.Implementations
//{
//    using System.Web.OData.Builder;
//    using App.Module2.Application.Initialization.OData;
//    using App.Module2.Shared.Models.Messages.V0100;

//    public class BodyDtoTest2ODataModelBuilderConfiguration : IAppModule2ODataModelBuilderConfiguration
//    {
//        public void Define(object builder)
//        {
//            Define(builder as ODataModelBuilder);
//        }
//        public void Define(ODataModelBuilder builder)
//        {
//            builder.EntitySet<BodyDto>("BodyDtoTest2".ToLower());
//            // Optional DTO Type description
//            // Tip/Warning: if you define ops here, at the model level, have to relist all ops allowed (ie, it cancels the globally set operations list):
//            // builder.EntityType<ExampleDto>().Filter(/*noparam to allow for any*/);
//            builder.EntityType<BodyDto>()
//                .HasKey(x => x.Id);

//        }
//    }
//}