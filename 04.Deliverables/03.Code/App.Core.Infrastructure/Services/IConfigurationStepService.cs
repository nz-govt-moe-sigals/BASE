namespace App.Core.Infrastructure.Services
{
    using System.Linq;
    using App.Core.Shared.Models.Messages;

    public interface IConfigurationStepService : IHasAppCoreService
    {
        void Register(ConfigurationStepType type, ConfigurationStepStatus status, string title, string description);
        IQueryable<ConfigurationStepRecord> Get();
    }
}