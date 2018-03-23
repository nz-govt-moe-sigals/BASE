namespace App.Core.Infrastructure.Services
{
    using App.Core.Shared.Services;

    public interface ILocalisationService : IHasAppCoreService
    {
        bool ThreadCultureSet { get; }
        void SetThreadCulture(string localisationCode);
        bool IsValidCultureInfoName(string clientLocalisationCode);
    }
}