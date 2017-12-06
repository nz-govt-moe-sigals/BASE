namespace App.Module1.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Core.Shared.Models.Messages.API.V0100;
    using App.Module1.Application.Initialization.OData;

    public class ExampleOdataModelBuilderConfiguration : IOdataModelBuilderConfiguration
    {
        public void Define(object builder)
        {
            Define(builder as ODataModelBuilder);
        }

        public void Define(ODataModelBuilder builder)
        {
            // SETUP STEP: 
            // For each exposed Message model (ie DTO), register them as
            // part of the OData Model.
            // IMPORTANT:
            // the path entered (eg: https://..api/example), will be case sensitively (!) 
            // matched against the path registered here ('example'), and from that 
            // a controller (exampleController) will be chosen to handle it
            builder.EntitySet<ExampleDto>("example");
            // Associate the entity to a controller prefix (eg: Example5Controller)
            // And...it's case sensitive (wtf?!)..so if you invoke it 
            // with /api/Example5/ it won't find the Controller.
            builder.EntitySet<ExampleDto>("example5");
            // continuing register other DTO messages here...

            // For each DTO, specify it's Id:
            builder.EntityType<ExampleDto>().HasKey(x => x.Id);
            // Optional DTO Type description
            // Tip/Warning: if you define ops here, at the model level, have to relist all ops allowed (ie, it cancels the globally set operations list):
            // builder.EntityType<ExampleDto>().Filter(/*noparam to allow for any*/);

            // And what is acceptable to search on:
            builder.EntityType<ExampleDto>().Filter("PublicText"); //Can be noparam to allow for any.
        }

    }

}