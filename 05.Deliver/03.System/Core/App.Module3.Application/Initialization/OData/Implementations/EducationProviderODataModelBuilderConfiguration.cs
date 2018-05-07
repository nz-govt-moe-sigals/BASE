using Microsoft.Web.Http;

namespace App.Module3.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Core.Infrastructure.Initialization.OData;
    using App.Module3.Application.Constants.Api;
    using App.Module3.Shared.Models.Messages.APIs.SIF.V0100;

    public class EducationProviderODataModelBuilderConfiguration 
        : 
        //AppModule3ODataModelBuilderReferenceDataConfigurationBase<EducationProviderDto>
            IAppModule3OdataModelBuilderConfiguration
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