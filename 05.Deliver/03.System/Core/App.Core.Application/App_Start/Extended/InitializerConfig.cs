using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Core.Application.App_Start
{
    using App.Core.Infrastructure.Initialization.Integration;
    using Owin;

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