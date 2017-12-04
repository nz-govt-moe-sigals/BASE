using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Shared.Models.Configuration
{
    using App.Core.Shared.Attributes;

    public class AnalyticsConfiguration
    {
        [Alias("System:Analytics:Telemetry:Disable")]
        public bool DisableTelemetry { get; set; }

    }
}
