using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Implementations
{
    using App.Core.Shared.Models.Messages;

    public class ConfigurationStepService : IConfigurationStepService
    {
        private readonly IUniversalDateTimeService _universalDateTimeService;
        static readonly List<ConfigurationStepSummary> _cache = new List<ConfigurationStepSummary>();

        static ConfigurationStepService()
        {
            
        }

        public ConfigurationStepService(IUniversalDateTimeService universalDateTimeService)
        {
            this._universalDateTimeService = universalDateTimeService;
        }

        public void Register(ConfigurationStepType type, ConfigurationStepStatus status, string title, string description)
        {
            var configurationStep = new ConfigurationStepSummary()
            {
                DateTime = this._universalDateTimeService.NowUtc(),
                Type = type,
                Status = status,
                Title = title,
                Description = description
            };
            _cache.Add(configurationStep);
        }

        public IQueryable<ConfigurationStepSummary> Get()
        {
            return _cache.AsReadOnly().AsQueryable();
        }
    }
}
