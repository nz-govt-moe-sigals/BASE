namespace App.Core.Infrastructure.Services
{
    using App.Core.Shared.Models.Configuration;

    /// <summary>
    /// Contract for an Infrastructure Service to 
    /// manage information about the System. 
    /// <para>
    /// The most common use is for rendering information
    /// in the header of application interfaces.
    /// </para>
    /// </summary>
    public interface IApplicationInformationService
    {
        ApplicationDescription GetApplicationInformation();
        ApplicationCreatorInformation GetApplicationCreatorInformation();
        ApplicationDistributorInformation GetApplicationDistributorInformation();
    }
}
