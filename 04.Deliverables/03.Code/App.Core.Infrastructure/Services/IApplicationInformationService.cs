namespace App.Core.Infrastructure.Services
{
    using App.Core.Shared.Models.Configuration;

    public interface IApplicationInformationService
    {
        ApplicationDescription GetApplicationInformation();
        ApplicationCreatorInformation GetApplicationCreatorInformation();
        ApplicationDistributorInformation GetApplicationDistributorInformation();
    }
}
