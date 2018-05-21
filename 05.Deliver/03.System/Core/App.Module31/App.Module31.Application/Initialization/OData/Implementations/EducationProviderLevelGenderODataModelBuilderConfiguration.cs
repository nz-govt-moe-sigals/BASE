using Microsoft.Web.Http;

namespace App.Module31.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Module31.Application.Constants.Api;
    using App.Module31.Shared.Models.Messages.APIs.SIF.V0100;

    public class EducationProviderLevelGenderODataModelBuilderConfiguration 
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

        public EntityTypeConfiguration<EducationProviderLevelGenderDto> Define(ODataModelBuilder builder)
        {
            var entity = builder.EntitySet<EducationProviderLevelGenderDto>(ApiControllerNames.EducationProviderLevelGender).EntityType;

            entity.HasKey(x => x.Id);
            return entity;
        }

      
    }
}




