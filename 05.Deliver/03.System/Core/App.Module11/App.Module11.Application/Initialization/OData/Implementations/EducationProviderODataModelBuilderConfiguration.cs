using Microsoft.Web.Http;

namespace App.Module11.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Module11.Application.Constants.Api;
    using App.Module11.Shared.Models.Messages.APIs.SIF.V0100;

    public class EducationProviderODataModelBuilderConfiguration 
        : 
        //AppModuleODataModelBuilderReferenceDataConfigurationBase<EducationProviderDto>
            IAppModuleOdataModelBuilderConfiguration
    {


        //public EducationProviderODataModelBuilderConfiguration() : base(ApiControllerNames.EducationProvider)
        //{
        //}

        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            Define(builder);

        }

        public EntityTypeConfiguration<EducationProviderDto> Define(ODataModelBuilder builder)
        {
            var entity = builder.EntitySet<EducationProviderDto>(ApiControllerNames.EducationProvider).EntityType;
            entity.HasKey(x => x.SchoolId);
            return entity;
        }

      
    }
}