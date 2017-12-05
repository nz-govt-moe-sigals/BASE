using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Shared.Models.Configuration
{
    using App.Core.Shared.Attributes;

    public class ApplicationInsightsConfiguration
    {

        [Alias("App:Core:Analytics:ApplicationInsights:InstrumentationKey")]
        public string Key { get; set; }

        [Alias("App:Core:Analytics:ApplicationInsights:Disable")]
        public bool DisableTelemetry { get; set; }

    }
}
