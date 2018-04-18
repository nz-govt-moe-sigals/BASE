namespace App.Module3.Application.Initialization.OData.Implementations
{
    using App.Module3.Application.Constants.Api;
    using App.Module3.Shared.Models.Messages.V0100;

    public class TeacherEducationODataModelBuilderConfiguration  : AppModule3ODataModelBuilderReferenceDataConfigurationBase<TeacherEducationDto>
    {
        public TeacherEducationODataModelBuilderConfiguration() : base(ApiControllerNames.TeacherEducation)
        {
        }
    }
}