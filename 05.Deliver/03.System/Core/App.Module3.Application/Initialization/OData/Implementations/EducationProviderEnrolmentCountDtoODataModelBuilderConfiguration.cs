//namespace App.Module3.Application.Initialization.OData.Implementations
//{
//    using System.Web.OData.Builder;
//    using App.Module3.Application.Constants.Api;
//    using App.Module3.Shared.Models.Messages.APIs.SIF.V0100;
//    using App.Module3.Shared.Models.Messages.APIs.V0100;

//    public class EducationProviderEnrolmentCountDtoODataModelBuilderConfiguration
//        : 
//        //AppModule3ODataModelBuilderReferenceDataConfigurationBase<EducationProviderDto>
//            IAppModule3OdataModelBuilderConfiguration
//    {


//        //public EducationProviderODataModelBuilderConfiguration() : base(ApiControllerNames.EducationProvider)
//        //{
//        //}



//        protected readonly string _controllerName;

//        public EducationProviderEnrolmentCountDtoODataModelBuilderConfiguration():this(ApiControllerNames.EducationProviderRollCount)
//        {

//        }

//        public EducationProviderEnrolmentCountDtoODataModelBuilderConfiguration(string controllerName)
//        {
//            this._controllerName = controllerName.ToLower();
//        }

//        public void Define(object builder)
//        {
//            Define(builder as ODataModelBuilder);
//        }
//        public void Define(ODataModelBuilder builder)
//        {
//            // Note that we are registering the path in lower case.
//            // And the full root with start with 
//            // ApiControllerNames.PathRoot (ie, 'odata/foo' for FooController):
//            builder.EntitySet<EducationProviderEnrolmentCountDto>(this._controllerName.ToLower().ToLower());

//            // Optional DTO Type description
//            // Tip/Warning: if you define ops here, at the model level, have to relist all ops allowed (ie, it cancels the globally set operations list):
//            // builder.EntityType<EducationOrganisationDto>().Filter(/*noparam to allow for any*/);
//            builder.EntityType<EducationProviderEnrolmentCountDto>()
//                .HasKey(x => x.Id);
//        }

//    }
//}