using App.Core.Infrastructure.Initialization.Integration;
using Owin;

namespace App.Host.Extended
{
    public class InitializerConfig
    {
        private readonly IntegrationSpikes _spikes;

        public InitializerConfig(IntegrationSpikes spikes)
        {
            this._spikes = spikes;
        }
        public void Configure(IAppBuilder appBuilder)
        {
            this._spikes.Initialize();
        }
    }
}