﻿namespace App.Core.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Core.Application.Constants.Api;
    using App.Core.Shared.Models.Messages.APIs.V0100;

    public class ExceptionRecordOdataModelBuilderConfiguration : IOdataModelBuilderConfiguration
    {
        public void Define(object builder)
        {
           Define(builder as ODataModelBuilder);
        }

        public void Define(ODataModelBuilder builder)
        {
            builder.EntitySet<ExceptionRecordDto>(ApiControllerNames.ExceptionRecord);
            //DTO Type description:
            // Optional DTO Type description
            // Tip/Warning: if you define ops here, at the model level, have to relist all ops allowed (ie, it cancels the globally set operations list):
            // builder.EntityType<ExceptionRecordDto>().Filter(/*noparam to allow for any*/);
            builder.EntityType<ExceptionRecordDto>()
                .HasKey(x => x.Id);
        }

    }
}