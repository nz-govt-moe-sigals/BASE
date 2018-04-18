namespace App.Module3.Application.Initialization.OData.Implementations
{
    using App.Module3.Application.Constants.Api;
    using App.Module3.Shared.Models.Messages.V0100;

    public class MaoriElectorateODataModelBuilderConfiguration  : AppModule3ODataModelBuilderReferenceDataConfigurationBase<MaoriElectorateDto>
    {
        public MaoriElectorateODataModelBuilderConfiguration() : base(ApiControllerNames.MaoriElectorate)
        {
        }
    }
}